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
using System.Linq;

namespace GrasscutterTools.Utils
{
    class SubstatSumEquality : IEqualityComparer<List<KeyValuePair<int, double>>>
    {
        public bool Equals(List<KeyValuePair<int, double>> left, List<KeyValuePair<int, double>> right)
        {
            if (sum_substat(left) == sum_substat(right))
                return true;
            else
                return false;
        }

        public int GetHashCode(List<KeyValuePair<int, double>> dict)
        {
            return sum_substat(dict).GetHashCode();
        }

        public static double sum_substat(List<KeyValuePair<int, double>> dict)
        {
            double sum = 0;
            foreach (KeyValuePair<int, double> kvp in dict)
            {
                sum += kvp.Value;
            }
            return sum;
        }
    }

    class ArtifactUtils
    {   
        public static Dictionary<string, double[][]> substats_rolls = new Dictionary<string, double[][]>
        {
            {
                "hp",
                new double[][] {
                    new double[] {23.9, 29.88},
                    new double[] {50.19, 60.95, 71.7},
                    new double[] {100.38, 114.72, 129.06, 143.4},
                    new double[] {167.3, 191.2, 215.1, 239},
                    new double[] {209.13, 239, 268.88, 298.75}
               }
            },
            {
                "hp_",
                new double[][] {
                    new double[] {1.17, 1.46},
                    new double[] {1.63, 1.98, 2.33},
                    new double[] {2.45, 2.8, 3.15, 3.5},
                    new double[] {3.26, 3.73, 4.2, 4.66},
                    new double[] {4.08, 4.66, 5.25, 5.83}
               }
            },
            {
                "atk",
                new double[][] {
                    new double[] {1.56, 1.95},
                    new double[] {3.27, 3.97, 4.67},
                    new double[] {6.54, 7.47, 8.4, 9.34},
                    new double[] {10.89, 12.45, 14, 15.56},
                    new double[] {13.62, 15.56, 17.51, 19.45 }
               }
            },
            {
                "atk_",
                new double[][] {
                    new double[] {1.17, 1.46},
                    new double[] {1.63, 1.98, 2.33},
                    new double[] {2.45, 2.8, 3.15, 3.5},
                    new double[] {3.26, 3.73, 4.2, 4.66},
                    new double[] {4.08, 4.66, 5.25, 5.83}
               }
            },
            {
                "def",
                new double[][] {
                    new double[] {1.85, 2.31},
                    new double[] {3.89, 4.72, 5.56},
                    new double[] {10, 11.11, 7.78, 8.89},
                    new double[] {12.96, 14.82, 16.67, 18.52},
                    new double[] {16.2, 18.52, 20.83, 23.15}
               }
            },
            {
                "def_",
                new double[][] {
                    new double[] {1.46, 1.82},
                    new double[] {2.04, 2.48, 2.91},
                    new double[] {3.06, 3.5, 3.93, 4.37},
                    new double[] {4.08, 4.66, 5.25, 5.83},
                    new double[] {5.1, 5.83, 6.56, 7.29}
               }
            },
            {
                "critRate_",
                new double[][] {
                    new double[] {.78, .97},
                    new double[] {1.09, 1.32, 1.55},
                    new double[] {1.63, 1.86, 2.1, 2.33},
                    new double[] {2.18, 2.49, 2.8, 3.11},
                    new double[] {2.72, 3.11, 3.5, 3.89}
               }
            },
            {
                "critDMG_",
                new double[][] {
                    new double[] {1.55, 1.94},
                    new double[] {2.18, 2.64, 3.11},
                    new double[] {3.26, 3.73, 4.2, 4.66},
                    new double[] {4.35, 4.97, 5.6, 6.22},
                    new double[] {5.44, 6.22, 6.99, 7.77}
               }
            },
            {
                "eleMas",
                new double[][] {
                    new double[] {4.66, 5.83},
                    new double[] {6.53, 7.93, 9.33},
                    new double[] {11.19, 12.59, 13.99, 9.79},
                    new double[] {13.06, 14.92, 16.79, 18.65},
                    new double[] {16.32, 18.65, 20.98, 23.31}
               }
            },
            {
                "enerRech_",
                new double[][] {
                    new double[] {1.3, 1.62},
                    new double[] {1.81, 2.2, 2.59},
                    new double[] {2.72, 3.11, 3.5, 3.89},
                    new double[] {3.63, 4.14, 4.66, 5.18},
                    new double[] {4.53, 5.18, 5.83, 6.48}
               }
            }
        };

        // ArtifactSub -> Rarity -> Stat value -> Stat index list
        public static Dictionary<string, Dictionary<int, List<KeyValuePair<double, int[]>>>> substats_dict;

        public static int[] SplitSubstats(string type, int rarity, double value)
        {
            if (!substats_initiated)
            {
                InitSubstats();
                substats_initiated = true;
            }
            double last_stat_diff = 99999;
            int[] last_stat_list = { 4, 4, 4, 4, 4, 4 };
            foreach (KeyValuePair<double, int[]> value_to_list in substats_dict[type][rarity])
            {
                if (Math.Abs(value - value_to_list.Key) >= last_stat_diff)
                {
                    return last_stat_list;
                }
                last_stat_diff = value - value_to_list.Key;
                last_stat_list = value_to_list.Value;
            }

            // Default, should never happen
            return last_stat_list;
        }
        private static void InitSubstats()
        {
            substats_dict = new Dictionary<string, Dictionary<int, List<KeyValuePair<double, int[]>>>>();
            foreach (KeyValuePair<string, double[][]> stat_block_info in substats_rolls)
            {
                string stat_name = stat_block_info.Key;
                substats_dict[stat_name] = new Dictionary<int, List<KeyValuePair<double, int[]>>>();
                for (int rarity_index = 0; rarity_index < stat_block_info.Value.Length; rarity_index++)
                {
                    var substat_options = new List<KeyValuePair<int, double>>();
                    // Substat index == 0 means no substat upgrade
                    substat_options.Add(new KeyValuePair<int, double>(0, 0));
                    for (int substat_index = 0; substat_index < substats_rolls[stat_name][rarity_index].Length; substat_index++)
                    {
                        substat_options.Add(new KeyValuePair<int, double>(substat_index+1, substats_rolls[stat_name][rarity_index][substat_index]));
                    }

                    var substat_sum_data = (from s1 in substat_options from s2 in substat_options from s3 in substat_options from s4 in substat_options from s5 in substat_options from s6 in substat_options select new { s1, s2, s3, s4, s5, s6 })
                        .Select(x => new List<KeyValuePair<int, double>> { x.s1, x.s2, x.s3, x.s4, x.s5, x.s6 })
                        .Distinct(new SubstatSumEquality());

                    var stats_map = new List<KeyValuePair<double, int[]>>();
                    foreach (List<KeyValuePair<int, double>> val in substat_sum_data.ToArray().OrderBy(list => SubstatSumEquality.sum_substat(list)))
                    {
                        var index_list = new List<int>();
                        foreach (KeyValuePair<int, double> pair in val)
                        {
                            if (pair.Key != 0)
                                index_list.Add(pair.Key);
                        }
                        stats_map.Add(new KeyValuePair<double, int[]>(SubstatSumEquality.sum_substat(val), index_list.ToArray()));
                    }

                    substats_dict[stat_name][rarity_index + 1] = stats_map;
                }
            }
        }

        private static bool substats_initiated = false;
    }
}
