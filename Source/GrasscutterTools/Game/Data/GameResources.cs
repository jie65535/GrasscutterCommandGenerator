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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using GrasscutterTools.Game.CutScene;
using GrasscutterTools.Game.Data.Excels;
using GrasscutterTools.Game.Inventory;
using GrasscutterTools.Game.Props;
using GrasscutterTools.Utils;

using Newtonsoft.Json;

namespace GrasscutterTools.Game.Data
{
    internal class GameResources
    {
        public Dictionary<int, AchievementData> AchievementData { get; set; }

        public Dictionary<int, AvatarData> AvatarData { get; set; }

        public Dictionary<int, HomeWorldBgmData> HomeWorldBgmData { get; set; }

        public Dictionary<int, DungeonData> DungeonData { get; set; }

        public Dictionary<int, GadgetData> GadgetData { get; set; }

        public List<GatherData> GatherData { get; set; }

        public Dictionary<int, HomeWorldFurnitureData> HomeWorldFurnitureData { get; set; }

        public Dictionary<int, MainQuestData> MainQuestData { get; set; }

        public Dictionary<int, QuestData> QuestData { get; set; }

        public Dictionary<int, MaterialData> MaterialData { get; set; }

        public Dictionary<int, MonsterData> MonsterData { get; set; }

        public Dictionary<int, ReliquaryData> ReliquaryData { get; set; }

        public Dictionary<int, SceneData> SceneData { get; set; }

        public List<SceneTagData> SceneTagData { get; set; }

        public Dictionary<int, WeaponData> WeaponData { get; set; }

        public TextMapData TextMapData { get; set; }

        public List<WeatherData> WeatherData { get; set; }
        public List<CutSceneItem> CutSceneData { get; set; }

        public GameResources(string resourcesDirPath, TextMapData textMapData)
        {
            TextMapData = textMapData;

            var properties = typeof(GameResources).GetProperties();
            foreach (var property in properties)
            {
                var type = property.PropertyType;
                if (!type.IsGenericType) continue;
                var genericArguments = type.GetGenericArguments();
                ResourceTypeAttribute attribute = null;
                foreach (var it in genericArguments)
                {
                    var attributes = it.GetCustomAttributes(typeof(ResourceTypeAttribute), true);
                    if (attributes.Length == 0) continue;
                    attribute = (ResourceTypeAttribute)attributes[0];
                    type = it;
                }
                if (attribute == null) continue;
                var dataFile = Path.Combine(resourcesDirPath, "ExcelBinOutput", attribute.Name);
                var data = LoadDataFile(type, dataFile);
                property.SetValue(this, data, null);
            }

            var illegalWeaponIds = new SparseSet(
                "10000-10008, 11411, 11506-11508, 12505, 12506, 12508, 12509," +
                "13503, 13506, 14411, 14503, 14508, 15504-15506, 20001");
            foreach (var id in WeaponData.Keys.Where(id => illegalWeaponIds.Contains(id)).ToList())
                WeaponData.Remove(id);

            var illegalRelicIds = new SparseSet(
                "20002, 20004, 23300-24825"
            );
            //var illegalRelicIds = new SparseSet(
            //    "20001, 23300-23340, 23383-23385, 78310-78554, 99310-99554"
            //);
            foreach (var id in ReliquaryData.Keys.Where(id => illegalRelicIds.Contains(id)).ToList())
                ReliquaryData.Remove(id);

            var illegalItemIds = new SparseSet(
                "3004-3008, 3018-3022"
            );
            //var illegalItemIds = new SparseSet(
            //    "3004-3008, 3018-3022, 100086, 100087, 100100-101000, 101106-101110, 101306, 101500-104000," +
            //    "105001, 105004, 106000-107000, 107011, 108000, 109000-110000," +
            //    "115000-130000, 200200-200899, 220050, 220054"
            //);
            foreach (var id in MaterialData.Keys.Where(id => illegalItemIds.Contains(id)).ToList())
                MaterialData.Remove(id);

            foreach (var id in AvatarData.Keys.Where(id => id < 10000002 || id >= 11000000).ToList())
                AvatarData.Remove(id);
        }

