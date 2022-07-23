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
using Newtonsoft.Json;

namespace GrasscutterTools.GOOD
{
    /// <summary>
    /// Character data representation
    /// Doc: https://frzyc.github.io/genshin-optimizer/#/doc
    /// Modified from https://github.com/Andrewthe13th/Inventory_Kamera/blob/master/InventoryKamera/game/Character.cs
    /// </summary>
    public class Character
    {
        /// <summary>
        /// e.g. "Rosaria"
        /// </summary>
        [JsonProperty("key")]
        public string Name { get; set; }

        /// <summary>
        /// 1-90 inclusive
        /// </summary>
        [JsonProperty("level")]
        public int Level { get; set; }

        /// <summary>
        /// 0-6 inclusive
        /// </summary>
        [JsonProperty("constellation")]
        public int Constellation { get; set; }

        /// <summary>
        /// 0-6 inclusive. need to disambiguate 80/90 or 80/80
        /// </summary>
        [JsonProperty("ascension")]
        public int Ascension { get; set; }

        /// <summary>
        /// does not include boost from constellations. 1-15 inclusive
        /// </summary>
        [JsonProperty("talent")]
        public Talents Talents { get; set; }
    }

    public struct Talents
    {
        [JsonProperty("auto")]
        public int Auto { get; set; }

        [JsonProperty("skill")]
        public int Skill { get; set; }

        [JsonProperty("burst")]
        public int Burst { get; set; }
    }
}