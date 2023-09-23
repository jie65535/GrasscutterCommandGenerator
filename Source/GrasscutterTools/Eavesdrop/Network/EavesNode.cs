using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Http;
using System.Net.Sockets;
using System.Net.Security;
using System.Globalization;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Text.RegularExpressions;
using System.Security.Cryptography.X509Certificates;

//using BrotliSharpLib;

namespace Eavesdrop.Network
{
    public class EavesNode : IDisposable
    {
        private SslStream _secureStream;
        private readonly TcpClient _client;
        private readonly Certifier _certifier;
        private static readonly Regex _responseCookieSplitter;

        public bool IsSecure => (_secureStream != null);

        static EavesNode()
        {
            _responseCookieSplitter = new Regex(",(?! )");
        }
        public EavesNode(Certifier certifier, TcpClient client)
        {
            _client = client;
            _certifier = certifier;

            _client.NoDelay = true;
        }

        public Task<HttpWebRequest> ReadRequestAsync()
        {
            return ReadRequestAsync(null);
        }
        private async Task<HttpWebRequest> ReadRequestAsync(Uri baseUri)
        {
            string method = null;
            var headers = new List<string>();
            string requestUrl = baseUri?.OriginalString;

            string command = ReadNonBufferedLine();
            if (string.IsNullOrWhiteSpace(command)) return null;

            if (string.IsNullOrWhiteSpace(command)) return null;
            string[] values = command.Split(' ');

            method = values[0];
            requestUrl += values[1];
            while (_client.Connected)
            {
                string header = ReadNonBufferedLine();
                if (string.IsNullOrWhiteSpace(header)) break;

                headers.Add(header);
            }

            if (method == "CONNECT")
            {
                baseUri = new Uri("https://" + requestUrl);
                await SendResponseAsync(HttpStatusCode.OK).ConfigureAwait(false);

                if (!SecureTunnel(baseUri.Host)) return null;
                return await ReadRequestAsync(baseUri).ConfigureAwait(false);
            }
            else return CreateRequest(method, headers, new Uri(requestUrl));
        }

        public async Task<ByteArrayContent> ReadRequestContentAsync(WebRequest request)
        {
            byte[] payload = await GetPayload(GetStream(), request.ContentLength).ConfigureAwait(false);
            if (payload == null) return null;

            //if (request.Headers[HttpRequestHeader.ContentEncoding] == "br")
            //{
            //    request.Headers[HttpRequestHeader.ContentEncoding] = ""; // No longer encoded.
            //    payload = Brotli.DecompressBuffer(payload, 0, payload.Length);
            //}
            return new ByteArrayContent(payload);
        }
        public async Task WriteRequestContentAsync(WebRequest request, HttpContent content)
        {
            byte[] payload = null;
            if (content is StreamContent streamContent)
            {
                // TODO:
                throw new NotSupportedException();
            }
            else payload = await content.ReadAsByteArrayAsync().ConfigureAwait(false);

            //if (request.Headers[HttpRequestHeader.ContentEncoding] == "br")
            //{
            //    payload = Brotli.CompressBuffer(payload, 0, payload.Length);
            //}

            request.ContentLength = payload.Length;
            using (Stream output = await request.GetRequestStreamAsync().ConfigureAwait(false))
            {
                await output.WriteAsync(payload, 0, payload.Length).ConfigureAwait(false);
            }
        }

        public Task SendResponseAsync(WebResponse response, HttpContent content)
        {
            string description = "OK";
            var status = HttpStatusCode.OK;
            if (response is HttpWebResponse httpResponse)
            {
                status = httpResponse.StatusCode;
                description = httpResponse.StatusDescription;
            }
            return SendResponseAsync(status, description, response.Headers, content);
        }
        public Task SendResponseAsync(HttpStatusCode status, string description = null)
        {
            return SendResponseAsync(status, (description ?? status.ToString()), null, null);
        }
        public async Task SendResponseAsync(HttpStatusCode status, string description, WebHeaderCollection headers, HttpContent content)
        {
            var headerBuilder = new StringBuilder();
            headerBuilder.AppendLine($"HTTP/{HttpVersion.Version10} {(int)status} {description}");
            if (headers != null)
            {
                foreach (string header in headers.AllKeys)
                {
                    if (header == "Transfer-Encoding") continue;

                    string value = headers[header];
                    if (string.IsNullOrWhiteSpace(value)) continue;

                    if (header.Equals("Set-Cookie", StringComparison.OrdinalIgnoreCase))
                    {
                        foreach (string setCookie in _responseCookieSplitter.Split(value))
                        {
                            headerBuilder.AppendLine($"{header}: {setCookie}");
                        }
                    }
                    else headerBuilder.AppendLine($"{header}: {value}");
                }
            }
            headerBuilder.AppendLine();

            byte[] headerData = Encoding.UTF8.GetBytes(headerBuilder.ToString());
            await GetStream().WriteAsync(headerData, 0, headerData.Length).ConfigureAwait(false);
            if (content != null)
            {
                // TODO: If the Content-Encoding header has been changed, re-compress while writing?
                Stream input = await content.ReadAsStreamAsync().ConfigureAwait(false);

                int bytesRead = 0;
                var buffer = new byte[8192];
                do
                {
                    bytesRead = await input.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false);
                    if (_client.Connected && bytesRead > 0)
                    {
                        await GetStream().WriteAsync(buffer, 0, bytesRead).ConfigureAwait(false);
                    }
                    else return;
                }
                while (input.CanRead && _client.Connected);
            }
        }

