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

namespace GrasscutterTools.GOOD
{
    /// <summary>
    /// Genshin Open Object Description (GOOD)
    /// Doc: https://frzyc.github.io/genshin-optimizer/#/doc
    /// Modified from https://github.com/Andrewthe13th/Inventory_Kamera/blob/master/InventoryKamera/data/GOOD.cs
    /// 
    /// Available for
    /// https://frzyc.github.io/genshin-optimizer/
    /// https://github.com/Andrewthe13th/Inventory_Kamera
    /// https://genshin.aspirine.su/
    /// https://seelie.me/
    /// https://github.com/daydreaming666/Amenoma
    /// https://www.mona-uranai.com/
    /// https://genshin.mingyulab.com/
    /// https://genshin-center.com/
    /// </summary>
    public class GOOD
    {
        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("weapons", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<Weapon> Weapons { get; set; }

        [JsonProperty("artifacts", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<Artifact> Artifacts { get; set; }

        [JsonProperty("characters", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<Character> Characters { get; set; }

        [JsonProperty("materials", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Dictionary<string, int> Materials { get; set; }
    }
}
