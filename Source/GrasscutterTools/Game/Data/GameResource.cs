using Newtonsoft.Json;

namespace GrasscutterTools.Game.Data
{
    internal abstract class GameResource
    {
        [JsonProperty("id")]
        public virtual int Id { get; set; }

        [JsonProperty("nameTextMapHash")]
        public long NameTextMapHash { get; set; }

        [JsonProperty("titleTextMapHash")]
        public string TitleTextMapHash { get; set; }

        [JsonProperty("descTextMapHash")]
        public long DescTextMapHash { get; set; }
    }
}
