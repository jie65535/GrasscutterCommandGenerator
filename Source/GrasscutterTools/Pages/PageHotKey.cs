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
using System.Windows.Forms;

using GrasscutterTools.Properties;
using GrasscutterTools.Utils;

using Newtonsoft.Json;

namespace GrasscutterTools.Pages
{
    internal partial class PageHotKey : BasePage
    {
        public override string Text => Resources.PageHotKey;

        private const string TAG = nameof(PageHotKey);

        public PageHotKey()
        {
            InitializeComponent();
            LvHotKeyList.FullRowSelect = true;
            if (DesignMode) return;

            InitHotKeys();
        }

        /// <summary>
        /// 热键保存位置
        /// </summary>
        private readonly string HotKeysFilePath = Common.GetAppDataFile("HotKeys.json");

        /// <summary>
        /// 热键配置是否存在更改
        /// </summary>
        private bool HotKeysChanged;

        /// <summary>
        /// 加载用户热键列表
        /// </summary>
        private List<HotKeyItem> LoadKeyItems()
        {
            List<HotKeyItem> list = null;
            try
            {
                Logger.I(TAG, "Loading HotKey json file from: " + HotKeysFilePath);
                list = JsonConvert.DeserializeObject<List<HotKeyItem>>(File.ReadAllText(HotKeysFilePath));
            }
            catch (Exception ex)
            {
                Logger.E(TAG, "Parsing HotKeys.json failed", ex);
            }

            if (list == null || list.Count == 0)
            {
                // 默认把移动命令加到列表
                list = new List<HotKeyItem>
                {
                    new("↑", "/tp ^ ^ ^10", "NumPad8", false),
                    new("↓", "/tp ^ ^ ^-10", "NumPad5", false),
                    new("←", "/tp ^-10 ^ ^", "NumPad4", false),
                    new("→", "/tp ^10 ^ ^", "NumPad6", false),
                    new("↑^↑", "/tp ~ ~10 ~", "NumPad0", false),
                };
            }

            return list;
        }

        /// <summary>
        /// 初始化快捷键
        /// </summary>
        private void InitHotKeys()
        {
            if (!File.Exists(HotKeysFilePath))
                return;
            try
            {
                // 还原设置
                Common.KeyGo.IsEnabled = ChkEnableGlobal.Checked = Settings.Default.IsHotkeyEenabled;
                Common.KeyGo.Items = LoadKeyItems();
                LvHotKeyList.Items.AddRange(Common.KeyGo.Items.Select(HotKeyItemToViewItem).ToArray());
                Logger.I(TAG, "Start Register All HotKeys");
                Common.KeyGo.RegAllKey();
            }
            catch (Exception ex)
            {
                Logger.W(TAG, "Failed to InitHotKeys", ex);
            }
        }

        /// <summary>
        /// 关闭时触发，取消注册并保存更改
        /// </summary>
        public override void OnClosed()
        {
            Settings.Default.IsHotkeyEenabled = Common.KeyGo.IsEnabled;

            Logger.I(TAG, "Cancel all HotKeys");
            Common.KeyGo.UnRegAllKey();

            if (!HotKeysChanged) return;
            Logger.I(TAG, "Save all HotKeys to: " + HotKeysFilePath);
            File.WriteAllText(HotKeysFilePath, JsonConvert.SerializeObject(Common.KeyGo.Items));
        }

        /// <summary>
        /// 将实体转为视图对象
        /// </summary>
        private static ListViewItem HotKeyItemToViewItem(HotKeyItem item) => new(new[]
        {
            item.Tag,
            item.HotKey,
            item.Commands
        })
        { Checked = item.IsEnabled };

