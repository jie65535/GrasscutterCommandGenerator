using System;
using System.Globalization;
using System.Windows.Forms;
using GrasscutterTools.Game.Props;

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
            CmbPlayerProperty.DataSource = PlayerProperty.Values;
            CmbPlayerProperty.DisplayMember = "Id";
        }

        private void NUDWorldLevel_ValueChanged(object sender, EventArgs e)
        {
            SetCommand(SetPropPrefix, "worldlevel " + NUDWorldLevel.Value);
        }

        private void NUDBPLevel_ValueChanged(object sender, EventArgs e)
        {
            SetCommand(SetPropPrefix, "bplevel " + NUDBPLevel.Value);
        }

        private void NUDTowerLevel_ValueChanged(object sender, EventArgs e)
        {
            SetCommand(SetPropPrefix, "towerlevel " + NUDTowerLevel.Value);
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
            SetCommand(SetPropPrefix, CmbPlayerProperty.Text.ToLower(CultureInfo.CurrentCulture) + " " + NUDPlayerPropertyValue.Value);
        }

        private void BtnPlayerPropertyButton_Click(object sender, EventArgs e)
        {
            if (CmbPlayerProperty.SelectedIndex == -1)
                return;
            SetCommand(SetPropPrefix, CmbPlayerProperty.Text.ToLower(CultureInfo.CurrentCulture) + " " + (sender as Button).Tag);
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
