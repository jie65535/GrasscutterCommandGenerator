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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GrasscutterTools.Game;
using GrasscutterTools.OpenCommand;
using GrasscutterTools.Properties;
using GrasscutterTools.Utils;

namespace GrasscutterTools.Forms
{
    public partial class FormMain : Form
    {
        #region - 初始化 Init -

        public FormMain()
        {
            InitializeComponent();
            Icon = Resources.IconGrasscutter;

            if (DesignMode) return;

            // 加载版本信息
            LoadVersion();

            // 加载设置
            LoadSettings();
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
            if (DesignMode) return;

            GameData.LoadResources();

            //LoadCustomCommands();
            //InitArtifactList();
            //InitGameItemList();
            //InitWeapons();
            //InitAvatars();
            //InitEntityList();
            //InitScenes();
            //InitStatList();
            //InitPermList();
            //InitQuestList();
            //InitMailPage();

            //ChangeTPArtifact();
        }

        /// <summary>
        /// 第一次显示窗体时触发
        /// </summary>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            // 还原窗体位置
            if (Settings.Default.MainFormLocation != default)
                Location = Settings.Default.MainFormLocation;
            // 还原窗体大小
            if (Settings.Default.MainFormSize != default)
                Size = Settings.Default.MainFormSize;
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
                //InitHomeSettings();

                // 初始化获取物品记录
                //InitGiveItemRecord();

                // 初始化生成记录
                //InitSpawnRecord();

                // 初始化开放命令
                //InitOpenCommand();

                // 初始化邮件列表
                //InitMailList();
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
                //SaveCustomCommands();

                // 保存开放命令设置
                //SaveOpenCommand();

                // 保存邮件设置
                //SaveMailSettings();

                // 保存默认设置
                Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resources.SettingSaveError + ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion - 初始化 Init -

        /// <summary>
        /// 命令版本
        /// </summary>
        private CommandVersion CommandVersion => Common.CommandVersion;

        #region - 命令 Command -

        /// <summary>
        /// 设置命令
        /// </summary>
        /// <param name="command">命令</param>
        private void SetCommand(string command)
        {
            var oldCommand = CmbCommand.Text;
            CmbCommand.Text = (ModifierKeys == Keys.Shift) ? $"{oldCommand} | {command}" : command;
            if (ChkAutoCopy.Checked)
                CopyCommand();
            AddCommandToList(command);

            if (ModifierKeys == Keys.Control)
            {
                OnOpenCommandInvoke();
            }
            else if (ModifierKeys == Keys.Alt)
            {
                OnOpenCommandInvoke();
                CmbCommand.Text = oldCommand;
            }
        }

        /// <summary>
        /// 添加命令到执行记录
        /// </summary>
        private void AddCommandToList(string command = "")
        {
            if (string.IsNullOrEmpty(command))
                command = CmbCommand.Text;
            if (!string.IsNullOrEmpty(command))
            {
                if (CmbCommand.Items.Count > 19)
                    CmbCommand.Items.RemoveAt(0);
                CmbCommand.Items.Add(command);
            }
        }

        /// <summary>
        /// 设置带参数的命令
        /// </summary>
        /// <param name="command">命令</param>
        /// <param name="args">参数</param>
        private void SetCommand(string command, string args)
        {
            //if (ChkIncludeUID.Checked)
            //    SetCommand($"{command} @{NUDUid.Value} {args.Trim()}");
            //else
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
            if (!string.IsNullOrEmpty(CmbCommand.Text))
                Clipboard.SetText(CmbCommand.Text);
        }

        /// <summary>
        /// 在命令行内按下回车时直接执行
        /// </summary>
        private void TxtCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) OnOpenCommandInvoke();
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
            var cmd = CmbCommand.Text;
            if (cmd.Length < 2)
            {
                ShowTip(Resources.CommandContentCannotBeEmpty, CmbCommand);
                return;
            }
            if (cmd.IndexOf('|') == -1)
                await RunCommands(FormatCommand(cmd));
            else
                await RunCommands(cmd.Split('|').Select(it => FormatCommand(it)).ToArray());
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

        /// <summary>
        /// 开放命令接口
        /// </summary>
        private OpenCommandAPI OC => Common.OC;
    }
}