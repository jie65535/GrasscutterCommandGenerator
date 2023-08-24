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

using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GrasscutterTools.Game.Shop
{
    internal class ShopGoodsData
    {
        [JsonProperty("goodsId")]
        public int GoodsId { get; set; }

        [JsonProperty("shopType")]
        public int ShopType { get; set; }

        [JsonProperty("itemId")]
        public int ItemId { get; set; }

        [JsonProperty("itemCount")]
        public int ItemCount { get; set; }

        [JsonProperty("costScoin")]
        public int CostScoin { get; set; }

        [JsonProperty("costHcoin")]
        public int CostHcoin { get; set; }

        [JsonProperty("costMcion")]
        public int CostMcion { get; set; }

        [JsonProperty("costItems")]
        public List<ItemParamData> CostItems { get; set; }

        [JsonProperty("minPlayerLevel")]
        public int MinPlayerLevel { get; set; }

        [JsonProperty("maxPlayerLevel")]
        public int MaxPlayerLevel { get; set; }

        [JsonProperty("buyLimit")]
        public int BuyLimit { get; set; }

        [JsonProperty("subTabId")]
        public int SubTabId { get; set; }

        [JsonProperty("refreshType"), JsonConverter(typeof(StringEnumConverter))]
        public ShopRefreshType RefreshType { get; set; }

        [JsonProperty("refreshParam")]
        public int RefreshParam { get; set; }

        [JsonProperty("beginTime")]
        public DateTime? BeginTime { get; set; }

        [JsonProperty("endTime")]
        public DateTime? EndTime { get; set; }
    }
}