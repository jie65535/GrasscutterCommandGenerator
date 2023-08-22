using GrasscutterTools.Game.Props;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GrasscutterTools.Game.Data.Excels
{
    [ResourceType("AvatarExcelConfigData.json")]
    internal class AvatarData : GameResource
    {
        [JsonProperty("qualityType"), JsonConverter(typeof(StringEnumConverter))]
        public QualityType QualityType { get; set; }
    }
}
