using Newtonsoft.Json;

namespace GrasscutterTools.Game.CutScene
{
    internal class CutSceneItem
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }
    }
}
