using System.Collections.Generic;
using System.Linq;

namespace GrasscutterTools.Game
{
    /// <summary>
    /// ID映射组，Key为分类，双斜杠构造
    /// </summary>
    public class ItemMapGroup : Dictionary<string, ItemMap>
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

                var category = idNamePairs.Substring(categoryLineStartIndex+2, categoryLineEndIndex - categoryLineStartIndex - 3).Trim();

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
    }
}
