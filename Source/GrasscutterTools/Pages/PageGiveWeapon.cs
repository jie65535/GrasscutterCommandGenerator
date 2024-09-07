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

using GrasscutterTools.Game;
using GrasscutterTools.Properties;
using GrasscutterTools.Utils;

namespace GrasscutterTools.Pages
{
    internal partial class PageGiveWeapon : BasePage
    {
        public override string Text => Resources.PageGiveWeaponTitle;

        public PageGiveWeapon()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode) return;
            ListWeapons.Items.Clear();
            ListWeapons.Items.AddRange(GameData.Weapons.Lines);
        }

        /// <summary>
        /// 武器列表过滤器文本改变时触发
        /// </summary>
        private void TxtWeaponFilter_TextChanged(object sender, EventArgs e)
        {
            UIUtil.ListBoxFilter(ListWeapons, GameData.Weapons.Lines, TxtWeaponFilter.Text);
            LblClearFilter.Visible = TxtWeaponFilter.Text.Length > 0;
        }

        /// <summary>
        /// 点击清空过滤器标签时触发
        /// </summary>
        private void LblClearFilter_Click(object sender, EventArgs e)
        {
            TxtWeaponFilter.Clear();
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

        private void ListWeapons_MeasureItem(object sender, System.Windows.Forms.MeasureItemEventArgs e)
        {
            e.ItemHeight = ListWeapons.Font.Height * 3 / 2;
        }
    }
}