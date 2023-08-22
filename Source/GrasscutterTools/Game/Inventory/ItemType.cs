
// ReSharper disable InconsistentNaming

using System.Collections.Generic;

namespace GrasscutterTools.Game.Inventory
{
    internal enum ItemType
    {
        ITEM_NONE = 0,
        ITEM_VIRTUAL = 1,
        ITEM_MATERIAL = 2,
        ITEM_RELIQUARY = 3,
        ITEM_WEAPON = 4,
        ITEM_DISPLAY = 5,
        ITEM_FURNITURE = 6,
    }


    internal static class ItemTypeExtension
    {
        private static readonly Dictionary<ItemType, string> TextMapCHS = new Dictionary<ItemType, string>
        {
            [ItemType.ITEM_NONE] = "未分类",
            [ItemType.ITEM_VIRTUAL] = "虚拟道具",
            [ItemType.ITEM_MATERIAL] = "材料",
            [ItemType.ITEM_RELIQUARY] = "圣遗物",
            [ItemType.ITEM_WEAPON] = "物品",
            [ItemType.ITEM_DISPLAY] = "任务",
            [ItemType.ITEM_FURNITURE] = "尘歌壶摆设",
        };
        private static readonly Dictionary<ItemType, string> TextMapEN = new Dictionary<ItemType, string>
        {
            [ItemType.ITEM_NONE] = "None",
            [ItemType.ITEM_VIRTUAL] = "Virtual",
            [ItemType.ITEM_MATERIAL] = "Material",
            [ItemType.ITEM_RELIQUARY] = "Reliquary",
            [ItemType.ITEM_WEAPON] = "Weapon",
            [ItemType.ITEM_DISPLAY] = "Display",
            [ItemType.ITEM_FURNITURE] = "Furniture",
        };

        public static string ToTranslatedString(this ItemType materialType, string language)
        {
            return language.StartsWith("zh") ? TextMapCHS[materialType] : TextMapEN[materialType];
        }
    }
}