        public Stream GetStream()
        {
            return ((Stream)_secureStream ?? _client.GetStream());
        }
        private StreamWriter WrapStreamWriter()
        {
            return new StreamWriter(GetStream(), Encoding.UTF8, 1024, true);
        }
        private StreamReader WrapStreamReader(int bufferSize = 1024)
        {
            return new StreamReader(GetStream(), Encoding.UTF8, true, bufferSize, true);
        }

        private string ReadNonBufferedLine()
        {
            string line = string.Empty;
            try
            {
                using (var binaryInput = new BinaryReader(GetStream(), Encoding.UTF8, true))
                {
                    do { line += binaryInput.ReadChar(); }
                    while (!line.EndsWith("\r\n"));
                }
            }
            catch (EndOfStreamException) { line += "\r\n"; }
            return line.Substring(0, line.Length - 2);
        }
        private bool SecureTunnel(string host)
        {
            try
            {
                X509Certificate2 certificate = _certifier.GenerateCertificate(host);

                _secureStream = new SslStream(GetStream());
                _secureStream.AuthenticateAsServer(certificate, false, SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls, false);

                return true;
            }
            catch { return false; }
        }
        private IEnumerable<Cookie> GetCookies(string cookieHeader, string host)
        {
            foreach (string cookie in cookieHeader.Split(';'))
            {
                int nameEndIndex = cookie.IndexOf('=');
                if (nameEndIndex == -1) continue;

                string name = cookie.Substring(0, nameEndIndex).Trim();
                string value = cookie.Substring(nameEndIndex + 1).Trim();

                yield return new Cookie(name, value, "/", host);
            }
        }
        private HttpWebRequest CreateRequest(string method, List<string> headers, Uri requestUri)
        {
            HttpWebRequest request = WebRequest.CreateHttp(requestUri);
            request.ProtocolVersion = HttpVersion.Version10;
            request.CookieContainer = new CookieContainer();
            request.AllowAutoRedirect = false;
            request.KeepAlive = false;
            request.Method = method;
            request.Proxy = null;

            foreach (string header in headers)
            {
                int delimiterIndex = header.IndexOf(':');
                if (delimiterIndex == -1) continue;

                string name = header.Substring(0, delimiterIndex);
                string value = header.Substring(delimiterIndex + 2);
                switch (name.ToLower())
                {
                    case "range":
                    case "expect":
                    case "keep-alive":
                    case "connection":
                    case "proxy-connection": break;

                    case "host": request.Host = value; break;
                    case "accept": request.Accept = value; break;
                    case "referer": request.Referer = value; break;
                    case "user-agent": request.UserAgent = value; break;
                    case "content-type": request.ContentType = value; break;

                    case "content-length":
                    {
                        request.ContentLength =
                            long.Parse(value, CultureInfo.InvariantCulture);

                        break;
                    }
                    case "cookie":
                    {
                        foreach (Cookie cookie in GetCookies(value, request.Host))
                        {
                            try
                            {
                                request.CookieContainer.Add(cookie);
                            }
                            catch (CookieException) { }
                        }
                        request.Headers[name] = value;
                        break;
                    }
                    case "if-modified-since":
                    {
                        request.IfModifiedSince = DateTime.Parse(
                            value.Split(';')[0], CultureInfo.InvariantCulture);

                        break;
                    }

                    case "date":
                        if (long.TryParse(value, out var timestamp))
                        {
                            request.Date = timestamp > 10_000_000_000L
                                ? DateTimeOffset.FromUnixTimeMilliseconds(timestamp).DateTime
                                : DateTimeOffset.FromUnixTimeSeconds(timestamp).DateTime;
                        }
                        else
                        {
                            request.Date = DateTime.Parse(value);
                        }
                        break;

                    default:
                    request.Headers[name] = value; break;
                }
            }
            return request;
        }
        
        public void Dispose()
        {
            Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                GetStream().Dispose();
                _client.Dispose();
            }
        }

        public static StreamContent ReadResponseContent(WebResponse response)
        {
            if (response.ContentLength == 0)
            {
                response.GetResponseStream().Dispose();
                return null;
            }

            Stream input = response.GetResponseStream();
            //if (response is HttpWebResponse httpResponse && !string.IsNullOrWhiteSpace(httpResponse.ContentEncoding))
            //{
            //    switch (httpResponse.ContentEncoding)
            //    {
            //        //case "br": input = new BrotliStream(input, CompressionMode.Decompress); break;
            //        case "gzip": input = new GZipStream(input, CompressionMode.Decompress); break;
            //        case "deflate": input = new DeflateStream(input, CompressionMode.Decompress); break;
            //    }
            //    response.Headers.Remove(HttpResponseHeader.ContentLength);
            //    response.Headers.Remove(HttpResponseHeader.ContentEncoding);
            //    response.Headers.Add(HttpResponseHeader.TransferEncoding, "chunked");
            //}
            return new StreamContent(input, response.ContentLength > 0 ? (int)response.ContentLength : 4096);
        }
        public static async Task<byte[]> GetPayload(Stream input, long length)
        {
            if (length < 1) return null;

            int totalBytesRead = 0;
            int nullBytesReadCount = 0;
            var payload = new byte[length];
            do
            {
                int bytesLeft = (payload.Length - totalBytesRead);
                int bytesRead = await input.ReadAsync(payload, totalBytesRead, bytesLeft).ConfigureAwait(false);

                if (bytesRead > 0)
                {
                    nullBytesReadCount = 0;
                    totalBytesRead += bytesRead;
                }
                else if (++nullBytesReadCount >= 2) return null;
            }
            while (totalBytesRead != payload.Length);
            return payload;
        }
    }
}