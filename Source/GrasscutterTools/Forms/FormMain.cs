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
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using GrasscutterTools.Game;
using GrasscutterTools.Pages;
using GrasscutterTools.Properties;
using GrasscutterTools.Utils;

namespace GrasscutterTools.Forms
{
    public partial class FormMain : Form
    {
        #region - 初始化 Init -

        private const string TAG = "FormMain";

        public FormMain()
        {
            Logger.I(TAG, "FormMain ctor enter");
            InitializeComponent();
            Icon = Resources.IconGrasscutter;

            if (DesignMode) return;

            try
            {
                var location = Settings.Default.MainFormLocation;
                // 还原窗体位置
                if (location != default && location.X >= 0 && location.Y >= 0)
                {
                    StartPosition = FormStartPosition.Manual;
                    Location = location;
                    Logger.I(TAG, "Restore window location: " + Location.ToString());
                }

                // 还原窗体大小
                if (Settings.Default.MainFormSize != default)
                {
                    Size = Settings.Default.MainFormSize;
                    Logger.I(TAG, "Restore window size: " + Size.ToString());
                }

                // 初始化页面
                InitPages();
            }
            catch (Exception ex)
            {
                Logger.E(TAG, "Loading settings error", ex);
                MessageBox.Show(Resources.SettingLoadError + ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Logger.I(TAG, "FormMain ctor completed");
        }

        /// <summary>
        /// 初始化并创建所有页面
        /// </summary>
        private void InitPages()
        {
            Logger.I(TAG, "InitPages enter");
            TCMain.SuspendLayout();
            var ph = CreatePage<PageHome>();
            ph.OnLanguageChanged = () => FormMain_Load(this, EventArgs.Empty);
            TPHome.Controls.Add(ph);
            var poc = CreatePage<PageOpenCommand>();
            poc.ShowTipInRunButton = msg => ShowTip(msg, BtnInvokeOpenCommand);
            TPRemoteCall.Controls.Add(poc);
            TPCustom.Controls.Add(CreatePage<PageCustomCommands>());
            TPArtifact.Controls.Add(CreatePage<PageGiveArtifact>());
            TPSpawn.Controls.Add(CreatePage<PageSpawn>());
            TPItem.Controls.Add(CreatePage<PageGiveItem>());
            TPAvatar.Controls.Add(CreatePage<PageAvatar>());
            TPWeapon.Controls.Add(CreatePage<PageGiveWeapon>());
            TPManage.Controls.Add(CreatePage<PageManagement>());
            TPMail.Controls.Add(CreatePage<PageMail>());
            TPQuest.Controls.Add(CreatePage<PageQuest>());
            TPScene.Controls.Add(CreatePage<PageScene>());
            TPAbout.Controls.Add(CreatePage<PageAbout>());
            TCMain.ResumeLayout();
            Logger.I(TAG, "InitPages completed");
        }

        /// <summary>
        /// 创建指定类型页面
        /// </summary>
        /// <typeparam name="T">页面类型，必须继承BasePage</typeparam>
        /// <returns>页面实例</returns>
        private T CreatePage<T>() where T : BasePage, new()
        {
            var page = new T
            {
                SetCommand = SetCommand,
                RunCommands = RunCommands,
                GetCommand = () => CmbCommand.Text,
                Dock = DockStyle.Fill,
                Name = typeof(T).Name,
            };
            return page;
        }

        /// <summary>
        /// 窗体载入时触发（切换语言时会重新载入）
        /// </summary>
        private void FormMain_Load(object sender, EventArgs e)
        {
            Logger.I(TAG, "FormMain_Load enter");
            Text += "  - by jie65535  - v" + Common.AppVersion.ToString(3);
#if DEBUG
            Text += "-debug";
#endif
            if (DesignMode) return;

            // 恢复自动复制选项状态
            ChkAutoCopy.Checked = Settings.Default.AutoCopy;

            // 加载游戏ID资源
            GameData.LoadResources();

            // 遍历每一个页面重新加载
            foreach (TabPage tp in TCMain.Controls)
            {
                if (tp.Controls.Count > 0 && tp.Controls[0] is BasePage page)
                {
                    Logger.I(TAG, $"{page.Name} OnLoad enter");
                    page.OnLoad();
                    Logger.I(TAG, $"{page.Name} OnLoad completed");
                }
            }
            Logger.I(TAG, "FormMain_Load completed");
        }

        /// <summary>
        /// 窗口关闭后触发
        /// </summary>
        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Logger.I(TAG, "FormMain FormClosed enter");
            // 遍历每一个页面，通知关闭
            foreach (TabPage tp in TCMain.Controls)
            {
                if (tp.Controls.Count > 0 && tp.Controls[0] is BasePage page)
                    page.OnClosed();
            }

            // 保存当前设置
            SaveSettings();
            Logger.I(TAG, "FormMain FormClosed completed");
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

                // 保存设置
                Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resources.SettingSaveError + ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion - 初始化 Init -

        #region - 命令 Command -

        /// <summary>
        /// 设置命令
        /// </summary>
        /// <param name="command">命令</param>
        private void SetCommand(string command)
        {
            Logger.I(TAG, $"SetCommand(\"{command}\")");
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
            if (Settings.Default.IsIncludeUID)
                SetCommand($"{command} @{Settings.Default.Uid} {args.Trim()}");
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
            if (Common.OC == null || !Common.OC.CanInvoke)
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
                        Logger.I(TAG, "RunCommand:" + cmd);
                        var msg = await Common.OC.Invoke(cmd);
                        TxtCommandRunLog.AppendText(string.IsNullOrEmpty(msg) ? "OK" : msg);
                        TxtCommandRunLog.AppendText(Environment.NewLine);
                    }
                    catch (Exception ex)
                    {
                        Logger.W(TAG, "RunCommand Error:", ex);
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
    }
}