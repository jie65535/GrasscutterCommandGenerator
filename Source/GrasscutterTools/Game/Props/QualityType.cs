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

// ReSharper disable InconsistentNaming

namespace GrasscutterTools.Game.Props
{
    internal enum QualityType
    {
        /// <summary>
        /// 无
        /// </summary>
        QUALITY_NONE = 0,

        /// <summary>
        /// 一星
        /// </summary>
        QUALITY_WHITE = 1,

        /// <summary>
        /// 二星
        /// </summary>
        QUALITY_GREEN = 2,

        /// <summary>
        /// 三星
        /// </summary>
        QUALITY_BLUE = 3,

        /// <summary>
        /// 四星
        /// </summary>
        QUALITY_PURPLE = 4,

        /// <summary>
        /// 五星
        /// </summary>
        QUALITY_ORANGE = 5,

        /// <summary>
        /// 限定五星
        /// </summary>
        //QUALITY_ORANGE_SP = 105,
        QUALITY_ORANGE_SP = 5,
    }
}