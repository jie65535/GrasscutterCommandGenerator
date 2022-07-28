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
using System.Globalization;
using System.Text.RegularExpressions;

using GrasscutterTools.Game;
using GrasscutterTools.Properties;

namespace GrasscutterTools.GOOD
{
    public static class GOODData
    {
        static GOODData()
        {
            var cultureInfo = CultureInfo.GetCultureInfo("en-US");
            var regex = new Regex(@"[\W]", RegexOptions.Compiled);

            Dictionary<string, int> ToGOODMap(ItemMap itemMap)
            {
                var dic = new Dictionary<string, int>(itemMap.Count);
                for (int i = 0; i < itemMap.Count; i++)
                {
                    var name = itemMap.Names[i];
                    var pascalCase = cultureInfo.TextInfo.ToTitleCase(name);
                    var nameGOOD = regex.Replace(pascalCase, string.Empty);
                    dic[nameGOOD] = itemMap.Ids[i];
                    //dic.Add(nameGOOD, itemMap.Ids[i]);
                }
                return dic;
            }

            var artifactCats = new ItemMap(Resources.ResourceManager.GetString("ArtifactCat", cultureInfo));
            var avatars = new ItemMap(Resources.ResourceManager.GetString("Avatar", cultureInfo));
            var weapons = new ItemMap(Resources.ResourceManager.GetString("Weapon", cultureInfo));

            ArtifactCats = ToGOODMap(artifactCats);
            Avatars = ToGOODMap(avatars);
            Weapons = ToGOODMap(weapons);
        }


        public static Dictionary<string, int> ArtifactCats { get; private set; }


        public static Dictionary<string, string> ArtifactSlotMap = new Dictionary<string, string> {
            {"goblet", "1"}, {"plume", "2"}, {"circlet", "3"}, {"flower", "4"}, {"sands", "5"}
        };

        public static Dictionary<string, int> ArtifactMainAttribution { get; } = new Dictionary<string, int>
        {
            { "hp"           , 10001 },
            { "hp_"          , 10002 },
            { "atk"          , 10003 },
            { "atk_"         , 10004 },
            { "def"          , 10005 },
            { "def_"         , 10006 },
            { "enerRech_"    , 10007 },
            { "eleMas"       , 10008 },
            { "critRate_"    , 13007 },
            { "critDMG_"     , 13008 },
            { "heal_"        , 13009 },
            { "pyro_dmg_"    , 15008 },
            { "electro_dmg_" , 15009 },
            { "cryo_dmg_"    , 15010 },
            { "hydro_dmg_"   , 15011 },
            { "anemo_dmg_"   , 15012 },
            { "geo_dmg_"     , 15013 },
            { "dendro_dmg_"  , 15014 },
            { "physical_dmg_", 15015 },
        };

        public static Dictionary<string, int> ArtifactSubAttribution { get; } = new Dictionary<string, int>
        {
            { "hp"       , 102 },
            { "hp_"      , 103 },
            { "atk"      , 105 },
            { "atk_"     , 106 },
            { "def"      , 108 },
            { "def_"     , 109 },
            { "critRate_", 120 },
            { "critDMG_" , 122 },
            { "enerRech_", 123 },
            { "eleMas"   , 124 },
        };

        public static Dictionary<string, int> Avatars { get; private set; }

        public static Dictionary<string, int> Weapons { get; private set; }

    }
}
