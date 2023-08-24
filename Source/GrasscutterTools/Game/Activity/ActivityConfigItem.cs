/**
 *  Grasscutter Tools
 *  Copyright (C) 2023 jie65535
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

namespace GrasscutterTools.Game.Activity
{
    internal class ActivityConfigItem
    {
        /// <summary>
        /// 活动ID
        /// </summary>
        [JsonProperty("activityId")]
        public int ActivityId { get; set; }

        /// <summary>
        /// 活动类型
        /// </summary>
        [JsonProperty("activityType")]
        public int ActivityType { get; set; }

        /// <summary>
        /// 调度ID
        /// </summary>
        [JsonProperty("scheduleId")]
        public int ScheduleId { get; set; }

        /// <summary>
        /// 满足条件列表
        /// </summary>
        [JsonProperty("meetCondList")]
        public List<int> MeetCondList { get; set; }

        /// <summary>
        /// 活动开始时间
        /// </summary>
        [JsonProperty("beginTime")]
        public DateTime BeginTime { get; set; }

        /// <summary>
        /// 活动结束时间
        /// </summary>
        [JsonProperty("endTime")]
        public DateTime EndTime { get; set; }
    }
}