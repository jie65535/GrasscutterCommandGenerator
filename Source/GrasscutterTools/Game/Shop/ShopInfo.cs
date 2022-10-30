using System.Collections.Generic;

using Newtonsoft.Json;

namespace GrasscutterTools.Game.Shop
{
    public class ShopInfo
    {
        [JsonProperty("goodsId")]
        public int GoodsId { get; set; }

        [JsonProperty("goodsItem")]
        public ItemParamData GoodsItem { get; set; }

        [JsonProperty("scoin")]
        public int SCoin { get; set; }

        [JsonProperty("costItemList")]
        public List<ItemParamData> CostItemList { get; set; }

        [JsonProperty("boughtNum")]
        public int BoughtNum { get; set; }

        [JsonProperty("buyLimit")]
        public int BuyLimit { get; set; }

        [JsonProperty("beginTime")]
        public int BeginTime { get; set; }

        [JsonProperty("endTime")]
        public int EndTime { get; set; } = 1924992000;

        [JsonProperty("minLevel")]
        public int MinLevel { get; set; }

        [JsonProperty("maxLevel")]
        public int MaxLevel { get; set; } = 61;

        [JsonProperty("preGoodsIdList")]
        public List<int> PreGoodsIdList { get; set; } = new List<int>();

        [JsonProperty("mcoin")]
        public int MCoin { get; set; }

        [JsonProperty("hcoin")]
        public int HCoin { get; set; }

        [JsonProperty("disableType")]
        public int DisableType { get; set; }


        [JsonProperty("secondarySheetId")]
        public int SecondarySheetId { get; set; }
    }
}
