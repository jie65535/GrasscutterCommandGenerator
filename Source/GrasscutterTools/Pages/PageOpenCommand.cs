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
using System.Threading.Tasks;
using System.Windows.Forms;
using GrasscutterTools.DispatchServer;
using GrasscutterTools.DispatchServer.Model;
using GrasscutterTools.Game;
using GrasscutterTools.GOOD;
using GrasscutterTools.OpenCommand;
using GrasscutterTools.Properties;
using GrasscutterTools.Utils;

using Newtonsoft.Json;

namespace GrasscutterTools.Pages
{
    internal partial class PageOpenCommand : BasePage
    {
        public override string Text => Resources.PageOpenCommandTitle;

        private const string TAG = nameof(PageOpenCommand);

        public PageOpenCommand()
        {
            InitializeComponent();
            if (DesignMode) return;

            InitServerRecords();
            if (!string.IsNullOrEmpty(Settings.Default.Host))
                TxtHost.Items.Add(Settings.Default.Host);
            TxtHost.Items.AddRange(ServerRecords.Select(it => it.Host).ToArray());

            NUDRemotePlayerId.Value = Settings.Default.RemoteUid;
            TxtHost.Text = Settings.Default.Host;
            if (!string.IsNullOrEmpty(Settings.Default.Host) && !string.IsNullOrEmpty(Settings.Default.TokenCache))
            {
                Common.OC = new OpenCommandAPI(Settings.Default.Host, Settings.Default.TokenCache);
                TxtToken.Text = Settings.Default.TokenCache;
                Task.Delay(1000).ContinueWith(_ => ShowTipInRunButton?.Invoke(Resources.TokenRestoredFromCache));
            }

            if (string.IsNullOrEmpty(TxtHost.Text))
            {
                TxtHost.Items.Add("http://127.0.0.1:443");
                TxtHost.SelectedIndex = 0;
            }
        }

        #region - 服务器记录 -

        private class ServerRecord
        {
            public string Tag { get; set; }
            public string Host { get; set; }
            public int Uid { get; set; }
            public string Token { get; set; }
        }

        private readonly string ServerRecordsFilePath = Common.GetAppDataFile("Servers.json");
        private List<ServerRecord> ServerRecords = new List<ServerRecord>();

        //{
        //    new ServerRecord
        //    {
        //        Host = "http://127.0.0.1:443",
        //        Tag = "Localhost",
        //        Token = "123456",
        //        Uid = 10001,
        //    }
        //};
        private void InitServerRecords()
        {
            if (!File.Exists(ServerRecordsFilePath))
                return;

            try
            {
                Logger.I(TAG, "Loading ServerRecords json file from: " + ServerRecordsFilePath);
                ServerRecords = JsonConvert.DeserializeObject<List<ServerRecord>>(File.ReadAllText(ServerRecordsFilePath));
            }
            catch (Exception ex)
            {
                Logger.W(TAG, "Parsing Servers.json failed.", ex);
            }
        }

        private void SaveServerRecords()
        {
            try
            {
                if (ServerRecords.Count == 0)
                    return;
                File.WriteAllText(ServerRecordsFilePath, JsonConvert.SerializeObject(ServerRecords));
            }
            catch (Exception ex)
            {
                Logger.W(TAG, "Save all server records failed.", ex);
            }
        }

        #endregion - 服务器记录 -

        /// <summary>
        /// 在运行按钮上显示提示，要求主窗口设置
        /// </summary>
        public Action<string> ShowTipInRunButton { get; set; }