        /// <summary>
        /// 列表选中项改变时触发
        /// </summary>
        private void LvHotKeyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LvHotKeyList.SelectedIndices.Count == 0) return;
            var i = LvHotKeyList.SelectedIndices[0];
            var hotKeyItem = Common.KeyGo.Items[i];
            TxtTag.Text = hotKeyItem.Tag;
            TxtHotKey.Text = hotKeyItem.HotKey;
            SetCommand(hotKeyItem.Commands);
        }

        /// <summary>
        /// 点击添加或更新按钮时触发
        /// </summary>
        private void BtnAddOrUpdate_Click(object sender, EventArgs e)
        {
            var tag = TxtTag.Text.Trim();
            var commands = GetCommand();
            var hotKey = TxtHotKey.Text;
            if (string.IsNullOrEmpty(tag) || string.IsNullOrEmpty(commands) || string.IsNullOrEmpty(hotKey))
            {
                MessageBox.Show(Resources.EmptyInputTip, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var i = Common.KeyGo.Items.FindIndex(it => it.Tag == tag);
                if (i == -1)
                {
                    var item = new HotKeyItem(tag, commands, hotKey);
                    Logger.I(TAG, $"New HotKey item [{hotKey}]");
                    Common.KeyGo.AddHotKey(item);
                    LvHotKeyList.Items.Add(HotKeyItemToViewItem(item));
                }
                else
                {
                    var item = Common.KeyGo.Items[i];
                    item.Commands = commands;
                    if (item.HotKey != hotKey)
                    {
                        Logger.I(TAG, $"Update HotKey from [{item.HotKey}] to [{hotKey}]");
                        item.HotKey = hotKey;
                        Common.KeyGo.ChangeHotKey(item);
                    }

                    LvHotKeyList.Items[i] = HotKeyItemToViewItem(item);
                }

                HotKeysChanged = true;
            }
            catch (Exception ex)
            {
                Logger.E(TAG, "AddOrUpdate HotKey failed", ex);
                MessageBox.Show(ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 点击移除按钮时触发
        /// </summary>
        private void BtnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                var tag = TxtTag.Text.Trim();
                var i = Common.KeyGo.Items.FindIndex(it => it.Tag == tag);
                if (i == -1) return;
                var item = Common.KeyGo.Items[i];
                Logger.I(TAG, $"Remove HotKey [{item.HotKey}] \"{item.Tag}\"");
                Common.KeyGo.DelHotKey(item);
                LvHotKeyList.Items.RemoveAt(i);
                HotKeysChanged = true;
            }
            catch (Exception ex)
            {
                Logger.E(TAG, "Remove HotKey failed", ex);
                MessageBox.Show(ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 快捷键选项卡按键按下时触发
        /// </summary>
        private void TxtHotKey_KeyDown(object sender, KeyEventArgs e)
        {
            // ESC键清空当前快捷键
            if (e.KeyCode == Keys.Escape)
            {
                TxtHotKey.Text = "";
                return;
            }

            // 可选的功能键
            //// 必须带功能键
            //if (e.Modifiers == Keys.None)
            //    return;

            // 必须是组合键
            if (e.KeyCode == Keys.ControlKey || e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.Menu)
                return;

            var text = e.KeyCode.ToString();
            if (e.Control)
                text = "Ctrl + " + text;
            if (e.Shift)
                text = "Shift + " + text;
            if (e.Alt)
                text = "Alt + " + text;

            TxtHotKey.Text = text;
        }

        /// <summary>
        /// 列表中的复选框改变时触发
        /// </summary>
        private void LvHotKeyList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var isEnable = e.NewValue == CheckState.Checked;
            try
            {
                var item = Common.KeyGo.Items[e.Index];
                if (isEnable)
                {
                    // 尝试注册快捷键
                    Logger.I(TAG, $"Register hotKey [{item.HotKey}] as \"{item.Tag}\"");
                    Common.KeyGo.RegKey(item);
                }
                else
                {
                    // 尝试注销快捷键
                    Logger.I(TAG, $"Cancel hotKey [{item.HotKey}]");
                    Common.KeyGo.UnRegKey(item);
                }
                // 更新使能状态
                item.IsEnabled = isEnable;
            }
            catch (Exception ex)
            {
                // 如果操作失败，还原选项，禁止设置
                e.NewValue = e.CurrentValue;
                Logger.E(TAG, (isEnable ? "Enable" : "Disable") + " HotKey failed", ex);
                MessageBox.Show(ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 添加热键快捷设置方法
        /// </summary>
        /// <param name="tag">标签名</param>
        public void AddNewHotKey(string tag)
        {
            TxtHotKey.Tag = "";
            TxtTag.Text = tag;
        }

        /// <summary>
        /// 切换启用全局快捷键时触发
        /// </summary>
        private void ChkEnableGlobal_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Common.KeyGo.IsEnabled = ChkEnableGlobal.Checked;
            }
            catch (Exception ex)
            {
                Logger.E(TAG, "Failed to switch global hotkeys", ex);
                MessageBox.Show(ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        
        /// <summary>
        /// 标签输入栏改变时触发
        /// </summary>
        private void TxtTag_TextChanged(object sender, EventArgs e)
        {
            LblClearFilter.Visible = TxtTag.Text.Length > 0;
        }

        /// <summary>
        /// 点击清空标签输入栏标签时触发
        /// </summary>
        private void LblClearFilter_Click(object sender, EventArgs e)
        {
            TxtTag.Clear();
        }
    }
}