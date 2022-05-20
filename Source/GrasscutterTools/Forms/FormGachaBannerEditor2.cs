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
using System.Windows.Forms.DataVisualization.Charting;

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

        #region - 卡池 -

        private void InitCheckedListBoxs()
        {
            ListFallbackItems.BeginUpdate();
            var a5 = ListFallbackItems.Groups["GroupA5"];
            var a4 = ListFallbackItems.Groups["GroupA4"];
            var a3 = ListFallbackItems.Groups["GroupA3"];
            var w5 = ListFallbackItems.Groups["GroupW5"];
            var w4 = ListFallbackItems.Groups["GroupW4"];
            var w3 = ListFallbackItems.Groups["GroupW3"];
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
            ListFallbackItems.Items.Clear();
            ListFallbackItems.Items.AddRange(avatars.Concat(weapons).ToArray());


            ListUpItems.BeginUpdate();
            var ua5 = ListUpItems.Groups["GroupUpA5"];
            var ua4 = ListUpItems.Groups["GroupUpA4"];
            var uw5 = ListUpItems.Groups["GroupUpW5"];
            var uw4 = ListUpItems.Groups["GroupUpW4"];
            var upAvatars = GetAvatarsByColor("yellow")
                .Select(it => new ListViewItem(new string[] { it.Item1.ToString(), it.Item2 }, ua5) { ForeColor = Color.OrangeRed })
                .Concat(GetAvatarsByColor("purple")
                .Select(it => new ListViewItem(new string[] { it.Item1.ToString(), it.Item2 }, ua4) { ForeColor = Color.Purple }));
            var upWeapons = GetWeaponsByColor("yellow")
                .Select(it => new ListViewItem(new string[] { it.Item1.ToString(), it.Item2 }, uw5) { ForeColor = Color.OrangeRed })
                .Concat(GetWeaponsByColor("purple")
                .Select(it => new ListViewItem(new string[] { it.Item1.ToString(), it.Item2 }, uw4) { ForeColor = Color.Purple }));
            ListUpItems.Items.Clear();
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

        private IEnumerable<int> GetCheckedItems(ListView list, ListViewGroup group)
        {
            foreach (ListViewItem item in list.CheckedItems)
                if (item.Group == group)
                    yield return int.Parse(item.Text);
        }

        #endregion

        #region - 权重 -

        Series SeriesW5;
        Series SeriesW4;
        Series SeriesPW5;
        Series SeriesPW4;

        private void InitWeights(GachaBanner2 banner)
        {
            var w5  = ListBannerWeights.Groups["GroupWeight5"];
            var w4  = ListBannerWeights.Groups["GroupWeight4"];
            var pw5 = ListBannerWeights.Groups["GroupPoolWeight5"];
            var pw4 = ListBannerWeights.Groups["GroupPoolWeight4"];
            SeriesW5 = ChartWeights.Series["SeriesWeight5"];
            SeriesW5.Color = Color.OrangeRed;
            SeriesW5.Points.Clear();
            SeriesW4 = ChartWeights.Series["SeriesWeight4"];
            SeriesW4.Color = Color.Purple;
            SeriesW4.Points.Clear();
            SeriesPW5 = ChartWeights.Series["SeriesPoolWeight5"];
            SeriesPW5.Color = Color.Orange;
            SeriesPW5.Points.Clear();
            SeriesPW4 = ChartWeights.Series["SeriesPoolWeight4"];
            SeriesPW4.Color = Color.MediumPurple;
            SeriesPW4.Points.Clear();
            var t = SelectWeights(banner.Weights5).Select(it => new ListViewItem(it, w5) { ForeColor = SeriesW5.Color })
                .Concat(SelectWeights(banner.Weights4).Select(it => new ListViewItem(it, w4) { ForeColor = SeriesW4.Color }))
                .Concat(SelectWeights(banner.PoolBalanceWeights5).Select(it => new ListViewItem(it, pw5) { ForeColor = SeriesPW5.Color }))
                .Concat(SelectWeights(banner.PoolBalanceWeights4).Select(it => new ListViewItem(it, pw4) { ForeColor = SeriesPW4.Color }));
            ListBannerWeights.BeginUpdate();
            ListBannerWeights.Items.Clear();
            ListBannerWeights.Items.AddRange(t.ToArray());
            ListBannerWeights.EndUpdate();
            UpdateChart();
        }

        private void UpdateChart()
        {
            // TODO
        }

        private IEnumerable<string[]> SelectWeights(int[,] weights)
        {
            for (int i = 0; i < weights.GetLength(0); i++)
                yield return new string[] { weights[i, 0].ToString(), weights[i, 1].ToString() };
        }

        private int[,] GetWeights(ListViewGroup group)
        {
            var weights = new int[group.Items.Count, 2];
            int i = 0;
            foreach (ListViewItem item in group.Items)
            {
                weights[i, 0] = int.Parse(item.SubItems[0].Text);
                weights[i, 1] = int.Parse(item.SubItems[1].Text);
                i++;
            }
            return weights;
        }

        private void ListBannerWeights_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ListBannerWeights.SelectedItems.Count != 1)
                return;
            MessageBox.Show("TODO");
        }

        private void MenuItemEdit_Click(object sender, EventArgs e)
        {
            if (ListBannerWeights.SelectedItems.Count != 1)
            {
                MessageBox.Show("请先选择目标", Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("TODO");
        }

        private void MenuItemAdd_Click(object sender, EventArgs e)
        {
            if (ListBannerWeights.SelectedItems.Count != 1)
            {
                MessageBox.Show("请先选择目标", Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("TODO");
        }

        private void MenuItemRemove_Click(object sender, EventArgs e)
        {
            if (ListBannerWeights.SelectedItems.Count != 1)
            {
                MessageBox.Show("请先选择目标", Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("TODO");
        }

        #endregion

        #region - 序列化 -

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
                InitWeights(banner);
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
                GachaType           = (int)NUDGachaType.Value,
                ScheduleId          = (int)NUDScheduleId.Value,
                BannerType          = (BannerType)CmbBannerType.SelectedIndex,
                PrefabPath          = $"GachaShowPanel_A{prefabId:000}",
                PreviewPrefabPath   = $"UI_Tab_GachaShowPanel_A{prefabId:000}",
                TitlePath           = $"UI_GACHA_SHOW_PANEL_A{prefabId:000}_TITLE",
                CostItem            = RbCostItem224.Checked ? 224 : 223,
                BeginTime           = (int)new DateTimeOffset(DTPBeginTime.Value).ToUnixTimeSeconds(),
                EndTime             = (int)new DateTimeOffset(DTPEndTime.Value).ToUnixTimeSeconds(),
                SortId              = (int)NUDSortId.Value,
                EventChance5        = (int)NUDEventChance5.Value,
                EventChance4        = (int)NUDEventChance4.Value,
                FallbackItems3      = GetCheckedItems(ListFallbackItems, ListFallbackItems.Groups["GroupA3"])
                                         .Concat(GetCheckedItems(ListFallbackItems, ListFallbackItems.Groups["GroupW3"]))
                                         .ToArray(),
                FallbackItems4Pool1 = GetCheckedItems(ListFallbackItems, ListFallbackItems.Groups["GroupA4"]).ToArray(),
                FallbackItems4Pool2 = GetCheckedItems(ListFallbackItems, ListFallbackItems.Groups["GroupW4"]).ToArray(),
                FallbackItems5Pool1 = GetCheckedItems(ListFallbackItems, ListFallbackItems.Groups["GroupA5"]).ToArray(),
                FallbackItems5Pool2 = GetCheckedItems(ListFallbackItems, ListFallbackItems.Groups["GroupW5"]).ToArray(),

                Weights4            = GetWeights(ListBannerWeights.Groups["GroupWeight4"]),
                Weights5            = GetWeights(ListBannerWeights.Groups["GroupWeight5"]),
                PoolBalanceWeights4 = GetWeights(ListBannerWeights.Groups["GroupPoolWeight4"]),
                PoolBalanceWeights5 = GetWeights(ListBannerWeights.Groups["GroupPoolWeight5"]),
        };
            return banner;
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
                ShowBanner(JsonConvert.DeserializeObject<GachaBanner2>(TxtJson.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Json解析失败，错误消息：" + ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
        
    }
}