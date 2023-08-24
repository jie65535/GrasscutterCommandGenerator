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

using GrasscutterTools.Game.Props;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GrasscutterTools.Game.Data.Excels
{
    [ResourceType("AvatarExcelConfigData.json")]
    internal class AvatarData : GameResource
    {
        [JsonProperty("qualityType"), JsonConverter(typeof(StringEnumConverter))]
        public QualityType QualityType { get; set; }
    }
}