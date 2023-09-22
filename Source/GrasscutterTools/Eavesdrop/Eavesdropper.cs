using System;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Collections.Generic;

using Eavesdrop.Network;

namespace Eavesdrop
{
    public static class Eavesdropper
    {
        private static TcpListener _listener;
        private static readonly object _stateLock;

        public delegate Task AsyncEventHandler<TEventArgs>(object sender, TEventArgs e);

        public static event AsyncEventHandler<RequestInterceptedEventArgs> RequestInterceptedAsync;
        private static async Task OnRequestInterceptedAsync(RequestInterceptedEventArgs e)
        {
            Task interceptedTask = RequestInterceptedAsync?.Invoke(null, e);
            if (interceptedTask != null)
            {
                await interceptedTask;
            }
        }

        public static event AsyncEventHandler<ResponseInterceptedEventArgs> ResponseInterceptedAsync;
        private static async Task OnResponseInterceptedAsync(ResponseInterceptedEventArgs e)
        {
            Task interceptedTask = ResponseInterceptedAsync?.Invoke(null, e);
            if (interceptedTask != null)
            {
                await interceptedTask;
            }
        }

        public static List<string> Overrides { get; }
        public static bool IsRunning { get; private set; }
        public static Certifier Certifier { get; set; }

        static Eavesdropper()
        {
            _stateLock = new object();

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            Overrides = new List<string>();
            Certifier = new Certifier("Eavesdrop", "Eavesdrop Root Certificate Authority");
        }

        public static void Terminate()
        {
            lock (_stateLock)
            {
                ResetMachineProxy();
                IsRunning = false;

                if (_listener != null)
                {
                    _listener.Stop();
                    _listener = null;
                }
            }
        }
        public static void Initiate(int port)
        {
            Initiate(port, Interceptors.Default);
        }
        public static void Initiate(int port, Interceptors interceptors)
        {
            Initiate(port, interceptors, true);
        }
        public static void Initiate(int port, Interceptors interceptors, bool setSystemProxy)
        {
            lock (_stateLock)
            {
                Terminate();

                _listener = new TcpListener(IPAddress.Any, port);
                _listener.Start();

                IsRunning = true;

                Task.Factory.StartNew(InterceptRequestAsync, TaskCreationOptions.LongRunning);
                if (setSystemProxy)
                {
                    SetMachineProxy(port, interceptors);
                }
            }
        }

        private static async Task InterceptRequestAsync()
        {
            while (IsRunning && _listener != null)
            {
                try
                {
                    TcpClient client = await _listener.AcceptTcpClientAsync().ConfigureAwait(false);
                    Task handleClientAsync = HandleClientAsync(client);
                }
                catch (ObjectDisposedException)
                {
                }
            }
        }

        private static async Task HandleClientAsync(TcpClient client)
        {
            using var local = new EavesNode(Certifier, client);
            WebRequest request = await local.ReadRequestAsync().ConfigureAwait(false);
            if (request == null) return;

            HttpContent requestContent = null;
            var requestArgs = new RequestInterceptedEventArgs(request);
            try
            {
                requestArgs.Content = requestContent = await local.ReadRequestContentAsync(request).ConfigureAwait(false);
                await OnRequestInterceptedAsync(requestArgs).ConfigureAwait(false);
                if (requestArgs.Cancel) return;

                request = requestArgs.Request;
                if (requestArgs.Content != null)
                {
                    await local.WriteRequestContentAsync(request, requestArgs.Content).ConfigureAwait(false);
                }
            }
            finally
            {
                requestContent?.Dispose();
                requestArgs.Content?.Dispose();
            }

            WebResponse response = null;
            try { response = await request.GetResponseAsync().ConfigureAwait(false); }
            catch (WebException ex) { response = ex.Response; }
            catch (ProtocolViolationException)
            {
                response?.Dispose();
                response = null;
            }

            if (response == null) return;
            HttpContent responseContent = null;
            var responseArgs = new ResponseInterceptedEventArgs(request, response);
            try
            {
                responseArgs.Content = responseContent = EavesNode.ReadResponseContent(response);
                await OnResponseInterceptedAsync(responseArgs).ConfigureAwait(false);
                if (responseArgs.Cancel) return;

                await local.SendResponseAsync(responseArgs.Response, responseArgs.Content).ConfigureAwait(false);
            }
            finally
            {
                response.Dispose();
                responseArgs.Response.Dispose();

                responseContent?.Dispose();
                responseArgs.Content?.Dispose();
            }
        }

        private static void ResetMachineProxy()
        {
            INETOptions.Overrides.Clear();
            INETOptions.IsIgnoringLocalTraffic = false;

            INETOptions.HTTPAddress = null;
            INETOptions.HTTPSAddress = null;
            INETOptions.IsProxyEnabled = false;

            INETOptions.Save();
        }
        private static void SetMachineProxy(int port, Interceptors interceptors)
        {
            foreach (string @override in Overrides)
            {
                if (INETOptions.Overrides.Contains(@override)) continue;
                INETOptions.Overrides.Add(@override);
            }

            string address = ("127.0.0.1:" + port);
            if (interceptors.HasFlag(Interceptors.HTTP))
            {
                INETOptions.HTTPAddress = address;
            }
            if (interceptors.HasFlag(Interceptors.HTTPS))
            {
                INETOptions.HTTPSAddress = address;
            }
            INETOptions.IsProxyEnabled = true;
            INETOptions.IsIgnoringLocalTraffic = true;

            INETOptions.Save();
        }
    }
}
