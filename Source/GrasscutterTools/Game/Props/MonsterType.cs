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