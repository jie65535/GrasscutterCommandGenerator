using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrasscutterTools.Utils
{
    public class SparseSet
    {
        private struct Range
        {
            public int Min;
            public int Max;

            public Range(int min, int max)
            {
                Min = min;
                Max = max;
            }
            public bool Check(int value) =>
                Min <= value && value <= Max;
        }

        private readonly List<Range> rangeEntries;
        private readonly HashSet<int> denseEntries;
        public SparseSet(string csv)
        {
            rangeEntries = new List<Range>();
            denseEntries = new HashSet<int>();
            foreach (var token in csv.Replace("\n", "").Replace(" ", "").Split(','))
            {
                var tokens = token.Split('-');
                switch (tokens.Length)
                {
                    case 1:
                        denseEntries.Add(int.Parse(tokens[0]));
                        break;
                    case 2:
                        rangeEntries.Add(new Range(int.Parse(tokens[0]), int.Parse(tokens[1])));
                        break;
                    default:
                        throw new ArgumentException($"Invalid token passed to SparseSet initializer - {token} (split length {tokens.Length})");
                }
            }
        }

        public bool Contains(int i)
        {
            foreach (var range in rangeEntries)
                if (range.Check(i))
                    return true;
            return denseEntries.Contains(i);
        }
    }
}
