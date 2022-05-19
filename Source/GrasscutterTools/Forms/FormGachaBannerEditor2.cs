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
    public partial class FormGachaBannerEditor2 : Form
    {
        #region - 初始化 -

        public FormGachaBannerEditor2()
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
            // TODO
        }

        //private void InitCheckedListBox(CheckedListBox list, string color)
        //{
        //    var kvs = new List<string>();
        //    for (int i = 0; i < GameData.AvatarColors.Count; i++)
        //    {
        //        if (GameData.AvatarColors.Names[i] == color)
        //        {
        //            var id = GameData.AvatarColors.Ids[i];
        //            var index = Array.IndexOf(GameData.Avatars.Ids, id % 1000 + 10000000);
        //            if (index >= 0)
        //                kvs.Add($"{id}:{GameData.Avatars.Names[index]}");
        //        }
        //    }
        //    for (int i = 0; i < GameData.WeaponColors.Count; i++)
        //    {
        //        if (GameData.WeaponColors.Names[i] == color)
        //        {
        //            var id = GameData.WeaponColors.Ids[i];
        //            var index = Array.IndexOf(GameData.Weapons.Ids, id);
        //            if (index >= 0)
        //                kvs.Add($"{id}:{GameData.Weapons.Names[index]}");
        //        }
        //    }
        //    list.Items.AddRange(kvs.ToArray());
        //}

        private void InitRateUpItems(GachaBanner2 banner)
        {
            // TODO
        }

        #endregion - 初始化 -

        #region - UI -

        private void ShowBanner(GachaBanner2 banner)
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
                NUDEventChance5.Value       = banner.EventChance5;
                NUDEventChance4.Value       = banner.EventChance4;
                InitRateUpItems(banner);
            }
            catch (Exception ex)
            {
                MessageBox.Show("UI更新失败：" + ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private GachaBanner2 ParseBanner()
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


            var prefabId = GameData.GachaBannerPrefabs.Ids[CmbPrefab.SelectedIndex];
            var banner = new GachaBanner2
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
                EventChance5      = (int)NUDEventChance5.Value,
                EventChance4      = (int)NUDEventChance4.Value,
            };
            return banner;
        }

        #endregion - UI -

        #region - 事件 -

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
                ShowBanner(JsonConvert.DeserializeObject<GachaBanner2>(TxtJson.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Json解析失败，错误消息：" + ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion - 事件 -
    }
}