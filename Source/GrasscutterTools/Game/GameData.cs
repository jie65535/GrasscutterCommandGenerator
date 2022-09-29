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
using GrasscutterTools.Utils;

namespace GrasscutterTools.Game
{
    internal static class GameData
    {
        public static void LoadResources()
        {
            //SparseSet illegalWeaponIds = new SparseSet(
            //    "10000-10008, 11411, 11506-11508, 12505, 12506, 12508, 12509," +
            //    "13503, 13506, 14411, 14503, 14505, 14508, 15504-15506");


            //SparseSet illegalRelicIds = new SparseSet(
            //    "20001, 23300-23340, 23383-23385, 78310-78554, 99310-99554"
            //    );

            //SparseSet illegalItemIds = new SparseSet(
            //    "100086, 100087, 100100-101000, 101106-101110, 101306, 101500-104000," +
            //    "105001, 105004, 106000-107000, 107011, 108000, 109000-110000," +
            //    "115000-130000, 200200-200899, 220050, 220054"
            //    );

            ArtifactSets = new ItemMap(Resources.ArtifactSets);
            ArtifactMainAttribution = new ItemMap(Resources.ArtifactMainAttribution);
            ArtifactSubAttribution = new ItemMap(Resources.ArtifactSubAttribution);
            Items = new ItemMap(Resources.Items);
            Monsters = new ItemMap(Resources.Monsters);
            Scenes = new ItemMap(Resources.Scenes);
            GachaBannerPrefabs = new ItemMap(Resources.GachaBennerPrefab);
            Quests = new ItemMap(Resources.Quests);
        }

        public static ItemMap ArtifactSets { get; private set; }

        public static ItemMap ArtifactMainAttribution { get; private set; }

        public static ItemMap ArtifactSubAttribution { get; private set; }

        public static ItemMap Items { get; private set; }

        public static ItemMap Monsters { get; private set; }

        public static ItemMap Scenes { get; private set; }

        public static ItemMap GachaBannerPrefabs { get; private set; }

        public static ItemMap Quests { get; private set; }
    }
}
