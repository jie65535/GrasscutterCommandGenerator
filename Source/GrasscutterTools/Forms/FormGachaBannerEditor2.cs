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
using System.Drawing;
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


            ShowBanner(new GachaBanner2());
        }

        private void InitBannerPrefab()
        {
            CmbPrefab.Items.Clear();
            CmbPrefab.Items.AddRange(GameData.GachaBannerPrefabs.Names);
        }


        private void InitCheckedListBoxs()
        {
            var c = new Dictionary<string, string>();
            ListFallbackItems.BeginUpdate();
            var a5 = ListFallbackItems.Groups.Add("a5", "5星角色");
            var a4 = ListFallbackItems.Groups.Add("a4", "4星角色");
            var a3 = ListFallbackItems.Groups.Add("a3", "3星角色");
            var w5 = ListFallbackItems.Groups.Add("w5", "5星武器");
            var w4 = ListFallbackItems.Groups.Add("w4", "4星武器");
            var w3 = ListFallbackItems.Groups.Add("w3", "3星武器");
            var avatars = GetAvatarsByColor("yellow")
                .Select(it => new ListViewItem(new string[] { it.Item1.ToString(), it.Item2 }, a5) { ForeColor = Color.OrangeRed })
                .Concat(GetAvatarsByColor("purple")
                .Select(it => new ListViewItem(new string[] { it.Item1.ToString(), it.Item2 }, a4) { ForeColor = Color.Purple }))
                .Concat(GetAvatarsByColor("blue")
                .Select(it => new ListViewItem(new string[] { it.Item1.ToString(), it.Item2 }, a3) { ForeColor = Color.Blue }));
            var weapons = GetWeaponsByColor("yellow")
                .Select(it => new ListViewItem(new string[] { it.Item1.ToString(), it.Item2 }, w5) { ForeColor = Color.OrangeRed })
                .Concat(GetWeaponsByColor("purple")
                .Select(it => new ListViewItem(new string[] { it.Item1.ToString(), it.Item2 }, w4) { ForeColor = Color.Purple }))
                .Concat(GetWeaponsByColor("blue")
                .Select(it => new ListViewItem(new string[] { it.Item1.ToString(), it.Item2 }, w3) { ForeColor = Color.Blue }));
            ListFallbackItems.Items.AddRange(avatars.Concat(weapons).ToArray());


            ListUpItems.BeginUpdate();
            var ua5 = ListUpItems.Groups.Add("ua5", "5星角色");
            var ua4 = ListUpItems.Groups.Add("ua4", "4星角色");
            var uw5 = ListUpItems.Groups.Add("uw5", "5星武器");
            var uw4 = ListUpItems.Groups.Add("uw4", "4星武器");
            var upAvatars = GetAvatarsByColor("yellow")
                .Select(it => new ListViewItem(new string[] { it.Item1.ToString(), it.Item2 }, ua5) { ForeColor = Color.OrangeRed })
                .Concat(GetAvatarsByColor("purple")
                .Select(it => new ListViewItem(new string[] { it.Item1.ToString(), it.Item2 }, ua4) { ForeColor = Color.Purple }));
            var upWeapons = GetWeaponsByColor("yellow")
                .Select(it => new ListViewItem(new string[] { it.Item1.ToString(), it.Item2 }, uw5) { ForeColor = Color.OrangeRed })
                .Concat(GetWeaponsByColor("purple")
                .Select(it => new ListViewItem(new string[] { it.Item1.ToString(), it.Item2 }, uw4) { ForeColor = Color.Purple }));
            ListUpItems.Items.AddRange(upAvatars.Concat(upWeapons).ToArray());

            ListFallbackItems.EndUpdate();
            ListUpItems.EndUpdate();
        }

        private IEnumerable<(int, string)> GetAvatarsByColor(string color)
        {
            for (int i = 0; i < GameData.AvatarColors.Count; i++)
            {
                if (GameData.AvatarColors.Names[i] == color)
                {
                    var id = GameData.AvatarColors.Ids[i];
                    var index = Array.IndexOf(GameData.Avatars.Ids, id % 1000 + 10000000);
                    if (index >= 0)
                        yield return (id, GameData.Avatars.Names[index]);
                }
            }
        }

        private IEnumerable<(int, string)> GetWeaponsByColor(string color)
        {
            for (int i = 0; i < GameData.WeaponColors.Count; i++)
            {
                if (GameData.WeaponColors.Names[i] == color)
                {
                    var id = GameData.WeaponColors.Ids[i];
                    var index = Array.IndexOf(GameData.Weapons.Ids, id);
                    if (index >= 0)
                        yield return (id, GameData.Weapons.Names[index]);
                }
            }
        }

        private void InitItems(GachaBanner2 banner)
        {
            var f = banner.FallbackItems3
                .Concat(banner.FallbackItems4Pool1)
                .Concat(banner.FallbackItems4Pool2)
                .Concat(banner.FallbackItems5Pool1)
                .Concat(banner.FallbackItems5Pool2)
                .ToArray();
            foreach (ListViewItem item in ListFallbackItems.Items)
                item.Checked = Array.IndexOf(f, int.Parse(item.Text)) >= 0;

            var u = banner.RateUpItems4.Concat(banner.RateUpItems5).ToArray();
            foreach (ListViewItem item in ListUpItems.Items)
                item.Checked = Array.IndexOf(u, int.Parse(item.Text)) >= 0;
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
                DTPBeginTime.Value          = DateTimeOffset.FromUnixTimeSeconds(banner.BeginTime).DateTime;
                DTPEndTime.Value            = DateTimeOffset.FromUnixTimeSeconds(banner.EndTime).DateTime;
                NUDSortId.Value             = banner.SortId;
                NUDEventChance5.Value       = banner.EventChance5;
                NUDEventChance4.Value       = banner.EventChance4;
                InitItems(banner);
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
                BeginTime         = (int)new DateTimeOffset(DTPBeginTime.Value).ToUnixTimeSeconds(),
                EndTime           = (int)new DateTimeOffset(DTPEndTime.Value).ToUnixTimeSeconds(),
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