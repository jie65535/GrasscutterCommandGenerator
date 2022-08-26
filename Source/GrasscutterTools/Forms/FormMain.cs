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
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using GrasscutterTools.DispatchServer;
using GrasscutterTools.Game;
using GrasscutterTools.GOOD;
using GrasscutterTools.OpenCommand;
using GrasscutterTools.Properties;
using GrasscutterTools.Utils;

using Newtonsoft.Json;

namespace GrasscutterTools.Forms
{
    public partial class FormMain : Form
    {
        #region - 初始化 -

        public FormMain()
        {
            InitializeComponent();
            Icon = Resources.IconGrasscutter;
            LoadVersion();
            LoadSettings();
            LoadUpdate();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            MultiLanguage.LoadLanguage(this, typeof(FormMain));
#if DEBUG
            Text += "  - by jie65535  - v" + AppVersion.ToString(3) + "-debug";
#else
            Text += "  - by jie65535  - v" + AppVersion.ToString(3);
#endif

            GameData.LoadResources();

            LoadCustomCommands();
            InitArtifactList();
            InitGameItemList();
            InitWeapons();
            InitAvatars();
            InitEntityList();
            InitScenes();
            InitStatList();
            InitPermList();
            InitQuestList();

            ChangeTPArtifact();
            ChangeBtnGiveAllChar();

        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSettings();
        }

        private readonly string[] LanguageNames = new string[] { "简体中文", "繁體中文", "English", "Русский" };
        private readonly string[] Languages = new string[] { "zh-CN", "zh-TW", "en-US", "ru-RU" };


        private Version AppVersion;
        private void LoadVersion()
        {
            AppVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
        }

