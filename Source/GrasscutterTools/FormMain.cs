using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GrasscutterTools.Game;
using GrasscutterTools.Properties;

namespace GrasscutterTools
{
    public partial class FormMain : Form
    {
        #region - 初始化 -

        public FormMain()
        {
            InitializeComponent();
            Icon = Resources.IconGrasscutter;
            LoadSettings();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            MultiLanguage.LoadLanguage(this, typeof(FormMain));
            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            Text += "  - by jie65535  - v" + version.ToString(3);

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
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSettings();
        }


        private readonly string[] LanguageNames = new string[] { "简体中文", "English" };
        private readonly string[] Languages = new string[] { "zh-CN", "en-US" };

        private void LoadSettings()
        {
            try
            {
                ChkAutoCopy.Checked = Settings.Default.AutoCopy;
                NUDUid.Value = Settings.Default.Uid;

                CmbLanguage.Items.AddRange(LanguageNames);
                CmbLanguage.SelectedIndex = Array.IndexOf(Languages, Settings.Default.DefaultLanguage);

                InitGiveItemRecord();
                InitSpawnRecord();
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载设置时异常：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveSettings()
        {
            try
            {
                Settings.Default.AutoCopy = ChkAutoCopy.Checked;
                Settings.Default.Uid = NUDUid.Value;
                Settings.Default.Save();
                SaveCustomCommands();
                SaveGiveItemRecord();
                SaveSpawnRecord();
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存设置时异常：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion - 初始化 -

        #region - 主页 -


        FormGachaBannerEditor FormGachaBannerEditor;
        private void BtnOpenGachaBannerEditor_Click(object sender, EventArgs e)
        {
            if (FormGachaBannerEditor == null || FormGachaBannerEditor.IsDisposed)
            {
                FormGachaBannerEditor = new FormGachaBannerEditor();
                FormGachaBannerEditor.Show();
            }
            else
            {
                FormGachaBannerEditor.TopMost = true;
                FormGachaBannerEditor.TopMost = false;
            }
        }

        FormTextMapBrowser FormTextMapBrowser;
        private void BtnOpenTextMap_Click(object sender, EventArgs e)
        {
            if (FormTextMapBrowser == null || FormTextMapBrowser.IsDisposed)
            {
                FormTextMapBrowser = new FormTextMapBrowser();
                FormTextMapBrowser.Show();
            }
            else
            {
                FormTextMapBrowser.TopMost = true;
                FormTextMapBrowser.TopMost = false;
            }
        }

        private void CmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            MultiLanguage.SetDefaultLanguage(Languages[CmbLanguage.SelectedIndex]);
            FormMain_Load(this, EventArgs.Empty);
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
            for (int i = 0; i < lines.Length-1; i += 2)
                AddCustomCommand(lines[i].Trim(), lines[i+1].Trim());
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
                MessageBox.Show("命令标签不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(TxtCommand.Text))
            {
                MessageBox.Show("命令内容不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("命令标签不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var name = TxtCustomName.Text.Trim();

            foreach (LinkLabel lnk in FLPCustomCommands.Controls)
            {
                if (lnk.Text == name && MessageBox.Show("确认删除？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    FLPCustomCommands.Controls.Remove(lnk);
                    CustomCommandsChanged = true;
                    //TxtCustomName.Text = "";
                    //TxtCommand.Text = "";
                    await ButtonComplete(BtnRemoveCustomCommand);
                    return;
                }
            }

            MessageBox.Show("未找到该命令", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #endregion - 自定义 -

        #region - 圣遗物 -

        private Dictionary<string, List<KeyValuePair<int, string>>> subAttrs;

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

        private void LblAddSubAttr_Click(object sender, EventArgs e)
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
            NUDArtifactStars.Maximum = GameData.Artifacts.Ids[endIndex]   / 100 % 10;


            var parts = GameData.Artifacts.Names.Skip(beginIndex).Take(endIndex-beginIndex+1).Distinct().ToArray();
            var i = CmbArtifactPart.SelectedIndex;
            CmbArtifactPart.Items.Clear();
            CmbArtifactPart.Items.AddRange(parts);
            if (i < parts.Length) // 重新选中
                CmbArtifactPart.SelectedIndex = i;

            ArtifactInputChanged(sender, e);
        }

        readonly string[] ArtifactPartLabels = new string[] { "空之杯", "死之羽", "理之冠", "生之花", "时之沙"};
        private void CmbArtifactPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbArtifactPart.SelectedIndex < 0)
            {
                LblArtifactName.Text = "";
                return;
            }
            var name = CmbArtifactPart.SelectedItem as string;
            var id = GameData.Artifacts.Ids[Array.IndexOf(GameData.Artifacts.Names, name)];
            LblArtifactName.Text = ArtifactPartLabels[id / 10 % 10 - 1];

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
                return;

            var t = CmbMainAttribution.SelectedItem as string;
            var mainAttr = t.Substring(0, t.IndexOf(':')).Trim();

            var subAttrs = "";
            if (ListSubAttributionChecked.Items.Count > 0)
            {
                var subAttrDir = new Dictionary<string, int>(ListSubAttributionChecked.Items.Count);
                foreach (string item in ListSubAttributionChecked.Items)
                {
                    var subId = item.Substring(0, item.IndexOf(':')).Trim();
                    var times = int.Parse(item.Substring(item.LastIndexOf('x')+1));
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
            SetCommand("/giveart", $"{id} {mainAttr} {subAttrs}{NUDArtifactLevel.Value}");
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
            ListSubAttributionChecked.Items.Clear();
            ArtifactInputChanged(null, EventArgs.Empty);
        }

        #endregion - 圣遗物 -

        #region - 武器 -

        private void InitWeapons()
        {
            ListWeapons.Items.Clear();
            ListWeapons.Items.AddRange(GameData.Weapons.Names);
        }

        private void TxtWeaponFilter_TextChanged(object sender, EventArgs e)
        {
            var filter = TxtWeaponFilter.Text.Trim();
            if (!string.IsNullOrEmpty(filter))
            {
                foreach (var name in GameData.Weapons.Names)
                {
                    if (name.Contains(filter))
                    {
                        ListWeapons.SelectedItem = name;
                        return;
                    }
                }
            }
        }

        private void WeaponValueChanged(object sender, EventArgs e)
        {
            if (ListWeapons.SelectedIndex >= 0)
            {
                var id = GameData.Weapons.Ids[ListWeapons.SelectedIndex];
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
            if (string.IsNullOrEmpty(filter))
            {
                ListGameItems.Items.AddRange(GameData.Items.Lines);
            }
            else
            {
                ListGameItems.Items.AddRange(GameData.Items.Lines.Where(n => n.Contains(filter)).ToArray());
            }
            ListGameItems.EndUpdate();
        }

        private bool GenGiveItemCommand()
        {
            var name = ListGameItems.SelectedItem as string;
            if (!string.IsNullOrEmpty(name))
            {
                var id = name.Substring(0, name.IndexOf(':')).Trim();

                SetCommand(ChkDrop.Checked ? "/drop" : "/give",
                    $"{id} {NUDGameItemAmout.Value} {NUDGameItemLevel.Value}");
                return true;
            }
            return false;
        }

        private void GiveItemsInputChanged(object sender, EventArgs e)
        {
            GenGiveItemCommand();
        }

        #region -- 物品记录 --

        readonly string GiveItemCommandsRecordPath = Path.Combine(Application.LocalUserAppDataPath, "GiveItemCommands.txt");
        List<GameCommand> GiveItemCommands;
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
        #endregion

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
                GenAvatar(GameData.Avatars.Ids[CmbAvatar.SelectedIndex], (int)NUDAvatarLevel.Value);
        }

        private void GenAvatar(int avatarId, int level)
        {
            SetCommand("/givechar", $"{avatarId} {level}");
        }

        #endregion - 角色 -

        #region - 生成 -

        private void InitEntityList()
        {
            RbEntityAnimal.Tag = GameData.Animals.Lines;
            RbEntityMonster.Tag = GameData.Monsters.Lines;
            RbEntityNPC.Tag = GameData.NPCs.Lines;
            RbEntityOrnament.Tag = GameData.Ornaments.Lines;
            RbEntityAnimal.Checked = true;
        }

        private void TxtEntityFilter_TextChanged(object sender, EventArgs e)
        {
            var filter = TxtEntityFilter.Text.Trim();
            var rb = RbEntityAnimal.Checked ? RbEntityAnimal :
                    RbEntityMonster.Checked ? RbEntityMonster :
                    RbEntityNPC;
            var data = rb.Tag as string[];
            ListGameItems.BeginUpdate();
            ListEntity.Items.Clear();
            if (string.IsNullOrEmpty(filter))
            {
                ListEntity.Items.AddRange(data);
            }
            else
            {
                ListEntity.Items.AddRange(data.Where(n => n.Contains(filter)).ToArray());
            }
            ListGameItems.EndUpdate();
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
            var rb = sender as RadioButton;
            if (rb.Checked)
            {
                ListGameItems.BeginUpdate();
                ListEntity.Items.Clear();
                ListEntity.Items.AddRange(rb.Tag as string[]);
                ListGameItems.EndUpdate();
            }
        }

        #region -- 生成记录 --

        readonly string SpawnCommandsRecordPath = Path.Combine(Application.LocalUserAppDataPath, "SpawnCommands.txt");
        List<GameCommand> SpawnCommands;
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

        #endregion

        #endregion - 生成 -

        #region - 场景 -

        private void InitScenes()
        {
            ListScenes.Items.Clear();
            ListScenes.Items.AddRange(GameData.Scenes.Lines);

            CmbClimateType.Items.Clear();
            CmbClimateType.Items.AddRange(Resources.ClimateType.Split(','));
        }

        private void ListScenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListScenes.SelectedIndex >= 0)
            {
                var id = GameData.Scenes.Ids[ListScenes.SelectedIndex];
                SetCommand("/changescene", id.ToString());
            }
        }

        private void CmbClimateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbClimateType.SelectedIndex < 0)
                return;
            SetCommand("/weather", $"0 {CmbClimateType.SelectedIndex}");
        }

        #endregion - 场景 -

        #region - 状态 -

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

            var stat = SetStatsCommand.Stats[CmbStat.SelectedIndex];
            LblStatPercent.Visible = stat.Percent;
            LblStatTip.Text = stat.Tip;

            SetCommand("/setstats", $"{stat.ArgName} {NUDStat.Value}{(stat.Percent?"%":"")}");
        }

        private void LnkSetTalentClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetCommand("/talent", $"{(sender as LinkLabel).Tag} {NUDTalentLevel.Value}");
        }

        #endregion - 状态 -

        #region - 其它 -

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
                MessageBox.Show("权限不能为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SetCommand($"/permission {(sender as Button).Tag} @{uid} {perm}");
        }

        private void AccountButtonClicked(object sender, EventArgs e)
        {
            var username = TxtAccountUserName.Text.Trim();
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("用户名不能为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SetCommand($"/account {(sender as Button).Tag} {username} {(ChkAccountSetUid.Checked ? NUDAccountUid.Value.ToString() : "")}");
        }

        #endregion - 其它 -

        #region - 关于 -

        private void LnkGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://github.com/jie65535/GrasscutterCommandGenerator");
            }
            catch (Exception)
            {
                MessageBox.Show("浏览器打开失败，你可以通过以下链接手动访问：\n"
                    + "https://github.com/jie65535/GrasscutterCommandGenerator",
                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region - 命令 -

        private void SetCommand(string command)
        {
            TxtCommand.Text = command;
            if (ChkAutoCopy.Checked)
                CopyCommand();
        }

        private void SetCommand(string command, string args)
        {
            if (ChkIncludeUID.Checked)
                SetCommand($"{command} @{NUDUid.Value} {args}");
            else
                SetCommand($"{command} {args}");
        }

        private async void BtnCopy_Click(object sender, EventArgs e)
        {
            CopyCommand();
            await ButtonComplete(BtnCopy);
        }

        private void CopyCommand()
        {
            Clipboard.SetText(TxtCommand.Text);
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

        #endregion - 通用 -

        #region - 命令记录 -

        List<GameCommand> GetCommands(string commandsText)
        {
            var lines = commandsText.Split('\n');
            List<GameCommand> commands = new List<GameCommand>(lines.Length/2);
            for (int i = 0; i < lines.Length-1; i += 2)
                commands.Add(new GameCommand(lines[i].Trim(), lines[i+1].Trim()));
            return commands;
        }

        string GetCommandsText(List<GameCommand> commands)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var cmd in commands)
            {
                builder.AppendLine(cmd.Name);
                builder.AppendLine(cmd.Command);
            }
            return builder.ToString();
        }

        #endregion

        #region - 远程 -

        private void LnkRCHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("TODO：正在开发中", "TODO");
        }

        private void BtnPingHost_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TODO：正在开发中", "TODO");
        }

        #endregion
    }
}