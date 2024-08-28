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
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using GrasscutterTools.Game;
using GrasscutterTools.Game.Activity;
using GrasscutterTools.Game.Data;
using GrasscutterTools.Properties;

using Newtonsoft.Json;

namespace GrasscutterTools.Pages
{
    internal partial class PageTools : BasePage
    {
        public override string Text => "Tools";

        public PageTools()
        {
            InitializeComponent();
        }

        public override void OnLoad()
        {
            TxtGcResRoot.Text = Settings.Default.ResourcesDirPath;
            TxtProjectResRoot.Text = Settings.Default.ProjectResourcePath;
        }

        private void BtnUpdateResources_Click(object sender, EventArgs e)
        {
            var src = new OpenFileDialog
            {
                Title = "请选择当前原文件",
                Multiselect = false,
            };
            var dest = new OpenFileDialog
            {
                Title = "请选择包含新ID的文件",
                Multiselect = false,
            };

            if (src.ShowDialog() == DialogResult.OK && dest.ShowDialog() == DialogResult.OK)
            {
                var srcLines = File.ReadAllLines(src.FileName);
                var srcDic = new Dictionary<string, string>(srcLines.Length);
                foreach (var line in srcLines)
                {
                    var sp = line.IndexOf(':');
                    if (sp > 0)
                    {
                        var value = line.Substring(sp + 1).Trim();
                        if (!value.StartsWith("[N/A]"))
                            srcDic[line.Substring(0, sp).Trim()] = line.Substring(sp + 1).Trim();
                    }
                }

                var destLines = File.ReadAllLines(dest.FileName);
                using (var outStream = File.Create(dest.FileName))
                using (var outTxtStream = new StreamWriter(outStream))
                {
                    foreach (var line in destLines)
                    {
                        var sp = line.IndexOf(':');
                        if (sp == -1)
                        {
                            outTxtStream.WriteLine(line);
                        }
                        else
                        {
                            var key = line.Substring(0, sp).Trim();
                            if (!srcDic.TryGetValue(key, out var value))
                                value = line.Substring(sp + 1).Trim();
                            outTxtStream.WriteLine($"{key}:{value}");
                        }
                    }
                }
            }
        }

        private bool CheckInputPaths()
        {
            if (string.IsNullOrEmpty(TxtProjectResRoot.Text) || string.IsNullOrEmpty(TxtGcResRoot.Text))
            {
                MessageBox.Show("请先填写资源目录路径！", Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Directory.Exists(TxtProjectResRoot.Text) && Directory.Exists(TxtGcResRoot.Text))
            {
                Settings.Default.ResourcesDirPath = TxtGcResRoot.Text;
                Settings.Default.ProjectResourcePath = TxtProjectResRoot.Text;
                return true;
            }
            else
            {
                MessageBox.Show("请填写正确的Res路径！", Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private TextMapData TextMapData;
        private GameResources GameResources;

        private void BtnUpdateAllResources_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckInputPaths()) return;

                TextMapData ??= new TextMapData(TxtGcResRoot.Text);
                GameResources ??= new GameResources(TxtGcResRoot.Text, TextMapData);

                GameResources.ConvertResources(TxtProjectResRoot.Text);
                MessageBox.Show("OK", Resources.Tips, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdateActivity_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckInputPaths()) return;

                var json = File.ReadAllText(
                    Path.Combine(TxtGcResRoot.Text, "ExcelBinOutput", "NewActivityExcelConfigData.json"),
                    Encoding.UTF8);
                var activityItems = JsonConvert.DeserializeObject<List<NewActivityItem>>(json);

                TextMapData ??= new TextMapData(TxtGcResRoot.Text);

                // UpdateActivityForLanguage(activityItems, "TextMapCHS", "zh-cn");
                UpdateActivityForLanguage(activityItems, "TextMapCHT", "zh-tw");
                UpdateActivityForLanguage(activityItems, "TextMapEN", "en-us");
                UpdateActivityForLanguage(activityItems, "TextMapRU", "ru-ru");
                MessageBox.Show("OK", Resources.Tips, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateActivityForLanguage(IReadOnlyCollection<NewActivityItem> activityItems, string textMap, string language)
        {
            var i = Array.IndexOf(TextMapData.TextMapFiles, textMap);
            TextMapData.LoadTextMap(TextMapData.TextMapFilePaths[i]);

            var activityMap = new Dictionary<int, string>(activityItems.Count);
            foreach (var item in activityItems)
                activityMap[item.ActivityId] = TextMapData.GetText(item.NameTextMapHash);

            var buffer = new StringBuilder();
            foreach (var item in GameData.Activity)
            {
                buffer.Append("// ").AppendLine(item.Key);
                foreach (var id in item.Value.Ids)
                {
                    buffer.Append(id).Append(':');
                    buffer.AppendLine(activityMap.TryGetValue(id, out var title) ? title : item.Value[id]);
                }
            }
            var activityFilePath = Path.Combine(TxtProjectResRoot.Text, language, "Activity.txt");
            File.WriteAllText(activityFilePath, buffer.ToString(), Encoding.UTF8);

            //File.WriteAllLines(
            //    activityFilePath,
            //    activityItems.Select(it => $"{it.ActivityId}:{TextMapData.GetText(it.NameTextMapHash)}"),
            //    Encoding.UTF8);
        }



        private void UpdateGachaResourceForLanguage(string textMap, string language)
        {
            var i = Array.IndexOf(TextMapData.TextMapFiles, textMap);
            TextMapData.LoadTextMap(TextMapData.TextMapFilePaths[i]);

            var titleBuffer = new StringBuilder();
            const string titlePattern = "UI_GACHA_SHOW_PANEL_([^_]+?)_TITLE";
            const string markPattern = "<[^>]+>";

            foreach (var kv in TextMapData.ManualTextMap)
            {
                var titleId = Regex.Match(kv.Value, titlePattern);
                if (!titleId.Success) continue;
                var text = TextMapData.TextMap[kv.Key];
                titleBuffer.Append(titleId.Groups[1].Captures[0].Value)
                    .Append(":")
                    .AppendLine(Regex.Replace(text, markPattern, ""));
            }

            var titleFilePath = Path.Combine(TxtProjectResRoot.Text, language, "GachaBannerTitle.txt");
            File.WriteAllText(titleFilePath, titleBuffer.ToString(), Encoding.UTF8);

        }

        private void BtnUpdateBannerTitles_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckInputPaths()) return;

                TextMapData ??= new TextMapData(TxtGcResRoot.Text);

                UpdateGachaResourceForLanguage("TextMapCHS", "zh-cn");
                UpdateGachaResourceForLanguage("TextMapCHT", "zh-tw");
                UpdateGachaResourceForLanguage("TextMapEN", "en-us");
                UpdateGachaResourceForLanguage("TextMapRU", "ru-ru");
                MessageBox.Show("OK", Resources.Tips, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}