        private void LoadSettings()
        {
            try
            {
                ChkAutoCopy.Checked       = Settings.Default.AutoCopy;
                NUDUid.Value              = Settings.Default.Uid;
                ChkTopMost.Checked        = Settings.Default.IsTopMost;
                ChkNewCommand.Checked     = Settings.Default.CommandVersion == "1.2.2";

                CmbLanguage.Items.AddRange(LanguageNames);
                CmbLanguage.SelectedIndex = Array.IndexOf(Languages, Settings.Default.DefaultLanguage);


                InitGiveItemRecord();
                InitSpawnRecord();
                InitOpenCommand();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resources.SettingLoadError + ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveSettings()
        {
            try
            {
                Settings.Default.AutoCopy  = ChkAutoCopy.Checked;
                Settings.Default.Uid       = NUDUid.Value;
                Settings.Default.IsTopMost = ChkTopMost.Checked;
                Settings.Default.CommandVersion = ChkNewCommand.Checked ? "1.2.2" : string.Empty;
                SaveCustomCommands();
                SaveGiveItemRecord();
                SaveSpawnRecord();
                SaveOpenCommand();
                Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resources.SettingSaveError + ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUpdate()
        {
#if !DEBUG
            Task.Run(async () =>
            {
                try
                {
                    await Task.Delay(5000);
                    var info = await ReleaseAPI.GetReleasesLastest("jie65535", "GrasscutterCommandGenerator");
                    if (Version.TryParse(info.TagName.Substring(1), out Version lastestVersion) && AppVersion < lastestVersion)
                    {
                        if (!string.IsNullOrEmpty(Settings.Default.CheckedLastVersion)
                            && Version.TryParse(Settings.Default.CheckedLastVersion, out Version checkedVersion)
                            && checkedVersion >= lastestVersion)
                            return;
                        BeginInvoke(new Action(() =>
                        {
                            var r = MessageBox.Show(
                                string.Format(Resources.NewVersionInfo, info.Name, info.CraeteTime.ToLocalTime(), info.Body),
                                Resources.CheckToNewVersion,
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information);
                            if (r == DialogResult.Yes)
                                OpenURL(info.Url);
                            else if (r == DialogResult.No)
                                Settings.Default.CheckedLastVersion = lastestVersion.ToString();
                        }));
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            });
#endif
        }

        #endregion - 初始化 -

        #region - 主页 -

        private Form GachaBannerEditor;

        private void BtnOpenGachaBannerEditor_Click(object sender, EventArgs e)
        {
            if (GachaBannerEditor == null || GachaBannerEditor.IsDisposed)
            {
                GachaBannerEditor = new FormGachaBannerEditor2();
                GachaBannerEditor.Show();
            }
            else
            {
                GachaBannerEditor.TopMost = true;
                GachaBannerEditor.TopMost = false;
            }
        }

        private FormTextMapBrowser TextMapBrowser;

        private void BtnOpenTextMap_Click(object sender, EventArgs e)
        {
            if (TextMapBrowser == null || TextMapBrowser.IsDisposed)
            {
                TextMapBrowser = new FormTextMapBrowser();
                TextMapBrowser.Show();
            }
            else
            {
                TextMapBrowser.TopMost = true;
                TextMapBrowser.TopMost = false;
            }
        }
        async private void ButtonOpenGOODImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Filter = "GOOD file (*.GOOD;*.json)|*.GOOD;*.json|All files (*.*)|*.*",
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (DialogResult.Yes != MessageBox.Show(Resources.GOODImportText + openFileDialog1.FileName + "?",
                    Resources.GOODImportTitle, MessageBoxButtons.YesNo))
                    return;
                try
                {
                    GOOD.GOOD good = JsonConvert.DeserializeObject<GOOD.GOOD>(File.ReadAllText(openFileDialog1.FileName));
                    var commands_list = new List<string>();
                    var missingItems = new List<string>();

                    if (good.Characters != null)
                    {
                        foreach (var character in good.Characters)
                        {
                            if (character.Name != "Traveler")
                            {
                                if (GOODData.Avatars.TryGetValue(character.Name, out var character_id))
                                    commands_list.Add("/give " + character_id + " lv" + character.Level + "c" + character.Constellation);
                                else
                                    missingItems.Add(character.Name);
                                // TODO: Implement command to set talent level when giving character in Grasscutter
                            }
                        }
                    }

                    if (good.Weapons != null)
                    {
                        foreach (var weapon in good.Weapons)
                        {
                            if (GOODData.Weapons.TryGetValue(weapon.Name, out var weapon_id))
                                commands_list.Add("/give " + weapon_id + " lv" + weapon.Level + "r" + weapon.RefinementLevel);
                            else
                                missingItems.Add(weapon.Name);
                            // TODO: Implement command to give weapon directly to character in Grasscutter
                        }
                    }

                    if (good.Artifacts != null)
                    {
                        foreach (var artifact in good.Artifacts)
                        {
                            // Format: set rarity slot 
                            if (!GOODData.ArtifactCats.TryGetValue(artifact.SetName, out var artifact_set_id))
                            {
                                missingItems.Add(artifact.SetName);
                                continue;
                            }
                            var artifact_id = artifact_set_id.ToString() + artifact.Rarity.ToString() + GOODData.ArtifactSlotMap[artifact.GearSlot] + "4";
                            var artifact_mainStat_id = GOODData.ArtifactMainAttribution[artifact.MainStat];
                            var artifact_substats = "";
                            var artifact_substat_prefix = artifact.Rarity + "0";
                            int substat_count = 0;
                            foreach (var substat in artifact.SubStats)
                            {
                                if (substat.Value <= 0)
                                    continue;
                                substat_count++;
                                var substat_key = substat.Stat;
                                var substat_key_id = GOODData.ArtifactSubAttribution[substat_key];
                                var substat_indices = ArtifactUtils.SplitSubstats(substat_key, artifact.Rarity, substat.Value);

                                foreach (int index in substat_indices)
                                {
                                    artifact_substats += artifact_substat_prefix + substat_key_id + index.ToString() + " ";
                                }
                            }

                            // HACK: Add def+2 substat to counteract Grasscutter automatically adding another substat
                            if (substat_count == 4)
                                artifact_substats += "101081 ";
                            commands_list.Add("/give " + artifact_id + " lv" + artifact.Level + " " + artifact_mainStat_id + " " + artifact_substats);
                            // TODO: Implement command to give artifact directly to character in Grasscutter
                        }
                    }

                    // TODO: Materials
                    //if (good.Materials != null)
                    //{
                    //    foreach (var material in good.Materials)
                    //    {

                    //    }
                    //}

                    var msg = string.Format("Loaded {0} Characters\nLoaded {1} Weapons\nLoaded {2} Artifacts\n",
                        good.Characters?.Count ?? 0,
                        good.Weapons?.Count ?? 0,
                        good.Artifacts?.Count ?? 0
                        );
                    if (missingItems.Count > 0)
                    {
                        msg += string.Format("There are {0} pieces of data that cannot be parsed, including:\n{1}",
                            missingItems.Count,
                            string.Join("\n", missingItems.Take(10)));
                        if (missingItems.Count > 10)
                            msg += "......";
                    }
                    msg += "Do you want to start?";

                    if (DialogResult.Yes != MessageBox.Show(msg, Resources.Tips, MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                        return;


                    if (await RunCommands(commands_list.ToArray()))
                        MessageBox.Show(Resources.GOODImportSuccess);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            MultiLanguage.SetDefaultLanguage(Languages[CmbLanguage.SelectedIndex]);
            FormMain_Load(this, EventArgs.Empty);
        }

        private void ChkTopMost_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = ChkTopMost.Checked;
        }

        private void ChkNewCommand_CheckedChanged(object sender, EventArgs e)
        {
            ChangeTPArtifact();
            ChangeBtnGiveAllChar();
        }

        #endregion - 主页 -

        #region - 自定义 -

        private readonly string CustomCommandsFilePath = Path.Combine(Application.LocalUserAppDataPath, "CustomCommands.txt");

        private bool CustomCommandsChanged;

        private void LoadCustomCommands()
        {
            if (File.Exists(CustomCommandsFilePath))
                LoadCustomCommandControls(File.ReadAllText(CustomCommandsFilePath));
            else
                LoadCustomCommandControls(Resources.CustomCommands);
        }

        private void LoadCustomCommandControls(string commands)
        {
            FLPCustomCommands.Controls.Clear();
            var lines = commands.Split('\n');
            for (int i = 0; i < lines.Length - 1; i += 2)
                AddCustomCommand(lines[i].Trim(), lines[i + 1].Trim());
        }

        private void SaveCustomCommands()
        {
            if (CustomCommandsChanged)
                File.WriteAllText(CustomCommandsFilePath, SaveCustomCommandControls());
        }

        private string SaveCustomCommandControls()
        {
            StringBuilder builder = new StringBuilder();
            foreach (LinkLabel lnk in FLPCustomCommands.Controls)
            {
                builder.AppendLine(lnk.Text);
                builder.AppendLine(lnk.Tag as string);
            }
            return builder.ToString();
        }

        private void CustomCommand_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (sender is LinkLabel lnk && lnk.Tag is string command)
            {
                TxtCustomName.Text = lnk.Text;
                SetCommand(command);
            }
        }

        private async void BtnSaveCustomCommand_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtCustomName.Text))
            {
                MessageBox.Show(Resources.CommandTagCannotBeEmpty, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(TxtCommand.Text))
            {
                MessageBox.Show(Resources.CommandContentCannotBeEmpty, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var name = TxtCustomName.Text.Trim();
            var command = TxtCommand.Text.Trim();

            foreach (LinkLabel lnk in FLPCustomCommands.Controls)
            {
                if (lnk.Text == name)
                {
                    lnk.Tag = command;
                    CustomCommandsChanged = true;
                    await ButtonComplete(BtnSaveCustomCommand);
                    return;
                }
            }

            CustomCommandsChanged = true;
            AddCustomCommand(name, command);
            await ButtonComplete(BtnSaveCustomCommand);
        }

        private void AddCustomCommand(string name, string command)
        {
            var lnk = new LinkLabel
            {
                Text = name,
                Tag = command,
                AutoSize = true,
            };
            lnk.LinkClicked += CustomCommand_Click;
            FLPCustomCommands.Controls.Add(lnk);
        }

        private async void BtnRemoveCustomCommand_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtCustomName.Text))
            {
                MessageBox.Show(Resources.CommandTagCannotBeEmpty, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var name = TxtCustomName.Text.Trim();

            foreach (LinkLabel lnk in FLPCustomCommands.Controls)
            {
                if (lnk.Text == name && MessageBox.Show(Resources.AskConfirmDeletion, Resources.Tips, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    FLPCustomCommands.Controls.Remove(lnk);
                    CustomCommandsChanged = true;
                    //TxtCustomName.Text = "";
                    //TxtCommand.Text = "";
                    await ButtonComplete(BtnRemoveCustomCommand);
                    return;
                }
            }

            MessageBox.Show(Resources.CommandNotFound, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (var stream = dialog.OpenFile())
                using (var reader = new StreamReader(stream))
                {
                    LoadCustomCommandControls(reader.ReadToEnd());
                    CustomCommandsChanged = true;
                }
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                FileName = "Commands.txt",
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (var stream = dialog.OpenFile())
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(SaveCustomCommandControls());
                }
            }
        }

        private void LnkResetCustomCommands_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show(Resources.RestoreCustomCommands, Resources.Tips, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (File.Exists(CustomCommandsFilePath))
                    File.Delete(CustomCommandsFilePath);
                LoadCustomCommandControls(Resources.CustomCommands);
            }
        }

        #endregion - 自定义 -

        #region - 圣遗物 -

        private Dictionary<string, List<KeyValuePair<int, string>>> subAttrs;

        private string[] ArtifactPartLabels;

        private void InitArtifactList()
        {
            CmbArtifactSet.Items.Clear();
            CmbArtifactSet.Items.AddRange(GameData.ArtifactCats.Names);
            CmbMainAttribution.Items.Clear();
            CmbMainAttribution.Items.AddRange(GameData.ArtifactMainAttribution.Lines);

            subAttrs = new Dictionary<string, List<KeyValuePair<int, string>>>();
            for (int i = 0; i < GameData.ArtifactSubAttribution.Count; i++)
            {
                var name = GameData.ArtifactSubAttribution.Names[i];
                var pi = name.IndexOf('+');
                var prefix = name.Substring(0, pi);
                var value = name.Substring(pi);
                if (!subAttrs.TryGetValue(prefix, out List<KeyValuePair<int, string>> list))
                {
                    list = new List<KeyValuePair<int, string>>();
                    subAttrs[prefix] = list;
                }
                list.Add(new KeyValuePair<int, string>(GameData.ArtifactSubAttribution.Ids[i], value));
            }
            CmbSubAttribution.Items.Clear();
            CmbSubAttribution.Items.AddRange(subAttrs.Keys.ToArray());

            ArtifactPartLabels = Resources.ArtifactPartLabels.Split(',');
        }

        private void CmbSubAttribution_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbSubAttributionValue.Items.Clear();
            if (CmbSubAttribution.SelectedIndex >= 0)
            {
                CmbSubAttributionValue.Items.AddRange(subAttrs[CmbSubAttribution.SelectedItem as string].Select(kv => kv.Value).ToArray());
                CmbSubAttributionValue.SelectedIndex = 0;
            }
        }

        private void BtnAddSubAttr_Click(object sender, EventArgs e)
        {
            if (CmbSubAttribution.SelectedIndex >= 0 && CmbSubAttributionValue.SelectedIndex >= 0)
            {
                var name = CmbSubAttribution.SelectedItem as string;
                var kv = subAttrs[name][CmbSubAttributionValue.SelectedIndex];
                ListSubAttributionChecked.Items.Add($"{kv.Key}:{name}{kv.Value} x{NUDSubAttributionTimes.Value}");
                ArtifactInputChanged(null, EventArgs.Empty);
            }
        }

        private void CmbArtifactSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbArtifactSet.SelectedIndex < 0)
                return;
            var setId = GameData.ArtifactCats.Ids[CmbArtifactSet.SelectedIndex];
            var beginIndex = Array.FindIndex(GameData.Artifacts.Ids, id => id / 1000 == setId);
            var endIndex = Array.FindLastIndex(GameData.Artifacts.Ids, id => id / 1000 == setId);

            // 限制星级输入范围
            NUDArtifactStars.Minimum = GameData.Artifacts.Ids[beginIndex] / 100 % 10;
            NUDArtifactStars.Maximum = GameData.Artifacts.Ids[endIndex] / 100 % 10;

            var parts = GameData.Artifacts.Names.Skip(beginIndex).Take(endIndex - beginIndex + 1).Distinct().ToArray();
            var i = CmbArtifactPart.SelectedIndex;
            CmbArtifactPart.Items.Clear();
            CmbArtifactPart.Items.AddRange(parts);
            if (i < parts.Length) // 重新选中
                CmbArtifactPart.SelectedIndex = i;

            ArtifactInputChanged(sender, e);
        }

        private void CmbArtifactPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbArtifactPart.SelectedIndex < 0)
            {
                LblArtifactName.Text = "";
                return;
            }
            var name = CmbArtifactPart.SelectedItem as string;
            var id = GameData.Artifacts.Ids[Array.IndexOf(GameData.Artifacts.Names, name)];
            var pardIndex = id / 10 % 10 - 1;
            if (pardIndex < ArtifactPartLabels?.Length)
                LblArtifactName.Text = ArtifactPartLabels[pardIndex];
            else
                LblArtifactName.Text = "";
            ArtifactInputChanged(sender, e);
        }

