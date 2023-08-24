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

using System;
using System.Collections.Generic;

namespace GrasscutterTools.Game
{
    internal class ItemMap
    {
        public ItemMap(string idNamePairs)
        {
            var lines = idNamePairs.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var capacity = lines.Length;
            IdMap = new Dictionary<int, string>(capacity);
            //NameMap = new Dictionary<string, int>(capacity);
            var IdList = new List<int>(capacity);
            var NameList = new List<string>(capacity);
            var lineList = new List<string>(capacity);

            foreach (var line in lines)
            {
                var si = line.IndexOf(':');
                if (si > 0 && int.TryParse(line.Substring(0, si).Trim(), out int id))
                {
                    var name = line.Substring(si + 1).Trim();
                    if (!string.IsNullOrEmpty(name) && name != "null")
                    {
                        IdMap[id] = name;
                        //NameMap[name] = id;
                        IdList.Add(id);
                        NameList.Add(name);
                        lineList.Add(line);
                    }
                }
            }

            Ids = IdList.ToArray();
            Names = NameList.ToArray();
            Lines = lineList.ToArray();
        }

        private readonly Dictionary<int, string> IdMap;
        //private readonly Dictionary<string, int> NameMap;

        public int Count => Ids.Length;

        public string this[int id] => IdMap.TryGetValue(id, out string name) ? name : EmptyName;

        public static string EmptyName = "???";
        //public int this[string name] => NameMap[name];

        public int[] Ids { get; }

        public string[] Names { get; }

        public string[] Lines { get; }

        public static int ToId(string line) => int.Parse(line.Substring(0, line.IndexOf(':')).Trim());

        public static bool TryToId(string line, out int id)
        {
            id = 0;
            var sp = line.IndexOf(':');
            if (sp == -1) return false;
            return int.TryParse(line.Substring(0, sp).Trim(), out id);
        }
    }
}