using Newtonsoft.Json;

namespace GrasscutterTools.Game.Drop
{
    public class DropData
    {
        /// <summary>
        /// 物品ID
        /// </summary>
        [JsonProperty("itemId")]
        public int ItemId { get; set; }

        /// <summary>
        /// 最小数量
        /// </summary>
        [JsonProperty("minCount")]
        public int MinCount { get; set; }

        /// <summary>
        /// 最大数量
        /// </summary>
        [JsonProperty("maxCount")]
        public int MaxCount { get; set; }

        /// <summary>
        /// 最小权重，范围0~10000
        /// </summary>
        [JsonProperty("minWeight")]
        public int MinWeight { get; set; }

        /// <summary>
        /// 最大权重，范围0~10000
        /// </summary>
        [JsonProperty("maxWeight")]
        public int MaxWeight { get; set; }

        // 以下属性可用但没有必要

        ///// <summary>
        ///// 是否共享？
        ///// </summary>
        //[JsonProperty("share")]
        //public bool IsShare { get; set; }

        ///// <summary>
        ///// 是否直接给予
        ///// </summary>
        //[JsonProperty("give")]
        //public bool IsGive { get; set; }

        public override string ToString()
        {
            if (MinCount != MaxCount)
                return $"{ItemId}:{GameData.Items[ItemId]} | x[{MinCount}~{MaxCount}] w[{MinWeight}~{MaxWeight}]";
            else
                return $"{ItemId}:{GameData.Items[ItemId]} | x{MinCount} w[{MinWeight}~{MaxWeight}]";
        }
    }
}