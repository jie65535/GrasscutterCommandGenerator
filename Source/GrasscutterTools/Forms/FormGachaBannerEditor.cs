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
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using GrasscutterTools.Game;
using GrasscutterTools.Game.Gacha;
using GrasscutterTools.Properties;

using Newtonsoft.Json;

namespace GrasscutterTools.Forms
{
    /// <summary>
    /// 卡池编辑器
    /// </summary>
    public partial class FormGachaBannerEditor : Form
    {
        #region - 初始化 -

        public FormGachaBannerEditor()
        {
            InitializeComponent();

            Icon = Resources.IconGrasscutter;
            CmbBannerType.SelectedIndex = 0;
            InitBannerPrefab();
            InitCheckedListBoxs();
        }

        private void InitBannerPrefab()
        {
            CmbPrefab.Items.Clear();
            CmbPrefab.Items.AddRange(GameData.GachaBannerPrefabs.Names);
        }

        private void InitCheckedListBoxs()
        {
            InitCheckedListBox(ListYellowPool, "yellow");
            InitCheckedListBox(ListPurplePool, "purple");
        }

        private void InitCheckedListBox(CheckedListBox list, string color)
        {
            var kvs = new List<string>();
            for (int i = 0; i < GameData.AvatarColors.Count; i++)
            {
                if (GameData.AvatarColors.Names[i] == color)
                {
                    var id = GameData.AvatarColors.Ids[i];
                    var index = Array.IndexOf(GameData.Avatars.Ids, id);
                    if (index >= 0)
                        kvs.Add($"{id}:{GameData.Avatars.Names[index]}");
                }
            }
            for (int i = 0; i < GameData.WeaponColors.Count; i++)
            {
                if (GameData.WeaponColors.Names[i] == color)
                {
                    var id = GameData.WeaponColors.Ids[i];
                    var index = Array.IndexOf(GameData.Weapons.Ids, id);
                    if (index >= 0)
                        kvs.Add($"{id}:{GameData.Weapons.Names[index]}");
                }
            }
            list.Items.AddRange(kvs.ToArray());
        }

        private void InitRateUpItems(GachaBanner banner)
        {
            UpdateCheckedListBox(ListYellowPool, banner.RateUpItems1);
            UpdateCheckedListBox(ListPurplePool, banner.RateUpItems2);
        }

        #endregion - 初始化 -

        #region - UI -

