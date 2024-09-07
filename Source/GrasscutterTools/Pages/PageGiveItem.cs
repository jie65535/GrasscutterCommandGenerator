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

using GrasscutterTools.Properties;

using GrasscutterTools.Utils;

namespace GrasscutterTools.Pages
{
    internal partial class PageGiveItem : BasePage
    {
        public override string Text => Resources.PageGiveItemTitle;

        public PageGiveItem()
        {
            InitializeComponent();
            if (DesignMode) return;

            InitGiveItemRecord();
        }

        private List<string[]> ItemList;

        /// <summary>
        /// 初始化游戏物品列表
        /// </summary>
        public override void OnLoad()
        {
            var types = new List<string>();
            var itemList = new List<string[]>();

            types.Add(Resources.All);
            SelectedItemTypeLines = GameData.Items.Lines;
            itemList.Add(SelectedItemTypeLines);
            foreach (var kv in GameData.Items)
            {
                types.Add(kv.Key);
                itemList.Add(kv.Value.Lines);
            }

            CmbFilterItem.DataSource = types;
            ItemList = itemList;
            
            LoadItemList();
        }

        /// <summary>
        /// 当前选中的物品类型行
        /// </summary>
        private string[] SelectedItemTypeLines;

        /// <summary>
        /// 点击过滤物品按钮时触发
        /// </summary>
        private void CmbFilterItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbFilterItem.SelectedIndex < 0 || ItemList == null) return;
            var lines = ItemList[CmbFilterItem.SelectedIndex];
            if (SelectedItemTypeLines == lines) return;
            SelectedItemTypeLines = lines;
            LoadItemList();
        }

        /// <summary>
        /// 加载物品列表
        /// </summary>
        private void LoadItemList()
        {
            UIUtil.ListBoxFilter(ListGameItems, SelectedItemTypeLines, TxtGameItemFilter.Text);
        }

        /// <summary>
        /// 物品列表过滤器文本改变时触发
        /// </summary>
        private void TxtGameItemFilter_TextChanged(object sender, EventArgs e)
        {
            LoadItemList();
            LblClearFilter.Visible = TxtGameItemFilter.Text.Length > 0;
        }

        /// <summary>
        /// 点击清空过滤器标签时触发
        /// </summary>
        private void LblClearFilter_Click(object sender, EventArgs e)
        {
            TxtGameItemFilter.Clear();
        }

        /// <summary>
        /// 生成获取物品命令
        /// </summary>
        /// <returns>是否生成成功</returns>
        private bool GenGiveItemCommand()
        {
            var name = ListGameItems.SelectedItem as string;
            if (!string.IsNullOrEmpty(name))
            {
                var id = ItemMap.ToId(name);

                NUDGameItemLevel.Enabled = true;
                if (ChkDrop.Checked)
                {
                    if (CommandVersion.Check(CommandVersion.V1_3_1))
                    {
                        SetCommand("/spawn", $"{id} x{NUDGameItemAmout.Value} lv{NUDGameItemLevel.Value}");
                    }
                    else if (CommandVersion.Check(CommandVersion.V1_2_2))
                    {
                        SetCommand("/spawn", $"{id} {NUDGameItemAmout.Value} {NUDGameItemLevel.Value}");
                    }
                    else
                    {
                        NUDGameItemLevel.Enabled = false;
                        SetCommand("/drop", $"{id} {NUDGameItemAmout.Value}");
                    }
                }
                else
                {
                    if (CommandVersion.Check(CommandVersion.V1_2_2))
                        SetCommand("/give", $"{id} x{NUDGameItemAmout.Value} lv{NUDGameItemLevel.Value}");
                    else
                        SetCommand("/give", $"{id} {NUDGameItemAmout.Value} {NUDGameItemLevel.Value}");
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取物品输入改变时触发
        /// </summary>
        private void GiveItemsInputChanged(object sender, EventArgs e)
        {
            GenGiveItemCommand();
        }


        #region -- 物品记录 --

        /// <summary>
        /// 获取物品记录文件路径
        /// </summary>
        private readonly string GiveItemCommandsRecordPath = Common.GetAppDataFile("GiveItemCommands.txt");

        /// <summary>
        /// 获取物品记录
        /// </summary>
        private List<GameCommand> GiveItemCommands;

        /// <summary>
        /// 初始化获取物品记录
        /// </summary>
        private void InitGiveItemRecord()
        {
            if (File.Exists(GiveItemCommandsRecordPath))
            {
                GiveItemCommands = GameCommand.Parse(File.ReadAllText(GiveItemCommandsRecordPath));
                ListGiveItemLogs.Items.AddRange(GiveItemCommands.Select(c => c.Name).ToArray());
            }
            else
            {
                GiveItemCommands = new List<GameCommand>();
            }
        }

        /// <summary>
        /// 保存获取物品记录
        /// </summary>
        private void SaveGiveItemRecord()
        {
            File.WriteAllText(GiveItemCommandsRecordPath, GameCommand.ToString(GiveItemCommands));
        }

        /// <summary>
        /// 获取物品记录列表选中项改变时触发
        /// </summary>
        private void ListGiveItemLogs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListGiveItemLogs.SelectedIndex >= 0)
            {
                BtnRemoveGiveItemLog.Enabled = true;
                SetCommand(GiveItemCommands[ListGiveItemLogs.SelectedIndex].Command);
            }
            else
            {
                BtnRemoveGiveItemLog.Enabled = false;
            }
        }

        /// <summary>
        /// 点击保存记录按钮时触发
        /// </summary>
        private void BtnSaveGiveItemLog_Click(object sender, EventArgs e)
        {
            var cmd = new GameCommand($"{ListGameItems.SelectedItem} x{NUDGameItemAmout.Value}", GetCommand());
            GiveItemCommands.Add(cmd);
            ListGiveItemLogs.Items.Add(cmd.Name);
            SaveGiveItemRecord();
        }

        /// <summary>
        /// 点击移除获取物品记录时触发
        /// </summary>
        private void BtnRemoveGiveItemLog_Click(object sender, EventArgs e)
        {
            if (ListGiveItemLogs.SelectedIndex >= 0)
            {
                GiveItemCommands.RemoveAt(ListGiveItemLogs.SelectedIndex);
                ListGiveItemLogs.Items.RemoveAt(ListGiveItemLogs.SelectedIndex);
                SaveGiveItemRecord();
            }
        }

        /// <summary>
        /// 点击清空获取物品记录时触发
        /// </summary>
        private void LblClearGiveItemLogs_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Resources.AskConfirmDeletion, Resources.Tips, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                GiveItemCommands.Clear();
                ListGiveItemLogs.Items.Clear();
                SaveGiveItemRecord();
            }
        }

        #endregion -- 物品记录 --

        private void ListGameItems_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = ListGameItems.Font.Height * 3 / 2;
        }
    }
}