        private static object LoadDataFile(Type type, string path)
        {
            IList list = null;
            try
            {
                list = (IList)JsonConvert.DeserializeObject(File.ReadAllText(path), typeof(List<>).MakeGenericType(type));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to load \"{path}\", Exception={ex}");
            }
            if (type.IsSubclassOf(typeof(GameResource)))
            {
                var dicType = typeof(Dictionary<,>).MakeGenericType(typeof(int), type);
                var dic = (IDictionary)Activator.CreateInstance(dicType);
                if (list != null)
                {
                    foreach (GameResource gameResource in list)
                    {
                        if (gameResource.Id == 0) continue;
                        dic.Add(gameResource.Id, gameResource);
                    }
                }
                return dic;
            }
            else
            {
                if (list == null)
                    list = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(type));
                return list;
            }
        }

        private Dictionary<string, string> Languages = new Dictionary<string, string>
        {
            ["zh-cn"] = "TextMapCHS",
            ["zh-tw"] = "TextMapCHT",
            ["en-us"] = "TextMapEN",
            ["ru-ru"] = "TextMapRU",
        };

        public void ConvertResources(string projectResourcesDir)
        {
            var currentCultureInfo = Thread.CurrentThread.CurrentUICulture;
            try
            {
                var sb = new StringBuilder(MaterialData.Count * 24);
                foreach (var language in Languages)
                {
                    var dir = Path.Combine(projectResourcesDir, language.Key);
                    TextMapData.LoadTextMap(TextMapData.TextMapFilePaths[Array.IndexOf(TextMapData.TextMapFiles, language.Value)]);

                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(language.Key);
                    GameData.LoadResources();

                    #region Achievement

                    // Achievement
                    File.WriteAllLines(
                        Path.Combine(dir, "Achievement.txt"),
                        AchievementData.Values.Where(it => it.IsUsed)
                            .Select(it => $"{it.Id}:{TextMapData.GetText(it.TitleTextMapHash.ToString())} - {TextMapData.GetText(it.DescTextMapHash.ToString())}"),
                        Encoding.UTF8);

                    #endregion Achievement

                    #region Artifact

                    // Artifact
                    File.WriteAllLines(
                        Path.Combine(dir, "Artifact.txt"),
                        ReliquaryData.Values.OrderBy(it => it.Id).Select(it => $"{it.Id}:{TextMapData.GetText(it.NameTextMapHash.ToString())}"),
                        Encoding.UTF8);

                    #endregion Artifact

                    #region Avatar

                    // Avatar
                    File.WriteAllLines(
                        Path.Combine(dir, "Avatar.txt"),
                        MaterialData.Values
                            .Where(it => it.MaterialType == MaterialType.MATERIAL_AVATAR)
                            .Select(it => $"{it.Id}:{TextMapData.GetText(it.NameTextMapHash.ToString())}"),
                        Encoding.UTF8);

                    #endregion Avatar

                    #region Dungeon
                    
                    // Dungeon
                    sb.Clear();
                    foreach (var it in DungeonData.Values)
                    {
                        if (!TextMapData.TryGetText(it.NameTextMapHash.ToString(), out var name))
                        {
                            var temp = GameData.Dungeons[it.Id];
                            if (temp != ItemMap.EmptyName)
                                name = temp;
                        }

                        sb.AppendFormat("{0}:{1}", it.Id, name).AppendLine();
                    }
                    File.WriteAllText(
                        Path.Combine(dir, "Dungeon.txt"),
                        sb.ToString(),
                        Encoding.UTF8);
                    //File.WriteAllLines(
                    //    Path.Combine(dir, "Dungeon.txt"),
                    //    DungeonData.Values.Select(it => $"{it.Id}:{TextMapData.GetText(it.NameTextMapHash.ToString())}"),
                    //    Encoding.UTF8);

                    #endregion Dungeon

                    #region Gadget

                    // Gadget
                    sb.Clear();
                    var gatherMap = new Dictionary<int, int>(GatherData.Count);
                    foreach (var it in GatherData.Where(it => !gatherMap.ContainsKey(it.GadgetId)))
                        gatherMap.Add(it.GadgetId, it.ItemId);
                    var furnitureMap = new Dictionary<int, long>(HomeWorldFurnitureData.Count);
                    foreach (var it in HomeWorldFurnitureData.Values.Where(it => it.FurnitureGadgetId != null))
                        foreach (var gadgetId in it.FurnitureGadgetId.Where(id => id > 0 && !furnitureMap.ContainsKey(id)))
                            furnitureMap.Add(gadgetId, it.NameTextMapHash);
                    var oldFirst = language.Key.StartsWith("zh");
                    foreach (var gadgetTypes in GadgetData.Values.OrderBy(it => it.Id).GroupBy(it => it.Type))
                    {
                        sb.Append("// ").AppendLine(GadgetType.ToTranslatedString(gadgetTypes.Key, language.Key));
                        foreach (var it in gadgetTypes)
                        {
                            var name = oldFirst ? GameData.Gadgets[it.Id] : ItemMap.EmptyName;

                            if (name == ItemMap.EmptyName)
                            {
                                if (!TextMapData.TryGetText(it.NameTextMapHash.ToString(), out name)
                                    && !TextMapData.TryGetText(it.InteractNameTextMapHash.ToString(), out name))
                                {
                                    if (gatherMap.TryGetValue(it.Id, out var itemId)
                                        && MaterialData.TryGetValue(itemId, out var item))
                                    {
                                        name = TextMapData.GetText(item.NameTextMapHash.ToString());
                                    }
                                    else if (furnitureMap.TryGetValue(it.Id, out var hash))
                                    {
                                        name = TextMapData.GetText(hash.ToString());
                                    }
                                    else if (!string.IsNullOrEmpty(it.JsonName))
                                    {
                                        name = it.JsonName;
                                    }
                                    else if (!oldFirst)
                                    {
                                        var temp = GameData.Gadgets[it.Id];
                                        if (temp != ItemMap.EmptyName)
                                            name = temp;
                                    }
                                }
                            }

                            sb.AppendFormat("{0}:{1}", it.Id, name).AppendLine();
                        }
                        sb.AppendLine();
                    }

                    // 旧的数据
                    //var old = GameData.Gadgets.AllIds.Where(it => !GadgetData.ContainsKey(it));
                    //if (old.Any())
                    //{
                    //    sb.AppendLine("// Old lines");
                    //    foreach (var it in old)
                    //        sb.AppendFormat("{0}:{1}", it, GameData.Gadgets[it]).AppendLine();
                    //}

                    File.WriteAllText(
                        Path.Combine(dir, "Gadget.txt"),
                        sb.ToString(),
                        Encoding.UTF8);

                    #endregion Gadget

                    #region Item

                    // Item
                    sb.Clear();
                    foreach (var itemTypes in MaterialData.Values.GroupBy(it => it.ItemType))
                    {
                        sb.Append("// ").AppendLine(itemTypes.Key.ToTranslatedString(language.Key));
                        if (itemTypes.Key == ItemType.ITEM_MATERIAL)
                        {
                            foreach (var m in itemTypes
                                         .GroupBy(it => it.MaterialType)
                                         .Where(it => it.Key != MaterialType.MATERIAL_NONE)
                                         .OrderBy(it => it.Average(m => m.Id)))
                            {
                                sb.Append("// ").AppendLine(m.Key.ToTranslatedString(language.Key));

                                if (m.Key == MaterialType.MATERIAL_BGM)
                                {
                                    foreach (var materialData in m)
                                    {
                                        var param = int.Parse(materialData.ItemUse[0].UseParam[0]);
                                        var name = HomeWorldBgmData.ContainsKey(param) ? TextMapData.GetText(
                                            HomeWorldBgmData[param].BgmNameTextMapHash.ToString()) : string.Empty;
                                        sb.AppendFormat("{0}:{1} - {2}",
                                            materialData.Id,
                                            TextMapData.GetText(materialData.NameTextMapHash.ToString()),
                                            name);
                                        sb.AppendLine();
                                    }
                                }
                                else
                                {
                                    foreach (var materialData in m)
                                        sb.AppendFormat("{0}:{1}", materialData.Id, TextMapData.GetText(materialData.NameTextMapHash.ToString())).AppendLine();
                                }
                                sb.AppendLine();
                            }
                        }
                        else
                        {
                            foreach (var materialData in itemTypes)
                                sb.AppendFormat("{0}:{1}", materialData.Id, TextMapData.GetText(materialData.NameTextMapHash.ToString())).AppendLine();
                            sb.AppendLine();
                        }
                    }

                    sb.Append("// ").AppendLine(ItemType.ITEM_FURNITURE.ToTranslatedString(language.Key));
                    foreach (var value in HomeWorldFurnitureData.Values)
                        sb.AppendFormat("{0}:{1}", value.Id, TextMapData.GetText(value.NameTextMapHash.ToString())).AppendLine();

                    File.WriteAllText(Path.Combine(dir, "Item.txt"), sb.ToString(), Encoding.UTF8);

                    #endregion Item

                    #region Monsters

                    // Monsters
                    sb.Clear();
                    foreach (var monsterType in MonsterData.Values.OrderBy(it => it.Id)
                                 .GroupBy(it => it.Type)
                                 .OrderBy(it => it.Key))
                    {
                        sb.Append("// ").AppendLine(monsterType.Key.ToTranslatedString(language.Key));
                        foreach (var monsterData in monsterType)
                        {
                            if (TextMapData.TryGetText(monsterData.NameTextMapHash.ToString(), out var text))
                            {
                                sb.AppendFormat("{0}:{1}", monsterData.Id, text);
                            }
                            else
                            {
                                var name = GameData.Monsters[monsterData.Id];
                                if (name == ItemMap.EmptyName)
                                    sb.AppendFormat("{0}:{1} - {2}", monsterData.Id, monsterData.MonsterName, text);
                                else
                                    sb.AppendFormat("{0}:{1}", monsterData.Id, name);
                            }
                            sb.AppendLine();
                        }
                        sb.AppendLine();
                    }
                    File.WriteAllText(
                        Path.Combine(dir, "Monsters.txt"),
                        sb.ToString(),
                        Encoding.UTF8);

                    #endregion Monsters

                    #region Quest

                    // Quest
                    sb.Clear();
                    foreach (var it in QuestData.Values.OrderBy(it => it.Id))
                    {
                        var name = GameData.Quests[it.Id];
                        if (name == ItemMap.EmptyName)
                        {
                            sb.AppendFormat("{0}:{1} - {2}",
                                it.Id,
                                TextMapData.GetText(MainQuestData[it.MainId].TitleTextMapHash.ToString()),
                                TextMapData.GetText(it.DescTextMapHash.ToString()));
                        }
                        else
                        {
                            sb.AppendFormat("{0}:{1}", it.Id, name);
                        }
                        sb.AppendLine();
                    }
                    File.WriteAllText(
                        Path.Combine(dir, "Quest.txt"),
                        sb.ToString(),
                        Encoding.UTF8);

                    #endregion Quest

                    #region Scene

                    // Scene
                    sb.Clear();
                    foreach (var it in DungeonData.Values)
                    {
                        var scene = SceneData[it.SceneId];
                        scene.NameTextMapHash = it.NameTextMapHash;
                    }
                    foreach (var it in SceneData.Values.OrderBy(it => it.Id))
                    {
                        if (it.NameTextMapHash == 0 || !TextMapData.TryGetText(it.NameTextMapHash.ToString(), out var name))
                        {
                            name = GameData.Scenes[it.Id];
                            if (name == ItemMap.EmptyName)
                                name = it.ScriptData;
                        }
                        sb.AppendLine($"{it.Id}:{name}");
                    }
                    File.WriteAllText(
                        Path.Combine(dir, "Scene.txt"),
                        sb.ToString(),
                        Encoding.UTF8);

                    #endregion Scene

                    #region CutScene

                    // CutScene
                    File.WriteAllLines(
                        Path.Combine(dir, "Cutscene.txt"),
                        CutSceneData.Select(it =>
                        {
                            var text = GameData.CutScenes[it.Id];
                            return text == ItemMap.EmptyName
                                ? $"{it.Id}:{it.Path.Substring(it.Path.IndexOf('/') + 1)}"
                                : $"{it.Id}:{text}";
                        }), Encoding.UTF8);

                    #endregion CutScene

                    #region Weapon

                    // Weapon
                    File.WriteAllLines(
                        Path.Combine(dir, "Weapon.txt"),
                        WeaponData.Values.Select(it => $"{it.Id}:{TextMapData.GetText(it.NameTextMapHash.ToString())}"),
                        Encoding.UTF8);

                    #endregion Weapon
                }

                #region SceneTag

                // SceneTag

                sb.Clear();

                foreach (var scene in SceneTagData
                             .GroupBy(it => it.SceneId))
                {
                    sb.Append("// ").AppendLine(scene.Key.ToString());
                    foreach (var sceneTag in scene)
                    {
                        sb.Append($"{sceneTag.Id}:{sceneTag.SceneTagName}");
                        if (sceneTag.IsDefaultValid)
                            sb.Append(" (Default)");
                        sb.AppendLine();
                    }
                }
                File.WriteAllText(
                    Path.Combine(projectResourcesDir, "SceneTag.txt"),
                    sb.ToString(),
                    Encoding.UTF8);

                #endregion

                #region Weather

                // Weather

                sb.Clear();

                foreach (var scene in WeatherData
                             .GroupBy(it => it.SceneId)
                             .OrderBy(it => it.Key))
                {
                    sb.Append("// ").AppendLine(scene.Key.ToString());
                    foreach (var weather in scene)
                    {
                        var profileName = weather.ProfileName.Substring(weather.ProfileName.LastIndexOf('/') + 1)
                                                                    .Replace("ESP_", "");
                        sb.AppendLine($"{weather.AreaId}:{profileName}");
                    }
                }
                File.WriteAllText(
                    Path.Combine(projectResourcesDir, "Weather.txt"),
                    sb.ToString(),
                    Encoding.UTF8);

                #endregion

                File.WriteAllLines(
                    Path.Combine(projectResourcesDir, "AvatarColor.txt"),
                    AvatarData.Values.Select(it => $"{it.Id % 1000 + 1000}:{(int)it.QualityType}"),
                    Encoding.UTF8);

                File.WriteAllLines(
                    Path.Combine(projectResourcesDir, "WeaponColor.txt"),
                    WeaponData.Values.Select(it => $"{it.Id}:{(it.RankLevel >= 5 ? "yellow" : it.RankLevel >= 4 ? "purple" : "blue")}"),
                    Encoding.UTF8);
            }
            finally
            {
                Thread.CurrentThread.CurrentUICulture = currentCultureInfo;
            }
        }
    }
}