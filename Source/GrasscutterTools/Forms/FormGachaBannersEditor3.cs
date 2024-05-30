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
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using GrasscutterTools.Game;
using GrasscutterTools.Game.Gacha;
using GrasscutterTools.Properties;
using GrasscutterTools.Utils;

using Newtonsoft.Json;

namespace GrasscutterTools.Forms
{
    /// <summary>
    /// 卡池编辑器
    /// </summary>
    public partial class FormGachaBannersEditor3 : Form
    {
        #region - 成员 -

        private List<GachaBanner3> Banners;

        #endregion - 成员 -

        #region - 构造与窗体事件 -

        public FormGachaBannersEditor3()
        {
            InitializeComponent();

            Icon = Resources.IconGrasscutter;
            CmbBannerType.SelectedIndex = 0;
            InitBannerPrefab();
            InitCheckedListBoxs();

            ShowBanner(new GachaBanner3());
        }

        private void InitBannerPrefab()
        {
            CmbPrefab.DisplayMember = "Value";
            CmbPrefab.DataSource = GameData.GachaBannerPrefabs;
            CmbTitlePath.DisplayMember = "Value";
            CmbTitlePath.DataSource = GameData.GachaBannerTitles;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            try
            {
                // 加载文件路径
                var path = Settings.Default.BannersJsonPath;
                TxtBannersJsonPath.Text = path;
                if (!string.IsNullOrEmpty(path) && File.Exists(path))
                    LoadBanners(File.ReadAllText(path));
                else
                    LoadBanners(Encoding.UTF8.GetString(Resources.Banners));
            }
            catch (Exception ex)
            {
                LoadBanners(Encoding.UTF8.GetString(Resources.Banners));
                MessageBox.Show(ex.ToString(), Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // 保存文件路径
            Settings.Default.BannersJsonPath = TxtBannersJsonPath.Text;

            base.OnFormClosed(e);
        }

        private void LnkWeightHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Grasscutters/Grasscutter/pull/639");
        }

        private void LnkOpenOldEditor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new FormGachaBannerEditor().ShowDialog();
        }

        #endregion - 构造与窗体事件 -

        #region - Banners.json 文件相关 -

        /// <summary>
        /// 加载按钮点击时触发
        /// </summary>
        private void BtnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                var path = TxtBannersJsonPath.Text.Trim();
                if (path == string.Empty)
                {
                    var dialog = new OpenFileDialog
                    {
                        FileName = "Banners.json",
                        Filter = "Banners.Json (*.json)|*.json|All files (*.*)|*.*",
                    };
                    var result = dialog.ShowDialog();
                    if (result == DialogResult.OK)
                        path = TxtBannersJsonPath.Text = dialog.FileName;
                    else
                        return;
                }

                var content = File.ReadAllText(path);
                if (string.IsNullOrEmpty(content))
                    content = Encoding.UTF8.GetString(Resources.Banners);
                LoadBanners(content);
                MessageBox.Show("OK", Resources.Tips, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 保存按钮点击时触发
        /// </summary>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var path = TxtBannersJsonPath.Text.Trim();
                if (path == string.Empty)
                {
                    var dialog = new SaveFileDialog
                    {
                        FileName = "Banners.json",
                        Filter = "Banners.json (*.json)|*.json|All files (*.*)|*.*",
                    };
                    var result = dialog.ShowDialog();
                    if (result == DialogResult.OK)
                        path = TxtBannersJsonPath.Text = dialog.FileName;
                    else
                        return;
                }

                var json = JsonConvert.SerializeObject(Banners, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore })
                    .Replace(",\"", ",\r\n  \"").Replace("{\"", "{\r\n  \"").Replace("\"}", "\"\r\n}");
                File.WriteAllText(path, json);
                MessageBox.Show("OK", Resources.Tips, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion - Banners.json 文件相关 -

        #region - 卡池列表 -

        /// <summary>
        /// 从指定Json中加载卡池
        /// </summary>
        /// <param name="bannersJson">Banner.json 内容</param>
        private void LoadBanners(string bannersJson)
        {
            // 反序列化
            Banners = JsonConvert.DeserializeObject<List<GachaBanner3>>(bannersJson);
            ShowBanners();
        }

        /// <summary>
        /// 显示当前卡池列表
        /// </summary>
        private void ShowBanners()
        {
            ListBanners.BeginUpdate();
            ListBanners.Items.Clear();
            ListBanners.Items.AddRange(Banners.ToArray());
            ListBanners.EndUpdate();
        }

        /// <summary>
        /// 卡池列表选中项改变时触发
        /// </summary>
        private void ListBanners_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBanners.SelectedIndex < 0) return;
            ShowBanner(ListBanners.SelectedItem as GachaBanner3);
        }

