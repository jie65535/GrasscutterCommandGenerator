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

using Newtonsoft.Json;

namespace GrasscutterTools.Utils
{
    /// <summary>
    /// 热键项
    /// </summary>
    internal class HotKeyItem
    {
        public HotKeyItem()
        {
        }

        public HotKeyItem(string tag, string commands, string hotKey, bool isEnabled = true)
        {
            Tag = tag;
            Commands = commands;
            HotKey = hotKey;
            IsEnabled = isEnabled;
        }

        /// <summary>
        /// Gets or sets the hot key identifier.
        /// </summary>
        /// <value>
        /// The hot key identifier.
        /// </value>
        [JsonIgnore]
        public int HotKeyId { get; set; }

        /// <summary>
        /// Gets or sets the name of the Tag.
        /// </summary>
        /// <value>
        /// The name of the Tag.
        /// </value>
        public string Tag { get; set; }

        /// <summary>
        /// Gets or sets the Commands.
        /// </summary>
        /// <value>
        /// The Commands.
        /// </value>
        public string Commands { get; set; }

        /// <summary>
        /// Gets or sets the hot key.
        /// 组合键之间使用+隔开，例如："Ctrl+Shift+W"
        /// </summary>
        /// <value>
        /// The hot key.
        /// </value>
        public string HotKey { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="HotKeyItem"/> is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsEnabled { get; set; } = true;
    }
}