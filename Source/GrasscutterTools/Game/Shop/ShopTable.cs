using System.Collections.Generic;

using Newtonsoft.Json;

namespace GrasscutterTools.Game.Shop
{
    public class ShopTable
    {
        [JsonProperty("shopId")]
        public int ShopType { get; set; }

        [JsonProperty("items")]
        public List<ShopInfo> Items { get; set; }
    }
}
