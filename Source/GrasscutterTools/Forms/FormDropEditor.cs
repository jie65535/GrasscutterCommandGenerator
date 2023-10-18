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
using GrasscutterTools.Game.Drop;
using GrasscutterTools.Properties;
using GrasscutterTools.Utils;

using Newtonsoft.Json;

namespace GrasscutterTools.Forms
{
    public partial class FormDropEditor : Form
    {
        #region - 成员 -

        /// <summary>
        /// 掉落池
        /// Key:怪物ID
        /// Value:掉落列表
        /// </summary>
        private Dictionary<int, List<DropData>> Banners;

        /// <summary>
        /// 怪物集
        /// </summary>
        private readonly string[] Monsters;

        /// <summary>
        /// 当前选中项的掉落列表
        /// （当选中多条时，数据为交集）
        /// </summary>
        private readonly List<DropData> SelectedDropList = new List<DropData>();

        /// <summary>
        /// 掉落物剪贴板
        /// </summary>
        private readonly List<DropData> DropClipboard = new List<DropData>();

        #endregion - 成员 -

        #region - 构造与窗体事件 -

        public FormDropEditor()
        {
            InitializeComponent();

            Icon = Resources.IconGrasscutter;

            Monsters = GameData.Monsters.AllLines.ToArray();
            Array.Sort(Monsters);

            ListMonsters.Items.AddRange(Monsters);
            ListItems.Items.AddRange(GameData.Items.Lines);

            Banners = new Dictionary<int, List<DropData>>();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            try
            {
                // 加载文件路径
                var path = Settings.Default.DropJsonPath;
                TxtDropJsonPath.Text = path;
                if (!string.IsNullOrEmpty(path) && File.Exists(path))
                    LoadBanners(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // 保存文件路径
            Settings.Default.DropJsonPath = TxtDropJsonPath.Text;

            base.OnFormClosed(e);
        }

        #endregion - 构造与窗体事件 -

        #region - Drop.json 文件相关 -

        /// <summary>
        /// 加载按钮点击时触发
        /// </summary>
        private void BtnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                var path = TxtDropJsonPath.Text.Trim();
                if (path == string.Empty)
                {
                    var dialog = new OpenFileDialog
                    {
                        FileName = "Drop.json",
                        Filter = "Drop.Json (*.json)|*.json|All files (*.*)|*.*",
                    };
                    var result = dialog.ShowDialog();
                    if (result == DialogResult.OK)
                        path = TxtDropJsonPath.Text = dialog.FileName;
                    else
                        return;
                }

                // 反序列化
                LoadBanners(path);
                MessageBox.Show("OK", Resources.Tips, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBanners(string path)
        {
            // 反序列化
            var banners = JsonConvert.DeserializeObject<List<DropInfo>>(File.ReadAllText(path));
            Banners = new Dictionary<int, List<DropData>>(banners.Count);
            foreach (var item in banners)
                Banners.Add(item.MonsterId, item.DropDataList);
        }

        /// <summary>
        /// 保存按钮点击时触发
        /// </summary>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var path = TxtDropJsonPath.Text.Trim();
                if (path == string.Empty)
                {
                    var dialog = new SaveFileDialog
                    {
                        FileName = "Drop.json",
                        Filter = "Drop.json (*.json)|*.json|All files (*.*)|*.*",
                    };
                    var result = dialog.ShowDialog();
                    if (result == DialogResult.OK)
                        path = TxtDropJsonPath.Text = dialog.FileName;
                    else
                        return;
                }

                // 序列化
                var banners = new List<DropInfo>(Banners.Count);
                foreach (var item in Banners)
                {
                    banners.Add(new DropInfo
                    {
                        MonsterId = item.Key,
                        DropDataList = item.Value,
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

        #endregion - Drop.json 文件相关 -

        #region - 怪物列表 -

        /// <summary>
        /// 怪物列表过滤器文本改变时触发
        /// </summary>
        private void TxtMonsterFilter_TextChanged(object sender, EventArgs e)
        {
            UIUtil.ListBoxFilter(ListMonsters, Monsters, TxtMonsterFilter.Text);
            LblClearMonsterFilter.Visible = TxtMonsterFilter.Text.Length > 0;
        }

        /// <summary>
        /// 点击清空怪物过滤器标签时触发
        /// </summary>
        private void LblClearMonsterFilter_Click(object sender, EventArgs e)
        {
            TxtMonsterFilter.Clear();
        }

        /// <summary>
        /// 遍历选中项怪物Id集合
        /// </summary>
        private IEnumerable<int> SelectedMonsterIds()
        {
            foreach (string item in ListMonsters.SelectedItems)
                yield return ItemMap.ToId(item);
        }

        /// <summary>
        /// 怪物列表选中项改变时触发
        /// </summary>
        private void ListMonsters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListMonsters.SelectedItems.Count == 0) return;

            // 掉落物列表标题显示
            var sp = GrpDropList.Text.IndexOf(" | ");
            if (sp >= 0) GrpDropList.Text = GrpDropList.Text.Remove(sp);
            if (ListMonsters.SelectedItems.Count == 1)
            {
                var item = ListMonsters.SelectedItem as string;
                GrpDropList.Text += " | " + item;
            }
            else
            {
                GrpDropList.Text += " | Monsters x" + ListMonsters.SelectedItems.Count.ToString();
            }

            // 获取选中项中相同的掉落物集合（仅物品、掉落数量、掉落概率完全一致的显示）
            SelectedDropList.Clear();
            var first = true;
            foreach (var monsterId in SelectedMonsterIds())
            {
                if (Banners.TryGetValue(monsterId, out List<DropData> dropList))
                {
                    if (first)
                    {
                        SelectedDropList.AddRange(dropList);
                        first = false;
                    }
                    else if (SelectedDropList.Count > 0)
                    {
                        // 仅保留交集
                        var intersect = SelectedDropList.Intersect(dropList).ToList();
                        SelectedDropList.Clear();
                        SelectedDropList.AddRange(intersect);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    SelectedDropList.Clear();
                    break;
                }
            }

            ShowDropList(SelectedDropList);
        }

        /// <summary>
        /// 显示指定掉落列表
        /// </summary>
        /// <param name="dropList">掉落物列表</param>
        private void ShowDropList(List<DropData> dropList)
        {
            // 显示到列表
            ListDropData.BeginUpdate();
            ListDropData.Items.Clear();
            if (dropList.Count > 0)
            {
                ListDropData.Items.AddRange(dropList.Select(it => it.ToString()).ToArray());
                ListDropData.SelectedIndex = 0;
            }
            ListDropData.EndUpdate();
        }

        #endregion - 怪物列表 -

        #region - 掉落物列表 -

        /// <summary>
        /// 掉落列表选中项改变时触发
        /// </summary>
        private void ListDropData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListDropData.SelectedIndex == -1) return;

            var dropData = SelectedDropList[ListDropData.SelectedIndex];

            TxtItem.Text = $"{dropData.ItemId} : {GameData.Items[dropData.ItemId]}";
            NUDMinCount.Value = dropData.MinCount;
            NUDMaxCount.Value = dropData.MaxCount;
            NUDMinWeight.Value = dropData.MinWeight;
            NUDMaxWeight.Value = dropData.MaxWeight;

            //BtnCopy.Enabled = true;
            //BtnDelete.Enabled = true;
            //BtnAddOrUpdate.Enabled = true;
        }

        /// <summary>
        /// 点击复制按钮时触发
        /// </summary>
        private async void BtnCopy_Click(object sender, EventArgs e)
        {
            if (ListDropData.SelectedIndex == -1) return;
            DropClipboard.Clear();
            DropClipboard.Add(SelectedDropList[ListDropData.SelectedIndex]);
            await UIUtil.ButtonComplete(BtnCopy);
        }

        /// <summary>
        /// 点击复制全部按钮时触发
        /// </summary>
        private async void BtnCopyAll_Click(object sender, EventArgs e)
        {
            if (SelectedDropList.Count == 0) return;
            DropClipboard.Clear();
            DropClipboard.AddRange(SelectedDropList);
            await UIUtil.ButtonComplete(BtnCopyAll);
        }

        /// <summary>
        /// 点击粘贴按钮时触发
        /// </summary>
        private void BtnPaste_Click(object sender, EventArgs e)
        {
            if (DropClipboard.Count == 0) return;
            foreach (var item in DropClipboard)
                AddOrUpdateDrop(item);
            ShowDropList(SelectedDropList);
        }

        /// <summary>
        /// 点击删除按钮时触发
        /// </summary>
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (ListDropData.SelectedIndex == -1) return;

            var dropData = SelectedDropList[ListDropData.SelectedIndex];
            RemoveDrop(dropData);
            ShowDropList(SelectedDropList);
        }

        /// <summary>
        /// 点击清空按钮时触发
        /// </summary>
        private void BtnClear_Click(object sender, EventArgs e)
        {
            if (SelectedDropList.Count == 0)
                return;
            if (MessageBox.Show(Resources.AskConfirmDeletion, Resources.Tips, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                for (int i = SelectedDropList.Count - 1; i >= 0; i--)
                    RemoveDrop(SelectedDropList[i]);
                ShowDropList(SelectedDropList);
            }
        }

        /// <summary>
        /// 点击添加或更新按钮时触发
        /// </summary>
        private void BtnAddOrUpdate_Click(object sender, EventArgs e)
        {
            if (ListMonsters.SelectedItems.Count == 0)
                return;
            try
            {
                AddOrUpdateDrop(GetInput());
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ShowDropList(SelectedDropList);
        }

        /// <summary>
        /// 获取输入
        /// </summary>
        /// <returns>掉落物信息</returns>
        private DropData GetInput()
        {
            var dropData = new DropData();

            var item = TxtItem.Text;
            dropData.ItemId = ItemMap.ToId(item);
            //if (int.TryParse(item.Substring(0, item.IndexOf(':')).Trim(), out int itemId))
            //{
            //    dropData.ItemId = itemId;
            //}

            if (NUDMaxCount.Value < NUDMinCount.Value)
            {
                dropData.MinCount = (int)NUDMaxCount.Value;
                dropData.MaxCount = (int)NUDMinCount.Value;
            }
            else
            {
                dropData.MinCount = (int)NUDMinCount.Value;
                dropData.MaxCount = (int)NUDMaxCount.Value;
            }

            if (NUDMaxWeight.Value < NUDMinWeight.Value)
            {
                dropData.MinWeight = (int)NUDMaxWeight.Value;
                dropData.MaxWeight = (int)NUDMinWeight.Value;
            }
            else
            {
                dropData.MinWeight = (int)NUDMinWeight.Value;
                dropData.MaxWeight = (int)NUDMaxWeight.Value;
            }

            return dropData;
        }

        /// <summary>
        /// 添加或更新掉落物到当前选中项
        /// </summary>
        /// <param name="data">掉落物信息</param>
        private void AddOrUpdateDrop(DropData data)
        {
            if (ListMonsters.SelectedItems.Count == 0)
                return;

            foreach (var monsterId in SelectedMonsterIds())
            {
                if (!Banners.TryGetValue(monsterId, out List<DropData> dropList))
                {
                    dropList = new List<DropData>();
                    Banners[monsterId] = dropList;
                }

                AddOrUpdateDrop(dropList, data);
            }

            AddOrUpdateDrop(SelectedDropList, data);
        }

        /// <summary>
        /// 从当前选中项移除掉落物
        /// </summary>
        /// <param name="data">掉落物信息</param>
        private void RemoveDrop(DropData data)
        {
            if (ListMonsters.SelectedItems.Count == 0)
                return;

            foreach (var monsterId in SelectedMonsterIds())
            {
                if (!Banners.TryGetValue(monsterId, out List<DropData> dropList))
                {
                    dropList = new List<DropData>();
                    Banners[monsterId] = dropList;
                }

                dropList.Remove(data);
            }

            SelectedDropList.Remove(data);
        }

        /// <summary>
        /// 添加或更新掉落物到指定列表中
        /// </summary>
        /// <param name="dropList">掉落物列表</param>
        /// <param name="data">掉落物信息</param>
        private void AddOrUpdateDrop(List<DropData> dropList, DropData data)
        {
            int i = 0;
            for (; i < dropList.Count; i++)
                if (dropList[i].ItemId == data.ItemId)
                    break;
            if (i == dropList.Count)
                dropList.Add(data);
            else
                dropList[i] = data;
        }

        #endregion - 掉落物列表 -

        #region - 物品列表 -

        /// <summary>
        /// 物品列表过滤器文本改变时触发
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
            TxtItem.Text = ListItems.SelectedItem as string;
        }

        #endregion - 物品列表 -


    }
}