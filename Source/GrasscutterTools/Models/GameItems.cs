using System;
using System.Collections.ObjectModel;

namespace GrasscutterTools.Models
{
    public class GameItems : Collection<GameItem>
    {
        public GameItems(string sources)
        {
            var lines = sources.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var category = string.Empty;
            foreach (var line in lines)
            {
                if (line.StartsWith("//"))
                {
                    category = line.Substring(2).Trim().Replace('_', ' ').ToLowerInvariant();
                    category = char.ToUpperInvariant(category[0]) + category.Substring(1);
                }
                else
                {
                    var sp = line.IndexOf(':');
                    if (sp >= 0)
                    {
                        Items.Add(new GameItem
                        {
                            Id = int.Parse(line.Substring(0, sp).Trim()),
                            Name = line.Substring(sp + 1).Trim(),
                            Category = category
                        });
                    }
                }
            }
        }
    }
}
