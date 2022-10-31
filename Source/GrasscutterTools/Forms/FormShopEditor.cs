using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using GrasscutterTools.Game;
using GrasscutterTools.Game.Shop;
using GrasscutterTools.Properties;
using GrasscutterTools.Utils;

using Newtonsoft.Json;

namespace GrasscutterTools.Forms
{
    public partial class FormShopEditor : Form
    {
        #region - 成员 -

        private Dictionary<int, List<ShopInfo>> Shops = new Dictionary<int, List<ShopInfo>>();

        private List<ShopInfo> SelectedShop = new List<ShopInfo>();

        #endregion

        #region - 构造与窗体事件 -

        public FormShopEditor()
        {
            InitializeComponent();

            Icon = Resources.IconGrasscutter;

            ListShop.Items.AddRange(GameData.ShopType.Lines);
            ListItems.Items.AddRange(GameData.Items.Lines);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            try
            {
                // 加载文件路径
                var path = Settings.Default.ShopJsonPath;
                TxtShopJsonPath.Text = path;
                if (!string.IsNullOrEmpty(path) && File.Exists(path))
                    LoadShops(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            Settings.Default.ShopJsonPath = TxtShopJsonPath.Text;
            Settings.Default.Save();

            base.OnFormClosed(e);
        }

        #endregion - 构造与窗体事件 -

        #region - Shop.json 文件相关 -

        /// <summary>
        /// 点击加载Shop.json按钮时触发
        /// </summary>
        private void BtnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                var path = TxtShopJsonPath.Text.Trim();
                if (path == string.Empty)
                {
                    var dialog = new OpenFileDialog
                    {
                        FileName = "Shop.json",
                        Filter = "Shop.Json (*.json)|*.json|All files (*.*)|*.*",
                    };
                    var result = dialog.ShowDialog();
                    if (result == DialogResult.OK)
                        path = TxtShopJsonPath.Text = dialog.FileName;
                    else
                        return;
                }

                // 反序列化
                LoadShops(path);
                MessageBox.Show("OK", Resources.Tips, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 加载商店
        /// </summary>
        /// <param name="path"></param>
        private void LoadShops(string path)
        {
            // 反序列化
            var banners = JsonConvert.DeserializeObject<List<ShopTable>>(File.ReadAllText(path));
            Shops = new Dictionary<int, List<ShopInfo>>(banners.Count);
            foreach (var item in banners)
                Shops.Add(item.ShopType, item.Items);
        }

        /// <summary>
        /// 点击保存Shop.json按钮时触发
        /// </summary>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var path = TxtShopJsonPath.Text.Trim();
                if (path == string.Empty)
                {
                    var dialog = new SaveFileDialog
                    {
                        FileName = "Shop.json",
                        Filter = "Shop.json (*.json)|*.json|All files (*.*)|*.*",
                    };
                    var result = dialog.ShowDialog();
                    if (result == DialogResult.OK)
                        path = TxtShopJsonPath.Text = dialog.FileName;
                    else
                        return;
                }

                // 序列化
                var banners = new List<ShopTable>(Shops.Count);
                foreach (var shop in Shops)
                {
                    banners.Add(new ShopTable
                    {
                        ShopType = shop.Key,
                        Items = shop.Value,
                    });
                }
                File.WriteAllText(path, JsonConvert.SerializeObject(banners));
                MessageBox.Show("OK", Resources.Tips, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion - Shop.json 文件相关 -

        #region - 商店列表 -

        /// <summary>
        /// 商店列表选中项改变时触发
        /// </summary>
        private void ListShop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListShop.SelectedIndex == -1) return;
            var shopType = ItemMap.ToId(ListShop.SelectedItem as string);
            SelectedShop.Clear();
            if (Shops.TryGetValue(shopType, out var items))
                SelectedShop.AddRange(items);
            ShowGoodsList(SelectedShop);
        }

        #endregion - 商店列表 -

        #region - 商品列表 -

        /// <summary>
        /// 显示商品列表
        /// </summary>
        private void ShowGoodsList(List<ShopInfo> banner)
        {
            ListGoods.BeginUpdate();
            ListGoods.Items.Clear();
            if (banner.Count > 0)
            {
                ListGoods.Items.AddRange(banner.Select(it => it.ToString()).ToArray());
                ListGoods.SelectedIndex = 0;
            }
            ListGoods.EndUpdate();
        }

        /// <summary>
        /// 商品列表选中项改变时触发
        /// </summary>
        private void ListGoods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListGoods.SelectedIndex == -1) return;
            ShowGoods(SelectedShop[ListGoods.SelectedIndex]);
        }

        #endregion - 商品列表 -

        #region - 商品信息 -

        /// <summary>
        /// 显示商品
        /// </summary>
        /// <param name="goods"></param>
        private void ShowGoods(ShopInfo goods)
        {
            NUDGoodsId.Value = goods.GoodsId;
            TxtGoodsItem.Text = $"{goods.GoodsItem.Id}:{GameData.Items[goods.GoodsItem.Id]}";
            NUDGoodsItemCount.Value = goods.GoodsItem.Count;
            NUDBuyLimit.Value = goods.BuyLimit;
            NUDMinLevel.Value = goods.MinLevel;
            NUDMaxLevel.Value = goods.MaxLevel;
            DTPBeginTime.Value = DateTimeOffset.FromUnixTimeSeconds(goods.BeginTime).DateTime;
            DTPEndTime.Value = DateTimeOffset.FromUnixTimeSeconds(goods.EndTime).DateTime;
            NUDRefreshParm.Value = goods.ShopRefreshParam;
            CmbRefreshType.SelectedIndex = (int)goods.RefreshType;
            NUDCostHcoin.Value = goods.HCoin;
            NUDCostScoin.Value = goods.SCoin;
            NUDCostMcoin.Value = goods.MCoin;
            var items = new ItemParamData[4];
            goods.CostItemList?.CopyTo(items, 0);
            NUDCostItem1.Value = items[0].Id;
            NUDCostItem1Count.Value = items[0].Count;
            NUDCostItem2.Value = items[1].Id;
            NUDCostItem2Count.Value = items[1].Count;
            NUDCostItem3.Value = items[2].Id;
            NUDCostItem3Count.Value = items[2].Count;
            NUDCostItem4.Value = items[3].Id;
            NUDCostItem4Count.Value = items[3].Count;
        }

        /// <summary>
        /// 点击生成商品ID链接标签时触发
        /// </summary>
        private void LnkGenGoodsId_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        /// <summary>
        /// 刷新类型选中项改变时触发
        /// </summary>
        private void CmbRefreshType_SelectedIndexChanged(object sender, EventArgs e)
        {
            NUDRefreshParm.Enabled = CmbRefreshType.SelectedIndex > 0;
        }

        /// <summary>
        /// 点击保存商品按钮时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSaveGoods_Click(object sender, EventArgs e)
        {
        }

        #endregion - 商品信息 -

        #region - 物品列表 -

        /// <summary>
        /// 物品列表过滤框输入改变事件
        /// </summary>
        private void TxtItemFilter_TextChanged(object sender, EventArgs e)
        {
            UIUtil.ListBoxFilter(ListItems, GameData.Items.Lines, TxtItemFilter.Text);
        }

        /// <summary>
        /// 物品列表选中项改变时触发
        /// </summary>
        private void ListItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListItems.SelectedIndex == -1) return;
            TxtGoodsItem.Text = ListItems.SelectedItem as string;
        }

        #endregion - 物品列表 -

    }
}