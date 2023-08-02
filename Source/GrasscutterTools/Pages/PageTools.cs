using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using GrasscutterTools.Game;
using GrasscutterTools.Game.Activity;
using GrasscutterTools.Game.CutScene;
using GrasscutterTools.Game.Dungeon;
using GrasscutterTools.Properties;

using Newtonsoft.Json;

namespace GrasscutterTools.Pages
{
    internal partial class PageTools : BasePage
    {
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

        private void BtnConvertCutScene_Click(object sender, EventArgs e)
        {
            var src = new OpenFileDialog
            {
                Title = "请选择 Json 格式的 Cutscene.txt",
                Multiselect = false,
            };
            if (src.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                var cutScenes = JsonConvert.DeserializeObject<List<CutSceneItem>>(File.ReadAllText(src.FileName));
                File.WriteAllLines(src.FileName, cutScenes.Select(it => $"{it.Id}:{it.Path.Substring(it.Path.IndexOf('/') + 1)}"));
                MessageBox.Show("OK", Resources.Tips, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void BtnUpdateDungeon_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckInputPaths()) return;

                var json = File.ReadAllText(
                    Path.Combine(TxtGcResRoot.Text, "ExcelBinOutput", "DungeonExcelConfigData.json"),
                    Encoding.UTF8);
                var dungeons = JsonConvert.DeserializeObject<List<DungeonItem>>(json);

                if (TextMapData == null)
                    TextMapData = new TextMapData(TxtGcResRoot.Text);

                UpdateDungeonsForLanguage(dungeons, "TextMapCHS", "zh-cn");
                UpdateDungeonsForLanguage(dungeons, "TextMapCHT", "zh-tw");
                UpdateDungeonsForLanguage(dungeons, "TextMapEN", "en-us");
                UpdateDungeonsForLanguage(dungeons, "TextMapRU", "ru-ru");
                MessageBox.Show("OK", Resources.Tips, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDungeonsForLanguage(IEnumerable<DungeonItem> dungeons, string textMap, string language)
        {
            var i = Array.IndexOf(TextMapData.TextMapFiles, textMap);
            TextMapData.LoadTextMap(TextMapData.TextMapFilePaths[i]);

            var dungeonFilePath = Path.Combine(TxtProjectResRoot.Text, language, "Dungeon.txt");
            File.WriteAllLines(
                dungeonFilePath,
                dungeons.Select(it => $"{it.Id}:{TextMapData.GetText(it.NameTextMapHash)}"),
                Encoding.UTF8);
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

                if (TextMapData == null)
                    TextMapData = new TextMapData(TxtGcResRoot.Text);

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
    }
}