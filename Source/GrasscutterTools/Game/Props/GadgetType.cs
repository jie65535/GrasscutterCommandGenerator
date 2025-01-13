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

using System.Collections.Generic;

namespace GrasscutterTools.Game.Props
{
    internal static class GadgetType
    {
        private static readonly Dictionary<string, string> TextMapCHS = new Dictionary<string, string>
        {
            ["Avatar"] = "角色",
            ["Gear"] = "机关装置",
            ["Field"] = "领域",
            ["Bullet"] = "技能/飞弹",
            ["Gadget"] = "Gadget",
            ["AirflowField"] = "气流领域",
            ["SpeedupField"] = "加速领域",
            ["GatherObject"] = "采集物品",
            ["Platform"] = "平台",
            ["AmberWind"] = "风琥珀",
            ["Vehicle"] = "载具",
            ["MonsterEquip"] = "怪物装备",
            ["Equip"] = "装备",
            ["SubEquip"] = "副装备",
            ["FishRod"] = "钓鱼竿",
            ["Grass"] = "草",
            ["Water"] = "水",
            ["Tree"] = "树",
            ["Bush"] = "灌木",
            ["Lightning"] = "闪电",
            ["CustomTile"] = "自定义贴图",
            ["TransPointFirst"] = "传送点1",
            ["TransPointSecond"] = "传送点2",
            ["Chest"] = "宝箱",
            ["GeneralRewardPoint"] = "通用奖励点",
            ["OfferingGadget"] = "祭品Gadget",
            ["Worktop"] = "工作台",
            ["CustomGadget"] = "自定义Gadget",
            ["BlackMud"] = "黑色泥浆",
            ["DeshretObeliskGadget"] = "赤王方尖碑",
            ["JourneyGearOperatorGadget"] = "旅途装备操作Gadget",
            ["QuestGadget"] = "任务Gadget",
            ["RoguelikeOperatorGadget"] = "肉鸽 操作台",
            ["NightCrowGadget"] = "幽邃鸦眼",
            ["MpPlayRewardPoint"] = "多人游戏奖励点",
            ["CurveMoveGadget"] = "曲线移动Gadget",
            ["RewardStatue"] = "地城奖励树",
            ["RewardPoint"] = "循环地城奖励点",
            ["Foundation"] = "底座",
            ["Projector"] = "投影仪",
            ["Screen"] = "屏幕",
            ["CoinCollectLevelGadget"] = "金币收集等级Gadget",
            ["EchoShell"] = "回声海螺",
            ["UgcSpecialGadget"] = "UGC特殊Gadget",
            ["UgcTowerLevelUpGadget"] = "UGC塔升级Gadget",
            ["GatherPoint"] = "采集物挂接点",
            ["MiracleRing"] = "奇迹之环",
            ["EnvAnimal"] = "环境动物",
            ["EnergyBall"] = "能量球",
            ["SealGadget"] = "封印Gadget",
            ["ViewPoint"] = "观景点",
            ["FishPool"] = "钓鱼点",
            ["ElemCrystal"] = "元素水晶",
            ["Deprecated"] = "弃用",
            ["WindSeed"] = "风种子",
            ["UIInteractGadget"] = "界面交互Gadget",
            ["Camera"] = "摄像机",
        };

        public static string ToTranslatedString(string gadgetType, string language)
        {
            if (string.IsNullOrEmpty(gadgetType)) gadgetType = "Deprecated";
            return language.StartsWith("zh") ? TextMapCHS[gadgetType] : gadgetType;
        }
    }
}