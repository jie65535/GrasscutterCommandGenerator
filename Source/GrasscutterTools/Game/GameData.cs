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
using GrasscutterTools.Properties;

namespace GrasscutterTools.Game
{
    internal static class GameData
    {
        public static void LoadResources()
        {
            Achievements = new ItemMap(Resources.Achievement);
            Activity = new ItemMapGroup(Resources.Activity);
            Artifacts = new ItemMap(Resources.Artifact);
            ArtifactCats = new ItemMap(Resources.ArtifactCat);
            ArtifactMainAttribution = new ItemMap(Resources.ArtifactMainAttribution);
            ArtifactSubAttribution = new ItemMap(Resources.ArtifactSubAttribution);
            Avatars = new ItemMap(Resources.Avatar);
            AvatarColors = new ItemMap(Resources.AvatarColor);
            CutScenes = new ItemMap(Resources.Cutscene);
            Items = new ItemMapGroup(Resources.Item);
            Monsters = new ItemMapGroup(Resources.Monsters);
            Gadgets = new ItemMapGroup(Resources.Gadget);
            Scenes = new ItemMap(Resources.Scene);
            SceneTags = new ItemMapGroup(Resources.SceneTag);
            Dungeons = new ItemMap(Resources.Dungeon);
            Weapons = new ItemMap(Resources.Weapon);
            WeaponColors = new ItemMap(Resources.WeaponColor);
            GachaBannerPrefabs = ToDictionary(Resources.GachaBannerPrefab);
            GachaBannerTitles = ToDictionary(Resources.GachaBannerTitle);
            Quests = new ItemMap(Resources.Quest);
            ShopType = new ItemMap(Resources.ShopType);
            Weathers = new ItemMapGroup(Resources.Weather);
        }

        private static List<KeyValuePair<string, string>> ToDictionary(string file)
        {
            var lines = file.Split('\n');
            var dic = new List<KeyValuePair<string, string>>(lines.Length);
            foreach (var line in lines)
            {
                var i = line.IndexOf(':');
                if (i <= 0) continue;
                var key = line.Substring(0, i).Trim();
                var value = line.Substring(i + 1).Trim();
                dic.Add(new KeyValuePair<string, string>(key, value));
            }
            return dic;
        }

        public static ItemMap Achievements { get; private set; }

        public static ItemMapGroup Activity { get; private set; }

        public static ItemMap Artifacts { get; private set; }

        public static ItemMap ArtifactCats { get; private set; }

        public static ItemMap ArtifactMainAttribution { get; private set; }

        public static ItemMap ArtifactSubAttribution { get; private set; }

        public static ItemMap Avatars { get; private set; }

        public static ItemMap AvatarColors { get; private set; }

        public static ItemMap CutScenes { get; private set; }

        public static ItemMapGroup Items { get; private set; }

        public static ItemMapGroup Monsters { get; private set; }

        public static ItemMapGroup Gadgets { get; private set; }

        public static ItemMap Scenes { get; private set; }

        public static ItemMapGroup SceneTags { get; private set; }

        public static ItemMap Dungeons { get; private set; }

        public static ItemMap Weapons { get; private set; }

        public static ItemMap WeaponColors { get; private set; }

        public static List<KeyValuePair<string, string>> GachaBannerPrefabs { get; private set; }

        public static List<KeyValuePair<string, string>> GachaBannerTitles { get; private set; }

        public static ItemMap Quests { get; private set; }

        public static ItemMap ShopType { get; private set; }

        public static ItemMapGroup Weathers { get; private set; }
    }
}