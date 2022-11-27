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

namespace GrasscutterTools.Game.Mail
{
    /// <summary>
    /// 附件
    /// </summary>
    public struct MailItem
    {
        /// <summary>
        /// 物品ID
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// 物品数量
        /// </summary>
        public int ItemCount { get; set; }

        /// <summary>
        /// 物品等级
        /// </summary>
        public int ItemLevel { get; set; }

        public override string ToString()
        {
            var name = GameData.Items[ItemId];
            if (name == ItemMap.EmptyName)
                name = GameData.Weapons[ItemId];
            if (name == ItemMap.EmptyName)
                name = GameData.Artifacts[ItemId];
            if (ItemLevel > 1)
                return $"{ItemId}:{name} x{ItemCount} lv{ItemLevel}";
            else if (ItemCount > 1)
                return $"{ItemId}:{name} x{ItemCount}";
            else
                return $"{ItemId}:{name}";
        }
    }
}