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
using System.Text;

using GrasscutterTools.Properties;

using Newtonsoft.Json;

namespace GrasscutterTools.Game
{
    internal static class SetStatsCommand
    {
        public class Stat
        {
            public Stat(string name, string argName, bool percent, string tip = "")
            {
                Name = name;
                ArgName = argName;
                Percent = percent;
                Tip = tip;
            }

            /// <summary>
            /// 属性名
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// 参数名
            /// </summary>
            public string ArgName { get; set; }

            /// <summary>
            /// 是否百分比
            /// </summary>
            public bool Percent { get; set; }

            /// <summary>
            /// 提示
            /// </summary>
            public string Tip { get; set; }
        }

        public static Stat[] Stats { get; private set; }

        public static void InitStats()
        {
            var json = Encoding.UTF8.GetString(Resources.AvatarStats);
            Stats = JsonConvert.DeserializeObject<Stat[]>(json);
        }

        //static SetStatsCommand()
        //{
        //    Stats = new List<Stat>
        //    {
        //        new Stat("最大生命值", "maxhp", false),
        //        new Stat("当前生命值", "hp", false),
        //        new Stat("当前攻击力", "atk", false),
        //        new Stat("基础攻击力", "atkb", false, "这似乎不会重新计算攻击力，可能只对buff类有效。"),
        //        new Stat("防御力", "def", false),
        //        new Stat("元素精通", "em", false),
        //        new Stat("元素充能效率", "er", true),
        //        new Stat("暴击率", "crate", true),
        //        new Stat("暴击伤害", "cdmg", true),
        //        new Stat("伤害加成", "dmg", true, "这似乎在攻击后被重置"),
        //        new Stat("风元素伤害加成", "eanemo", true),
        //        new Stat("冰元素伤害加成", "ecryo", true),
        //        new Stat("草元素伤害加成", "edendro", true),
        //        new Stat("雷元素伤害加成", "eelectro", true),
        //        new Stat("土元素伤害加成", "egeo", true),
        //        new Stat("水元素伤害加成", "ehydro", true),
        //        new Stat("火元素伤害加成", "epyro", true),
        //        new Stat("物理伤害加成", "ephys", true),
        //        new Stat("伤害减免", "resall", true, "这似乎在攻击后被重置"),
        //        new Stat("风元素伤害减免", "resanemo", true),
        //        new Stat("冰元素伤害减免", "rescryo", true),
        //        new Stat("草元素伤害减免", "resdendro", true),
        //        new Stat("雷元素伤害减免", "reselectro",  true),
        //        new Stat("土元素伤害减免", "resgeo", true),
        //        new Stat("水元素伤害减免", "reshydro", true),
        //        new Stat("火元素伤害减免", "respyro", true),
        //        new Stat("物理伤害减免", "resphys", true),
        //        new Stat("冷却缩减", "cdr", true),
        //        new Stat("治疗加成", "heal", true),
        //        new Stat("受治疗加成", "heali", true),
        //        new Stat("护盾强效","shield", true),
        //        new Stat("忽略防御", "defi", true),
        //    };
        //}
    }
}