        /// <summary>
        /// 点击添加或更新卡池按钮时触发
        /// </summary>
        private void BtnAddOrUpdate_Click(object sender, EventArgs e)
        {
            var banner = ParseBanner();
            var i = Banners.FindIndex(it => it.GachaType == banner.GachaType && it.ScheduleId == banner.ScheduleId);
            if (i >= 0)
            {
                Banners[i] = banner;
                ListBanners.Items[i] = banner;
            }
            else
            {
                Banners.Add(banner);
                ListBanners.Items.Add(banner);
            }
        }

        /// <summary>
        /// 点击删除卡池按钮时触发
        /// </summary>
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (ListBanners.SelectedIndex < 0) return;
            if (MessageBox.Show(Resources.AskConfirmDeletion, Resources.Tips, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Banners.RemoveAt(ListBanners.SelectedIndex);
                ListBanners.Items.RemoveAt(ListBanners.SelectedIndex);
            }
        }

        /// <summary>
        /// 点击清空卡池按钮时触发
        /// </summary>
        private void BtnClear_Click(object sender, EventArgs e)
        {
            if (ListBanners.Items.Count < 0) return;
            if (MessageBox.Show(Resources.AskConfirmDeletion, Resources.Tips, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Banners.Clear();
                ListBanners.Items.Clear();
            }
        }

        #endregion - 卡池列表 -

        #region - 卡池 -

        private void LnkCheckLatestBanners_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UIUtil.OpenURL("https://github.com/Zhaokugua/Grasscutter_Banners");
        }

