using Newtonsoft.Json;

namespace GrasscutterTools.Game.Data.Excels
{
    [ResourceType("AchievementExcelConfigData.json")]
    internal class AchievementData : GameResource
    {
        [JsonProperty("isDisuse")]
        public bool IsDisuse { get; set; }

        public bool IsUsed => !IsDisuse;
    }
}
