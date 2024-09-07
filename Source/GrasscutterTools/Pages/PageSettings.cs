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
using System.Linq;
using System.Windows.Forms;
using GrasscutterTools.Forms;
using GrasscutterTools.Game;
using GrasscutterTools.Properties;

namespace GrasscutterTools.Pages
{
    internal partial class PageSettings : BasePage
    {
        public override string Text => Resources.PageSettingsTitle;

        public PageSettings()
        {
            InitializeComponent();
            if (DesignMode) return;

            // 玩家UID
            NUDUid.Value = Settings.Default.Uid;
            NUDUid.ValueChanged += (o, e) => Settings.Default.Uid = NUDUid.Value;

            // 是否包含UID
            ChkIncludeUID.Checked = Settings.Default.IsIncludeUID;
            ChkIncludeUID.CheckedChanged += (o, e) => Settings.Default.IsIncludeUID = ChkIncludeUID.Checked;

            // 窗口透明度
            TbWindowOpacity.Value = Settings.Default.WindowOpacity;
            TbWindowOpacity.Scroll += TbWindowOpacity_Scroll;

            // 置顶
            ChkTopMost.Checked = FormMain.Instance.TopMost = Settings.Default.IsTopMost;
            ChkTopMost.CheckedChanged += (o, e) => Settings.Default.IsTopMost = FormMain.Instance.TopMost = ChkTopMost.Checked;

            // 命令版本初始化
            if (Version.TryParse(Settings.Default.CommandVersion, out Version current))
                CommandVersion.Current = current;
            CmbGcVersions.DataSource = CommandVersion.List.Select(it => it.ToString(3)).ToList();
            CmbGcVersions.SelectedIndex = Array.IndexOf(CommandVersion.List, CommandVersion.Current);
            CmbGcVersions.SelectedIndexChanged += (o, e) => CommandVersion.Current = CommandVersion.List[CmbGcVersions.SelectedIndex];
            CommandVersion.VersionChanged += (o, e) => Settings.Default.CommandVersion = CommandVersion.Current.ToString(3);

            ChkListPages.ItemHeight = ChkListPages.Font.Height * 3 / 2;
        }

        /// <summary>
        /// 页面加载时触发
        /// </summary>
        public override void OnLoad()
        {
            InitPageList();
        }

        /// <summary>
        /// 页面关闭时触发
        /// </summary>
        public override void OnClosed()
        {
            // 保存设置
            Settings.Default.WindowOpacity = TbWindowOpacity.Value;
            // 如果设置有更改
            if (isChanged)
            {
                // 保存页面选项卡顺序设置
                FormMain.Instance.SavePageTabOrders();
            }
        }


        #region - 页面列表 Page list -

        private bool isChanged;

        /// <summary>
        /// 初始化页面列表
        /// </summary>
        private void InitPageList()
        {
            ChkListPages.ItemCheck -= ChkListPages_ItemCheck;
            ChkListPages.BeginUpdate();
            ChkListPages.Items.Clear();
            foreach (var pageTab in FormMain.Instance.PageTabOrders)
                ChkListPages.Items.Add(FormMain.Instance.Pages[pageTab.Item1].Text, pageTab.Item2);

            ChkListPages.EndUpdate();
            ChkListPages.ItemCheck += ChkListPages_ItemCheck;
        }

        /// <summary>
        /// 页面选项更改时触发
        /// </summary>
        private void ChkListPages_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var tab = FormMain.Instance.PageTabOrders[e.Index];
            // 不允许修改首页和设置页的可见性
            if (tab.Item1 is nameof(PageHome) or nameof(PageSettings))
                return;
            FormMain.Instance.PageTabOrders[e.Index] =
                new Tuple<string, bool>(tab.Item1, e.NewValue == CheckState.Checked);
            FormMain.Instance.UpdatePagesNav();
            isChanged = true;
        }

        private void MovePageOrder(int from, int to)
        {
            // 交换记录保存顺序
            var temp = FormMain.Instance.PageTabOrders[from];
            FormMain.Instance.PageTabOrders.RemoveAt(from);
            FormMain.Instance.PageTabOrders.Insert(to, temp);

            // 交换控件选项顺序
            var selectedItem = ChkListPages.SelectedItem;
            ChkListPages.ItemCheck -= ChkListPages_ItemCheck;
            ChkListPages.BeginUpdate();
            ChkListPages.Items.RemoveAt(from);
            ChkListPages.Items.Insert(to, selectedItem);
            ChkListPages.SetItemChecked(to, temp.Item2);
            ChkListPages.SelectedIndex = to;
            ChkListPages.EndUpdate();
            ChkListPages.ItemCheck += ChkListPages_ItemCheck;


            // 更新导航顺序
            FormMain.Instance.UpdatePagesNav();
            isChanged = true;
        }

        /// <summary>
        /// 点击向上移动时触发
        /// </summary>
        private void BtnMoveUp_Click(object sender, EventArgs e)
        {
            var i = ChkListPages.SelectedIndex;
            if (i <= 1) return;
            MovePageOrder(i, i - 1);
        }

        /// <summary>
        /// 点击向下移动时触发
        /// </summary>
        private void BtnMoveDown_Click(object sender, EventArgs e)
        {
            var i = ChkListPages.SelectedIndex;
            if (i == -1 || i == ChkListPages.Items.Count - 1) return;
            MovePageOrder(i, i + 1);
        }

        #endregion

        /// <summary>
        /// 窗口透明度滑块滑动时触发
        /// </summary>
        private void TbWindowOpacity_Scroll(object sender, EventArgs e)
        {
            FormMain.Instance.Opacity = TbWindowOpacity.Value / 100.0;
        }

        /// <summary>
        /// 点击重置页面列表时触发
        /// </summary>
        private void BtnResetPageList_Click(object sender, EventArgs e)
        {
            FormMain.Instance.ResetPageTabOrders();
            FormMain.Instance.UpdatePagesNav();
            InitPageList();
            isChanged = true;
        }
    }
}