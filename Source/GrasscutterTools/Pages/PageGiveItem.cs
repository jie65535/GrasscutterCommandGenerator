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
        public PageGiveItem()
        {
            InitializeComponent();
            if (DesignMode) return;

            InitGiveItemRecord();
        }


        /// <summary>
        /// 初始化游戏物品列表
        /// </summary>
        public override void OnLoad()
        {
            ListGameItems.Items.Clear();
            ListGameItems.Items.AddRange(GameData.Items.Lines);
        }

        /// <summary>
        /// 物品列表过滤器文本改变时触发
        /// </summary>
        private void TxtGameItemFilter_TextChanged(object sender, EventArgs e)
        {
            UIUtil.ListBoxFilter(ListGameItems, GameData.Items.Lines, TxtGameItemFilter.Text);
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

                if (ChkDrop.Checked)
                {
                    NUDGameItemLevel.Enabled = false;
                    SetCommand("/drop", $"{id} {NUDGameItemAmout.Value}");
                }
                else
                {
                    NUDGameItemLevel.Enabled = true;
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
        private readonly string GiveItemCommandsRecordPath = Path.Combine(Application.LocalUserAppDataPath, "GiveItemCommands.txt");

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

    }
}
