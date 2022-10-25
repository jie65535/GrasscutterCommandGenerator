using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using GrasscutterTools.Game;
using GrasscutterTools.Game.Drop;
using GrasscutterTools.Properties;

using Newtonsoft.Json;

namespace GrasscutterTools.Forms
{
    public partial class FormDropEditor : Form
    {
        public FormDropEditor()
        {
            InitializeComponent();

            Icon = Resources.IconGrasscutter;

            ListMonsters.Items.AddRange(GameData.Monsters.Lines);
            ListItems.Items.AddRange(GameData.Items.Lines);

            Banners = new Dictionary<int, List<DropData>>();
        }

        private Dictionary<int, List<DropData>> Banners;

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
                var banners = JsonConvert.DeserializeObject<List<DropInfo>>(File.ReadAllText(path));
                Banners = new Dictionary<int, List<DropData>>(banners.Count);
                foreach (var item in banners)
                    Banners.Add(item.MonsterId, item.DropDataList);
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

        #endregion


        #region - 怪物列表 -

        /// <summary>
        /// 怪物列表过滤器文本改变时触发
        /// </summary>
        private void TxtMonsterFilter_TextChanged(object sender, EventArgs e)
        {
            var filter = TxtMonsterFilter.Text.Trim();
            ListMonsters.BeginUpdate();
            ListMonsters.Items.Clear();
            ListMonsters.Items.AddRange(GameData.Monsters.Lines.Where(n => n.Contains(filter)).ToArray());
            ListMonsters.EndUpdate();
        }

        /// <summary>
        /// 怪物列表选中项改变时触发
        /// </summary>
        private void ListMonsters_SelectedIndexChanged(object sender, EventArgs e)
        {
            var monster = ListMonsters.SelectedItem as string;
            if (string.IsNullOrEmpty(monster)) return;
            var id = int.Parse(monster.Substring(0, monster.IndexOf(':')).Trim());
            ListDropData.BeginUpdate();
            ListDropData.Items.Clear();
            if (Banners.TryGetValue(id, out List<DropData> dropList))
                ListDropData.Items.AddRange(dropList.ToArray());
            ListDropData.EndUpdate();
        }

        #endregion

        #region - 掉落物列表 -

        /// <summary>
        /// 掉落列表选中项改变时触发
        /// </summary>
        private void ListDropData_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dropData = ListDropData.SelectedItem as DropData;
            if (dropData == null) return;
            TxtItem.Text = dropData.ItemId.ToString();
            NUDMinCount.Value = dropData.MinCount;
            NUDMaxCount.Value = dropData.MaxCount;
            NUDMinWeight.Value = dropData.MinWeight;
            NUDMaxWeight.Value = dropData.MaxWeight;
        }

        #endregion

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
            var item = ListItems.SelectedItem as string;
            if (string.IsNullOrEmpty(item)) return;
            TxtItem.Text = item;
        }

        #endregion
    }
}
