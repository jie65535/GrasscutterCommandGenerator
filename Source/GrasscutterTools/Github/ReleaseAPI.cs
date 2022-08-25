/**
 *  Grasscutter Tools
 *  Copyright (C) 2022 jie65535
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

using GrasscutterTools.Utils;

using Newtonsoft.Json;

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
                return await HttpHelper.GetAsync<ReleaseInfo>($"https://api.github.com/repos/{username}/{repo}/releases/latest");
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
