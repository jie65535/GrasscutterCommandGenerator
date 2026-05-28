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

                // 确保使用中文UI文化加载GameData，防止ConvertResources留下的ru-ru状态
                var savedCulture = System.Threading.Thread.CurrentThread.CurrentUICulture;
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-cn");
                GameData.LoadResources();
                System.Threading.Thread.CurrentThread.CurrentUICulture = savedCulture;

                UpdateActivityForLanguage(activityItems, "zh-cn");
                UpdateActivityForLanguage(activityItems, "zh-tw");
                UpdateActivityForLanguage(activityItems, "en-us");
                UpdateActivityForLanguage(activityItems, "ru-ru");
                MessageBox.Show("OK", Resources.Tips, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateActivityForLanguage(IReadOnlyCollection<NewActivityItem> activityItems, string languageCode)
        {
            TextMapData.LoadTextMapByLanguage(languageCode);

            // 从 JSON 构建 activityId -> 翻译文本的映射
            var activityMap = new Dictionary<int, string>();
            foreach (var item in activityItems)
                activityMap[item.ActivityId] = TextMapData.GetText(item.NameTextMapHash);

            var buffer = new StringBuilder();
            var processedIds = new HashSet<int>();

            // 保持原有的分组结构（从 GameData.Activity 读取），保留人工整理的内容
            // 旧的 // New 分组跳过，统一在末尾合并输出
            foreach (var group in GameData.Activity)
            {
                if (group.Key == "New")
                {
                    foreach (var id in group.Value.Ids)
                        processedIds.Add(id);
                    continue;
                }
                buffer.Append("// ").AppendLine(group.Key);
                foreach (var id in group.Value.Ids)
                {
                    processedIds.Add(id);
                    buffer.Append(id).Append(':');
                    // 对于中文，保留人工整理的内容；对于其他语言，使用 JSON 中的官方翻译
                    if (languageCode == "zh-cn")
                        buffer.AppendLine(group.Value[id]); // 使用旧的人工整理的内容
                    else
                        buffer.AppendLine(activityMap.TryGetValue(id, out var title) ? title : group.Value[id]);
                }
            }

            // 合并旧的 // New 和 JSON 中新增的活动
            var newIds = activityItems
                .Where(item => !processedIds.Contains(item.ActivityId))
                .Select(item => item.ActivityId)
                .Concat(GameData.Activity.TryGetValue("New", out var oldNewGroup)
                    ? oldNewGroup.Ids : Enumerable.Empty<int>())
                .Distinct()
                .OrderBy(id => id)
                .ToList();
            if (newIds.Count > 0)
            {
                buffer.AppendLine("// New");
                foreach (var id in newIds)
                {
                    var name = activityMap.TryGetValue(id, out var title) ? title :
                        GameData.Activity.TryGetValue("New", out var ng) && ng[id] != ItemMap.EmptyName ? ng[id] : title;
                    buffer.Append(id).Append(':').AppendLine(name);
                }
            }

            var activityFilePath = Path.Combine(TxtProjectResRoot.Text, languageCode, "Activity.txt");
            File.WriteAllText(activityFilePath, buffer.ToString(), Encoding.UTF8);
        }



        private void UpdateGachaResourceForLanguage(string languageCode)
        {
            TextMapData.LoadTextMapByLanguage(languageCode);

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

            var titleFilePath = Path.Combine(TxtProjectResRoot.Text, languageCode, "GachaBannerTitle.txt");
            File.WriteAllText(titleFilePath, titleBuffer.ToString(), Encoding.UTF8);

        }

        private void BtnUpdateBannerTitles_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckInputPaths()) return;

                TextMapData ??= new TextMapData(TxtGcResRoot.Text);

                UpdateGachaResourceForLanguage("zh-cn");
                UpdateGachaResourceForLanguage("zh-tw");
                UpdateGachaResourceForLanguage("en-us");
                UpdateGachaResourceForLanguage("ru-ru");
                MessageBox.Show("OK", Resources.Tips, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}