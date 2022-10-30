using Newtonsoft.Json;

namespace GrasscutterTools.Game.Shop
{
    public struct ItemParamData
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
