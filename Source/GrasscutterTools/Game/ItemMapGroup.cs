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
using System.Linq;

namespace GrasscutterTools.Game
{
    /// <summary>
    /// ID映射组，Key为分类，双斜杠构造
    /// </summary>
    internal class ItemMapGroup : Dictionary<string, ItemMap>
    {
        public ItemMapGroup(string idNamePairs)
        {
            for (int i = 0; i < idNamePairs.Length;)
            {
                var categoryLineStartIndex = idNamePairs.IndexOf("//", i);
                if (categoryLineStartIndex == -1)
                    break;
                var categoryLineEndIndex = idNamePairs.IndexOf('\n', categoryLineStartIndex);
                if (categoryLineEndIndex == -1)
                    break;

                var category = idNamePairs.Substring(categoryLineStartIndex + 2, categoryLineEndIndex - categoryLineStartIndex - 2).Trim();

                var nextStartIndex = idNamePairs.IndexOf("//", categoryLineEndIndex);
                if (nextStartIndex == -1)
                {
                    var itemMap = new ItemMap(idNamePairs.Substring(categoryLineEndIndex + 1));
                    if (itemMap.Count > 0)
                        Add(category, itemMap);
                    break;
                }
                else
                {
                    var pairs = idNamePairs.Substring(categoryLineEndIndex + 1, nextStartIndex - categoryLineEndIndex - 1);
                    var itemMap = new ItemMap(pairs);
                    if (itemMap.Count > 0)
                        Add(category, itemMap);
                    i = nextStartIndex;
                }
            }
        }

        /// <summary>
        /// 获取所有行
        /// </summary>
        public IEnumerable<string> AllLines => Values.SelectMany(it => it.Lines);

        /// <summary>
        /// 获取所有ID
        /// </summary>
        public IEnumerable<int> AllIds => Values.SelectMany(it => it.Ids);

        private string[] lines;
        public string[] Lines => lines ??= AllLines.ToArray();

        public string this[int id]
        {
            get
            {
                foreach (var map in Values)
                {
                    var n = map[id];
                    if (n != ItemMap.EmptyName)
                        return n;
                }
                return ItemMap.EmptyName;
            }
        }
    }
}