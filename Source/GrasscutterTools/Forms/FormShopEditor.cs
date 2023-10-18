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

        /// <summary>
        /// 商店列表数据
        /// </summary>
        private Dictionary<int, List<ShopInfo>> Shops = new Dictionary<int, List<ShopInfo>>();

        /// <summary>
        /// 选中的商店类型
        /// </summary>
        private int SelectedShopType;

        #endregion - 成员 -

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

            base.OnFormClosed(e);
        }

        #endregion - 构造与窗体事件 -

        #region - Shop.json 文件相关 -

        /// <summary>
        /// 点击加载Shop.json按钮时触发
        /// </summary>
        private void BtnLoad_Click(object sender, EventArgs e)
        {
            var path = TxtShopJsonPath.Text.Trim();
            try
            {
                if (path == string.Empty)
                {
                    var dialog = new OpenFileDialog
                    {
                        FileName = "Shop.json",
                        Filter = "Shop.json/ShopGoodsExcelConfigData.json (*.json)|*.json|ShopGoodsData.txt (*.txt)|*.txt|All files (*.*)|*.*",
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
        /// <param name="path">文件路径</param>
        private void LoadShops(string path)
        {
            var name = Path.GetFileName(path);
            var content = File.ReadAllText(path);
            var funs = new Action<string>[3]
            {
                LoadShopsFromShopJson,
                LoadShopsFromShopGoodsExcelConfigData,
                LoadShopsFromTsv
            };
            if (name == "ShopGoodsExcelConfigData.json")
            {
                funs[0] = LoadShopsFromShopGoodsExcelConfigData;
                funs[1] = LoadShopsFromShopJson;
            }
            else if (name == "ShopGoodsData.txt")
            {
                funs[0] = LoadShopsFromTsv;
                funs[1] = LoadShopsFromShopJson;
                funs[2] = LoadShopsFromShopGoodsExcelConfigData;
            }

            Exception firstEx = null;

            foreach (var fun in funs)
            {
                try
                {
                    fun(content);
                    return;
                }
                catch (Exception ex)
                {
                    if (firstEx == null)
                        firstEx = ex;
                }
            }
            throw firstEx;

            //{
            //    try
            //    {
            //        // 尝试当作Shop.json解析
            //        LoadShopsFromShopJson(content);
            //    }
            //    catch (Exception ex)
            //    {
            //        try
            //        {
            //            // 尝试当作ShopGoodsExcelConfigData.json解析
            //            LoadShopsFromShopGoodsExcelConfigData(path);
            //        }
            //        catch
            //        {
            //            try
            //            {
            //                // 当Json解析失败时尝试以tsv方式解析
            //                LoadShopsFromTsv(content);
            //            }
            //            catch
            //            {
            //                throw ex;
            //            }
            //        }
            //    }
            //}
        }

        private void LoadShopsFromShopJson(string content)
        {
            var banners = JsonConvert.DeserializeObject<List<ShopTable>>(content);
            Shops = new Dictionary<int, List<ShopInfo>>(banners.Count);
            foreach (var item in banners)
                Shops.Add(item.ShopType, item.Items);
        }

        private void LoadShopsFromShopGoodsExcelConfigData(string content)
        {
            var banners = JsonConvert.DeserializeObject<List<ShopGoodsData>>(content);
            Shops = new Dictionary<int, List<ShopInfo>>();
            foreach (var kv in banners.GroupBy(it => it.ShopType))
                Shops.Add(kv.Key, kv.Select(it => new ShopInfo(it)).ToList());
        }

        /// <summary>
        /// 从TSV加载商店
        /// </summary>
        /// <param name="content">文件内容</param>
        private void LoadShopsFromTsv(string content)
        {
            var lines = content.Split('\n');
            Shops = new Dictionary<int, List<ShopInfo>>();
            for (int i = 1; i < lines.Length; i++)
            {
                var cells = lines[i].Split('\t');
                if (cells.Length < 31) continue;
                var goods = new ShopInfo
                {
                    GoodsId = int.Parse(cells[0]),
                    GoodsItem = new ItemParamData(int.Parse(cells[2]), int.Parse(cells[4])),
                    BuyLimit = TryParse(cells[16]),
                    MinLevel = TryParse(cells[29]),
                    MaxLevel = TryParse(cells[30]),
                    BeginTime = (int)new DateTimeOffset(DateTime.Parse(cells[20])).ToUnixTimeSeconds(),
                    EndTime = (int)new DateTimeOffset(DateTime.Parse(cells[21])).ToUnixTimeSeconds(),
                    RefreshType = (ShopRefreshType)TryParse(cells[17]),
                    ShopRefreshParam = TryParse(cells[18]),
                    HCoin = TryParse(cells[5]),
                    SCoin = TryParse(cells[6]),
                    MCoin = TryParse(cells[7]),
                    CostItemList = new List<ItemParamData>
                    {
                        new ItemParamData(TryParse(cells[8]), TryParse(cells[9])),
                        new ItemParamData(TryParse(cells[10]), TryParse(cells[11])),
                        new ItemParamData(TryParse(cells[12]), TryParse(cells[13])),
                        new ItemParamData(TryParse(cells[14]), TryParse(cells[15])),
                    }
                };

                var shopType = int.Parse(cells[1]);
                if (!Shops.TryGetValue(shopType, out List<ShopInfo> shops))
                    Shops.Add(shopType, shops = new List<ShopInfo>());
                shops.Add(goods);
            }
        }

        private static int TryParse(string value) => int.TryParse(value, out int n) ? n : 0;

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

                if (Path.GetFileName(path) != "Shop.json")
                {
                    var ret = MessageBox.Show(Resources.ShopJsonOverrideWarning + '\n' + path, Resources.Warning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (ret != DialogResult.Yes)
                        return;
                }

                // 序列化
                var banners = new List<ShopTable>(Shops.Count);
                foreach (var shop in Shops)
                {
                    if (shop.Value != null && shop.Value.Count > 0)
                    {
                        banners.Add(new ShopTable
                        {
                            ShopType = shop.Key,
                            Items = shop.Value,
                        });
                    }
                }
                File.WriteAllText(path, JsonConvert.SerializeObject(banners, new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    DefaultValueHandling = DefaultValueHandling.Ignore,
                }));
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
            if (ListShop.SelectedIndex == -1)
            {
                SelectedShopType = 0;
                return;
            }
            SelectedShopType = ItemMap.ToId(ListShop.SelectedItem as string);
            Shops.TryGetValue(SelectedShopType, out var shop);
            ShowGoodsList(shop);
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
            if (banner != null && banner.Count > 0)
            {
                ListGoods.Items.AddRange(banner.Select(it => it.ToString()).ToArray());
                //ListGoods.SelectedIndex = 0;
            }
            ListGoods.EndUpdate();
        }

        /// <summary>
        /// 商品列表选中项改变时触发
        /// </summary>
        private void ListGoods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListGoods.SelectedIndex == -1) return;
            ShowGoods(Shops[SelectedShopType][ListGoods.SelectedIndex]);
        }

        /// <summary>
        /// 点击删除商品按钮时触发
        /// </summary>
        private void BtnDeleteGoods_Click(object sender, EventArgs e)
        {
            if (ListGoods.SelectedIndex == -1) return;
            if (MessageBox.Show(Resources.AskConfirmDeletion, Resources.Tips, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Shops[SelectedShopType].RemoveAt(ListGoods.SelectedIndex);
                ListGoods.Items.RemoveAt(ListGoods.SelectedIndex);
            }
        }

        /// <summary>
        /// 点击清空商品按钮时触发
        /// </summary>
        private void BtnClearGoods_Click(object sender, EventArgs e)
        {
            if (ListGoods.Items.Count == 0) return;
            if (MessageBox.Show(Resources.AskConfirmDeletion, Resources.Tips, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Shops.Remove(SelectedShopType);
                ListGoods.Items.Clear();
            }
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
            DTPBeginTime.Value = DateTimeOffset.FromUnixTimeSeconds(goods.BeginTime).LocalDateTime;
            DTPEndTime.Value = DateTimeOffset.FromUnixTimeSeconds(goods.EndTime).LocalDateTime;
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
            if (ListShop.SelectedIndex == -1) return;

            if (ItemMap.TryToId(TxtGoodsItem.Text, out int itemId))
                NUDGoodsId.Value = SelectedShopType * 1000 + itemId % 1000;
        }

        /// <summary>
        /// 刷新类型选中项改变时触发
        /// </summary>
        private void CmbRefreshType_SelectedIndexChanged(object sender, EventArgs e)
        {
            NUDRefreshParm.Enabled = CmbRefreshType.SelectedIndex > 0;
            if (CmbRefreshType.SelectedIndex == 0)
                NUDRefreshParm.Value = 0;
            else if (NUDRefreshParm.Value == 0)
                NUDRefreshParm.Value = 1;
        }

        /// <summary>
        /// 点击保存商品按钮时触发
        /// </summary>
        private void BtnSaveGoods_Click(object sender, EventArgs e)
        {
            if (!ItemMap.TryToId(TxtGoodsItem.Text, out int itemId))
            {
                MessageBox.Show(Resources.EmptyInputTip, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 检查ID冲突
            var goodsId = (int)NUDGoodsId.Value;
            if (Shops.Any(kv => kv.Key != SelectedShopType && kv.Value.Any(it => it.GoodsId == goodsId)))
            {
                MessageBox.Show(Resources.GoodsIDConflictPrompt, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                List<ItemParamData> costs = new List<ItemParamData>();
                if (NUDCostItem1Count.Value > 0 && NUDCostItem1.Value > 0)
                    costs.Add(new ItemParamData((int)NUDCostItem1.Value, (int)NUDCostItem1Count.Value));
                if (NUDCostItem2Count.Value > 0 && NUDCostItem2.Value > 0)
                    costs.Add(new ItemParamData((int)NUDCostItem2.Value, (int)NUDCostItem2Count.Value));
                if (NUDCostItem3Count.Value > 0 && NUDCostItem3.Value > 0)
                    costs.Add(new ItemParamData((int)NUDCostItem3.Value, (int)NUDCostItem3Count.Value));
                if (NUDCostItem4Count.Value > 0 && NUDCostItem4.Value > 0)
                    costs.Add(new ItemParamData((int)NUDCostItem4.Value, (int)NUDCostItem4Count.Value));
                ShopInfo goods = new ShopInfo
                {
                    GoodsId = goodsId,
                    GoodsItem = new ItemParamData(itemId, (int)NUDGoodsItemCount.Value),
                    BuyLimit = (int)NUDBuyLimit.Value,
                    MinLevel = (int)NUDMinLevel.Value,
                    MaxLevel = (int)NUDMaxLevel.Value,
                    BeginTime = (int)new DateTimeOffset(DTPBeginTime.Value).ToUnixTimeSeconds(),
                    EndTime = (int)new DateTimeOffset(DTPEndTime.Value).ToUnixTimeSeconds(),
                    RefreshType = CmbRefreshType.SelectedIndex == -1 ? ShopRefreshType.NONE : (ShopRefreshType)CmbRefreshType.SelectedIndex,
                    ShopRefreshParam = (int)NUDRefreshParm.Value,
                    HCoin = (int)NUDCostHcoin.Value,
                    SCoin = (int)NUDCostScoin.Value,
                    MCoin = (int)NUDCostMcoin.Value,
                    CostItemList = costs,
                    // 以下属性不认识，代码里看似也没用，不写了
                    //BoughtNum
                    //DisableType
                    //PreGoodsIdList
                    //SecondarySheetId
                };

                if (Shops.TryGetValue(SelectedShopType, out var shop))
                {
                    var i = shop.FindIndex(it => it.GoodsId == goodsId);
                    if (i == -1)
                    {
                        // 增加到现有列表
                        shop.Add(goods);
                        ListGoods.Items.Add(goods.ToString());
                    }
                    else
                    {
                        // 修改
                        shop[i] = goods;
                        ListGoods.Items[i] = goods.ToString();
                    }
                }
                else
                {
                    // 增加到新列表
                    Shops[SelectedShopType] = new List<ShopInfo> { goods };
                    ListGoods.Items.Add(goods.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion - 商品信息 -

        #region - 物品列表 -

        /// <summary>
        /// 物品列表过滤框输入改变事件
        /// </summary>
        private void TxtItemFilter_TextChanged(object sender, EventArgs e)
        {
            UIUtil.ListBoxFilter(ListItems, GameData.Items.Lines, TxtItemFilter.Text);
            LblClearItemFilter.Visible = TxtItemFilter.Text.Length > 0;
        }

        /// <summary>
        /// 点击清空物品列表过滤器标签时触发
        /// </summary>
        private void LblClearItemFilter_Click(object sender, EventArgs e)
        {
            TxtItemFilter.Clear();
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