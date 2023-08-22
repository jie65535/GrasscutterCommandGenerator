using Newtonsoft.Json;

namespace GrasscutterTools.Game.Data.Excels
{
    [ResourceType("HomeWorldBgmExcelConfigData.json")]
    internal class HomeWorldBgmData : GameResource
    {
        [JsonProperty("homeBgmId")]
        public override int Id { get; set; }

        [JsonProperty("bgmNameTextMapHash")]
        public long BgmNameTextMapHash { get; set; }
    }
}
