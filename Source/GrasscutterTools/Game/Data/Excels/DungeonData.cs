using Newtonsoft.Json;

namespace GrasscutterTools.Game.Data.Excels
{
    [ResourceType("DungeonExcelConfigData.json")]
    internal class DungeonData : GameResource
    {
        [JsonProperty("sceneId")]
        public int SceneId { get; set; }
    }
}
