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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using GrasscutterTools.DispatchServer;
using GrasscutterTools.Game;
using GrasscutterTools.Game.Mail;
using GrasscutterTools.GOOD;
using GrasscutterTools.OpenCommand;
using GrasscutterTools.Properties;
using GrasscutterTools.Utils;

using Newtonsoft.Json;

namespace GrasscutterTools.Forms
{
    public partial class FormMain : Form
    {
        #region - 初始化 Init -

        public FormMain()
        {
            InitializeComponent();
            Icon = Resources.IconGrasscutter;

            // 加载版本信息
            LoadVersion();

            // 加载设置
            LoadSettings();
            
#if !DEBUG  // 仅正式版
            // 检查更新，但不要弹窗
            Task.Run(async () => { try { await LoadUpdate(); } catch { /* 启动时检查更新，忽略异常 */ }});
#endif
        }

        /// <summary>
        /// 窗体载入时触发（切换语言时会重新载入）
        /// </summary>
        private void FormMain_Load(object sender, EventArgs e)
        {
            Text += "  - by jie65535  - v" + AppVersion.ToString(3);
#if DEBUG
            Text += "-debug";
            //Text += "-debug -攻击修改特供版";
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
            InitMailPage();

            ChangeTPArtifact();
        }

        /// <summary>
        /// 第一次显示窗体时触发
        /// </summary>
        protected override void OnShown(EventArgs e)
        {
            // 还原窗体位置
            if (Settings.Default.MainFormLocation != default)
                Location = Settings.Default.MainFormLocation;
            // 还原窗体大小
            if (Settings.Default.MainFormSize != default)
                Size = Settings.Default.MainFormSize;
            base.OnShown(e);
        }

        /// <summary>
        /// 窗口关闭后触发
        /// </summary>
        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 保存当前设置
            SaveSettings();
        }


        /// <summary>
        /// 应用版本
        /// </summary>
        private Version AppVersion;

        /// <summary>
        /// 加载应用版本
        /// </summary>
        private void LoadVersion()
        {
            AppVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
        }

        /// <summary>
        /// 载入设置
        /// </summary>
        private void LoadSettings()
        {
            try
            {
                // 恢复自动复制选项状态
                ChkAutoCopy.Checked = Settings.Default.AutoCopy;

                // 初始化首页设置
                InitHomeSettings();

                // 初始化获取物品记录
                InitGiveItemRecord();

                // 初始化生成记录
                InitSpawnRecord();

                // 初始化开放命令
                InitOpenCommand();

                // 初始化邮件列表
                InitMailList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resources.SettingLoadError + ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 保存设置
        /// </summary>
        private void SaveSettings()
        {
            try
            {
                // 记录界面状态
                Settings.Default.AutoCopy = ChkAutoCopy.Checked;
                Settings.Default.MainFormLocation = Location;
                // 如果命令窗口已经弹出了，则不要保存多余的高度
                if (TxtCommandRunLog != null)
                    Settings.Default.MainFormSize = new Size(Width, Height - TxtCommandRunLogMinHeight);
                else
                    Settings.Default.MainFormSize = Size;

                // 保存自定义命令
                SaveCustomCommands();

                // 保存开放命令设置
                SaveOpenCommand();

                // 保存邮件设置
                SaveMailSettings();

                // 保存默认设置
                Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resources.SettingSaveError + ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ReleaseAPI.ReleaseInfo LastestInfo = null;
        private Version lastestVersion = null;

        private async Task LoadUpdate()
        {
            var info = await ReleaseAPI.GetReleasesLastest("jie65535", "GrasscutterCommandGenerator");
            if (Version.TryParse(info.TagName.Substring(1), out lastestVersion) && AppVersion < lastestVersion)
            {
                if (!string.IsNullOrEmpty(Settings.Default.CheckedLastVersion)
                    && Version.TryParse(Settings.Default.CheckedLastVersion, out Version checkedVersion)
                    && checkedVersion >= lastestVersion)
                    return;
                LastestInfo = info;
                BeginInvoke(new Action(() =>
                {
                    LnkNewVersion.Visible = true;
                    LnkNewVersion.Text = Resources.CheckToNewVersion;
                    this.Text += " - " + Resources.CheckToNewVersion;
                }));
            }
        }

        #endregion - 初始化 Init -

        #region - 主页 Home -

        /// <summary>
        /// 命令版本
        /// </summary>
        private CommandVersion CommandVersion;

        /// <summary>
        /// 初始化首页设置
        /// </summary>
        private void InitHomeSettings()
        {
            // 玩家UID
            NUDUid.Value = Settings.Default.Uid;
            NUDUid.ValueChanged += (o, e) => Settings.Default.Uid = NUDUid.Value;

            // 置顶
            ChkTopMost.Checked = Settings.Default.IsTopMost;
            ChkTopMost.CheckedChanged += (o, e) => Settings.Default.IsTopMost = TopMost = ChkTopMost.Checked;

            // 命令版本初始化
            CommandVersion = Version.TryParse(Settings.Default.CommandVersion, out Version current) ? new CommandVersion(current) : CommandVersion.Latest();
            CmbGcVersions.DataSource = CommandVersion.List.Select(it => it.ToString(3)).ToList();
            CmbGcVersions.SelectedIndex = Array.IndexOf(CommandVersion.List, CommandVersion.Current);
            CmbGcVersions.SelectedIndexChanged += (o, e) => CommandVersion.Current = CommandVersion.List[CmbGcVersions.SelectedIndex];
            CommandVersion.VersionChanged += OnCommandVersionChanged;


            // 初始化多语言
            CmbLanguage.DataSource = MultiLanguage.LanguageNames;
            if (string.IsNullOrEmpty(Settings.Default.DefaultLanguage))
            {
                // 如果未选择语言，则默认载入本地语言
                var i = Array.IndexOf(MultiLanguage.Languages, Thread.CurrentThread.CurrentUICulture);
                // 仅支持时切换，避免重复加载
                if (i > 0) CmbLanguage.SelectedIndex = i;
            }
            else
            {
                CmbLanguage.SelectedIndex = Array.IndexOf(MultiLanguage.Languages, Settings.Default.DefaultLanguage);
            }
            CmbLanguage.SelectedIndexChanged += CmbLanguage_SelectedIndexChanged;
        }

        private static void ToTop(Form form)
        {
            form.TopMost = true;
            form.TopMost = false;
        }

        /// <summary>
        /// 卡池编辑器窗口实例
        /// </summary>
        private Form GachaBannerEditor;

        /// <summary>
        /// 点击打开卡池编辑器时触发
        /// </summary>
        private void BtnOpenGachaBannerEditor_Click(object sender, EventArgs e)
        {
            if (GachaBannerEditor == null || GachaBannerEditor.IsDisposed)
            {
                GachaBannerEditor = new FormGachaBannerEditor2();
                GachaBannerEditor.Show();
            }
            else
            {
                ToTop(GachaBannerEditor);
            }
        }

        /// <summary>
        /// 文本浏览器窗口实例
        /// </summary>
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
                ToTop(TextMapBrowser);
            }
        }

        /// <summary>
        /// 掉落物编辑器窗口实例
        /// </summary>
        private FormDropEditor DropEditor;

        /// <summary>
        /// 点击打开掉落物编辑器时触发
        /// </summary>
        private void BtnOpenDropEditor_Click(object sender, EventArgs e)
        {
            if (DropEditor == null || DropEditor.IsDisposed)
            {
                DropEditor = new FormDropEditor();
                DropEditor.Show();
            }
            else
            {
                ToTop(DropEditor);
            }
        }

        /// <summary>
        /// 商店编辑器窗口实例
        /// </summary>
        private FormShopEditor ShopEditor;

        /// <summary>
        /// 点击打开商店编辑器时触发
        /// </summary>
        private void BtnOpenShopEditor_Click(object sender, EventArgs e)
        {
            if (ShopEditor == null || ShopEditor.IsDisposed)
            {
                ShopEditor = new FormShopEditor();
                ShopEditor.Show();
            }
            else
            {
                ToTop(ShopEditor);
            }
        }

        /// <summary>
        /// 语言选中项改变时触发
        /// </summary>
        private void CmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbLanguage.SelectedIndex < 0) return;
            // 切换默认语言
            MultiLanguage.SetDefaultLanguage(MultiLanguage.Languages[CmbLanguage.SelectedIndex]);
            // 动态更改语言
            MultiLanguage.LoadLanguage(this, typeof(FormMain));
            // 重新载入页面资源
            FormMain_Load(this, EventArgs.Empty);
        }

