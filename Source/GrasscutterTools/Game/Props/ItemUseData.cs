using Newtonsoft.Json;

namespace GrasscutterTools.Game.Props
{
    internal class ItemUseData
    {
        [JsonProperty("useParam")]
        public string[] UseParam { get; set; }
    }
}
