using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace GrasscutterTools.Utils
{
    public static class HttpHelper
    {
        static readonly HttpClient httpClient = new HttpClient();

        static HttpHelper()
        {
            ServicePointManager.ServerCertificateValidationCallback = (_, _1, _2, _3) => true;
        }

        public static async Task<T> GetAsync<T>(string url)
        {
            try
            {
                var responseMessage = await httpClient.GetAsync(url);
                var responseString = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseString);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    throw ex.InnerException;
                throw;
            }
        }

        public static async Task<T> PostAsync<T>(string url, object obj)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                var responseMessage = await httpClient.PostAsync(url, content);
                var responseString = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseString);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    throw ex.InnerException;
                throw;
            }
        }
    }
}
