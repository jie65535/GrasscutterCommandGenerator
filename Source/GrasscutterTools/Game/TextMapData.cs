using System.Collections.Generic;
using System.IO;
using System.Linq;

using Newtonsoft.Json;

namespace GrasscutterTools.Game
{
    public class TextMapData
    {
        public TextMapData(string resourcesDirPath)
        {
            LoadManualTextMap(Path.Combine(resourcesDirPath, "ExcelBinOutput", "ManualTextMapConfigData.json"));
            LoadTextMaps(Path.Combine(resourcesDirPath, "TextMap"));
        }

        public Dictionary<string, string> ManualTextMap;
        public Dictionary<string, string> TextMap;
        public string[] TextMapFilePaths;
        public string[] TextMapFiles;

        private void LoadManualTextMap(string manualTextMapPath)
        {
            using (var fs = File.OpenRead(manualTextMapPath))
            using (var sr = new StreamReader(fs))
            using (var reader = new JsonTextReader(sr))
            {
                ManualTextMap = new Dictionary<string, string>();
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.PropertyName && (string)reader.Value == "TextMapId")
                    {
                        var textMapId = reader.ReadAsString();
                        reader.Read();
                        ManualTextMap.Add(reader.ReadAsString(), textMapId);
                    }
                }
            }
        }

        private void LoadTextMaps(string textMapDirPath)
        {
            TextMapFilePaths = Directory.GetFiles(textMapDirPath, "TextMap*.json");
            if (TextMapFilePaths.Length == 0)
                throw new FileNotFoundException("TextMap*.json Not Found");
            TextMapFiles = TextMapFilePaths.Select(n => Path.GetFileNameWithoutExtension(n)).ToArray();
        }

        public void LoadTextMap(string textMapPath)
        {
            using (var fs = File.OpenRead(textMapPath))
            using (var sr = new StreamReader(fs))
            using (var reader = new JsonTextReader(sr))
            {
                TextMap = new Dictionary<string, string>();
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.PropertyName)
                    {
                        TextMap.Add((string)reader.Value, reader.ReadAsString());
                    }
                }
            }
        }
    }
}