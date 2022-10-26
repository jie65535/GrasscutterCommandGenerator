using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using GrasscutterTools.Game;
using GrasscutterTools.Game.Drop;
using GrasscutterTools.Properties;

using Newtonsoft.Json;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
        private readonly List<DropData> DropList = new List<DropData>();

        #endregion - 成员 -

        #region - 构造与窗体事件 -

        public FormDropEditor()
        {
            InitializeComponent();

            Icon = Resources.IconGrasscutter;

            Monsters = new string[GameData.Monsters.Lines.Length + GameData.Animals.Lines.Length];
            GameData.Monsters.Lines.CopyTo(Monsters, 0);
            GameData.Animals.Lines.CopyTo(Monsters, GameData.Monsters.Lines.Length);
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
            Settings.Default.Save();

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
            var filter = TxtMonsterFilter.Text.Trim();
            ListMonsters.BeginUpdate();
            ListMonsters.Items.Clear();
            ListMonsters.Items.AddRange(Monsters.Where(n => n.Contains(filter)).ToArray());
            ListMonsters.EndUpdate();
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
            DropList.Clear();
            var first = true;
            foreach (string item in ListMonsters.SelectedItems)
            {
                var monsterId = int.Parse(item.Substring(0, item.IndexOf(':')).Trim());
                if (Banners.TryGetValue(monsterId, out List<DropData> dropList))
                {
                    if (first)
                    {
                        DropList.AddRange(dropList);
                        first = false;
                    }
                    else if (DropList.Count > 0)
                    {
                        // 仅保留交集
                        var intersect = DropList.Intersect(dropList).ToList();
                        DropList.Clear();
                        DropList.AddRange(intersect);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    DropList.Clear();
                    break;
                }
            }

            // 显示到列表
            ListDropData.BeginUpdate();
            ListDropData.Items.Clear();
            if (DropList.Count > 0)
            {
                ListDropData.Items.AddRange(DropList.Select(it => it.ToString()).ToArray());
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

            var dropData = DropList[ListDropData.SelectedIndex];

            TxtItem.Text = $"{dropData.ItemId} : {GameData.Items[dropData.ItemId]}";
            NUDMinCount.Value = dropData.MinCount;
            NUDMaxCount.Value = dropData.MaxCount;
            NUDMinWeight.Value = dropData.MinWeight;
            NUDMaxWeight.Value = dropData.MaxWeight;

            //BtnCopy.Enabled = true;
            //BtnDelete.Enabled = true;
            //BtnAddOrUpdate.Enabled = true;
        }

        private void BtnCopy_Click(object sender, EventArgs e)
        {
        }

        private void BtnCopyAll_Click(object sender, EventArgs e)
        {
        }

        private void BtnPaste_Click(object sender, EventArgs e)
        {
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
        }

        private void BtnAddOrUpdate_Click(object sender, EventArgs e)
        {
        }

        #endregion - 掉落物列表 -

        #region - 物品列表 -

        /// <summary>
        /// 物品列表过滤器文本改变时触发
        /// </summary>
        private void TxtItemFilter_TextChanged(object sender, EventArgs e)
        {
            var filter = TxtItemFilter.Text.Trim();
            ListItems.BeginUpdate();
            ListItems.Items.Clear();
            ListItems.Items.AddRange(GameData.Items.Lines.Where(n => n.Contains(filter)).ToArray());
            ListItems.EndUpdate();
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