        public override void OnEnter()
        {
#if !DEBUG
            if (string.IsNullOrEmpty(Settings.Default.Host) || string.IsNullOrEmpty(Settings.Default.TokenCache))
            {
                // 自动尝试查询本地服务端地址，降低使用门槛
                Task.Run(async () =>
                {
                    var localhostList = new[] {
                        "http://127.0.0.1:443",
                        "https://127.0.0.1",
                        "http://127.0.0.1",
                        "https://127.0.0.1:80",
                        "http://127.0.0.1:8080",
                        "https://127.0.0.1:8080",
                    };
                    foreach (var host in localhostList)
                    {
                        try
                        {
                            await UpdateServerStatus(host);
                            // 自动填写本地服务端地址
                            BeginInvoke(new Action(() => TxtHost.Text = host));
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
        /// 保存开放命令参数
        /// </summary>
        public override void OnClosed()
        {
            Settings.Default.RemoteUid = NUDRemotePlayerId.Value;
            Settings.Default.Host = TxtHost.Text;
            Settings.Default.TokenCache = Common.OC?.Token;
        }

        /// <summary>
        /// 更新服务器状态
        /// </summary>
        /// <param name="host">主机地址</param>
        private async Task UpdateServerStatus(string host)
        {
            var status = await DispatchServerAPI.QueryServerStatus(host);
            if (InvokeRequired)
                BeginInvoke(new Action<ServerStatus>(ShowServerStatus), status);
            else
                ShowServerStatus(status);
        }

        private void ShowServerStatus(ServerStatus status)
        {
            LblServerVersion.Text = status.Version;
            LblPlayerCount.Text = status.MaxPlayer > 0 ? $"{status.PlayerCount}/{status.MaxPlayer}" : status.PlayerCount.ToString();
        }

        /// <summary>
        /// 输入服务器地址按下回车时触发
        /// </summary>
        private void TxtHost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) BtnQueryServerStatus_Click(BtnQueryServerStatus, e);
        }

        /// <summary>
        /// 地址栏选中项改变时触发
        /// </summary>
        private void TxtHost_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TxtHost.SelectedIndex >= 0 && TxtHost.SelectedIndex < ServerRecords.Count)
            {
                // 还原记录
                var record = ServerRecords[TxtHost.SelectedIndex];
                TxtToken.Text = record.Token;
                NUDRemotePlayerId.Value = record.Uid;
            }
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
                // "http://127.0.0.1/" -> "http://127.0.0.1"
                var host = TxtHost.Text.TrimEnd('/');
                try
                {
                    await UpdateServerStatus(host);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Resources.QueryServerStatusFailed + ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Settings.Default.Host = host;

                var isOcEnabled = false;
                try
                {
                    Common.OC = new OpenCommandAPI(host);
                    isOcEnabled = await Common.OC.Ping();
                }
                catch (Exception ex)
                {
#if DEBUG
                    MessageBox.Show(ex.ToString(), Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                    MessageBox.Show(ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
                }

                if (isOcEnabled)
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
        /// 玩家ID输入框按下回车时触发
        /// </summary>
        private void NUDRemotePlayerId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) BtnSendVerificationCode_Click(BtnSendVerificationCode, e);
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
                await Common.OC.SendCode((int)NUDRemotePlayerId.Value);
                BtnConnectOpenCommand.Enabled = true;
                NUDVerificationCode.Enabled = true;
                NUDVerificationCode.Focus();
                for (int i = 60; i > 0 && !Common.OC.CanInvoke; i--)
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
        /// 验证码输入框按下回车时触发
        /// </summary>
        private void NUDVerificationCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) BtnConnectOpenCommand_Click(BtnConnectOpenCommand, e);
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
                await Common.OC.Verify((int)NUDVerificationCode.Value);
                GrpRemoteCommand.Enabled = false;
                ShowTipInRunButton?.Invoke(Resources.ConnectedTip);
                ButtonOpenGOODImport.Enabled = true;

                var r = ServerRecords.Find(it => it.Host == TxtHost.Text);
                if (r != null)
                {
                    r.Token = Common.OC.Token;
                    r.Uid = (int)NUDRemotePlayerId.Value;
                }
                else
                {
                    ServerRecords.Add(new ServerRecord
                    {
                        Host = Common.OC.Host,
                        Tag = "TODO",
                        Token = Common.OC.Token,
                        Uid = (int)NUDRemotePlayerId.Value
                    });
                    TxtHost.Items.Add(Common.OC.Host);
                }
                SaveServerRecords();
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
        /// Token 输入框按下回车时触发
        /// </summary>
        private void TxtToken_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) BtnConsoleConnect_Click(BtnConsoleConnect, e);
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
            Common.OC.Token = TxtToken.Text;
            BtnConnectOpenCommand_Click(sender, e);
        }

        /// <summary>
        /// 点击开放命令标签时触发
        /// </summary>
        private void LnkOpenCommandLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UIUtil.OpenURL("https://github.com/jie65535/gc-opencommand-plugin");
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
            UIUtil.OpenURL("https://github.com/Andrewthe13th/Inventory_Kamera");
        }

        /// <summary>
        /// 点击GOOD帮助链接标签时触发
        /// </summary>
        private void LnkGOODHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UIUtil.OpenURL("https://frzyc.github.io/genshin-optimizer/#/doc");
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

        #region - 导入存档 GOOD -

        /// <summary>
        /// 点击GOOD导入存档按钮时触发
        /// </summary>
        private async void ButtonOpenGOODImport_Click(object sender, EventArgs e)
        {
            if (Common.OC == null || !Common.OC.CanInvoke)
            {
                UIUtil.ShowTip(Resources.RequireOpenCommandTip, ButtonOpenGOODImport);
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

        #endregion - 导入存档 GOOD -
    }
}