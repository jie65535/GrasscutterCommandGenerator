
using Newtonsoft.Json;

namespace GrasscutterTools.DispatchServer.Model
{
    public class ServerStatus
    {
        [JsonProperty("playerCount")]
        public int PlayerCount { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }

    public class ServerStatusResponse
    {
        [JsonProperty("retcode")]
        public int RetCode { get; set; }

        [JsonProperty("status")]
        public ServerStatus Status { get; set; }
    }
}
