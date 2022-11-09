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
namespace GrasscutterTools.Game.Shop
{
    /// <summary>
    /// 商品刷新类型
    /// </summary>
    public enum ShopRefreshType
    {
        /// <summary>
        /// 不刷新
        /// </summary>
        NONE,

        /// <summary>
        /// 按天刷新
        /// </summary>
        SHOP_REFRESH_DAILY,

        /// <summary>
        /// 按周刷新
        /// </summary>
        SHOP_REFRESH_WEEKLY,

        /// <summary>
        /// 按月刷新
        /// </summary>
        SHOP_REFRESH_MONTHLY,
    }
}
