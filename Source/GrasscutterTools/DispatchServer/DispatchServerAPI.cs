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
using System.Threading.Tasks;

using GrasscutterTools.DispatchServer.Model;
using GrasscutterTools.Utils;

namespace GrasscutterTools.DispatchServer
{
    public static class DispatchServerAPI
    {
        public static async Task<ServerStatus> QueryServerStatus(string host)
        {
            var response = await HttpHelper.GetAsync<ServerStatusResponse>(host + "/status/server");
            return response?.Status;
        }
    }
}