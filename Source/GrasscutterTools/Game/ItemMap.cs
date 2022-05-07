using System.Collections.Generic;

namespace GrasscutterTools.Game
{
    public class ItemMap
    {
        public ItemMap(string idNamePairs)
        {
            var lines = idNamePairs.Split('\n');
            var capacity = lines.Length;
            //IdMap = new Dictionary<int, string>(capacity);
            //NameMap = new Dictionary<string, int>(capacity);
            var IdList = new List<int>(capacity);
            var NameList = new List<string>(capacity);
            var lineList = new List<string>(capacity);

            foreach (var line in lines)
            {
                var si = line.IndexOf(':');
                if (si > 0 && int.TryParse(line.Substring(0, si).Trim(), out int id))
                {
                    var name = line.Substring(si+1).Trim();
                    if (!string.IsNullOrEmpty(name))
                    {
                        //IdMap[id] = name;
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

        //Dictionary<int, string> IdMap;
        //Dictionary<string, int> NameMap;
        //List<int> IdList;
        //List<string> NameList;


        public int Count => Ids.Length;

        //public string this[int id] => IdMap[id];
        
        //public int this[string name] => NameMap[name];
        
        public int[] Ids { get; }

        public string[] Names { get; }

        public string[] Lines { get; }
    }
}
