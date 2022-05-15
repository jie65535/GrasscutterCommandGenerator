using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using GrasscutterTools.Utils;

namespace GrasscutterTools.Github
{
    public static class ReleaseAPI
    {
        public static async Task<ReleaseInfo> GetReleasesLastest(string username, string repo)
        {
            var headerValue = new ProductInfoHeaderValue("GrasscutterTools", "1");
            try
            {
                HttpHelper.HttpClient.DefaultRequestHeaders.UserAgent.Add(headerValue);
                var r = await HttpHelper.GetAsync<dynamic>($"https://api.github.com/repos/{username}/{repo}/releases/latest");
                return new ReleaseInfo
                {
                    TagName = r.tag_name,
                    Url = r.html_url,
                    CraeteTime = r.created_at,
                    Name = r.name,
                    Body = r.body
                };
            }
            finally
            {
                HttpHelper.HttpClient.DefaultRequestHeaders.UserAgent.Remove(headerValue);
            }
        }

        public class ReleaseInfo
        {
            public string TagName { get; set; }

            public string Url { get; set; }

            public DateTimeOffset CraeteTime { get; set; }

            public string Name { get; set; }

            public string Body { get; set; }
        }
    }
}
