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
using System.ComponentModel;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GrasscutterTools.Game.Gacha
{
    /// <summary>
    /// https://github.com/Grasscutters/Grasscutter/pull/639
    /// </summary>
    public class GachaBanner2
    {
        /// <summary>
        /// 添加卡池请从400开始增加id数值进行添加，这个id需要每个池子不一样，
        /// 如果你想添加大量卡池，请按照每次增加固定数值的id进行添加，比如：411，412，413....
        /// </summary>
        [JsonProperty("gachaType")]
        public int GachaType { get; set; } = 400;

        /// <summary>
        /// 这个id需要每个池子不一样，如果你想添加大量卡池，
        /// 请按照每次增加固定数值的id进行添加,比如：2100，2200，2300....
        /// </summary>
        [JsonProperty("scheduleId")]
        public int ScheduleId { get; set; } = 800;

        /// <summary>
        /// 这个是卡池的预制路径id
        /// </summary>
        [JsonProperty("prefabPath")]
        public string PrefabPath { get; set; } = "GachaShowPanel_A007";

        /// <summary>
        /// 这个是抽卡的预览背景路径id
        /// </summary>
        [JsonProperty("previewPrefabPath")]
        public string PreviewPrefabPath { get; set; } = "UI_Tab_GachaShowPanel_A007";

        /// <summary>
        /// 这个是抽卡的标题路径id，有可能与之前两项的id不同
        /// （一般这3项的id只需保持一致即可，就是A0xx，xx为同一id）
        /// </summary>
        [JsonProperty("titlePath")]
        public string TitlePath { get; set; } = "UI_GACHA_SHOW_PANEL_A007_TITLE";

        /// <summary>
        /// 这个表示祈愿用的道具，224是相遇之缘，223是纠缠之缘 - 选择一个作为该卡池的抽卡道具
        /// (提示：请不要随便修改祈愿道具除了蓝球和粉球，有可能会引发bug，比如修改成摩拉抽卡可能导致卡住)
        /// </summary>
        [JsonProperty("costItem")]
        public int CostItem { get; set; } = 224;

        /// <summary>
        /// 开始时间（Unix时间戳）
        /// </summary>
        [JsonProperty("beginTime")]
        public int BeginTime { get; set; } = 0;

        /// <summary>
        /// 结束时间（Unix时间戳）
        /// </summary>
        [JsonProperty("endTime")]
        public int EndTime { get; set; } = 1924992000;

        /// <summary>
        /// 卡池顺序
        /// </summary>
        [JsonProperty("sortId")]
        public int SortId { get; set; } = 1000;

        /// <summary>
        /// 抽卡次数限制
        /// </summary>
        [JsonProperty("gachaTimesLimit")]
        public int GachaTimesLimit { get; set; } = int.MaxValue;

        /// <summary>
        /// 4星的up角色或物品
        /// </summary>
        [JsonProperty("rateUpItems4")]
        public int[] RateUpItems4 { get; set; } = { };

        /// <summary>
        /// 5星的up物品或者角色
        /// </summary>
        [JsonProperty("rateUpItems5")]
        public int[] RateUpItems5 { get; set; } = { };

        /// <summary>
        /// 3星普通池
        /// </summary>
        [JsonProperty("fallbackItems3")]
        public int[] FallbackItems3 { get; set; } = { 11301, 11302, 11306, 12301, 12302, 12305, 13303, 14301, 14302, 14304, 15301, 15302, 15304 };

        /// <summary>
        /// 4星普通角色池
        /// </summary>
        [JsonProperty("fallbackItems4Pool1")]
        public int[] FallbackItems4Pool1 { get; set; } = { 1014, 1020, 1023, 1024, 1025, 1027, 1031, 1032, 1034, 1036, 1039, 1043, 1044, 1045, 1048, 1053, 1055, 1056, 1064 };

        /// <summary>
        /// 4星普通武器池
        /// </summary>
        [JsonProperty("fallbackItems4Pool2")]
        public int[] FallbackItems4Pool2 { get; set; } = { 11401, 11402, 11403, 11405, 12401, 12402, 12403, 12405, 13401, 13407, 14401, 14402, 14403, 14409, 15401, 15402, 15403, 15405 };

        /// <summary>
        /// 5星普通角色池
        /// </summary>
        [JsonProperty("fallbackItems5Pool1")]
        public int[] FallbackItems5Pool1 { get; set; } = { 1003, 1016, 1042, 1035, 1041 };

        /// <summary>
        /// 5星普通角色池
        /// </summary>
        [JsonProperty("fallbackItems5Pool2")]
        public int[] FallbackItems5Pool2 { get; set; } = { 11501, 11502, 12501, 12502, 13502, 13505, 14501, 14502, 15501, 15502 };

        /// <summary>
        /// 是否从奖池中移除玩家星座等级6级以上的角色
        /// </summary>
        [JsonProperty("removeC6FromPool")]
        public bool RemoveC6FromPool { get; set; } = false;

        /// <summary>
        /// 自动从普通池中移除UP池物品或角色
        /// </summary>
        [JsonProperty("autoStripRateUpFromFallback")]
        public bool AutoStripRateUpFromFallback { get; set; } = true;

        /// <summary>
        /// 4星权重
        /// </summary>
        [JsonProperty("weights4")]
        public int[,] Weights4 { get; set; } = { { 1, 510 }, { 8, 510 }, { 10, 10000 } };

        /// <summary>
        /// 5星权重
        /// </summary>
        [JsonProperty("weights5")]
        public int[,] Weights5 { get; set; } = { { 1, 75 }, { 73, 150 }, { 90, 10000 } };

        /// <summary>
        /// 4星平衡奖池权重（即中的是武器还是角色）
        /// </summary>
        [JsonProperty("poolBalanceWeights4")]
        public int[,] PoolBalanceWeights4 { get; set; } = { { 1, 255 }, { 17, 255 }, { 21, 10455 } };

        /// <summary>
        /// 5星平衡奖池权重（即中的是武器还是角色）
        /// </summary>
        [JsonProperty("poolBalanceWeights5")]
        public int[,] PoolBalanceWeights5 { get; set; } = { { 1, 30 }, { 147, 150 }, { 181, 10230 } };

        /// <summary>
        /// 4星事件概率（抽中后，摇1~100随机数，如果大于该值则抽中up池）
        /// </summary>
        [JsonProperty("eventChance4")]
        public int EventChance4 { get; set; } = 50;

        /// <summary>
        /// 5星事件概率（抽中后，摇1~100随机数，如果大于该值则抽中up池）
        /// </summary>
        [JsonProperty("eventChance5")]
        public int EventChance5 { get; set; } = 50;

        /// <summary>
        /// 这个有3种类型，standard表示常驻池，event表示限时角色祈愿池，
        /// weapon表示限时武器祈愿池，选择一种类型的卡池
        /// </summary>
        [JsonProperty("bannerType"), JsonConverter(typeof(StringEnumConverter))]
        public BannerType BannerType { get; set; } = BannerType.STANDARD;
    }
}