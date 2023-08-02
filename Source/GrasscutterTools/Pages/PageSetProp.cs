using System;
using System.Globalization;
using System.Windows.Forms;

using GrasscutterTools.Game.Props;
using GrasscutterTools.Properties;

namespace GrasscutterTools.Pages
{
    internal partial class PageSetProp : BasePage
    {
        private const string SetPropPrefix = "/setProp";

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
            SetCommand(SetPropPrefix, "setopenstate " + NUDOpenStateValue.Value);
        }

        private void BtnUnsetOpenState_Click(object sender, EventArgs e)
        {
            SetCommand(SetPropPrefix, "unsetopenstate " + NUDOpenStateValue.Value);
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
    }
}