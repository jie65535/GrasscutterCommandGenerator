using Newtonsoft.Json;

namespace GrasscutterTools.Game.Data.Excels
{
    [ResourceType("WeaponExcelConfigData.json")]
    internal class WeaponData : GameResource
    {
        [JsonProperty("rankLevel")]
        public int RankLevel { get; set; }
    }
}
