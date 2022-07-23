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

namespace GrasscutterTools.GOOD
{
    /// <summary>
    /// Weapon data representation
    /// Doc: https://frzyc.github.io/genshin-optimizer/#/doc
    /// Modified from https://github.com/Andrewthe13th/Inventory_Kamera/blob/master/InventoryKamera/game/Weapon.cs
    /// </summary>
    public class Weapon
    {
        /// <summary>
        /// e.g. "CrescentPike"
        /// </summary>
        [JsonProperty("key")]
        public string Name { get; set; }

        /// <summary>
        /// 1-90 inclusive
        /// </summary>
        [JsonProperty("level")]
        public int Level { get; set; }

        /// <summary>
        /// 0-6 inclusive. need to disambiguate 80/90 or 80/80
        /// </summary>
        [JsonProperty("ascension")]
        public int AscensionLevel { get; set; }

        /// <summary>
        /// 1-5 inclusive
        /// </summary>
        [JsonProperty("refinement")]
        public int RefinementLevel { get; set; }

        /// <summary>
        /// where "" means not equipped.
        /// </summary>
        [JsonProperty("location")]
        [DefaultValue("")]
        public string EquippedCharacter { get; set; }

        /// <summary>
        /// Whether the weapon is locked in game.
        /// </summary>
        [JsonProperty("lock")]
        public bool Lock { get; set; }
    }
}