/**
 *  Grasscutter Tools
 *  Copyright (C) 2023 jie65535
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU Affero General Public License as published
 *  by the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU Affero General Public License for more details.
 *
 *  You should have received a copy of the GNU Affero General Public License
 *  along with this program.  If not, see <https://www.gnu.org/licenses/>.
 *
 **/

using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace GrasscutterTools.Utils
{
    internal class GithubHelper
    {
        public static async Task<ReleaseInfo> GetReleasesLatest(string username, string repo)
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

        public static async Task<byte[]> DownloadRepo(string username, string repo, string branch)
        {
            byte[] zipBytes;
            try
            {
                zipBytes = await HttpHelper.GetDataAsync(
                    $"https://github.com/{username}/{repo}/archive/refs/heads/{branch}.zip");
            }
            catch
            {
                zipBytes = await HttpHelper.GetDataAsync(
                    $"https://hub.fastgit.org/{username}/{repo}/archive/refs/heads/{branch}.zip");
            }

            return zipBytes;
        }

        public class ReleaseInfo
        {
            [JsonProperty("tag_name")]
            public string TagName { get; set; }

            [JsonProperty("html_url")]
            public string Url { get; set; }

            [JsonProperty("created_at")]
            public DateTimeOffset CreateTime { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("body")]
            public string Body { get; set; }
        }
    }
}