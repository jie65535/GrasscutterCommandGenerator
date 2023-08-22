using System.Collections.Generic;
using GrasscutterTools.Game.Inventory;
using GrasscutterTools.Game.Props;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GrasscutterTools.Game.Data.Excels
{
    [ResourceType("MaterialExcelConfigData.json")]
    internal class MaterialData : GameResource
    {
        [JsonProperty("itemType"), JsonConverter(typeof(StringEnumConverter))]
        public ItemType ItemType { get; set; }

        [JsonProperty("materialType"), JsonConverter(typeof(StringEnumConverter))]
        public MaterialType MaterialType { get; set; }

        [JsonProperty("itemUse")]
        public List<ItemUseData> ItemUse { get; set; }
    }
}
