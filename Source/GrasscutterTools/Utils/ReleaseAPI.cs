using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace GrasscutterTools.Utils
{
    internal class ReleaseAPI
    {
        public static async Task<ReleaseInfo> GetReleasesLastest(string username, string repo)
        {
            var headerValue = new ProductInfoHeaderValue("GrasscutterTools", "1");
            try
            {
                HttpHelper.HttpClient.DefaultRequestHeaders.UserAgent.Add(headerValue);
                return await HttpHelper.GetAsync<ReleaseInfo>($"https://api.github.com/repos/{username}/{repo}/releases/latest");
            }
            catch
            {
                // 如果Github无法访问，尝试从Gitee获取
                var release = await HttpHelper.GetAsync<ReleaseInfo>($"https://gitee.com/api/v5/repos/{username}/{repo}/releases/latest");
                release.Url = $"https://gitee.com/{username}/{repo}/releases";
                return release;
            }
            finally
            {
                HttpHelper.HttpClient.DefaultRequestHeaders.UserAgent.Remove(headerValue);
            }
        }

        public class ReleaseInfo
        {
            [JsonProperty("tag_name")]
            public string TagName { get; set; }

            [JsonProperty("html_url")]
            public string Url { get; set; }

            [JsonProperty("created_at")]
            public DateTimeOffset CraeteTime { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("body")]
            public string Body { get; set; }
        }
    }
}
