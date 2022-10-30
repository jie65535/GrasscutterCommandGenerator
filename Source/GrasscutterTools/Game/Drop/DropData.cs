/**
 *  Grasscutter Tools
 *  Copyright (C) 2022 jie65535
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU Affero General Public License as published
 *  by the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU Affero General Public License for more details.
 *
 *  You should have received a copy of the GNU Affero General Public License
 *  along with this program.  If not, see <https://www.gnu.org/licenses/>.
 * 
 **/
using Newtonsoft.Json;

namespace GrasscutterTools.Game.Drop
{
    public struct DropData
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