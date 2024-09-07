using System;
using System.Linq;
using System.Windows.Forms;

using GrasscutterTools.Game;
using GrasscutterTools.Properties;
using GrasscutterTools.Utils;

namespace GrasscutterTools.Pages
{
    internal partial class PageAchievement : BasePage
    {
        public override string Text => Resources.PageAchievementTitle;

        public PageAchievement()
        {
            InitializeComponent();
        }

        public override void OnLoad()
        {
            base.OnLoad();

            UpdateList();
        }

        /// <summary>
        /// 点击全部达成时触发
        /// </summary>
        private void LnkGrantAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetCommand("/achievement grantall");
        }

        /// <summary>
        /// 点击全部撤销时触发
        /// </summary>
        private void LnkRevokeAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetCommand("/achievement revokeall");
        }

        /// <summary>
        /// 更新列表显示内容
        /// </summary>
        private void UpdateList()
        {
            UIUtil.ListBoxFilter(ListAchievements, GameData.Achievements.Lines, TxtAchievementFilter.Text);
        }

        /// <summary>
        /// 过滤器输入改变时触发
        /// </summary>
        private void TxtAchievementFilter_TextChanged(object sender, EventArgs e)
        {
            UpdateList();
            LblClearFilter.Visible = TxtAchievementFilter.Text.Length > 0;
        }

        /// <summary>
        /// 点击清空过滤器标签时触发
        /// </summary>
        private void LblClearFilter_Click(object sender, EventArgs e)
        {
            TxtAchievementFilter.Clear();
        }

        /// <summary>
        /// 获取所有选中项ID
        /// </summary>
        /// <returns>所有选中项ID，如未选中返回 null</returns>
        private int[] GetSelectedIds()
        {
            if (ListAchievements.SelectedItems.Count == 0)
                return null;
            var selectedIds = new int[ListAchievements.SelectedItems.Count];
            var i = 0;
            foreach (string item in ListAchievements.SelectedItems)
                selectedIds[i++] = int.Parse(item.Substring(0, item.IndexOf(':')));
            return selectedIds;
        }

        private void GenSelected(string command, string args = "")
        {
            var selectedIds = GetSelectedIds();
            if (selectedIds == null)
            {
                MessageBox.Show(Resources.SelectAnyItem, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (selectedIds.Length == 1)
                SetCommand(args == "" ? $"{command} {selectedIds[0]}" : $"{command} {selectedIds[0]} {args}");
            else
                SetCommand(string.Join(" | ", selectedIds.Select(it => args == "" ? $"{command} {it}" : $"{command} {it} {args}")));
        }

        private void BtnGrant_Click(object sender, EventArgs e)
        {
            GenSelected("/achievement grant");
        }

        private void BtnRevoke_Click(object sender, EventArgs e)
        {
            GenSelected("/achievement revoke");
        }

        private void BtnProgress_Click(object sender, EventArgs e)
        {
            GenSelected("/achievement progress", NUDProgress.Text);
        }

        private void ListAchievements_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = ListAchievements.Font.Height * 3 / 2;
        }
    }
}