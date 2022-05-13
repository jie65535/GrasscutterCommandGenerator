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