        private void ArtifactInputChanged(object sender, EventArgs e)
        {
            // 圣遗物ID五位数，ABCDE，其中AB是圣遗物类型（魔女/水/风套......）
            // C是星级（5就是五星），D是圣遗物部位，E是初始词条数量
            if (CmbArtifactSet.SelectedIndex < 0 || CmbArtifactPart.SelectedIndex < 0)
                return;
            //var setId = GameData.ArtifactCats.Ids[CmbArtifactSet.SelectedIndex];
            //var part = CmbArtifactPart.SelectedIndex+1;
            //var index = Array.FindLastIndex(
            //    GameData.Artifacts.Ids,
            //    it =>  it / 1000     == setId // 套装ID
            //        //&& it / 100 % 10 == NUDArtifactStars.Value // 星级
            //        && it / 10 % 10  == part // 部位
            //    );
            var name = CmbArtifactPart.SelectedItem as string;
            var id = GameData.Artifacts.Ids[Array.LastIndexOf(GameData.Artifacts.Names, name)];
            id = id / 1000 * 1000 + (int)NUDArtifactStars.Value * 100 + id % 100;
            if (CmbMainAttribution.SelectedIndex < 0)
            {
                if (ChkNewCommand.Checked)
                    SetCommand("/give", $"{id} lv{NUDArtifactLevel.Value}");
                else
                    SetCommand("/giveart", $"{id} {NUDArtifactLevel.Value}");
            }
            else
            {
                var t = CmbMainAttribution.SelectedItem as string;
                var mainAttr = t.Substring(0, t.IndexOf(':')).Trim();

                var subAttrs = "";
                if (ListSubAttributionChecked.Items.Count > 0)
                {
                    var subAttrDir = new Dictionary<string, int>(ListSubAttributionChecked.Items.Count);
                    foreach (string item in ListSubAttributionChecked.Items)
                    {
                        var subId = item.Substring(0, item.IndexOf(':')).Trim();
                        var times = int.Parse(item.Substring(item.LastIndexOf('x') + 1));
                        if (subAttrDir.ContainsKey(subId))
                            subAttrDir[subId] += times;
                        else
                            subAttrDir[subId] = times;
                    }

                    foreach (var kv in subAttrDir)
                    {
                        if (kv.Value > 1)
                            subAttrs += $"{kv.Key},{kv.Value} ";
                        else
                            subAttrs += $"{kv.Key} ";
                    }
                }
                if (ChkNewCommand.Checked)
                    SetCommand("/give", $"{id} lv{NUDArtifactLevel.Value} {mainAttr} {subAttrs}");
                else
                    SetCommand("/giveart", $"{id} {mainAttr} {subAttrs}{NUDArtifactLevel.Value}");
            }
        }

