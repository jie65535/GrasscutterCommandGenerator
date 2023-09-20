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
using System.Threading.Tasks;

using GrasscutterTools.Utils;

using Newtonsoft.Json;

namespace GrasscutterTools.OpenCommand
{
    internal class OpenCommandAPI
    {
        public OpenCommandAPI(string host, string token = "")
        {
            Host = host;
            API = host + "/opencommand/api";
            Token = token;
            CanInvoke = !string.IsNullOrEmpty(token);
        }

        public string Host { get; }

        private readonly string API;

        public string Token { get; set; }

        public bool CanInvoke { get; private set; }

        private Version version = new Version(1, 6, 1);

        public Version Version
        {
            get => version;
            private set
            {
                version = value;
                CanInvokeMultipleCmd = version >= new Version(1, 7);
            }
        }

        public bool CanInvokeMultipleCmd { get; private set; }

        public async Task<bool> Ping()
        {
            //try
            //{
            var response = await DoRequest("ping");
            if (response.Data is string str && Version.TryParse(str, out var version))
                Version = version;
            
            return response.RetCode == 200;
            //}
            //catch (Exception)
            //{
            //    return false;
            //}
        }

        public async Task SendCode(int playerId)
        {
            var response = await DoRequest("sendCode", playerId);
            Token = response.Data as string;
        }

        public async Task Verify(int code)
        {
            await DoRequest("verify", code);
            CanInvoke = true;
        }

        public async Task<string> Invoke(string command)
        {
            var response = await DoRequest("command", command);
            return response.Data as string;
        }

        private async Task<Response> DoRequest(string action, object data = null)
        {
            var response = await HttpHelper.PostAsync<Response>(API, new Request(Token, action, data));
            if (response.RetCode == 401)
                Token = "";
            if (response.RetCode != 200)
                throw new InvokeException(response.Message);
            return response;
        }

        public class Request
        {
            public Request(string token, string action, object data)
            {
                Token = token;
                Action = action;
                Data = data;
            }

            [JsonProperty("token")]
            public string Token { get; set; }

            [JsonProperty("action")]
            public string Action { get; set; }

            [JsonProperty("data")]
            public object Data { get; set; }
        }

        public class Response
        {
            [JsonProperty("retcode")]
            public int RetCode { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("data")]
            public object Data { get; set; }
        }

        internal class InvokeException : Exception
        {
            public InvokeException(string message) : base(message)
            {
            }
        }
    }
}