        private void InitCheckedListBoxs()
        {
            ListFallbackItems.BeginUpdate();
            var a5 = ListFallbackItems.Groups["GroupA5"];
            var a4 = ListFallbackItems.Groups["GroupA4"];
            var w5 = ListFallbackItems.Groups["GroupW5"];
            var w4 = ListFallbackItems.Groups["GroupW4"];
            var w3 = ListFallbackItems.Groups["GroupW3"];
            var avatars = GetAvatarsByColor("5")
                .Select(it => new ListViewItem(new string[] { it.Item1.ToString(), it.Item2 }, a5) { ForeColor = Color.OrangeRed })
                .Concat(GetAvatarsByColor("4")
                .Select(it => new ListViewItem(new string[] { it.Item1.ToString(), it.Item2 }, a4) { ForeColor = Color.Purple }));
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
            var upAvatars = GetAvatarsByColor("5")
                .Select(it => new ListViewItem(new string[] { it.Item1.ToString(), it.Item2 }, ua5) { ForeColor = Color.OrangeRed })
                .Concat(GetAvatarsByColor("4")
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

        private void InitItems(GachaBanner3 banner)
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

        private void InitWeights(GachaBanner3 banner)
        {
            TxtWeight5.Text = '[' + string.Join(", ", SelectWeights(banner.Weights5).Select(w => $"[{w.Count}, {w.Weight}]")) + ']';
            TxtWeight4.Text = '[' + string.Join(", ", SelectWeights(banner.Weights4).Select(w => $"[{w.Count}, {w.Weight}]")) + ']';
            TxtPoolWeight5.Text = '[' + string.Join(", ", SelectWeights(banner.PoolBalanceWeights5).Select(w => $"[{w.Count}, {w.Weight}]")) + ']';
            TxtPoolWeight4.Text = '[' + string.Join(", ", SelectWeights(banner.PoolBalanceWeights4).Select(w => $"[{w.Count}, {w.Weight}]")) + ']';

            ChartWeights.SuspendLayout();
            ChartWeights.Series[0].Points.Clear();
            foreach (var w in SelectWeights(banner.Weights5))
                ChartWeights.Series[0].Points.AddXY(w.Count, w.Weight / 100.0);
            ChartWeights.Series[1].Points.Clear();
            foreach (var w in SelectWeights(banner.Weights4))
                ChartWeights.Series[1].Points.AddXY(w.Count, w.Weight / 100.0);
            ChartWeights.ResumeLayout();
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

        #region - 卡池参数 -

        private static string TrimPrefixAndSuffix(string text, int prefixLength, int suffixLength)
        {
            return text.Substring(prefixLength, text.Length - prefixLength - suffixLength);
        }


        /// <summary>
        /// 显示指定卡池参数
        /// </summary>
        /// <param name="banner">卡池对象</param>
        private void ShowBanner(GachaBanner3 banner)
        {
            try
            {
                NUDGachaType.Value = banner.GachaType;
                NUDScheduleId.Value = banner.ScheduleId;
                CmbBannerType.SelectedIndex = (int)banner.BannerType;
                const string prefabPrefix = "GachaShowPanel_";
                if (string.IsNullOrEmpty(banner.PrefabPath) || banner.PrefabPath.Length <= prefabPrefix.Length)
                {
                    CmbPrefab.SelectedIndex = -1;
                }
                else
                {
                    var prefabKey = banner.PrefabPath.Substring(prefabPrefix.Length);
                    CmbPrefab.SelectedIndex = GameData.GachaBannerPrefabs.FindIndex(it => it.Key == prefabKey);
                }

                const string titlePrefix = "UI_GACHA_SHOW_PANEL_";
                const string suffix = "_TITLE";
                if (string.IsNullOrEmpty(banner.TitlePath) || banner.TitlePath.Length <= titlePrefix.Length + suffix.Length)
                {
                    CmbTitlePath.SelectedIndex = -1;
                }
                else
                {
                    var titleKey = TrimPrefixAndSuffix(banner.TitlePath, titlePrefix.Length, suffix.Length);
                    CmbTitlePath.SelectedIndex = GameData.GachaBannerTitles.FindIndex(it => it.Key == titleKey);
                }
                RbCostItem224.Checked = banner.CostItemId == 224;
                RbCostItem223.Checked = banner.CostItemId == 223;
                NUDCostItemAmount1.Value = banner.CoseItemAmount;
                NUDCostItemAmount10.Value = banner.CoseItemAmount10;
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

        private GachaBanner3 ParseBanner()
        {
            if (CmbBannerType.SelectedIndex < 0)
            {
                MessageBox.Show("请选择奖池类型", Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            if (CmbPrefab.SelectedIndex < 0 || CmbTitlePath.SelectedIndex < 0)
            {
                MessageBox.Show("请选择奖池预制", Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            var prefabId = GameData.GachaBannerPrefabs[CmbPrefab.SelectedIndex].Key;
            var titleId = GameData.GachaBannerTitles[CmbTitlePath.SelectedIndex].Key;
            var banner = new GachaBanner3
            {
                GachaType = (int)NUDGachaType.Value,
                ScheduleId = (int)NUDScheduleId.Value,
                BannerType = (BannerType)CmbBannerType.SelectedIndex,
                PrefabPath = $"GachaShowPanel_{prefabId}",
                PreviewPrefabPath = $"UI_Tab_GachaShowPanel_{prefabId}",
                TitlePath = $"UI_GACHA_SHOW_PANEL_{titleId}_TITLE",
                CostItemId = RbCostItem224.Checked ? 224 : 223,
                CoseItemAmount = (int)NUDCostItemAmount1.Value,
                CostItemId10 = RbCostItem224.Checked ? 224 : 223,
                CoseItemAmount10 = (int)NUDCostItemAmount10.Value,
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

        #endregion - 卡池参数 -
    }
}