        private void ListSubAttributionChecked_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListSubAttributionChecked.SelectedIndex >= 0)
            {
                ListSubAttributionChecked.Items.RemoveAt(ListSubAttributionChecked.SelectedIndex);
                ListSubAttributionChecked.ClearSelected();
                ArtifactInputChanged(null, EventArgs.Empty);
            }
        }

        private void LblClearSubAttrCheckedList_Click(object sender, EventArgs e)
        {
            CmbMainAttribution.SelectedIndex = -1;
            ListSubAttributionChecked.Items.Clear();
            ArtifactInputChanged(null, EventArgs.Empty);
        }

        private void ChangeTPArtifact()
        {
            if (ChkNewCommand.Checked)
            {
                NUDArtifactLevel.Minimum = 0;
                NUDArtifactLevel.Maximum = 20;
            }
            else
            {
                NUDArtifactLevel.Minimum = 1;
                NUDArtifactLevel.Maximum = 21;
            }
            LblArtifactLevelTip.Text = $"[{NUDArtifactLevel.Minimum}-{NUDArtifactLevel.Maximum}]";
        }

        #endregion - 圣遗物 -

        #region - 武器 -

        private void InitWeapons()
        {
            ListWeapons.Items.Clear();
            ListWeapons.Items.AddRange(GameData.Weapons.Lines);
        }

        private void TxtWeaponFilter_TextChanged(object sender, EventArgs e)
        {
            var filter = TxtWeaponFilter.Text.Trim();
            ListWeapons.BeginUpdate();
            ListWeapons.Items.Clear();
            ListWeapons.Items.AddRange(GameData.Weapons.Lines.Where(n => n.Contains(filter)).ToArray());
            ListWeapons.EndUpdate();
        }

        private void WeaponValueChanged(object sender, EventArgs e)
        {
            var name = ListWeapons.SelectedItem as string;
            if (!string.IsNullOrEmpty(name))
            {
                var id = name.Substring(0, name.IndexOf(':')).Trim();
                if (ChkNewCommand.Checked)
                    SetCommand("/give", $"{id} x{NUDWeaponAmout.Value} lv{NUDWeaponLevel.Value} r{NUDWeaponRefinement.Value}");
                else
                    SetCommand("/give", $"{id} {NUDWeaponAmout.Value} {NUDWeaponLevel.Value} {NUDWeaponRefinement.Value}");
            }
        }

        #endregion - 武器 -

        #region - 物品 -

        private void InitGameItemList()
        {
            ListGameItems.Items.Clear();
            ListGameItems.Items.AddRange(GameData.Items.Lines);
        }

        private void TxtGameItemFilter_TextChanged(object sender, EventArgs e)
        {
            var filter = TxtGameItemFilter.Text.Trim();
            ListGameItems.BeginUpdate();
            ListGameItems.Items.Clear();
            ListGameItems.Items.AddRange(GameData.Items.Lines.Where(n => n.Contains(filter)).ToArray());
            ListGameItems.EndUpdate();
        }

        private bool GenGiveItemCommand()
        {
            var name = ListGameItems.SelectedItem as string;
            if (!string.IsNullOrEmpty(name))
            {
                var id = name.Substring(0, name.IndexOf(':')).Trim();

                if (ChkDrop.Checked)
                {
                    NUDGameItemLevel.Enabled = false;
                    SetCommand("/drop", $"{id} {NUDGameItemAmout.Value}");
                }
                else
                {
                    NUDGameItemLevel.Enabled = true;
                    if (ChkNewCommand.Checked)
                        SetCommand("/give", $"{id} x{NUDGameItemAmout.Value} lv{NUDGameItemLevel.Value}");
                    else
                        SetCommand("/give", $"{id} {NUDGameItemAmout.Value} {NUDGameItemLevel.Value}");
                }
                return true;
            }
            return false;
        }

        private void GiveItemsInputChanged(object sender, EventArgs e)
        {
            GenGiveItemCommand();
        }

        #region -- 物品记录 --

        private readonly string GiveItemCommandsRecordPath = Path.Combine(Application.LocalUserAppDataPath, "GiveItemCommands.txt");
        private List<GameCommand> GiveItemCommands;

        private void InitGiveItemRecord()
        {
            if (File.Exists(GiveItemCommandsRecordPath))
            {
                GiveItemCommands = GetCommands(File.ReadAllText(GiveItemCommandsRecordPath));
                ListGiveItemLogs.Items.AddRange(GiveItemCommands.Select(c => c.Name).ToArray());
            }
            else
            {
                GiveItemCommands = new List<GameCommand>();
            }
        }

        private void SaveGiveItemRecord()
        {
            File.WriteAllText(GiveItemCommandsRecordPath, GetCommandsText(GiveItemCommands));
        }

        private void ListGiveItemLogs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListGiveItemLogs.SelectedIndex >= 0)
            {
                BtnRemoveGiveItemLog.Enabled = true;
                SetCommand(GiveItemCommands[ListGiveItemLogs.SelectedIndex].Command);
            }
            else
            {
                BtnRemoveGiveItemLog.Enabled = false;
            }
        }

        private void BtnSaveGiveItemLog_Click(object sender, EventArgs e)
        {
            if (GenGiveItemCommand())
            {
                var cmd = new GameCommand($"{ListGameItems.SelectedItem} x{NUDGameItemAmout.Value}", TxtCommand.Text);
                GiveItemCommands.Add(cmd);
                ListGiveItemLogs.Items.Add(cmd.Name);
            }
        }

        private void BtnRemoveGiveItemLog_Click(object sender, EventArgs e)
        {
            if (ListGiveItemLogs.SelectedIndex >= 0)
            {
                GiveItemCommands.RemoveAt(ListGiveItemLogs.SelectedIndex);
                ListGiveItemLogs.Items.RemoveAt(ListGiveItemLogs.SelectedIndex);
            }
        }

        private void LblClearGiveItemLogs_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Resources.AskConfirmDeletion, Resources.Tips, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                GiveItemCommands.Clear();
                ListGiveItemLogs.Items.Clear();
            }
        }

        #endregion -- 物品记录 --

        #endregion - 物品 -

        #region - 角色 -

        private void InitAvatars()
        {
            CmbAvatar.Items.Clear();
            CmbAvatar.Items.AddRange(GameData.Avatars.Names);
        }

        private void CmbAvatar_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: Load Avatar Image
            AvatarInputChanged();
        }

        private void NUDAvatarLevel_ValueChanged(object sender, EventArgs e)
        {
            AvatarInputChanged();
        }

        private void AvatarInputChanged()
        {
            if (CmbAvatar.SelectedIndex >= 0)
                GenAvatar((int)NUDAvatarLevel.Value);
        }

        private void GenAvatar(int level)
        {
            if (ChkNewCommand.Checked)
            {
                int avatarId = GameData.Avatars.Ids[CmbAvatar.SelectedIndex];
                SetCommand("/give", $"{avatarId} lv{level}");
            }
            else
            {
                int avatarId = GameData.Avatars.Ids[CmbAvatar.SelectedIndex] - 1000 + 10000000;
                SetCommand("/givechar", $"{avatarId} {level}");
            }
        }

        private void BtnGiveAllChar_Click(object sender, EventArgs e)
        {
            var level = NUDAvatarLevel.Value;
            var constellation = NUDAvatarConstellation.Value;
            SetCommand("/give avatars", $"lv{level} c{constellation}");
        }

        private void ChangeBtnGiveAllChar()
        {
            if (ChkNewCommand.Checked)
                BtnGiveAllChar.Enabled = true;
            else
                BtnGiveAllChar.Enabled = false;
        }

        #endregion - 角色 -

        #region - 生成 -

        private void InitEntityList()
        {
            RbEntityAnimal.Tag = GameData.Animals.Lines;
            RbEntityMonster.Tag = GameData.Monsters.Lines;
            RbEntityNPC.Tag = GameData.NPCs.Lines;
            RbEntityAnimal.Checked = true;
            LoadEntityList();
        }
        private void LoadEntityList()
        {
            var rb = RbEntityAnimal.Checked ? RbEntityAnimal :
                    RbEntityMonster.Checked ? RbEntityMonster :
                    RbEntityNPC;
            if (rb.Checked)
            {
                ListEntity.BeginUpdate();
                ListEntity.Items.Clear();
                ListEntity.Items.AddRange(rb.Tag as string[]);
                ListEntity.EndUpdate();
            }
        }

        private void TxtEntityFilter_TextChanged(object sender, EventArgs e)
        {
            var filter = TxtEntityFilter.Text.Trim();
            var rb = RbEntityAnimal.Checked ? RbEntityAnimal :
                    RbEntityMonster.Checked ? RbEntityMonster :
                    RbEntityNPC;
            var data = rb.Tag as string[];
            ListEntity.BeginUpdate();
            ListEntity.Items.Clear();
            ListEntity.Items.AddRange(data.Where(n => n.Contains(filter)).ToArray());
            ListEntity.EndUpdate();
        }

        private bool GenSpawnEntityCommand()
        {
            var selectedItem = ListEntity.SelectedItem as string;
            if (!string.IsNullOrEmpty(selectedItem))
            {
                var id = selectedItem.Substring(0, selectedItem.IndexOf(':')).Trim();
                SetCommand("/spawn", $"{id} {NUDEntityAmout.Value} {NUDEntityLevel.Value}");
                return true;
            }
            return false;
        }

        private void SpawnEntityInputChanged(object sender, EventArgs e)
        {
            GenSpawnEntityCommand();
        }

        private void RbEntity_CheckedChanged(object sender, EventArgs e)
        {
            LoadEntityList();
        }

        #region -- 生成记录 --

        private readonly string SpawnCommandsRecordPath = Path.Combine(Application.LocalUserAppDataPath, "SpawnCommands.txt");
        private List<GameCommand> SpawnCommands;

        private void InitSpawnRecord()
        {
            if (File.Exists(SpawnCommandsRecordPath))
            {
                SpawnCommands = GetCommands(File.ReadAllText(SpawnCommandsRecordPath));
                ListSpawnLogs.Items.AddRange(SpawnCommands.Select(c => c.Name).ToArray());
            }
            else
            {
                SpawnCommands = new List<GameCommand>();
            }
        }

        private void SaveSpawnRecord()
        {
            File.WriteAllText(SpawnCommandsRecordPath, GetCommandsText(SpawnCommands));
        }

        private void ListSpawnLogs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListSpawnLogs.SelectedIndex >= 0)
            {
                BtnRemoveSpawnLog.Enabled = true;
                SetCommand(SpawnCommands[ListSpawnLogs.SelectedIndex].Command);
            }
            else
            {
                BtnRemoveSpawnLog.Enabled = false;
            }
        }

        private void BtnSaveSpawnLog_Click(object sender, EventArgs e)
        {
            if (GenSpawnEntityCommand())
            {
                var cmd = new GameCommand($"{ListEntity.SelectedItem} Lv{NUDEntityLevel.Value} x{NUDEntityAmout.Value}", TxtCommand.Text);
                SpawnCommands.Add(cmd);
                ListSpawnLogs.Items.Add(cmd.Name);
            }
        }

        private void BtnRemoveSpawnLog_Click(object sender, EventArgs e)
        {
            if (ListSpawnLogs.SelectedIndex >= 0)
            {
                SpawnCommands.RemoveAt(ListSpawnLogs.SelectedIndex);
                ListSpawnLogs.Items.RemoveAt(ListSpawnLogs.SelectedIndex);
            }
        }

        private void LblClearSpawnLogs_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Resources.AskConfirmDeletion, Resources.Tips, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SpawnCommands.Clear();
                ListSpawnLogs.Items.Clear();
            }
        }

        #endregion -- 生成记录 --

        #endregion - 生成 -

        #region - 场景 -

        private void InitScenes()
        {
            ListScenes.Items.Clear();
            ListScenes.Items.AddRange(GameData.Scenes.Lines);

            CmbClimateType.Items.Clear();
            CmbClimateType.Items.AddRange(Resources.ClimateType.Split(','));
        }

        private void TxtSceneFilter_TextChanged(object sender, EventArgs e)
        {
            var filter = TxtSceneFilter.Text.Trim();
            ListScenes.BeginUpdate();
            ListScenes.Items.Clear();
            ListScenes.Items.AddRange(GameData.Scenes.Lines.Where(n => n.Contains(filter)).ToArray());
            ListScenes.EndUpdate();
        }

        private void ListScenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListScenes.SelectedIndex < 0)
            {
                ChkIncludeSceneId.Enabled = false;
                return;
            }
            ChkIncludeSceneId.Enabled = true;

            // 可以直接弃用 scene 命令
            var name = ListScenes.SelectedItem as string;
            var id = name.Substring(0, name.IndexOf(':')).Trim();
            if (!ChkNewCommand.Checked)
            {
                SetCommand("/scene", id.ToString());
            }
            else
            {
                SetCommand("/tp ~ ~ ~", id.ToString());
            }
        }

        static readonly string[] climateTypes = { "none", "sunny", "cloudy", "rain", "thunderstorm", "snow", "mist" };
        private void CmbClimateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbClimateType.SelectedIndex < 0)
                return;
            if (ChkNewCommand.Checked)
                SetCommand("/weather", CmbClimateType.SelectedIndex < climateTypes.Length ? climateTypes[CmbClimateType.SelectedIndex] : "none");
            else
                SetCommand("/weather", $"0 {CmbClimateType.SelectedIndex}");
        }

        private void BtnTeleport_Click(object sender, EventArgs e)
        {
            string args = $"{NUDTpX.Value} {NUDTpY.Value} {NUDTpZ.Value}";
            if (ChkIncludeSceneId.Checked && ListScenes.SelectedIndex != -1)
                args += $" {GameData.Scenes.Ids[ListScenes.SelectedIndex]}";
            SetCommand("/tp", args);
        }

        #endregion - 场景 -

        #region - 数据 -

        private void InitStatList()
        {
            LblStatTip.Text = "";
            SetStatsCommand.InitStats();
            CmbStat.Items.Clear();
            CmbStat.Items.AddRange(SetStatsCommand.Stats.Select(s => s.Name).ToArray());
        }

        private void SetStatsInputChanged(object sender, EventArgs e)
        {
            if (CmbStat.SelectedIndex < 0)
                return;
            else
                BtnLockStat.Enabled = BtnUnlockStat.Enabled = true;

            var stat = SetStatsCommand.Stats[CmbStat.SelectedIndex];
            LblStatPercent.Visible = stat.Percent;
            LblStatTip.Text = stat.Tip;

            SetCommand("/setstats", $"{stat.ArgName} {NUDStat.Value}{(stat.Percent ? "%" : "")}");
        }

        private void BtnLockStat_Click(object sender, EventArgs e)
        {
            var stat = SetStatsCommand.Stats[CmbStat.SelectedIndex];
            SetCommand("/setstats", $"lock {stat.ArgName} {NUDStat.Value}{(stat.Percent ? "%" : "")}");
        }

        private void BtnUnlockStat_Click(object sender, EventArgs e)
        {
            var stat = SetStatsCommand.Stats[CmbStat.SelectedIndex];
            SetCommand("/setstats", $"unlock {stat.ArgName}");
        }

        private void LnkSetTalentClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetCommand("/talent", $"{(sender as LinkLabel).Tag} {NUDTalentLevel.Value}");
        }

        #endregion - 数据 -

        #region - 管理 -

        private void InitPermList()
        {
            CmbPerm.Items.Clear();
            CmbPerm.Items.AddRange(Resources.Permissions.Split('\n').Select(l => l.Trim()).ToArray());
        }

        private void BtnPermClick(object sender, EventArgs e)
        {
            var uid = NUDPermUID.Value;
            var perm = CmbPerm.Text.Trim();
            if (string.IsNullOrEmpty(perm))
            {
                MessageBox.Show(Resources.PermissionCannotBeEmpty, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SetCommand($"/permission {(sender as Button).Tag} @{uid} {perm}");
        }

        private void AccountButtonClicked(object sender, EventArgs e)
        {
            var username = TxtAccountUserName.Text.Trim();
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show(Resources.UsernameCannotBeEmpty, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SetCommand($"/account {(sender as Button).Tag} {username} {(ChkAccountSetUid.Checked ? NUDAccountUid.Value.ToString() : "")}");
        }

        private void BtnBan_Click(object sender, EventArgs e)
        {
            var uid = NUDBanUID.Value;
            var endTime = DTPBanEndTime.Value;
            var command = $"/ban @{uid} {new DateTimeOffset(endTime).ToUnixTimeSeconds()}";
            var reaseon = Regex.Replace(TxtBanReason.Text.Trim(), @"\s+", "-");
            if (!string.IsNullOrEmpty(reaseon))
                command += $" {reaseon}";
            SetCommand(command);
        }

        private void BtnUnban_Click(object sender, EventArgs e)
        {
            SetCommand($"/unban @{NUDBanUID.Value}");
        }

        #endregion - 管理 -

        #region - 关于 -

        private void LnkGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenURL("https://github.com/jie65535/GrasscutterCommandGenerator");
        }

        #endregion - 关于 -

        #region - 命令 -

        private void SetCommand(string command)
        {
            TxtCommand.Text = command;
            if (ChkAutoCopy.Checked)
                CopyCommand();
            if (ModifierKeys == Keys.Control)
                OnOpenCommandInvoke();
        }

        private void SetCommand(string command, string args)
        {
            if (ChkIncludeUID.Checked)
                SetCommand($"{command} @{NUDUid.Value} {args.Trim()}");
            else
                SetCommand($"{command} {args.Trim()}");
        }

        private async void BtnCopy_Click(object sender, EventArgs e)
        {
            CopyCommand();
            await ButtonComplete(BtnCopy);
        }

        private void CopyCommand()
        {
            if (!string.IsNullOrEmpty(TxtCommand.Text))
                Clipboard.SetText(TxtCommand.Text);
        }

        private void OnOpenCommandInvoke()
        {
            BtnInvokeOpenCommand_Click(BtnInvokeOpenCommand, EventArgs.Empty);
        }

        private async void BtnInvokeOpenCommand_Click(object sender, EventArgs e)
        {
            if (!BtnInvokeOpenCommand.Enabled) return;
            if (TxtCommand.Text.Length < 2)
            {
                ShowTip(Resources.CommandContentCannotBeEmpty, TxtCommand);
                return;
            }
            await RunCommands(TxtCommand.Text);
        }

        private async Task<bool> RunCommands(params string[] commands)
        {
            if (OC == null || !OC.CanInvoke)
            {
                ShowTip(Resources.RequireOpenCommandTip, BtnInvokeOpenCommand);
                TCMain.SelectedTab = TPRemoteCall;
                return false;
            }

            ExpandCommandRunLog();
            try
            {
                BtnInvokeOpenCommand.Enabled = false;
                BtnInvokeOpenCommand.Cursor = Cursors.WaitCursor;
                int i = 0;
                foreach (var command in commands)
                {
                    TxtCommandRunLog.AppendText(">");
                    TxtCommandRunLog.AppendText(command);
                    if (commands.Length > 1)
                        TxtCommandRunLog.AppendText($" ({++i}/{commands.Length})");
                    TxtCommandRunLog.AppendText(Environment.NewLine);
                    var cmd = command.Substring(1);
                    try
                    {
                        var msg = await OC.Invoke(cmd);
                        TxtCommandRunLog.AppendText(string.IsNullOrEmpty(msg) ? "OK" : msg);
                        TxtCommandRunLog.AppendText(Environment.NewLine);
                    }
                    catch (Exception ex)
                    {
                        TxtCommandRunLog.AppendText("Error: ");
                        TxtCommandRunLog.AppendText(ex.Message);
                        TxtCommandRunLog.AppendText(Environment.NewLine);
                        MessageBox.Show(ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    TxtCommandRunLog.ScrollToCaret();
                }
            }
            finally
            {
                BtnInvokeOpenCommand.Cursor = Cursors.Default;
                BtnInvokeOpenCommand.Enabled = true;
            }
            return true;
        }

        private const int TxtCommandRunLogMinHeight = 150;
        private TextBox TxtCommandRunLog;
        private void ExpandCommandRunLog()
        {
            if (GrpCommand.Height < TxtCommandRunLogMinHeight)
            {
                if (WindowState == FormWindowState.Maximized)
                    WindowState = FormWindowState.Normal;
                TCMain.Anchor &= ~AnchorStyles.Bottom;
                GrpCommand.Anchor |= AnchorStyles.Top;
                Size = new Size(Width, Height + TxtCommandRunLogMinHeight);
                MinimumSize = new Size(MinimumSize.Width, MinimumSize.Height + TxtCommandRunLogMinHeight);
                TCMain.Anchor |= AnchorStyles.Bottom;
                GrpCommand.Anchor &= ~AnchorStyles.Top;
            }

            if (TxtCommandRunLog == null)
            {
                TxtCommandRunLog = new TextBox
                {
                    Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom,
                    Multiline = true,
                    Font = new Font("Consolas", 9F),
                    Location = new Point(BtnInvokeOpenCommand.Left, BtnInvokeOpenCommand.Bottom + 6),
                    Size = new Size(GrpCommand.Width - BtnInvokeOpenCommand.Left * 2, TxtCommandRunLogMinHeight),
                    ReadOnly = true,
                    BackColor = Color.White,
                    ScrollBars = ScrollBars.Vertical,
                };
                GrpCommand.Controls.Add(TxtCommandRunLog);
            }
        }

        #endregion - 命令 -

        #region - 通用 -

        private async Task ButtonComplete(Button btn)
        {
            var t = btn.Text;
            btn.Text = "√";
            btn.Enabled = false;
            await Task.Delay(300);
            btn.Text = t;
            btn.Enabled = true;
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                OnOpenCommandInvoke();
            }
        }

        private readonly ToolTip TTip = new ToolTip();
        private void ShowTip(string message, Control control)
        {
            TTip.Show(message, control, 0, control.Size.Height, 3000);
        }

        #endregion - 通用 -

        #region - 命令记录 -

        private List<GameCommand> GetCommands(string commandsText)
        {
            var lines = commandsText.Split('\n');
            List<GameCommand> commands = new List<GameCommand>(lines.Length / 2);
            for (int i = 0; i < lines.Length - 1; i += 2)
                commands.Add(new GameCommand(lines[i].Trim(), lines[i + 1].Trim()));
            return commands;
        }

        private string GetCommandsText(List<GameCommand> commands)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var cmd in commands)
            {
                builder.AppendLine(cmd.Name);
                builder.AppendLine(cmd.Command);
            }
            return builder.ToString();
        }

        #endregion - 命令记录 -

        #region - 远程 -

        private OpenCommandAPI OC;

        private void InitOpenCommand()
        {
            NUDRemotePlayerId.Value = Settings.Default.RemoteUid;
            TxtHost.Text = Settings.Default.Host;
            if (!string.IsNullOrEmpty(Settings.Default.Host) && !string.IsNullOrEmpty(Settings.Default.TokenCache))
            {
                OC = new OpenCommandAPI(Settings.Default.Host, Settings.Default.TokenCache);
                TxtToken.Text = Settings.Default.TokenCache;
                Task.Run(async () =>
                {
                    await Task.Delay(1000);
                    BeginInvoke(new Action(() => ShowTip(Resources.TokenRestoredFromCache, BtnInvokeOpenCommand)));
                });
            }
            else
            {
                // 自动尝试查询本地服务端地址，降低门槛
                Task.Run(async () =>
                {
                    await Task.Delay(5000);
                    var localhosts = new string[] {
                        "http://127.0.0.1:443",
                        "https://127.0.0.1",
                        "http://127.0.0.1",
                        "https://127.0.0.1:80",
                        "http://127.0.0.1:8080",
                        "https://127.0.0.1:8080",
                    };
                    foreach (var host in localhosts)
                    {
                        try
                        {
                            await UpdateServerStatus(host);
                            // 自动填写本地服务端地址
                            TxtHost.Text = host;
                            break;
                        }
                        catch (Exception)
                        {
                            // Ignore
                        }
                    }
                });
            }
        }

        private void SaveOpenCommand()
        {
            Settings.Default.RemoteUid = NUDRemotePlayerId.Value;
            Settings.Default.Host = TxtHost.Text;
            Settings.Default.TokenCache = OC?.Token;
        }

        private async Task UpdateServerStatus(string host)
        {
            var status = await DispatchServerAPI.QueryServerStatus(host);
            LblServerVersion.Text = status.Version;
            if (status.MaxPlayer >= 0)
                LblPlayerCount.Text = $"{status.PlayerCount}/{status.MaxPlayer}";
            else
                LblPlayerCount.Text = status.PlayerCount.ToString();
        }

        private async void BtnQueryServerStatus_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            btn.Enabled = false;
            btn.Cursor = Cursors.WaitCursor;
            try
            {
                try
                {
                    await UpdateServerStatus(TxtHost.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Resources.QueryServerStatusFailed + ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                OC = new OpenCommandAPI(TxtHost.Text);
                if (await OC.Ping())
                {
                    LblOpenCommandSupport.Text = "√";
                    LblOpenCommandSupport.ForeColor = Color.Green;
                    GrpRemoteCommand.Enabled = true;
                }
                else
                {
                    LblOpenCommandSupport.Text = "×";
                    LblOpenCommandSupport.ForeColor = Color.Red;
                    GrpRemoteCommand.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btn.Cursor = Cursors.Default;
                btn.Enabled = true;
            }
        }

        private async void BtnSendVerificationCode_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var t = btn.Text;
            btn.Enabled = false;
            NUDRemotePlayerId.Enabled = false;
            try
            {
                btn.Text = Resources.CodeSending;
                await OC.SendCode((int)NUDRemotePlayerId.Value);
                BtnConnectOpenCommand.Enabled = true;
                NUDVerificationCode.Enabled = true;
                NUDVerificationCode.Focus();
                for (int i = 60; i > 0 && !OC.CanInvoke; i--)
                {
                    btn.Text = string.Format(Resources.CodeResendTip, i);
                    await Task.Delay(1000);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btn.Text = t;
                btn.Enabled = true;
                NUDRemotePlayerId.Enabled = true;
            }
        }

        private async void BtnConnectOpenCommand_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            btn.Enabled = false;
            try
            {
                await OC.Verify((int)NUDVerificationCode.Value);
                GrpRemoteCommand.Enabled = false;
                BtnInvokeOpenCommand.Focus();
                ShowTip(Resources.ConnectedTip, BtnInvokeOpenCommand);
                ButtonOpenGOODImport.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btn.Cursor = Cursors.Default;
                btn.Enabled = true;
            }
        }

        private void BtnConsoleConnect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtToken.Text))
            {
                MessageBox.Show(Resources.TokenCannotBeEmpty, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            OC.Token = TxtToken.Text;
            BtnConnectOpenCommand_Click(sender, e);
        }

        private void LnkOpenCommandLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenURL("https://github.com/jie65535/gc-opencommand-plugin");
        }

        private void LnkRCHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(Resources.OpenCommandHelp, Resources.Help, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LnkInventoryKamera_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenURL("https://github.com/Andrewthe13th/Inventory_Kamera");
        }

        private void LnkGOODHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenURL("https://frzyc.github.io/genshin-optimizer/#/doc");
        }

        private void LnkLinks_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var links = new List<string>
            {
                "https://frzyc.github.io/genshin-optimizer/",
                "https://genshin.aspirine.su/",
                "https://genshin.mingyulab.com/",
                "https://genshin-center.com/",
                "https://github.com/Andrewthe13th/Inventory_Kamera",
                "https://github.com/daydreaming666/Amenoma",
                "https://seelie.me/",
                "https://www.mona-uranai.com/",
            };
            MessageBox.Show(string.Join("\n", links), "Links", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OpenURL(string url)
        {
            try
            {
                System.Diagnostics.Process.Start(url);
            }
            catch (Exception)
            {
                MessageBox.Show(Resources.BrowserOpenFailedTip + "\n " + url,
                    Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion - 远程 -

        #region - 任务 -

        private void InitQuestList()
        {
            QuestFilterChanged(null, EventArgs.Empty);
        }

        private void QuestFilterChanged(object sender, EventArgs e)
        {
            ListQuest.BeginUpdate();
            ListQuest.Items.Clear();
            ListQuest.Items.AddRange(GameData.Quests.Lines.Where(l =>
            {
                if (!ChkQuestFilterHIDDEN.Checked && l.Contains((string)ChkQuestFilterHIDDEN.Tag))
                    return false;
                if (!ChkQuestFilterUNRELEASED.Checked && l.Contains((string)ChkQuestFilterUNRELEASED.Tag))
                    return false;
                if (!ChkQuestFilterTEST.Checked && l.Contains((string)ChkQuestFilterTEST.Tag))
                    return false;
                if (!string.IsNullOrEmpty(TxtQuestFilter.Text))
                    return l.Contains(TxtQuestFilter.Text);
                return true;
            }).ToArray());
            ListQuest.EndUpdate();
        }

        private void QuestButsClicked(object sender, EventArgs e)
        {
            if (ListQuest.SelectedIndex == -1)
                return;
            var item = ListQuest.SelectedItem as string;
            var id = item.Substring(0, item.IndexOf(':')).Trim();
            SetCommand("/quest", $"{(sender as Button).Tag} {id}");
        }

        #endregion - 任务 -

    }
}
