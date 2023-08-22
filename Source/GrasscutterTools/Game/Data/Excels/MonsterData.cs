using GrasscutterTools.Game.Props;
using Newtonsoft.Json;

namespace GrasscutterTools.Game.Data.Excels
{
    [ResourceType("MonsterExcelConfigData.json")]
    internal class MonsterData : GameResource
    {
        [JsonProperty("monsterName")]
        public string MonsterName { get; set; }

        [JsonProperty("type")]
        public MonsterType Type { get; set; }
    }
}
