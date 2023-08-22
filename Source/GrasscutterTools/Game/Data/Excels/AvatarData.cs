using Newtonsoft.Json;

namespace GrasscutterTools.Game.Data.Excels
{
    [ResourceType("AvatarExcelConfigData.json")]
    internal class AvatarData : GameResource
    {
        [JsonProperty("qualityType")]
        public string QualityType { get; set; }
    }
}
