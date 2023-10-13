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
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using GrasscutterTools.Properties;

namespace GrasscutterTools.Pages
{
    internal partial class PageManagement : BasePage
    {
        public override string Text => Resources.PageManagementTitle;

        public PageManagement()
        {
            InitializeComponent();
            if (DesignMode) return;
        }

        public override void OnLoad()
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
    }
}