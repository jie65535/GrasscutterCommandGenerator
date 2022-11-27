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

namespace GrasscutterTools.Game.Player
{
    /// <summary>
    /// 玩家数据
    /// </summary>
    internal class PlayerData
    {
        /// <summary>
        /// 升到下一级所需经验，索引为当前等级
        /// </summary>
        public static int[] LevelExp = new int[]
        {
            0, 375, 500, 625, 725, 850, 950, 1075, 1200, 1300, 1425, 1525, 1650, 1775, 1875, 2000, 2375, 2500, 2625,
            2775, 2825, 3425, 3725, 4000, 4300, 4575, 4875, 5150, 5450, 5725, 6025, 6300, 6600, 6900, 7175, 7475, 7750,
            8050, 8325, 8625, 10550, 11525, 12475, 13450, 14400, 15350, 16325, 17275, 18250, 19200, 26400, 28800, 31200,
            33600, 36000, 232350, 258950, 285750, 312825, 340125, 0,
        };

        /// <summary>
        /// 玩家最大等级数
        /// </summary>
        public const int PlayerMaxLevel = 60;
    }
}