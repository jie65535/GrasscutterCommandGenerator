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
    /// 使用这个只需替换掉你原来的的data/banner.json文件，
    /// 然后重启服务器和客户端，即可享受全卡池抽卡，卡池的选择方式是点击左右箭头进行切换
    /// </summary>
    public class GachaBanner
    {
        /// <summary>
        /// 添加卡池请从400开始增加id数值进行添加，这个id需要每个池子不一样，
        /// 如果你想添加大量卡池，请按照每次增加固定数值的id进行添加，比如：411，412，413....
        /// </summary>
        [JsonProperty("gachaType")]
        public int GachaType { get; set; }

        /// <summary>
        /// 这个id需要每个池子不一样，如果你想添加大量卡池，
        /// 请按照每次增加固定数值的id进行添加,比如：2100，2200，2300....
        /// </summary>
        [JsonProperty("scheduleId")]
        public int ScheduleId { get; set; }

        /// <summary>
        /// 这个有3种类型，standard表示常驻池，event表示限时角色祈愿池，
        /// weapon表示限时武器祈愿池，选择一种类型的卡池
        /// </summary>
        [JsonProperty("bannerType", DefaultValueHandling = DefaultValueHandling.Include), JsonConverter(typeof(StringEnumConverter))]
        public BannerType BannerType { get; set; }

        /// <summary>
        /// 这个是卡池的预制路径id
        /// </summary>
        [JsonProperty("prefabPath")]
        public string PrefabPath { get; set; }

        /// <summary>
        /// 这个是抽卡的预览背景路径id
        /// </summary>
        [JsonProperty("previewPrefabPath")]
        public string PreviewPrefabPath { get; set; }

        /// <summary>
        /// 这个是抽卡的标题路径id，有可能与之前两项的id不同
        /// （一般这3项的id只需保持一致即可，就是A0xx，xx为同一id）
        /// </summary>
        [JsonProperty("titlePath")]
        public string TitlePath { get; set; }

        /// <summary>
        /// 这个表示祈愿用的道具，224是相遇之缘，223是纠缠之缘 - 选择一个作为该卡池的抽卡道具
        /// (提示：请不要随便修改祈愿道具除了蓝球和粉球，有可能会引发bug，比如修改成摩拉抽卡可能导致卡住)
        /// </summary>
        [JsonProperty("costItem")]
        public int CostItem { get; set; }

        /// <summary>
        /// 祈愿什么时候开始（默认设置为0）
        /// </summary>
        [JsonProperty("beginTime")]
        public int BeginTime { get; set; } = 0;

        /// <summary>
        /// 这个卡池持续多长时间（默认为这个极大的数字）
        /// </summary>
        [JsonProperty("endTime")]
        public int EndTime { get; set; } = 1924992000;

        /// <summary>
        /// 暂时未搞清楚功能，可能与卡池在屏幕的左右顺序有关
        /// </summary>
        [JsonProperty("sortId")]
        public int SortId { get; set; }

        /// <summary>
        /// 通常为5星的up角色或物品（可修改，可添加，查看gm手册可修改为任意角色或者物品）
        /// </summary>
        [JsonProperty("rateUpItems1")]
        public int[] RateUpItems1 { get; set; }

        /// <summary>
        /// 通常为4星的up物品或者角色(可修改，可添加，查看gm手册可修改为任意角色或者物品)
        /// </summary>
        [JsonProperty("rateUpItems2")]
        public int[] RateUpItems2 { get; set; }

        /// <summary>
        /// 5星概率(0~10000)
        /// </summary>
        [JsonProperty("baseYellowWeight", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(60)]
        public int BaseYellowWeight { get; set; } = 60; // Max 10000

        /// <summary>
        /// 4星概率(0~10000)
        /// </summary>
        [JsonProperty("basePurpleWeight", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(510)]
        public int BasePurpleWeight { get; set; } = 510; // Max 10000

        /// <summary>
        /// 事件概率（抽中后，摇1~100随机数，如果大于该值则抽中up池）
        /// </summary>
        [JsonProperty("eventChance", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(50)]
        public int EventChance { get; set; } = 50; // Chance to win a featured event item

        /// <summary>
        /// 软保底，失败多少次开始提升抽中概率（在这之上每失败一次概率增加1%）
        /// </summary>
        [JsonProperty("softPity", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(75)]
        public int SoftPity { get; set; } = 75;

        /// <summary>
        /// 硬保底（失败多少次必出）
        /// </summary>
        [JsonProperty("hardPity", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(90)]
        public int HardPity { get; set; } = 90;
    }
}