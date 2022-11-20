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
using GrasscutterTools.Properties;

namespace GrasscutterTools.Game
{
    internal static class GameData
    {
        public static void LoadResources()
        {
            Artifacts = new ItemMap(Resources.Artifact);
            ArtifactCats = new ItemMap(Resources.ArtifactCat);
            ArtifactMainAttribution = new ItemMap(Resources.ArtifactMainAttribution);
            ArtifactSubAttribution = new ItemMap(Resources.ArtifactSubAttribution);
            Avatars = new ItemMap(Resources.Avatar);
            AvatarColors = new ItemMap(Resources.AvatarColor);
            Items = new ItemMap(Resources.Item);
            Monsters = new ItemMapGroup(Resources.Monsters);
            Gadgets = new ItemMapGroup(Resources.Gadget);
            Scenes = new ItemMap(Resources.Scene);
            Weapons = new ItemMap(Resources.Weapon);
            WeaponColors = new ItemMap(Resources.WeaponColor);
            GachaBannerPrefabs = new ItemMap(Resources.GachaBennerPrefab);
            GachaBannerTitles = new ItemMap(Resources.GachaBannerTitle);
            Quests = new ItemMap(Resources.Quest);
            ShopType = new ItemMap(Resources.ShopType);
        }


        public static ItemMap Artifacts { get; private set; }

        public static ItemMap ArtifactCats { get; private set; }

        public static ItemMap ArtifactMainAttribution { get; private set; }

        public static ItemMap ArtifactSubAttribution { get; private set; }

        public static ItemMap Avatars { get; private set; }

        public static ItemMap AvatarColors { get; private set; }

        public static ItemMap Items { get; private set; }

        public static ItemMapGroup Monsters { get; private set; }

        public static ItemMapGroup Gadgets { get; private set; }

        public static ItemMap Scenes { get; private set; }

        public static ItemMap Weapons { get; private set; }

        public static ItemMap WeaponColors { get; private set; }

        public static ItemMap GachaBannerPrefabs { get; private set; }
        public static ItemMap GachaBannerTitles { get; private set; }

        public static ItemMap Quests { get; private set; }

        public static ItemMap ShopType { get; private set; }
    }
}
