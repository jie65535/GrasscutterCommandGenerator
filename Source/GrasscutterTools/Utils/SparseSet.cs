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
using System.Collections.Generic;
using System.Linq;

namespace GrasscutterTools.Utils
{
    internal class SparseSet
    {
        private readonly struct Range
        {
            private readonly int Min;
            private readonly int Max;

            public Range(int min, int max)
            {
                Min = min;
                Max = max;
            }

            public bool Check(int value) =>
                Min <= value && value <= Max;
        }

        private readonly List<Range> RangeEntries;
        private readonly HashSet<int> DenseEntries;

        public SparseSet(string csv)
        {
            RangeEntries = new List<Range>();
            DenseEntries = new HashSet<int>();
            foreach (var token in csv.Replace("\n", "").Replace(" ", "").Split(','))
            {
                var tokens = token.Split('-');
                switch (tokens.Length)
                {
                    case 1:
                        DenseEntries.Add(int.Parse(tokens[0]));
                        break;

                    case 2:
                        RangeEntries.Add(new Range(int.Parse(tokens[0]), int.Parse(tokens[1])));
                        break;

                    default:
                        throw new ArgumentException($"Invalid token passed to SparseSet initializer - {token} (split length {tokens.Length})");
                }
            }
        }

        public bool Contains(int i)
        {
            return RangeEntries.Any(range => range.Check(i)) || DenseEntries.Contains(i);
        }
    }
}