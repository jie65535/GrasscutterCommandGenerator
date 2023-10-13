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
using System.Globalization;
using System.Windows.Forms;

using GrasscutterTools.Game.Props;
using GrasscutterTools.Properties;

namespace GrasscutterTools.Pages
{
    internal partial class PageSetProp : BasePage
    {
        public override string Text => Resources.PageSetPropTitle;

        private const string SetPropPrefix = "/prop";

        public PageSetProp()
        {
            InitializeComponent();
        }

        public override void OnLoad()
        {
            foreach (var line in Resources.PlayerProperty.Split('\n'))
            {
                try
                {
                    var values = line.Split(':');
                    var prop = PlayerProperty.Values.Find(it => it.Id == values[0]);
                    if (prop == null) continue;
                    prop.Name = values[1].Trim();
                    var desc = values[2].Trim();
                    if (!string.IsNullOrEmpty(desc))
                        prop.Description = desc;
                }
                catch
                {
                }
            }
            CmbPlayerProperty.DataSource = PlayerProperty.Values;
            CmbPlayerProperty.DisplayMember = "Name";
        }

        private void NUDWorldLevel_ValueChanged(object sender, EventArgs e)
        {
            SetCommand(SetPropPrefix, "worldlevel " + NUDWorldLevel.Value);
        }

        private void NUDBPLevel_ValueChanged(object sender, EventArgs e)
        {
            SetCommand(SetPropPrefix, "bplevel " + NUDTowerLevel.Value);
        }

        private void NUDTowerLevel_ValueChanged(object sender, EventArgs e)
        {
            SetCommand(SetPropPrefix, "towerlevel " + NUDBPLevel.Value);
        }

        private void BtnSetPropButton_Click(object sender, EventArgs e)
        {
            SetCommand(SetPropPrefix, (sender as Button).Tag as string);
        }

        private void BtnSetOpenState_Click(object sender, EventArgs e)
        {
            SetCommand(SetPropPrefix, "SetOpenState " + NUDOpenStateValue.Value);
        }

        private void BtnUnsetOpenState_Click(object sender, EventArgs e)
        {
            SetCommand(SetPropPrefix, "UnsetOpenState " + NUDOpenStateValue.Value);
        }

        private void NUDPlayerPropertyValue_ValueChanged(object sender, EventArgs e)
        {
            if (CmbPlayerProperty.SelectedIndex == -1)
                return;
            var selectedItem = (PlayerProperty)CmbPlayerProperty.SelectedItem;
            SetCommand(SetPropPrefix, selectedItem.Id.ToLower(CultureInfo.CurrentCulture) + " " + NUDPlayerPropertyValue.Value);
        }

        private void BtnPlayerPropertyButton_Click(object sender, EventArgs e)
        {
            if (CmbPlayerProperty.SelectedIndex == -1)
                return;
            var selectedItem = (PlayerProperty)CmbPlayerProperty.SelectedItem;
            SetCommand(SetPropPrefix, selectedItem.Id.ToLower(CultureInfo.CurrentCulture) + " " + (sender as Button).Tag);
        }

        private void CmbPlayerProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbPlayerProperty.SelectedIndex == -1)
                return;
            var selectedItem = (PlayerProperty)CmbPlayerProperty.SelectedItem;
            NUDPlayerPropertyValue.Maximum = selectedItem.Max;
            NUDPlayerPropertyValue.Minimum = selectedItem.Min;
            LblPlayerPropertyDesc.Text = selectedItem.Description;
        }

        private void PropCheckedChanged(object sender, EventArgs e)
        {
            var chk = sender as CheckBox;
            var prop = chk.Tag as string;
            SetCommand(SetPropPrefix, prop + ' ' + (chk.Checked ? "on" : "off"));
        }

        private void BtnUnlockMapBarrier_Click(object sender, EventArgs e)
        {
            SetCommand($"{SetPropPrefix} SetOpenState 47 | {SetPropPrefix} SetOpenState 48");
        }

        private void BtnUnlockAll_Click(object sender, EventArgs e)
        {
            SetCommand("/unlockall");
        }
    }
}