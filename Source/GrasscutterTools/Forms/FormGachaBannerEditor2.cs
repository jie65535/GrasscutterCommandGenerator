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

        private void LnkWeightHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Grasscutters/Grasscutter/pull/639");
        }

        private void LnkOpenOldEditor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new FormGachaBannerEditor().ShowDialog();
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
                    var index = Array.IndexOf(GameData.Avatars.Ids, id);
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

        #endregion - 卡池 -

        #region - 权重 -

        private struct GachaWeight
        {
            public int Count;
            public int Weight;

            public GachaWeight(int count, int weight)
            {
                Count = count;
                Weight = weight;
            }
        }

        private void InitWeights(GachaBanner2 banner)
        {
            TxtWeight5.Text = '[' + string.Join(", ", SelectWeights(banner.Weights5).Select(w => $"[{w.Count}, {w.Weight}]")) + ']';
            TxtWeight4.Text = '[' + string.Join(", ", SelectWeights(banner.Weights4).Select(w => $"[{w.Count}, {w.Weight}]")) + ']';
            TxtPoolWeight5.Text = '[' + string.Join(", ", SelectWeights(banner.PoolBalanceWeights5).Select(w => $"[{w.Count}, {w.Weight}]")) + ']';
            TxtPoolWeight4.Text = '[' + string.Join(", ", SelectWeights(banner.PoolBalanceWeights4).Select(w => $"[{w.Count}, {w.Weight}]")) + ']';
        }

        private IEnumerable<GachaWeight> SelectWeights(int[,] weights)
        {
            for (int i = 0; i < weights.GetLength(0); i++)
                yield return new GachaWeight(weights[i, 0], weights[i, 1]);
        }

        private int[,] GetWeights(string weights)
        {
            return JsonConvert.DeserializeObject<int[,]>(weights);
        }

        #endregion - 权重 -

        #region - 序列化 -

        private void ShowBanner(GachaBanner2 banner)
        {
            try
            {
                NUDGachaType.Value = banner.GachaType;
                NUDScheduleId.Value = banner.ScheduleId;
                CmbBannerType.SelectedIndex = (int)banner.BannerType;
                if (string.IsNullOrEmpty(banner.TitlePath) || !int.TryParse(banner.TitlePath.Substring("UI_GACHA_SHOW_PANEL_A".Length, 3), out int prefabId))
                    CmbPrefab.SelectedIndex = -1;
                else
                    CmbPrefab.SelectedIndex = Array.IndexOf(GameData.GachaBannerPrefabs.Ids, prefabId);
                RbCostItem224.Checked = banner.CostItem == 224;
                RbCostItem223.Checked = banner.CostItem == 223;
                DTPBeginTime.Value = DateTimeOffset.FromUnixTimeSeconds(banner.BeginTime).DateTime;
                DTPEndTime.Value = DateTimeOffset.FromUnixTimeSeconds(banner.EndTime).DateTime;
                NUDSortId.Value = banner.SortId;
                NUDEventChance5.Value = banner.EventChance5;
                NUDEventChance4.Value = banner.EventChance4;
                ChkRemoveC6FormPool.Checked = banner.RemoveC6FromPool;
                ChkAutoStripRateUpFromFallback.Checked = banner.AutoStripRateUpFromFallback;
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
                GachaType = (int)NUDGachaType.Value,
                ScheduleId = (int)NUDScheduleId.Value,
                BannerType = (BannerType)CmbBannerType.SelectedIndex,
                PrefabPath = $"GachaShowPanel_A{prefabId:000}",
                PreviewPrefabPath = $"UI_Tab_GachaShowPanel_A{prefabId:000}",
                TitlePath = $"UI_GACHA_SHOW_PANEL_A{prefabId:000}_TITLE",
                CostItem = RbCostItem224.Checked ? 224 : 223,
                BeginTime = (int)new DateTimeOffset(DTPBeginTime.Value, TimeSpan.Zero).ToUnixTimeSeconds(),
                EndTime = (int)new DateTimeOffset(DTPEndTime.Value, TimeSpan.Zero).ToUnixTimeSeconds(),
                SortId = (int)NUDSortId.Value,
                EventChance5 = (int)NUDEventChance5.Value,
                EventChance4 = (int)NUDEventChance4.Value,

                RateUpItems4 = GetCheckedItems(ListUpItems, ListUpItems.Groups["GroupUpA4"])
                                         .Concat(GetCheckedItems(ListUpItems, ListUpItems.Groups["GroupUpW4"]))
                                         .ToArray(),
                RateUpItems5 = GetCheckedItems(ListUpItems, ListUpItems.Groups["GroupUpA5"])
                                         .Concat(GetCheckedItems(ListUpItems, ListUpItems.Groups["GroupUpW5"]))
                                         .ToArray(),

                FallbackItems3 = GetCheckedItems(ListFallbackItems, ListFallbackItems.Groups["GroupA3"])
                                         .Concat(GetCheckedItems(ListFallbackItems, ListFallbackItems.Groups["GroupW3"]))
                                         .ToArray(),
                FallbackItems4Pool1 = GetCheckedItems(ListFallbackItems, ListFallbackItems.Groups["GroupA4"]).ToArray(),
                FallbackItems4Pool2 = GetCheckedItems(ListFallbackItems, ListFallbackItems.Groups["GroupW4"]).ToArray(),
                FallbackItems5Pool1 = GetCheckedItems(ListFallbackItems, ListFallbackItems.Groups["GroupA5"]).ToArray(),
                FallbackItems5Pool2 = GetCheckedItems(ListFallbackItems, ListFallbackItems.Groups["GroupW5"]).ToArray(),

                RemoveC6FromPool = ChkRemoveC6FormPool.Checked,
                AutoStripRateUpFromFallback = ChkAutoStripRateUpFromFallback.Checked,

                Weights4 = GetWeights(TxtWeight4.Text),
                Weights5 = GetWeights(TxtWeight5.Text),
                PoolBalanceWeights4 = GetWeights(TxtPoolWeight4.Text),
                PoolBalanceWeights5 = GetWeights(TxtPoolWeight5.Text),
            };
            return banner;
        }

        private void BtnGen_Click(object sender, EventArgs e)
        {
            try
            {
                var banner = ParseBanner();
                if (banner != null)
                {
                    var json = JsonConvert.SerializeObject(banner);
                    json = json.Replace(",\"", ",\r\n  \"").Insert(1, "\r\n  ");
                    TxtJson.Text = json.Insert(json.Length-1, "\r\n");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion - 序列化 -
    }
}