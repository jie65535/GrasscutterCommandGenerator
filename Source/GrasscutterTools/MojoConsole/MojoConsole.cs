using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace GrasscutterTools.MojoConsole
{
    internal class MojoConsole
    {
        static readonly HttpClient httpClient = new HttpClient();

        public string Host { get; set; }

        private string API => Host + "/mojoplus/api";

        public string Key { get; set; }

        public async Task<string> Invoke(string payload)
        {
            var response = await DoRequest(new Request(Key, "invoke", payload));
            if (response.Code == 500)
                throw new InvokeException(response.Payload);
            return response.Payload;
        }

        public async Task<bool> Ping()
        {
            try
            {
                var response = await DoRequest(new Request(Key, "ping"));
                return response?.Code == 200;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private async Task<Response> DoRequest(Request request)
        {
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(API, content);
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(responseString);
        }

        public class Request
        {
            public Request(string k, string method, string payload = "")
            {
                K = k;
                Method = method;
                Payload = payload;
            }

            [JsonProperty("k")]
            public string K { get; set; }

            [JsonProperty("request")]
            public string Method { get; set; }

            [JsonProperty("payload")]
            public string Payload { get; set; }
        }

        public class Response
        {
            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("code")]
            public int Code { get; set; }


            [JsonProperty("payload")]
            public string Payload { get; set; }
        }


        internal class InvokeException : Exception
        {
            public InvokeException(string message) : base(message)
            {
            }
        }
    }
}
