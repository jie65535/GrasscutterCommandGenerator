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
using System.Collections.Generic;

using Newtonsoft.Json;

namespace GrasscutterTools.Game.Drop
{
    internal class DropInfo
    {
        /// <summary>
        /// 怪物ID
        /// </summary>
        [JsonProperty("monsterId")]
        public int MonsterId { get; set; }

        /// <summary>
        /// 掉落列表
        /// </summary>
        [JsonProperty("dropDataList")]
        public List<DropData> DropDataList { get; set; } = new List<DropData>();
    }
}