        private void ShowBanner(GachaBanner banner)
        {
            try
            {
                NUDGachaType.Value          = banner.GachaType;
                NUDScheduleId.Value         = banner.ScheduleId;
                CmbBannerType.SelectedIndex = (int)banner.BannerType;
                if (string.IsNullOrEmpty(banner.TitlePath) || !int.TryParse(banner.TitlePath.Substring("UI_GACHA_SHOW_PANEL_A".Length, 3), out int prefabId))
                    CmbPrefab.SelectedIndex = -1;
                else
                    CmbPrefab.SelectedIndex = Array.IndexOf(GameData.GachaBannerPrefabs.Ids, prefabId);
                RbCostItem224.Checked       = banner.CostItem == 224;
                RbCostItem223.Checked       = banner.CostItem == 223;
                NUDBeginTime.Value          = banner.BeginTime;
                NUDEndTime.Value            = banner.EndTime;
                NUDSortId.Value             = banner.SortId;
                TxtRateUpItems1.Text        = string.Join(", ", banner.RateUpItems1);
                TxtRateUpItems2.Text        = string.Join(", ", banner.RateUpItems2);
                NUDBaseYellowWeight.Value   = banner.BaseYellowWeight * 0.01M;
                NUDBasePurpleWeight.Value   = banner.BasePurpleWeight * 0.01M;
                NUDEventChance.Value        = banner.EventChance;
                NUDSoftPity.Value           = banner.SoftPity;
                NUDHardPity.Value           = banner.HardPity;
                InitRateUpItems(banner);
            }
            catch (Exception ex)
            {
                MessageBox.Show("UI更新失败：" + ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private GachaBanner ParseBanner()
        {
            if (CmbBannerType.SelectedIndex < 0)
            {
                MessageBox.Show("请选择奖池类型", Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            if (CmbPrefab.SelectedIndex < 0)
            {
                MessageBox.Show("请选择奖池预制", Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            int[] yellowIds;
            if (string.IsNullOrEmpty(TxtRateUpItems1.Text))
                yellowIds = new int[0];
            else
                yellowIds = TxtRateUpItems1.Text.Split(',').Select(s => int.Parse(s.Trim())).ToArray();

            int[] purpleIds;
            if (string.IsNullOrEmpty(TxtRateUpItems2.Text))
                purpleIds = new int[0];
            else
                purpleIds = TxtRateUpItems2.Text.Split(',').Select(s => int.Parse(s.Trim())).ToArray();

            var prefabId = GameData.GachaBannerPrefabs.Ids[CmbPrefab.SelectedIndex];
            GachaBanner banner = new GachaBanner
            {
                GachaType         = (int)NUDGachaType.Value,
                ScheduleId        = (int)NUDScheduleId.Value,
                BannerType        = (BannerType)CmbBannerType.SelectedIndex,
                PrefabPath        = $"GachaShowPanel_A{prefabId:000}",
                PreviewPrefabPath = $"UI_Tab_GachaShowPanel_A{prefabId:000}",
                TitlePath         = $"UI_GACHA_SHOW_PANEL_A{prefabId:000}_TITLE",
                CostItem          = RbCostItem224.Checked ? 224 : 223,
                BeginTime         = (int)NUDBeginTime.Value,
                EndTime           = (int)NUDEndTime.Value,
                SortId            = (int)NUDSortId.Value,
                RateUpItems1      = yellowIds,
                RateUpItems2      = purpleIds,
                BaseYellowWeight  = (int)(NUDBaseYellowWeight.Value * 100),
                BasePurpleWeight  = (int)(NUDBasePurpleWeight.Value * 100),
                EventChance       = (int)NUDEventChance.Value,
                SoftPity          = (int)NUDSoftPity.Value,
                HardPity          = (int)NUDHardPity.Value
            };
            return banner;
        }

        #endregion - UI -

        #region - 事件 -

        private void UpdateCheckedListBox(CheckedListBox list, int[] checkedIds)
        {
            for (int i = 0; i < list.Items.Count; i++)
            {
                if (checkedIds.Length == 0)
                    list.SetItemChecked(i, false);
                else
                {
                    var item = list.Items[i] as string;
                    var id = int.Parse(item.Substring(0, item.IndexOf(':')));
                    list.SetItemChecked(i, Array.IndexOf(checkedIds, id) != -1);
                }
            }
        }

        private void ListYellowPool_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            BeginInvoke(new Action(() =>
                UpdateCheckedItems(ListYellowPool, TxtRateUpItems1)
            ));
        }

        private void ListPurplePool_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            BeginInvoke(new Action(() =>
                UpdateCheckedItems(ListPurplePool, TxtRateUpItems2)
            ));
        }

        private void UpdateCheckedItems(CheckedListBox list, TextBox txt)
        {
            if (list.CheckedItems.Count == 0)
                txt.Text = "";
            else
            {
                StringBuilder builder = new StringBuilder();
                foreach (string item in list.CheckedItems)
                    builder.Append(item.Substring(0, item.IndexOf(':')))
                        .Append(", ");
                txt.Text = builder.ToString(0, builder.Length - 2);
            }
        }

        private void BtnGen_Click(object sender, EventArgs e)
        {
            var banner = ParseBanner();
            if (banner != null)
            {
                TxtJson.Text = JsonConvert.SerializeObject(banner, Formatting.Indented);
            }
        }

        private void BtnParse_Click(object sender, EventArgs e)
        {
            try
            {
                ShowBanner(JsonConvert.DeserializeObject<GachaBanner>(TxtJson.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Json解析失败，错误消息：" + ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion - 事件 -
    }
}