
// ReSharper disable InconsistentNaming

using System.Collections.Generic;

namespace GrasscutterTools.Game.Props
{
    /// <summary>
    /// 怪物种类
    /// </summary>
    internal enum MonsterType
    {
        MONSTER_NONE = 0,
        MONSTER_ORDINARY = 1,
        MONSTER_BOSS = 2,
        MONSTER_ENV_ANIMAL = 3,
        MONSTER_LITTLE_MONSTER = 4,
        MONSTER_FISH = 5,
        MONSTER_PARTNER = 6,
    }


    internal static class ItemTypeExtension
    {
        private static readonly Dictionary<MonsterType, string> TextMapCHS = new Dictionary<MonsterType, string>
        {
            [MonsterType.MONSTER_NONE] = "未分类",
            [MonsterType.MONSTER_ORDINARY] = "普通怪物",
            [MonsterType.MONSTER_BOSS] = "BOSS",
            [MonsterType.MONSTER_ENV_ANIMAL] = "动物",
            [MonsterType.MONSTER_LITTLE_MONSTER] = "小怪",
            [MonsterType.MONSTER_FISH] = "鱼",
            [MonsterType.MONSTER_PARTNER] = "友军",
        };
        private static readonly Dictionary<MonsterType, string> TextMapEN = new Dictionary<MonsterType, string>
        {
            [MonsterType.MONSTER_NONE] = "None",
            [MonsterType.MONSTER_ORDINARY] = "Ordinary",
            [MonsterType.MONSTER_BOSS] = "Boss",
            [MonsterType.MONSTER_ENV_ANIMAL] = "Env_animal",
            [MonsterType.MONSTER_LITTLE_MONSTER] = "Little_monster",
            [MonsterType.MONSTER_FISH] = "Fish",
            [MonsterType.MONSTER_PARTNER] = "Partner",
        };

        public static string ToTranslatedString(this MonsterType materialType, string language)
        {
            return language.StartsWith("zh") ? TextMapCHS[materialType] : TextMapEN[materialType];
        }
    }
}
