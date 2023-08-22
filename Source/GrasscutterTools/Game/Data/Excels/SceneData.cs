using GrasscutterTools.Game.Props;
using Newtonsoft.Json;

namespace GrasscutterTools.Game.Data.Excels
{
    [ResourceType("SceneExcelConfigData.json")]
    internal class SceneData : GameResource
    {
        [JsonProperty("type")]
        public SceneType SceneType { get; set; }

        [JsonProperty("scriptData")]
        public string ScriptData { get; set; }
    }
}