        /// <summary>
        /// 命令版本改变时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCommandVersionChanged(object sender, EventArgs e)
        {
            Settings.Default.CommandVersion = CommandVersion.Current.ToString(3);
            ChangeTPArtifact();
        }


        /// <summary>
        /// 点击检查更新时触发
        /// </summary>
        private void LnkNewVersion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (LastestInfo != null)
            {
                var r = MessageBox.Show(
                    string.Format(Resources.NewVersionInfo, LastestInfo.Name, LastestInfo.CraeteTime.ToLocalTime(), LastestInfo.Body),
                    Resources.CheckToNewVersion,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);
                if (r == DialogResult.Yes)
                    OpenURL(LastestInfo.Url);
                else if (r == DialogResult.No)
                    Settings.Default.CheckedLastVersion = lastestVersion.ToString();
            }
            else
            {
                // 没有更新，隐藏
                LnkNewVersion.Visible = false;
            }
        }

        #endregion - 主页 Home -

        #region - 自定义 Custom -

        /// <summary>
        /// 自定义命令保存位置
        /// </summary>
        private readonly string CustomCommandsFilePath = Path.Combine(Application.LocalUserAppDataPath, "CustomCommands.txt");

        /// <summary>
        /// 自定义命令是否存在更改
        /// </summary>
        private bool CustomCommandsChanged;

        /// <summary>
        /// 加载自定义命令
        /// </summary>
        private void LoadCustomCommands()
        {
            if (File.Exists(CustomCommandsFilePath))
                LoadCustomCommandControls(File.ReadAllText(CustomCommandsFilePath));
            else
                LoadCustomCommandControls(Resources.CustomCommands);
        }

        /// <summary>
        /// 加载自定义命令控件列表
        /// </summary>
        /// <param name="commands">命令集（示例："标签1\n命令1\n标签2\n命令2"）</param>
        private void LoadCustomCommandControls(string commands)
        {
            FLPCustomCommands.Controls.Clear();
            var lines = commands.Split('\n');
            for (int i = 0; i < lines.Length - 1; i += 2)
                AddCustomCommand(lines[i].Trim(), lines[i + 1].Trim());
        }

        /// <summary>
        /// 保存自定义命令
        /// </summary>
        private void SaveCustomCommands()
        {
            if (CustomCommandsChanged)
                File.WriteAllText(CustomCommandsFilePath, SaveCustomCommandControls());
        }

        /// <summary>
        /// 保存自定义命令控件列表
        /// </summary>
        /// <returns>命令集（示例："标签1\n命令1\n标签2\n命令2"）</returns>
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

        /// <summary>
        /// 自定义命令点击时触发
        /// </summary>
        private void CustomCommand_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (sender is LinkLabel lnk && lnk.Tag is string command)
            {
                TxtCustomName.Text = lnk.Text;
                SetCommand(command);
            }
        }

        /// <summary>
        /// 点击保存自定义命令列表时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    await UIUtil.ButtonComplete(BtnSaveCustomCommand);
                    return;
                }
            }

            CustomCommandsChanged = true;
            AddCustomCommand(name, command);
            await UIUtil.ButtonComplete(BtnSaveCustomCommand);
        }

        /// <summary>
        /// 添加自定义命令
        /// </summary>
        /// <param name="name">标签</param>
        /// <param name="command">命令</param>
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

        /// <summary>
        /// 点击移除自定义命令按钮时触发
        /// </summary>
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
                    await UIUtil.ButtonComplete(BtnRemoveCustomCommand);
                    return;
                }
            }

            MessageBox.Show(Resources.CommandNotFound, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 点击导入自定义命令时触发
        /// </summary>
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

        /// <summary>
        /// 点击导出自定义命令时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 点击重置链接按钮时触发
        /// </summary>
        private void LnkResetCustomCommands_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show(Resources.RestoreCustomCommands, Resources.Tips, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (File.Exists(CustomCommandsFilePath))
                    File.Delete(CustomCommandsFilePath);
                LoadCustomCommandControls(Resources.CustomCommands);
            }
        }

        #endregion - 自定义 Custom -

        #region - 圣遗物 Artifact -

        /// <summary>
        /// 副词条集
        /// </summary>
        private Dictionary<string, List<KeyValuePair<int, string>>> subAttrs;

        /// <summary>
        /// 部位标签集
        /// </summary>
        private string[] ArtifactPartLabels;

        /// <summary>
        /// 初始化圣遗物列表
        /// </summary>
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

        /// <summary>
        /// 福词条下拉框选中项改变时触发
        /// </summary>
        private void CmbSubAttribution_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbSubAttributionValue.Items.Clear();
            if (CmbSubAttribution.SelectedIndex >= 0)
            {
                CmbSubAttributionValue.Items.AddRange(subAttrs[CmbSubAttribution.SelectedItem as string].Select(kv => kv.Value).ToArray());
                CmbSubAttributionValue.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 点击添加副词条按钮时触发
        /// </summary>
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

        /// <summary>
        /// 圣遗物套装下拉框选中项改变时触发
        /// </summary>
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

        /// <summary>
        /// 圣遗物部件选中项改变时触发
        /// </summary>
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

        /// <summary>
        /// 圣遗物页面输入改变时调用
        /// </summary>
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
                if (CommandVersion.Check(CommandVersion.V1_2_2))
                    SetCommand("/give", $"{id} lv{NUDArtifactLevel.Value}");
                else
                    SetCommand("/giveart", $"{id} {NUDArtifactLevel.Value}");
            }
            else
            {
                var t = CmbMainAttribution.SelectedItem as string;
                var mainAttr = ItemMap.ToId(t);

                var subAttrs = "";
                if (ListSubAttributionChecked.Items.Count > 0)
                {
                    var subAttrDir = new Dictionary<int, int>(ListSubAttributionChecked.Items.Count);
                    foreach (string item in ListSubAttributionChecked.Items)
                    {
                        var subId = ItemMap.ToId(item);
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
                if (CommandVersion.Check(CommandVersion.V1_2_2))
                    SetCommand("/give", $"{id} lv{NUDArtifactLevel.Value} {mainAttr} {subAttrs}");
                else
                    SetCommand("/giveart", $"{id} {mainAttr} {subAttrs}{NUDArtifactLevel.Value}");
            }
        }

        /// <summary>
        /// 已添加的副词条列表选中项改变时触发
        /// </summary>
        private void ListSubAttributionChecked_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListSubAttributionChecked.SelectedIndex >= 0)
            {
                ListSubAttributionChecked.Items.RemoveAt(ListSubAttributionChecked.SelectedIndex);
                ListSubAttributionChecked.ClearSelected();
                ArtifactInputChanged(null, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 清除词条链接标签点击时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblClearSubAttrCheckedList_Click(object sender, EventArgs e)
        {
            CmbMainAttribution.SelectedIndex = -1;
            ListSubAttributionChecked.Items.Clear();
            ArtifactInputChanged(null, EventArgs.Empty);
        }

        /// <summary>
        /// 改变圣遗物等级输入范围（旧版本范围是1-21）
        /// </summary>
        private void ChangeTPArtifact()
        {
            if (CommandVersion.Check(CommandVersion.V1_2_2))
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

        /// <summary>
        /// 点击CharacterBuilder链接标签时触发
        /// </summary>
        private void LnkCharacterBuilder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenURL("https://github.com/Penelopeep/CharacterBuilder");
        }

        #endregion - 圣遗物 Artifact -

        #region - 武器 Weapons -

        /// <summary>
        /// 初始化武器列表
        /// </summary>
        private void InitWeapons()
        {
            ListWeapons.Items.Clear();
            ListWeapons.Items.AddRange(GameData.Weapons.Lines);
        }

        /// <summary>
        /// 武器列表过滤器文本改变时触发
        /// </summary>
        private void TxtWeaponFilter_TextChanged(object sender, EventArgs e)
        {
            UIUtil.ListBoxFilter(ListWeapons, GameData.Weapons.Lines, TxtWeaponFilter.Text);
        }

        /// <summary>
        /// 武器页面输入改变时触发
        /// </summary>
        private void WeaponValueChanged(object sender, EventArgs e)
        {
            var name = ListWeapons.SelectedItem as string;
            if (!string.IsNullOrEmpty(name))
            {
                var id = ItemMap.ToId(name);
                if (CommandVersion.Check(CommandVersion.V1_2_2))
                    SetCommand("/give", $"{id} x{NUDWeaponAmout.Value} lv{NUDWeaponLevel.Value} r{NUDWeaponRefinement.Value}");
                else
                    SetCommand("/give", $"{id} {NUDWeaponAmout.Value} {NUDWeaponLevel.Value} {NUDWeaponRefinement.Value}");
            }
        }

        /// <summary>
        /// 点击获取所有武器按钮时触发
        /// </summary>
        private void BtnGiveAllWeapons_Click(object sender, EventArgs e)
        {
            SetCommand("/give", $"weapons x{NUDWeaponAmout.Value} lv{NUDWeaponLevel.Value} r{NUDWeaponRefinement.Value}");
        }

        #endregion - 武器 Weapons -

        #region - 物品 Items -

        /// <summary>
        /// 初始化游戏物品列表
        /// </summary>
        private void InitGameItemList()
        {
            ListGameItems.Items.Clear();
            ListGameItems.Items.AddRange(GameData.Items.Lines);
        }

        /// <summary>
        /// 物品列表过滤器文本改变时触发
        /// </summary>
        private void TxtGameItemFilter_TextChanged(object sender, EventArgs e)
        {
            UIUtil.ListBoxFilter(ListGameItems, GameData.Items.Lines, TxtGameItemFilter.Text);
        }

        /// <summary>
        /// 生成获取物品命令
        /// </summary>
        /// <returns>是否生成成功</returns>
        private bool GenGiveItemCommand()
        {
            var name = ListGameItems.SelectedItem as string;
            if (!string.IsNullOrEmpty(name))
            {
                var id = ItemMap.ToId(name);

                if (ChkDrop.Checked)
                {
                    NUDGameItemLevel.Enabled = false;
                    SetCommand("/drop", $"{id} {NUDGameItemAmout.Value}");
                }
                else
                {
                    NUDGameItemLevel.Enabled = true;
                    if (CommandVersion.Check(CommandVersion.V1_2_2))
                        SetCommand("/give", $"{id} x{NUDGameItemAmout.Value} lv{NUDGameItemLevel.Value}");
                    else
                        SetCommand("/give", $"{id} {NUDGameItemAmout.Value} {NUDGameItemLevel.Value}");
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取物品输入改变时触发
        /// </summary>
        private void GiveItemsInputChanged(object sender, EventArgs e)
        {
            GenGiveItemCommand();
        }

        #region -- 物品记录 --

        /// <summary>
        /// 获取物品记录文件路径
        /// </summary>
        private readonly string GiveItemCommandsRecordPath = Path.Combine(Application.LocalUserAppDataPath, "GiveItemCommands.txt");

        /// <summary>
        /// 获取物品记录
        /// </summary>
        private List<GameCommand> GiveItemCommands;

        /// <summary>
        /// 初始化获取物品记录
        /// </summary>
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

        /// <summary>
        /// 保存获取物品记录
        /// </summary>
        private void SaveGiveItemRecord()
        {
            File.WriteAllText(GiveItemCommandsRecordPath, GetCommandsText(GiveItemCommands));
        }

        /// <summary>
        /// 获取物品记录列表选中项改变时触发
        /// </summary>
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

        /// <summary>
        /// 点击保存记录按钮时触发
        /// </summary>
        private void BtnSaveGiveItemLog_Click(object sender, EventArgs e)
        {
            if (GenGiveItemCommand())
            {
                var cmd = new GameCommand($"{ListGameItems.SelectedItem} x{NUDGameItemAmout.Value}", TxtCommand.Text);
                GiveItemCommands.Add(cmd);
                ListGiveItemLogs.Items.Add(cmd.Name);
                SaveGiveItemRecord();
            }
        }

        /// <summary>
        /// 点击移除获取物品记录时触发
        /// </summary>
        private void BtnRemoveGiveItemLog_Click(object sender, EventArgs e)
        {
            if (ListGiveItemLogs.SelectedIndex >= 0)
            {
                GiveItemCommands.RemoveAt(ListGiveItemLogs.SelectedIndex);
                ListGiveItemLogs.Items.RemoveAt(ListGiveItemLogs.SelectedIndex);
                SaveGiveItemRecord();
            }
        }

        /// <summary>
        /// 点击清空获取物品记录时触发
        /// </summary>
        private void LblClearGiveItemLogs_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Resources.AskConfirmDeletion, Resources.Tips, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                GiveItemCommands.Clear();
                ListGiveItemLogs.Items.Clear();
                SaveGiveItemRecord();
            }
        }

        #endregion -- 物品记录 --

        #endregion - 物品 Items -

        #region - 角色 Avatars -

        #region -- 获取角色 --

        /// <summary>
        /// 初始化角色列表
        /// </summary>
        private void InitAvatars()
        {
            CmbAvatar.Items.Clear();
            CmbAvatar.Items.AddRange(GameData.Avatars.Names);
        }

        /// <summary>
        /// 角色下拉框选中项改变时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmbAvatar_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: Load Avatar Image
            AvatarInputChanged();
        }

        /// <summary>
        /// 角色等级输入框数值改变时触发
        /// </summary>
        private void NUDAvatarLevel_ValueChanged(object sender, EventArgs e)
        {
            AvatarInputChanged();
        }

        /// <summary>
        /// 角色命座输入框数值改变时触发
        /// </summary>
        private void NUDAvatarConstellation_ValueChanged(object sender, EventArgs e)
        {
            AvatarInputChanged();
        }

        /// <summary>
        /// 角色页面输入改变时触发
        /// </summary>
        private void AvatarInputChanged()
        {
            if (CmbAvatar.SelectedIndex >= 0)
                GenAvatar((int)NUDAvatarLevel.Value, (int)NUDAvatarConstellation.Value, (int)NUDAvatarSkillLevel.Value);
        }

        /// <summary>
        /// 获取角色命令
        /// </summary>
        /// <param name="level">等级</param>
        private void GenAvatar(int level, int constellation, int skillLevel)
        {
            if (CommandVersion.Check(CommandVersion.V1_4_1))
            {
                int avatarId = GameData.Avatars.Ids[CmbAvatar.SelectedIndex];
                SetCommand("/give", $"{avatarId} lv{level} c{constellation} sl{skillLevel}");
            }
            else if (CommandVersion.Check(CommandVersion.V1_2_2))
            {
                int avatarId = GameData.Avatars.Ids[CmbAvatar.SelectedIndex];
                SetCommand("/give", $"{avatarId} lv{level} c{constellation}");
            }
            else
            {
                int avatarId = GameData.Avatars.Ids[CmbAvatar.SelectedIndex] - 1000 + 10000000;
                SetCommand("/givechar", $"{avatarId} {level}");
            }
        }

        /// <summary>
        /// 点击获取所有角色按钮时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGiveAllChar_Click(object sender, EventArgs e)
        {
            var level = NUDAvatarLevel.Value;
            var constellation = NUDAvatarConstellation.Value;
            var skillLevel = NUDAvatarSkillLevel.Value;
            if (CommandVersion.Check(CommandVersion.V1_4_1))
                SetCommand("/give avatars", $"lv{level} c{constellation} sl{skillLevel}");
            else
                SetCommand("/give avatars", $"lv{level} c{constellation}");
        }

        #endregion

        #region -- 切换主角元素 --

        /// <summary>
        /// 点击切换主角元素链接标签时触发
        /// </summary>
        private void LnkSwitchElement_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenURL("https://github.com/Penelopeep/SwitchElementTraveller");
        }

        /// <summary>
        /// 元素参数
        /// </summary>
        private readonly string[] Elements = { "white", "fire", "water", "wind", "ice", "rock", "electro", "grass" };

        /// <summary>
        /// 切换元素下拉框选中项改变时触发
        /// </summary>
        private void CmbSwitchElement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbSwitchElement.SelectedIndex == -1 || CmbSwitchElement.SelectedIndex >= Elements.Length) return;
            SetCommand("/se", Elements[CmbSwitchElement.SelectedIndex]);
        }
        #endregion

        #region -- 设置角色属性 --

        /// <summary>
        /// 初始化数据列表
        /// </summary>
        private void InitStatList()
        {
            LblStatTip.Text = "";
            SetStatsCommand.InitStats();
            CmbStat.Items.Clear();
            CmbStat.Items.AddRange(SetStatsCommand.Stats.Select(s => s.Name).ToArray());
        }

        /// <summary>
        /// 数据页面输入改变时触发
        /// </summary>
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

        /// <summary>
        /// 点击锁定按钮时触发
        /// </summary>
        private void BtnLockStat_Click(object sender, EventArgs e)
        {
            var stat = SetStatsCommand.Stats[CmbStat.SelectedIndex];
            SetCommand("/setstats", $"lock {stat.ArgName} {NUDStat.Value}{(stat.Percent ? "%" : "")}");
        }

        /// <summary>
        /// 点击解锁按钮时触发
        /// </summary>
        private void BtnUnlockStat_Click(object sender, EventArgs e)
        {
            var stat = SetStatsCommand.Stats[CmbStat.SelectedIndex];
            SetCommand("/setstats", $"unlock {stat.ArgName}");
        }

        #endregion

        #region -- 设置技能等级 --

        /// <summary>
        /// 点击设置技能按钮时触发
        /// </summary>
        private void LnkSetTalentClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetCommand("/talent", $"{(sender as LinkLabel).Tag} {NUDTalentLevel.Value}");
        }

        #endregion

        #region -- 设置命座 --

        /// <summary>
        /// 设置命座链接标签点击时触发
        /// </summary>
        private void LnkSetConst_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (NUDSetConstellation.Value >= 0)
                SetCommand("/setConst", $"{NUDSetConstellation.Value}" + (sender == LnkSetAllConst ? " all" : string.Empty));
            else
                SetCommand("/resetConst", (sender == LnkSetAllConst ? "all" : string.Empty));
        }

        #endregion

        #endregion - 角色 Avatars -

        #region - 生成 Spawns -

        #region -- 实体列表 --

        /// <summary>
        /// 初始化实体列表
        /// </summary>
        private void InitEntityList()
        {
            // 初始化列表类型过滤器
            MenuSpawnEntityFilter.SuspendLayout();
            MenuSpawnEntityFilter.Items.Clear();
            void AddTypes(ItemMapGroup group)
            {
                foreach (var kv in group)
                {
                    var item = new ToolStripMenuItem
                    {
                        Text = kv.Key,
                        Tag = kv.Value.Lines,
                    };
                    item.Click += OnEntityTypeFilterClick;
                    MenuSpawnEntityFilter.Items.Add(item);
                }
            }
            //MenuSpawnEntityFilter.Items.Add(new ToolStripLabel("Monsters"));
            AddTypes(GameData.Monsters);
            MenuSpawnEntityFilter.Items.Add(new ToolStripSeparator());
            //MenuSpawnEntityFilter.Items.Add(new ToolStripLabel("Gadgets"));
            AddTypes(GameData.Gadgets);
            MenuSpawnEntityFilter.ResumeLayout();

            // 默认显示所有
            SelectedEntityTypeLines = GameData.Monsters.AllLines.Concat(GameData.Gadgets.AllLines).ToArray();
            LoadEntityList();
        }

        /// <summary>
        /// 当前选中的实体类型行
        /// </summary>
        private string[] SelectedEntityTypeLines;

        /// <summary>
        /// 实体类型过滤器类型选中时触发
        /// </summary>
        private void OnEntityTypeFilterClick(object sender, EventArgs e)
        {
            var btn = sender as ToolStripMenuItem;
            SelectedEntityTypeLines = btn.Tag as string[];
            LoadEntityList();
        }

        /// <summary>
        /// 加载实体列表
        /// </summary>
        private void LoadEntityList()
        {
            UIUtil.ListBoxFilter(ListEntity, SelectedEntityTypeLines, TxtEntityFilter.Text);
        }

        /// <summary>
        /// 实体列表过滤器文本改变时触发
        /// </summary>
        private void TxtEntityFilter_TextChanged(object sender, EventArgs e)
        {
            LoadEntityList();
        }

        /// <summary>
        /// 实体列表类型过滤按钮点击时触发
        /// </summary>
        private void BtnFilterEntity_Click(object sender, EventArgs e)
        {
            MenuSpawnEntityFilter.Show(BtnFilterEntity, 0, BtnFilterEntity.Height);
        }

        /// <summary>
        /// 实体列表选中项改变时触发
        /// </summary>
        private void ListEntity_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 根据当前所在页面确定要做的事情

            // 攻击修改界面
            if (TCSpawnSettings.SelectedTab == TPAttackModArgs)
            {
                OnAttackModifierInputChanged(sender, e);
            }
            // 攻击注入界面
            else if (TCSpawnSettings.SelectedTab == TPAttackInfusedArgs)
            {
                // 无事发生，因为要页面上点击按钮才会生成命令
            }
            // 生成参数界面 或其它
            else
            {
                // 触发输入改变事件
                SpawnEntityInputChanged(sender, e);
            }
        }

        #endregion

        #region -- 生成记录 --

        /// <summary>
        /// 生成命令记录文件路径
        /// </summary>
        private readonly string SpawnCommandsRecordPath = Path.Combine(Application.LocalUserAppDataPath, "SpawnCommands.txt");

        /// <summary>
        /// 生成命令记录
        /// </summary>
        private List<GameCommand> SpawnCommands;

        /// <summary>
        /// 初始化生成记录
        /// </summary>
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

        /// <summary>
        /// 保存生成记录
        /// </summary>
        private void SaveSpawnRecord()
        {
            File.WriteAllText(SpawnCommandsRecordPath, GetCommandsText(SpawnCommands));
        }

        /// <summary>
        /// 生成记录列表选中项改变时触发
        /// </summary>
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

        /// <summary>
        /// 点击保存生成记录按钮时触发
        /// </summary>
        private void BtnSaveSpawnLog_Click(object sender, EventArgs e)
        {
            // 不再重新生成，直接记录当前命令行的内容
            //if (GenSpawnEntityCommand())
            {
                var cmd = new GameCommand($"{ListEntity.SelectedItem} | {TxtCommand.Text}", TxtCommand.Text);
                SpawnCommands.Add(cmd);
                ListSpawnLogs.Items.Add(cmd.Name);
                SaveSpawnRecord();
            }
        }

        /// <summary>
        /// 点击移除生成记录按钮时触发
        /// </summary>
        private void BtnRemoveSpawnLog_Click(object sender, EventArgs e)
        {
            if (ListSpawnLogs.SelectedIndex >= 0)
            {
                SpawnCommands.RemoveAt(ListSpawnLogs.SelectedIndex);
                ListSpawnLogs.Items.RemoveAt(ListSpawnLogs.SelectedIndex);
                SaveSpawnRecord();
            }
        }

        /// <summary>
        /// 点击清空生成记录按钮时触发
        /// </summary>
        private void LblClearSpawnLogs_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Resources.AskConfirmDeletion, Resources.Tips, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SpawnCommands.Clear();
                ListSpawnLogs.Items.Clear();
                SaveSpawnRecord();
            }
        }

        #endregion -- 生成记录 --

        #region -- 生成参数 --

        /// <summary>
        /// 生成页面输入改变时触发
        /// </summary>
        private void SpawnEntityInputChanged(object sender, EventArgs e)
        {
            if (ListEntity.SelectedIndex == -1) return;
            var selectedItem = ListEntity.SelectedItem as string;
            var id = ItemMap.ToId(selectedItem);

            if (CommandVersion.Check(CommandVersion.V1_3_1))
            {
                var args = id.ToString();
                void CheckAndConnect(NumericUpDown input, int value, string prefix)
                {
                    if (input.Value > value)
                        args += prefix + input.Value;
                }
                CheckAndConnect(NUDEntityAmout, 1, " x");
                CheckAndConnect(NUDEntityLevel, 1, " lv");
                CheckAndConnect(NUDEntityHp, -1, " hp");
                CheckAndConnect(NUDEntityMaxHp, 0, " maxhp");
                CheckAndConnect(NUDEntityAtk, -1, " atk");
                CheckAndConnect(NUDEntityDef, -1, " def");
                if (NUDEntityPosX.Value != 0 || NUDEntityPosY.Value != 0 || NUDEntityPosZ.Value != 0)
                    args += $" {NUDEntityPosX.Value} {NUDEntityPosY.Value} {NUDEntityPosZ.Value}";
                SetCommand("/spawn", args);
            }
            else
            {
                SetCommand("/spawn", $"{id} {NUDEntityAmout.Value} {NUDEntityLevel.Value}");
            }
        }

        #endregion

        #region -- 攻击修改参数 --

        /// <summary>
        /// 攻击修改插件链接标签点击时触发
        /// </summary>
        private void LnkAttackModifierPlugin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenURL("https://github.com/NotThorny/AttackModifier");
        }

        /// <summary>
        /// 攻击修改输入改变事件
        /// </summary>
        private void OnAttackModifierInputChanged(object sender, EventArgs e)
        {
            if (ListEntity.SelectedIndex == -1) return;
            var selectedItem = ListEntity.SelectedItem as string;
            var id = ItemMap.ToId(selectedItem);
            char skill;
            if (RbAtE.Checked)
            {
                skill = 'e';
                TxtAtEntityE.Text = selectedItem;
            }
            else if (RbAtQ.Checked)
            {
                skill = 'q';
                TxtAtEntityQ.Text = selectedItem;
            }
            else
            {
                skill = 'n';
                TxtAtEntityN.Text = selectedItem;
            }
            SetCommand("/at", $"set {skill} {id}");
        }

        /// <summary>
        /// 攻击修改页面命令事件
        /// </summary>
        private void OnAttackModifierCommand(object sender, EventArgs e)
        {
            SetCommand("/at", (sender as Control).Tag as string);
        }

        #endregion

        #region -- 攻击注入参数 --

        /// <summary>
        /// 攻击注入插件链接标签点击时触发
        /// </summary>
        private void LnkAttackInfusedWithItem_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenURL("https://github.com/snoobi-seggs/AttackInfusedWithItem");
        }

        /// <summary>
        /// 攻击注入页面命令事件
        /// </summary>
        private void OnAttackInfusedCommand(object sender, EventArgs e)
        {
            SetCommand("/snoospawn", (sender as Control).Tag as string);
        }

        /// <summary>
        /// 点击攻击注入按钮时触发
        /// </summary>
        private void BtnAttackInfuse_Click(object sender, EventArgs e)
        {
            if (ListEntity.SelectedIndex == -1) return;
            var selectedItem = ListEntity.SelectedItem as string;
            var id = ItemMap.ToId(selectedItem);

            var args = string.Empty;
            var flag = false;
            void ConnectArg(NumericUpDown input)
            {
                if (flag || input.Value != 0)
                {
                    flag = true;
                    args = " " + input.Value + args;
                }
            }
            ConnectArg(NUDAiwiRotateZ);
            ConnectArg(NUDAiwiRotateY);
            ConnectArg(NUDAiwiRotateX);
            ConnectArg(NUDAiwiSpread);
            ConnectArg(NUDAiwiCount);
            ConnectArg(NUDAiwiHeight);
            ConnectArg(NUDAiwiRadius);
            SetCommand("/snoospawn", id.ToString() + args);
            //SetCommand("/at", $"{id} {NUDAiwiRadius.Value} {NUDAiwiHeight.Value} {NUDAiwiCount.Value} {NUDAiwiSpread.Value} {NUDAiwiRotateX.Value} {NUDAiwiRotateY.Value} {NUDAiwiRotateZ.Value}");

        }
        #endregion

        #endregion - 生成 Spawns -

        #region - 场景 Scenes -

        /// <summary>
        /// 初始化场景列表
        /// </summary>
        private void InitScenes()
        {
            ListScenes.Items.Clear();
            ListScenes.Items.AddRange(GameData.Scenes.Lines);

            CmbClimateType.Items.Clear();
            CmbClimateType.Items.AddRange(Resources.ClimateType.Split(','));
        }

        /// <summary>
        /// 场景列表过滤器输入项改变时触发
        /// </summary>
        private void TxtSceneFilter_TextChanged(object sender, EventArgs e)
        {
            UIUtil.ListBoxFilter(ListScenes, GameData.Scenes.Lines, TxtSceneFilter.Text);
        }

        /// <summary>
        /// 场景列表选中项改变时触发
        /// </summary>
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
            var id = ItemMap.ToId(name);
            if (CommandVersion.Check(CommandVersion.V1_2_2))
            {
                SetCommand("/scene", id.ToString());
            }
            else
            {
                SetCommand("/tp ~ ~ ~", id.ToString());
            }
        }

        /// <summary>
        /// 气候类型列表
        /// </summary>
        static readonly string[] climateTypes = { "none", "sunny", "cloudy", "rain", "thunderstorm", "snow", "mist" };

        /// <summary>
        /// 气候类型下拉框选中项改变时触发
        /// </summary>
        private void CmbClimateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbClimateType.SelectedIndex < 0)
                return;
            if (CommandVersion.Check(CommandVersion.V1_2_2))
                SetCommand("/weather", CmbClimateType.SelectedIndex < climateTypes.Length ? climateTypes[CmbClimateType.SelectedIndex] : "none");
            else
                SetCommand("/weather", $"0 {CmbClimateType.SelectedIndex}");
        }

        /// <summary>
        /// 点击传送按钮时触发
        /// </summary>
        private void BtnTeleport_Click(object sender, EventArgs e)
        {
            string args = $"{NUDTpX.Value} {NUDTpY.Value} {NUDTpZ.Value}";
            if (ChkIncludeSceneId.Checked && ListScenes.SelectedIndex != -1)
                args += $" {GameData.Scenes.Ids[ListScenes.SelectedIndex]}";
            SetCommand("/tp", args);
        }

        #endregion - 场景 Scenes -

        #region - 管理 Management -

        /// <summary>
        /// 初始化权限列表
        /// </summary>
        private void InitPermList()
        {
            CmbPerm.Items.Clear();
            CmbPerm.Items.AddRange(Resources.Permissions.Split('\n').Select(l => l.Trim()).ToArray());
        }

        /// <summary>
        /// 点击授权按钮时触发
        /// </summary>
        private void BtnPermClick(object sender, EventArgs e)
        {
            var uid = NUDPermUID.Value;
            var perm = CmbPerm.Text.Trim();
            var act = (sender as Button).Tag.ToString();
            if (act == "list" || act == "clear")
            {
                SetCommand($"/permission {act} @{uid}");
            }
            else
            {
                if (string.IsNullOrEmpty(perm))
                {
                    MessageBox.Show(Resources.PermissionCannotBeEmpty, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                SetCommand($"/permission {act} @{uid} {perm}");
            }
        }

        /// <summary>
        /// 账号相关按钮点击时触发，Tag包含子命令
        /// </summary>
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

        /// <summary>
        /// 点击封禁按钮时触发
        /// </summary>
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

        /// <summary>
        /// 点击解封按钮时触发
        /// </summary>
        private void BtnUnban_Click(object sender, EventArgs e)
        {
            SetCommand($"/unban @{NUDBanUID.Value}");
        }

        #endregion - 管理 Management -

        #region - 邮件 Mail -

        /// <summary>
        /// 初始化邮件页面
        /// </summary>
        private void InitMailPage()
        {
            TxtMailSender.Text = Settings.Default.DefaultMailSender;
            LoadMailSelectableItems();
        }

        /// <summary>
        /// 保存邮件设置
        /// </summary>
        private void SaveMailSettings()
        {
            Settings.Default.DefaultMailSender = TxtMailSender.Text;
        }

        /// <summary>
        /// 点击清空邮件内容时触发
        /// </summary>
        private void LblClearMailContent_Click(object sender, EventArgs e)
        {
            TxtMailContent.Clear();
        }

        /// <summary>
        /// 点击发送邮件时触发
        /// </summary>
        private void BtnSendMail_Click(object sender, EventArgs e)
        {
            var mail = new Mail
            {
                Title = TxtMailTitle.Text.Trim(),
                Sender = TxtMailSender.Text.Trim(),
                Content = TxtMailContent.Text.Trim(),
                Recipient = RbMailSendToAll.Checked ? 0 : (int)NUDMailRecipient.Value,
                ItemList = new List<MailItem>(MailItems),
                SendTime = DateTime.Now,
            };

            if (mail.Title == "" || mail.Sender == "" || mail.Content == "")
            {
                MessageBox.Show(Resources.EmptyInputTip, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (mail.SendToAll)
            {
                MessageBox.Show(Resources.MailSendToAllWarning, Resources.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            var cmd = $"/sendMail {(mail.SendToAll ? "all" : mail.Recipient.ToString())} |" +
                $"/sendMail {mail.Title} |" +
                $"/sendMail {mail.Content.Replace("\r", "\\r").Replace("\n", "\\n")} |" +
                $"/sendMail {mail.Sender} |";
            foreach (var item in mail.ItemList)
                cmd += $"/sendMail {item.ItemId} {item.ItemCount} {item.ItemLevel} |";
            cmd += "/sendMail finish";

            SetCommand(cmd);
            AddMailToList(mail);
        }

        /// <summary>
        /// 展示邮件
        /// </summary>
        /// <param name="mail"></param>
        private void ShowMail(Mail mail)
        {
            TxtMailTitle.Text = mail.Title;
            TxtMailSender.Text = mail.Sender;
            TxtMailContent.Text = mail.Content;
            NUDMailRecipient.Value = mail.Recipient;
            RbMailSendToAll.Checked = mail.SendToAll;
            RbMailSendToPlayer.Checked = !mail.SendToAll;
            ShowMailItems(mail.ItemList);
        }


        #region -- 邮件附件列表 Mail items --

        /// <summary>
        /// 当前邮件附件列表
        /// </summary>
        private readonly List<MailItem> MailItems = new List<MailItem>();

        /// <summary>
        /// 展示邮件附件列表
        /// </summary>
        /// <param name="items"></param>
        private void ShowMailItems(List<MailItem> items)
        {
            MailItems.Clear();
            MailItems.AddRange(items);
            ListMailItems.BeginUpdate();
            ListMailItems.Items.Clear();
            ListMailItems.Items.AddRange(items.Select(it => it.ToString()).ToArray());
            ListMailItems.EndUpdate();
        }

        /// <summary>
        /// 点击添加邮件附件项时触发
        /// </summary>
        private void BtnAddMailItem_Click(object sender, EventArgs e)
        {
            if (ListMailSelectableItems.SelectedIndex == -1)
                return;
            var item = ListMailSelectableItems.SelectedItem as string;
            var itemId = ItemMap.ToId(item);
            var mailItem = new MailItem
            {
                ItemId = itemId,
                ItemCount = (int)NUDMailItemCount.Value,
                ItemLevel = (int)NUDMailItemLevel.Value,
            };
            MailItems.Add(mailItem);
            ListMailItems.Items.Add(mailItem.ToString());
        }

        /// <summary>
        /// 点击删除邮件附件项时触发
        /// </summary>
        private void BtnDeleteMailItem_Click(object sender, EventArgs e)
        {
            if (ListMailItems.SelectedIndex == -1) return;

            MailItems.RemoveAt(ListMailItems.SelectedIndex);
            ListMailItems.Items.RemoveAt(ListMailItems.SelectedIndex);
        }

        #endregion

        #region -- 邮件附件可选列表 Mail item selectable list --

        private string[] MailSelectableItems;
        
        /// <summary>
        /// 加载附件可选项列表
        /// </summary>
        private void LoadMailSelectableItems()
        {
            MailSelectableItems = new string[GameData.Items.Count + GameData.Weapons.Count + GameData.Artifacts.Count];
            int i = 0;
            GameData.Items.Lines.CopyTo(MailSelectableItems, i); i += GameData.Items.Count;
            GameData.Weapons.Lines.CopyTo(MailSelectableItems, i); i += GameData.Weapons.Count;
            GameData.Artifacts.Lines.CopyTo(MailSelectableItems, i); i += GameData.Artifacts.Count;

            Array.Sort(MailSelectableItems, (a, b) => ItemMap.ToId(a) - ItemMap.ToId(b));

            ListMailSelectableItems.Items.Clear();
            ListMailSelectableItems.Items.AddRange(MailSelectableItems);
        }

        /// <summary>
        /// 邮件页面物品列表过滤器文本改变时触发
        /// </summary>
        private void TxtMailSelectableItemFilter_TextChanged(object sender, EventArgs e)
        {
            UIUtil.ListBoxFilter(ListMailSelectableItems, MailSelectableItems, TxtMailSelectableItemFilter.Text);
        }

        #endregion

        #region -- 邮件列表 Mail list --

        /// <summary>
        /// 获取物品记录文件路径
        /// </summary>
        private readonly string MailListPath = Path.Combine(Application.LocalUserAppDataPath, "MailList.json");

        /// <summary>
        /// 邮件列表
        /// </summary>
        private List<Mail> MailList = new List<Mail>();

        /// <summary>
        /// 初始化邮件列表
        /// </summary>
        private void InitMailList()
        {
            if (File.Exists(MailListPath))
            {
                MailList = JsonConvert.DeserializeObject<List<Mail>>(File.ReadAllText(MailListPath));
                ListMailList.Items.AddRange(MailList.Select(it => it.ToString()).ToArray());
            }
            else
            {
                MailList = new List<Mail>();
            }
        }

        /// <summary>
        /// 保存邮件列表
        /// </summary>
        private void SaveMailList()
        {
            File.WriteAllText(MailListPath, JsonConvert.SerializeObject(MailList));
        }

        /// <summary>
        /// 添加邮件到列表
        /// </summary>
        /// <param name="mail">邮件</param>
        private void AddMailToList(Mail mail)
        {
            MailList.Add(mail);
            ListMailList.Items.Add(mail.ToString());
            SaveMailList();
        }

        /// <summary>
        /// 邮件列表选中项改变时发生
        /// </summary>
        private void ListMailList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListMailList.SelectedIndex == -1) return;
            // 显示选中邮件
            var mail = MailList[ListMailList.SelectedIndex];
            ShowMail(mail);
        }

        /// <summary>
        /// 点击删除邮件按钮时触发
        /// </summary>
        private void BtnRemoveMail_Click(object sender, EventArgs e)
        {
            if (ListMailList.SelectedIndex == -1) return;
            MailList.RemoveAt(ListMailList.SelectedIndex);
            ListMailList.Items.RemoveAt(ListMailList.SelectedIndex);
            SaveMailList();
        }

        /// <summary>
        /// 点击清空邮件列表按钮时触发
        /// </summary>
        private void BtnClearMail_Click(object sender, EventArgs e)
        {
            if (MailList.Count == 0) return;
            if (MessageBox.Show(Resources.AskConfirmDeletion, Resources.Tips, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ListMailList.Items.Clear();
                MailList.Clear();
                SaveMailList();
            }
        }

        #endregion

        #endregion

        #region - 关于 About -

        /// <summary>
        /// 点击Github链接时触发
        /// </summary>
        private void LnkGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenURL("https://github.com/jie65535/GrasscutterCommandGenerator");
        }

        #endregion - 关于 About -

        #region - 命令 Command -

        /// <summary>
        /// 设置命令
        /// </summary>
        /// <param name="command">命令</param>
        private void SetCommand(string command)
        {
            TxtCommand.Text = command;
            if (ChkAutoCopy.Checked)
                CopyCommand();
            if (ModifierKeys == Keys.Control)
                OnOpenCommandInvoke();
        }

        /// <summary>
        /// 设置带参数的命令
        /// </summary>
        /// <param name="command">命令</param>
        /// <param name="args">参数</param>
        private void SetCommand(string command, string args)
        {
            if (ChkIncludeUID.Checked)
                SetCommand($"{command} @{NUDUid.Value} {args.Trim()}");
            else
                SetCommand($"{command} {args.Trim()}");
        }

        /// <summary>
        /// 点击复制按钮时触发
        /// </summary>
        private async void BtnCopy_Click(object sender, EventArgs e)
        {
            CopyCommand();
            await UIUtil.ButtonComplete(BtnCopy);
        }

        /// <summary>
        /// 复制命令
        /// </summary>
        private void CopyCommand()
        {
            if (!string.IsNullOrEmpty(TxtCommand.Text))
                Clipboard.SetText(TxtCommand.Text);
        }

        /// <summary>
        /// 开放命令执行时触发
        /// </summary>
        private void OnOpenCommandInvoke()
        {
            BtnInvokeOpenCommand_Click(BtnInvokeOpenCommand, EventArgs.Empty);
        }

        /// <summary>
        /// 点击执行开放命令按钮时触发
        /// </summary>
        private async void BtnInvokeOpenCommand_Click(object sender, EventArgs e)
        {
            if (!BtnInvokeOpenCommand.Enabled) return;
            if (TxtCommand.Text.Length < 2)
            {
                ShowTip(Resources.CommandContentCannotBeEmpty, TxtCommand);
                return;
            }
            if (TxtCommand.Text.IndexOf('|') == -1)
                await RunCommands(FormatCommand(TxtCommand.Text));
            else
                await RunCommands(TxtCommand.Text.Split('|').Select(it => FormatCommand(it)).ToArray());
        }

        /// <summary>
        /// 格式化命令
        /// （去除收尾空白，替换换行）
        /// </summary>
        /// <param name="raw">原始输入</param>
        /// <returns>格式化后可执行命令</returns>
        private string FormatCommand(string raw)
        {
            return raw.Trim().Replace("\\r", "\r").Replace("\\n", "\n");
        }

        /// <summary>
        /// 运行命令
        /// </summary>
        /// <param name="commands">命令列表</param>
        /// <returns>是否执行成功</returns>
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
                    var cmd = command.TrimStart('/');
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

        /// <summary>
        /// 命令日志最小高度
        /// </summary>
        private const int TxtCommandRunLogMinHeight = 150;

        /// <summary>
        /// 命令日志文本框
        /// </summary>
        private TextBox TxtCommandRunLog;

        /// <summary>
        /// 展开命令记录（可重入）
        /// </summary>
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

        #endregion - 命令 Command -

        #region - 通用 General -

        /// <summary>
        /// 窗口按键按下时触发
        /// </summary>
        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                // F5 为执行命令
                OnOpenCommandInvoke();
            }
        }

        /// <summary>
        /// 提示气泡对象
        /// </summary>
        private readonly ToolTip TTip = new ToolTip();

        /// <summary>
        /// 在指定控件上显示提示气泡
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="control">控件</param>
        private void ShowTip(string message, Control control)
        {
            TTip.Show(message, control, 0, control.Size.Height, 3000);
        }

        #endregion - 通用 General -

        #region - 命令记录 Command Logs -

        /// <summary>
        /// 获取命令记录
        /// （反序列化）
        /// </summary>
        /// <param name="commandsText">命令记录文本（示例："标签1\n命令1\n标签2\n命令2..."）</param>
        /// <returns>命令列表</returns>
        private List<GameCommand> GetCommands(string commandsText)
        {
            var lines = commandsText.Split('\n');
            List<GameCommand> commands = new List<GameCommand>(lines.Length / 2);
            for (int i = 0; i < lines.Length - 1; i += 2)
                commands.Add(new GameCommand(lines[i].Trim(), lines[i + 1].Trim()));
            return commands;
        }

        /// <summary>
        /// 获取命令记录文本
        /// （序列化）
        /// </summary>
        /// <param name="commands">命令列表</param>
        /// <returns>命令记录文本（示例："标签1\n命令1\n标签2\n命令2..."）</returns>
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

        #endregion - 命令记录 Command Logs -

        #region - 远程 Remote -

        /// <summary>
        /// 开放命令接口
        /// </summary>
        private OpenCommandAPI OC;

        /// <summary>
        /// 进入远程页面时触发
        /// </summary>
        private void TPRemoteCall_Enter(object sender, EventArgs e)
        {
#if !DEBUG
            if (string.IsNullOrEmpty(Settings.Default.Host) || string.IsNullOrEmpty(Settings.Default.TokenCache))
            {
                // 自动尝试查询本地服务端地址，降低使用门槛
                Task.Run(async () =>
                {
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
#endif
        }

        /// <summary>
        /// 初始化开放命令
        /// </summary>
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
        }

        /// <summary>
        /// 保存开放命令参数
        /// </summary>
        private void SaveOpenCommand()
        {
            Settings.Default.RemoteUid = NUDRemotePlayerId.Value;
            Settings.Default.Host = TxtHost.Text;
            Settings.Default.TokenCache = OC?.Token;
        }

        /// <summary>
        /// 更新服务器状态
        /// </summary>
        /// <param name="host">主机地址</param>
        private async Task UpdateServerStatus(string host)
        {
            // "http://127.0.0.1/" -> "http://127.0.0.1"
            host = host.TrimEnd('/');
            var status = await DispatchServerAPI.QueryServerStatus(host);
            LblServerVersion.Text = status.Version;
            if (status.MaxPlayer >= 0)
                LblPlayerCount.Text = $"{status.PlayerCount}/{status.MaxPlayer}";
            else
                LblPlayerCount.Text = status.PlayerCount.ToString();
        }
        
        /// <summary>
        /// 点击查询服务器状态按钮时触发
        /// </summary>
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

        /// <summary>
        /// 点击发送校验码按钮时触发
        /// </summary>
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

        /// <summary>
        /// 点击连接到开放命令按钮时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 点击控制台连接按钮时触发
        /// </summary>
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

        /// <summary>
        /// 点击开放命令标签时触发
        /// </summary>
        private void LnkOpenCommandLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenURL("https://github.com/jie65535/gc-opencommand-plugin");
        }

        /// <summary>
        /// 点击帮助连接标签时触发
        /// </summary>
        private void LnkRCHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(Resources.OpenCommandHelp, Resources.Help, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 点击库存扫描链接标签时触发
        /// </summary>
        private void LnkInventoryKamera_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenURL("https://github.com/Andrewthe13th/Inventory_Kamera");
        }

        /// <summary>
        /// 点击GOOD帮助链接标签时触发
        /// </summary>
        private void LnkGOODHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenURL("https://frzyc.github.io/genshin-optimizer/#/doc");
        }

        /// <summary>
        /// 点击链接帮助标签时触发
        /// </summary>
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

        /// <summary>
        /// 使用浏览器打开网址
        /// </summary>
        /// <param name="url">网址</param>
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

        #endregion - 远程 Remote -

        #region - 导入存档 GOOD -

        /// <summary>
        /// 点击GOOD导入存档按钮时触发
        /// </summary>
        async private void ButtonOpenGOODImport_Click(object sender, EventArgs e)
        {
            if (OC == null || !OC.CanInvoke)
            {
                ShowTip(Resources.RequireOpenCommandTip, ButtonOpenGOODImport);
                return;
            }

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
                                {
                                    if (CommandVersion.Check(CommandVersion.V1_4_1))
                                    {
                                        // 取最低的技能等级
                                        var skillLevel = Math.Min(Math.Min(character.Talents.Auto, character.Talents.Skill), character.Talents.Burst);
                                        commands_list.Add($"/give {character_id} lv{character.Level} c{character.Constellation} sl{skillLevel}");
                                    }
                                    else
                                        commands_list.Add($"/give {character_id} lv{character.Level} c{character.Constellation}");
                                }
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
                                commands_list.Add($"/give {weapon_id} lv{weapon.Level} r{weapon.RefinementLevel}");
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
                            var artifact_id = artifact_set_id * 1000 + artifact.Rarity * 100 + GOODData.ArtifactSlotMap[artifact.GearSlot] * 10;
                            for (int i = 4; i > 0; i--)
                            {
                                if (Array.IndexOf(GameData.Artifacts.Ids, artifact_id + i) != -1)
                                {
                                    artifact_id += i;
                                    break;
                                }
                            }
                            if (artifact_id % 10 == 0)
                                artifact_id += 4;

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
                            commands_list.Add($"/give {artifact_id} lv{artifact.Level} {artifact_mainStat_id} {artifact_substats}");
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

        #endregion

        #region - 任务 Quests -

        /// <summary>
        /// 初始化任务列表
        /// </summary>
        private void InitQuestList()
        {
            QuestFilterChanged(null, EventArgs.Empty);
        }

        /// <summary>
        /// 任务列表过滤器文本改变时触发
        /// </summary>
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

        /// <summary>
        /// 任务相关按钮点击时触发（Tag带子命令）
        /// </summary>
        private void QuestButsClicked(object sender, EventArgs e)
        {
            if (ListQuest.SelectedIndex == -1)
                return;
            var item = ListQuest.SelectedItem as string;
            var id = ItemMap.ToId(item);
            SetCommand("/quest", $"{(sender as Button).Tag} {id}");
        }

        #endregion - 任务 Quests -

    }
}
