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
using System.IO;
using System.Linq;

using Newtonsoft.Json;

namespace GrasscutterTools.Game
{
    internal class TextMapData
    {
        public TextMapData(string resourcesDirPath)
        {
            LoadManualTextMap(Path.Combine(resourcesDirPath, "ExcelBinOutput", "ManualTextMapConfigData.json"));
            LoadTextMaps(Path.Combine(resourcesDirPath, "TextMap"));
            LoadTextMap(TextMapFilePaths[Array.IndexOf(TextMapFiles, "TextMapCHS")]);
            DefaultTextMap = TextMap;
        }

        public Dictionary<string, string> ManualTextMap;
        public Dictionary<string, string> DefaultTextMap;
        public Dictionary<string, string> TextMap;
        public string[] TextMapFilePaths;
        public string[] TextMapFiles;

        private void LoadManualTextMap(string manualTextMapPath)
        {
            if (!File.Exists(manualTextMapPath)) return;

            using (var fs = File.OpenRead(manualTextMapPath))
            using (var sr = new StreamReader(fs))
            using (var reader = new JsonTextReader(sr))
            {
                ManualTextMap = new Dictionary<string, string>();
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.PropertyName && ((string)reader.Value == "TextMapId" || (string)reader.Value == "textMapId"))
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

        public bool Contains(string textMapPath) => TextMap.ContainsKey(textMapPath) || DefaultTextMap.ContainsKey(textMapPath);

        public string GetText(string textMapHash)
        {
            return TextMap.TryGetValue(textMapHash, out var text) ? text
                : DefaultTextMap.TryGetValue(textMapHash, out text) ? "[CHS] - " + text
                : "[N/A] " + textMapHash;
        }

        public bool TryGetText(string textMapHash, out string text)
        {
            if (TextMap.TryGetValue(textMapHash, out text))
            {
                return true;
            }

            if (DefaultTextMap.TryGetValue(textMapHash, out text))
            {
                text = "[CHS] - " + text;
                return true;
            }

            text = "[N/A] " + textMapHash;
            return false;
        }
    }
}