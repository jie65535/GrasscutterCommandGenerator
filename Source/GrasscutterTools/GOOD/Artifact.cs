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
    /// Artifact data representation
    /// Doc: https://frzyc.github.io/genshin-optimizer/#/doc
    /// Modified from https://github.com/Andrewthe13th/Inventory_Kamera/blob/master/InventoryKamera/game/Artifact.cs
    /// </summary>
    public class Artifact
    {
        /// <summary>
        /// e.g. "GladiatorsFinale"
        /// </summary>
        [JsonProperty("setKey")]
        public string SetName { get; set; }

        /// <summary>
        /// //e.g. "plume"
        /// type SlotKey = "flower" | "plume" | "sands" | "goblet" | "circlet"
        /// </summary>
        [JsonProperty("slotKey")]
        public string GearSlot { get; set; }

        /// <summary>
        /// 1-5 inclusive
        /// </summary>
        [JsonProperty("rarity")]
        public int Rarity { get; set; }

        /// <summary>
        /// mainStatKey
        /// </summary>
        [JsonProperty("mainStatKey")]
        public string MainStat { get; set; }

        /// <summary>
        /// 0-20 inclusive
        /// </summary>
        [JsonProperty("level")]
        public int Level { get; set; }

        /// <summary>
        /// substats
        /// </summary>
        [JsonProperty("substats")]
        public SubStat[] SubStats { get; set; }

        /// <summary>
        /// where "" means not equipped.
        /// </summary>
        [JsonProperty("location")]
        public string EquippedCharacter { get; set; }

        /// <summary>
        /// Whether the artifact is locked in game.
        /// </summary>
        [JsonProperty("lock")]
        public bool Lock { get; set; }

        public struct SubStat
        {
            /// <summary>
            /// e.g. "critDMG_"
            /// </summary>
            [JsonProperty("key")]
            public string Stat { get; set; }

            /// <summary>
            /// e.g. 19.4
            /// </summary>
            [JsonProperty("value")]
            public double Value { get; set; }
        }
    }
}
