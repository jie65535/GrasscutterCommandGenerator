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
using System.Collections.Specialized;
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
    internal partial class FormMain : Form
    {
        private const string TAG = nameof(FormMain);

        public static FormMain Instance { get; private set; }

        #region - 初始化 Init -

        public FormMain()
        {
            Logger.I(TAG, "FormMain ctor enter");

            Instance = this;

            InitializeComponent();
            Icon = Resources.IconGrasscutter;

            if (DesignMode) return;

            Common.KeyGo = new KeyGo(Handle);
            Common.KeyGo.HotKeyTriggerEvent += OnHotKeyTrigger;

            try
            {
                if (!Settings.Default.IsUpgraded)
                {
                    Settings.Default.Upgrade();
                    Settings.Default.IsUpgraded = true;
                }
            }
            catch (Exception ex)
            {
                Logger.W(TAG, "Upgrade Settings failed.", ex);
            }

            try
            {
                var location = Settings.Default.MainFormLocation;
                // 还原窗体位置
                if (location.X > 0 && location.Y > 0)
                {
                    StartPosition = FormStartPosition.Manual;
                    Location = location;
                    Logger.I(TAG, "Restore window location: " + Location);
                }

                // 还原窗体大小
                if (Settings.Default.MainFormSize != default)
                {
                    Size = Settings.Default.MainFormSize;
                    Logger.I(TAG, "Restore window size: " + Size);
                }

                // 还原导航容器间隔位置
                if (Settings.Default.NavContainerSplitterDistance >= NavContainer.Panel1MinSize)
                {
                    NavContainer.SplitterDistance = Settings.Default.NavContainerSplitterDistance;
                    Logger.I(TAG, "Restore NavContainer SplitterDistance: " + NavContainer.SplitterDistance);
                }

                // 还原窗口的不透明度
                if (Settings.Default.WindowOpacity < 100)
                {
                    Opacity = Settings.Default.WindowOpacity / 100.0;
                    Logger.I(TAG, "Restore window opacity: " + Opacity);
                }

                // 恢复自动复制选项状态
                ChkAutoCopy.Checked = Settings.Default.AutoCopy;

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
        /// 重载界面
        /// </summary>
        public void Reload()
        {
            FormMain_Load(this, null);
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

            // 加载页面导航
            UpdatePagesNav();

            // 加载游戏ID资源
            GameData.LoadResources();

            // 遍历每一个页面重新加载
            foreach (var page in Pages.Values)
            {
                Logger.I(TAG, $"{page.Name} OnLoad enter");
                page.OnLoad();
                Logger.I(TAG, $"{page.Name} OnLoad completed");
            }

            // 默认选中首页
            if (ListPages.SelectedIndex == -1)
                ListPages.SelectedIndex = 0;

            Logger.I(TAG, "FormMain_Load completed");
        }

        /// <summary>
        /// 窗口关闭后触发
        /// </summary>
        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Logger.I(TAG, "FormMain FormClosed enter");
            // 遍历每一个页面，通知关闭
            foreach (var page in Pages.Values)
            {
                Logger.I(TAG, $"{page.Name} OnClosed enter");
                page.OnClosed();
                Logger.I(TAG, $"{page.Name} OnClosed completed");
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
                // 记录窗口位置
                if (WindowState == FormWindowState.Normal)
                    Settings.Default.MainFormLocation = Location;
                // 如果命令窗口已经弹出了，则不要保存多余的高度
                Settings.Default.MainFormSize = TxtCommandRunLog != null ? new Size(Width, Height - TxtCommandRunLogMinHeight) : Size;
                // 记录导航容器分隔位置
                Settings.Default.NavContainerSplitterDistance = NavContainer.SplitterDistance;
                // 保存设置
                Settings.Default.Save();
            }
            catch (Exception ex)
            {
                Logger.E(TAG, "Save settings failed.", ex);
                MessageBox.Show(Resources.SettingSaveError + ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion - 初始化 Init -

        #region - 页面导航 Nav -

        public Dictionary<string, BasePage> Pages { get; private set; }

        /// <summary>
        /// 初始化并创建所有页面
        /// </summary>
        private void InitPages()
        {
            Logger.I(TAG, "InitPages enter");
            Pages = new Dictionary<string, BasePage>(32);
            CreatePage<PageHome>();
            var poc = CreatePage<PageOpenCommand>();
            poc.ShowTipInRunButton = msg => ShowTip(msg, BtnInvokeOpenCommand);
            CreatePage<PageProxy>();
            CreatePage<PageCustomCommands>();
            CreatePage<PageHotKey>();
            CreatePage<PageGiveArtifact>();
            CreatePage<PageSetProp>();
            CreatePage<PageSpawn>();
            CreatePage<PageGiveItem>();
            CreatePage<PageAvatar>();
            CreatePage<PageGiveWeapon>();
            CreatePage<PageScene>();
            CreatePage<PageSceneTag>();
            CreatePage<PageWeather>();
            CreatePage<PageTasks>();
            CreatePage<PageManagement>();
            CreatePage<PageMail>();
            CreatePage<PageQuest>();
            CreatePage<PageAchievement>();
            CreatePage<PageSettings>();
            CreatePage<PageAbout>();
#if DEBUG
            CreatePage<PageTools>();
#endif
            Logger.I(TAG, "InitPages completed");
        }

        /// <summary>
        /// 当前的页面选项卡顺序
        /// string Item1 = Page Name(Key)
        /// bool Item2 = IsVisible
        /// </summary>
        public List<Tuple<string, bool>> PageTabOrders { get; set; }

        /// <summary>
        /// 加载页面选项卡顺序
        /// </summary>
        private List<Tuple<string, bool>> LoadPageTabOrders()
        {
            if (PageTabOrders != null) return PageTabOrders;
            List<Tuple<string, bool>> tabOrders;
            if (!(Settings.Default.PageOrders?.Count > 0))
            {
                tabOrders = new List<Tuple<string, bool>>(Pages.Count);
                // 默认状态
                foreach (var tab in Pages)
                    tabOrders.Add(new Tuple<string, bool>(tab.Key, true));
            }
            else
            {
                tabOrders = new List<Tuple<string, bool>>(Settings.Default.PageOrders.Count);
                // 从设置中读取
                foreach (var item in Settings.Default.PageOrders)
                {
                    // 冒号分隔的项   "PageHome:1"  0=隐藏 1=显示
                    var sp = item.IndexOf(':');
                    if (sp == -1 || !int.TryParse(item.Substring(sp + 1), out var isVisible)) continue;
                    tabOrders.Add(new Tuple<string, bool>(item.Substring(0, sp), isVisible != 0));
                }
            }

            return tabOrders;
        }

        /// <summary>
        /// 重置页面选项卡顺序
        /// </summary>
        public void ResetPageTabOrders()
        {
            PageTabOrders = new List<Tuple<string, bool>>(Pages.Count);
            // 默认状态
            foreach (var tab in Pages)
                PageTabOrders.Add(new Tuple<string, bool>(tab.Key, true));
        }

        /// <summary>
        /// 保存页面选项卡顺序
        /// </summary>
        public void SavePageTabOrders()
        {
            if (PageTabOrders == null || PageTabOrders.Count == 0)
            {
                Settings.Default.PageOrders = null;
                return;
            }

            var setting = new StringCollection();
            // 冒号分隔的项   "PageHome:1"  0=隐藏 1=显示
            foreach (var pageOrder in PageTabOrders)
                setting.Add($"{pageOrder.Item1}:{(pageOrder.Item2?'1':'0')}");
            Settings.Default.PageOrders = setting;
        }

        /// <summary>
        /// 初始化页面导航
        /// </summary>
        public void UpdatePagesNav()
        {
            ListPages.BeginUpdate();
            ListPages.Items.Clear();

            // 以下代码主要是为了加载用户自定义顺序的选项卡
            var tabOrders = LoadPageTabOrders();
            // 程序更新后增加或减少了界面的情况
            if (tabOrders.Count != Pages.Count)
            {
                PageTabOrders = new List<Tuple<string, bool>>(Pages.Count);
                var i = 0;
                var pageKeys = Pages.Keys.ToList();
                foreach (var pageOrder in tabOrders)
                {
                    // 新增页面优先显示
                    if (i < pageKeys.Count && tabOrders.All(it => it.Item1 != pageKeys[i]))
                    {
                        PageTabOrders.Add(new Tuple<string, bool>(pageKeys[i], true));
                        ListPages.Items.Add(Pages[pageKeys[i]].Text);
                    }
                    // 尝试获取页面标题
                    if (Pages.TryGetValue(pageOrder.Item1, out var page))
                    {
                        // 仅设置为可见时添加
                        if (pageOrder.Item2)
                            ListPages.Items.Add(page.Text);
                        PageTabOrders.Add(new Tuple<string, bool>(pageOrder.Item1, pageOrder.Item2));
                    }
                    // 如果获取不到页面标题，说明在本次更新中这个页面被删掉了，因此设置项也随之更新
                    i++;
                }
                // 加上新增在最后的页面
                if (ListPages.Items.Count == i)
                {
                    while (i < Pages.Count)
                    {
                        PageTabOrders.Add(new Tuple<string, bool>(pageKeys[i], true));
                        ListPages.Items.Add(Pages[pageKeys[i]].Text);
                        i++;
                    }
                }
                // 保存页面顺序
                SavePageTabOrders();
            }
            else
            {
                // 按照设定顺序显示
                foreach (var pageOrder in tabOrders)
                {
                    if (pageOrder.Item2)
                        ListPages.Items.Add(Pages[pageOrder.Item1].Text);
                }

                PageTabOrders = tabOrders;
            }

            ListPages.EndUpdate();
        }

        /// <summary>
        /// 导航列表选中项改变时触发
        /// </summary>
        private void ListPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListPages.SelectedIndex == -1) return;
            // 根据选中索引反查选中页面Key
            var key = PageTabOrders.Where(it => it.Item2)
                .ElementAt(ListPages.SelectedIndex)
                .Item1;
            // 通过Key找到页面的父节点也就是TabPage，设置为选中项
            ShowPage(Pages[key]);
        }

        /// <summary>
        /// 展示页面
        /// </summary>
        /// <param name="page">页面实例</param>
        private void ShowPage(BasePage page)
        {
            NavContainer.Panel2.SuspendLayout();
            NavContainer.Panel2.Controls.Clear();
            NavContainer.Panel2.Controls.Add(page);
            NavContainer.Panel2.ResumeLayout();
        }

        /// <summary>
        /// 导航列表项居中绘制
        /// </summary>
        private void ListPages_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            var strFmt = new StringFormat
            {
                Alignment = StringAlignment.Center, //文本垂直居中
                LineAlignment = StringAlignment.Center //文本水平居中
            };
            e.Graphics.DrawString(ListPages.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds, strFmt);
        }

        /// <summary>
        /// 导航列表高度测量
        /// </summary>
        private void ListPages_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            // 列表项高度为字体高度1.5倍
            e.ItemHeight = ListPages.Font.Height * 3 / 2;
        }

        /// <summary>
        /// 导航列表大小改变时触发
        /// </summary>
        private void ListPages_SizeChanged(object sender, EventArgs e)
        {
            // 立刻重绘列表项
            ListPages.Refresh();
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
            Pages.Add(page.Name, page);
            return page;
        }

        #endregion

        #region - 快捷键执行 HotKey -

        /// <summary>
        /// 快捷键触发时执行
        /// </summary>
        private void OnHotKeyTrigger(object sender, HotKeyTriggerEventArgs e)
        {
            BeginInvoke(new Func<Task>(() => RunRawCommands(e.HotKeyItem.Commands)));
            e.Handle = true;
        }

        private const int WM_HOTKEY = 0x312;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    Common.KeyGo.ProcessHotKey(m.WParam.ToInt32());
                    break;
            }
        }

        #endregion - 快捷键执行 HotKey -

        #region - 命令 Command -

        /// <summary>
        /// 设置命令
        /// </summary>
        /// <param name="command">命令</param>
        private void SetCommand(string command)
        {
            Logger.I(TAG, $"SetCommand(\"{command}\")");
            var oldCommand = CmbCommand.Text;
            if (ModifierKeys == Keys.Shift && !string.IsNullOrEmpty(oldCommand))
                command = $"{oldCommand} | {command}";
            AddCommandToList(command);
            if (ChkAutoCopy.Checked)
                CopyCommand();

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
            if (string.IsNullOrEmpty(command))
                return;
            if (CmbCommand.Items.Count > 19)
                CmbCommand.Items.RemoveAt(0);
            CmbCommand.Items.Add(command);
            CmbCommand.SelectedIndex = CmbCommand.Items.Count - 1;
        }

        /// <summary>
        /// 设置带参数的命令
        /// </summary>
        /// <param name="command">命令</param>
        /// <param name="args">参数</param>
        private void SetCommand(string command, string args)
        {
            if (!string.IsNullOrEmpty(args))
                command = $"{command} {args}";
            command = command.Trim();
            if (Settings.Default.IsIncludeUID)
                command = $"{command} @{Settings.Default.Uid}";
            SetCommand(command);
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

            await RunRawCommands(cmd);
        }

        /// <summary>
        /// 运行原始命令
        /// </summary>
        /// <param name="commands">命令字符串</param>
        /// <returns>是否执行成功</returns>
        private async Task<bool> RunRawCommands(string commands)
        {
            if (commands.IndexOf('|') == -1 || Common.OC?.CanInvokeMultipleCmd == true)
                return await RunCommands(FormatCommand(commands));
            return await RunCommands(commands.Split('|').Select(FormatCommand).ToArray());
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
                NavigateTo<PageOpenCommand>();
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
                        TxtCommandRunLog.AppendText(string.IsNullOrEmpty(msg) ? "OK" : msg.Replace("\n", "\r\n"));
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
                NavContainer.Anchor &= ~AnchorStyles.Bottom;
                GrpCommand.Anchor |= AnchorStyles.Top;
                Size = new Size(Width, Height + TxtCommandRunLogMinHeight);
                MinimumSize = new Size(MinimumSize.Width, MinimumSize.Height + TxtCommandRunLogMinHeight);
                NavContainer.Anchor |= AnchorStyles.Bottom;
                GrpCommand.Anchor &= ~AnchorStyles.Top;
            }

            if (TxtCommandRunLog == null)
            {
                TxtCommandRunLog = new TextBox
                {
                    Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom,
                    Multiline = true,
                    Font = new Font("Consolas", 9F),
                    Location = new Point(ChkAutoCopy.Left, ChkAutoCopy.Bottom + 6),
                    Size = new Size(GrpCommand.Width - ChkAutoCopy.Left * 2, TxtCommandRunLogMinHeight),
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
            else if ((e.Alt || e.Control) && e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
            {
                // Alt|Ctrl+数字键 = 跳转到对应页面
                var i = e.KeyCode == Keys.D0 ? 9 : e.KeyCode - Keys.D1;
                if (i < ListPages.Items.Count)
                    ListPages.SelectedIndex = i;
            }
            else if (e.Control && e.KeyCode == Keys.Tab)
            {
                // 切换到下一个页面
                ListPages.SelectedIndex = (ListPages.SelectedIndex + 1) % ListPages.Items.Count;
            }
            else if (Common.KeyGo.IsEnabled == false)
            {
                foreach (var hotkeyItem in Common.KeyGo.Items)
                {
                    if (!hotkeyItem.IsEnabled) continue;

                    var t = hotkeyItem.HotKey.LastIndexOf('+');
                    var key = (t >= 0) ? hotkeyItem.HotKey.Substring(t+1) : hotkeyItem.HotKey;
                    if (e.KeyCode != (Keys)Enum.Parse(typeof(Keys), key.Trim()))
                        continue;

                    if (t >= 0)
                    {
                        if (hotkeyItem.HotKey.Contains("Ctrl") && !e.Control)
                            continue;
                        if (hotkeyItem.HotKey.Contains("Shift") && !e.Shift)
                            continue;
                        if (hotkeyItem.HotKey.Contains("Alt") && !e.Alt)
                            continue;
                    }
                    BeginInvoke(new Func<Task>(() => RunRawCommands(hotkeyItem.Commands)));
                    break;
                }
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
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => ShowTip(message, control)));
                return;
            }
            TTip.Show(message, control, 0, control.Size.Height, 3000);
        }

        /// <summary>
        /// 导航到目标页面并返回该页面实例
        /// </summary>
        /// <typeparam name="TPage">页面类型</typeparam>
        public TPage NavigateTo<TPage>() where TPage : BasePage
        {
            var key = typeof(TPage).Name;
            var page = Pages[key] as TPage;
            var i = 0;
            foreach (var it in PageTabOrders.Where(it => it.Item2))
            {
                if (it.Item1 == key)
                {
                    ListPages.SelectedIndex = i;
                    return page;
                }
                i++;
            }

            ShowPage(page);
            return page;
        }

        #endregion - 通用 General -


        /// <summary>
        /// 命令栏文本改变时触发
        /// </summary>
        private void CmbCommand_TextChanged(object sender, EventArgs e)
        {
            LblClearFilter.Visible = CmbCommand.Text.Length > 0;
        }

        /// <summary>
        /// 点击清空命令栏标签时触发
        /// </summary>
        private void LblClearFilter_Click(object sender, EventArgs e)
        {
            CmbCommand.Text = "";
        }
    }
}