using GrasscutterTools.Properties;

namespace GrasscutterTools.Game
{
    internal static class GameData
    {
        public static void LoadResources()
        {
            Animals = new ItemMap(Resources.Animal);
            Artifacts = new ItemMap(Resources.Artifact);
            ArtifactCats = new ItemMap(Resources.ArtifactCat);
            ArtifactMainAttribution = new ItemMap(Resources.ArtifactMainAttribution);
            ArtifactSubAttribution = new ItemMap(Resources.ArtifactSubAttribution);
            Avatars = new ItemMap(Resources.Avatar);
            AvatarColors = new ItemMap(Resources.AvatarColor);
            Items = new ItemMap(Resources.Item);
            Monsters = new ItemMap(Resources.Monster);
            NPCs = new ItemMap(Resources.NPC);
            Scenes = new ItemMap(Resources.Scene);
            Weapons = new ItemMap(Resources.Weapon);
            WeaponColors = new ItemMap(Resources.WeaponColor);
            Ornaments = new ItemMap(Resources.Ornament);
            GachaBannerPrefabs = new ItemMap(Resources.GachaBennerPrefab);
        }

        public static ItemMap Animals { get; private set; }

        public static ItemMap Artifacts { get; private set; }

        public static ItemMap ArtifactCats { get; private set; }

        public static ItemMap ArtifactMainAttribution { get; private set; }

        public static ItemMap ArtifactSubAttribution { get; private set; }

        public static ItemMap Avatars { get; private set; }

        public static ItemMap AvatarColors { get; private set; }

        public static ItemMap Items { get; private set; }

        public static ItemMap Monsters { get; private set; }

        public static ItemMap NPCs { get; private set; }

        public static ItemMap Scenes { get; private set; }

        public static ItemMap Weapons { get; private set; }

        public static ItemMap WeaponColors { get; private set; }

        public static ItemMap Ornaments { get; private set; }

        public static ItemMap GachaBannerPrefabs { get; private set; }
    }
}