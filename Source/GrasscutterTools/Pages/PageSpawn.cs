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
    internal partial class PageSpawn : BasePage
    {
        public override string Text => Resources.PageSpawnTitle;

        public PageSpawn()
        {
            InitializeComponent();
            if (DesignMode) return;
            InitSpawnRecord();
        }

        public override void OnLoad()
        {
            InitEntityList();
        }

        public override void OnClosed()
        {
            SaveSpawnRecord();
        }

        #region -- 实体列表 --

        private List<string[]> EntityList;

        /// <summary>
        /// 初始化实体列表
        /// </summary>
        private void InitEntityList()
        {
            var types = new List<string>();
            var entityList = new List<string[]>();

            types.Add(Resources.All);
            // 默认显示所有
            SelectedEntityTypeLines = GameData.Monsters.AllLines.Concat(GameData.Gadgets.AllLines).ToArray();
            entityList.Add(SelectedEntityTypeLines);
            types.AddRange(GameData.Monsters.Select(it => it.Key));
            entityList.AddRange(GameData.Monsters.Select(it => it.Value.Lines));
            types.AddRange(GameData.Gadgets.Select(it => it.Key));
            entityList.AddRange(GameData.Gadgets.Select(it => it.Value.Lines));

            CmbFilterEntity.DataSource = types;
            EntityList = entityList;
            

            //Console.WriteLine(string.Join("\n", GameData.Gadgets.Keys));
            
            LoadEntityList();
        }

        /// <summary>
        /// 当前选中的实体类型行
        /// </summary>
        private string[] SelectedEntityTypeLines;

        
        /// <summary>
        /// 类别选中时触发
        /// </summary>
        private void CmbFilterEntity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbFilterEntity.SelectedIndex < 0 || EntityList == null) return;
            var lines = EntityList[CmbFilterEntity.SelectedIndex];
            if (SelectedEntityTypeLines == lines) return;
            SelectedEntityTypeLines = lines;
            LoadEntityList();
        }

        /// <summary>
        /// 加载实体列表
        /// </summary>
        private void LoadEntityList()
        {
            UIUtil.ListBoxFilter(ListEntity, SelectedEntityTypeLines, TxtEntityFilter.Text);
        }

        /// <summary>
        /// 实体列表过滤器文本改变时触发
        /// </summary>
        private void TxtEntityFilter_TextChanged(object sender, EventArgs e)
        {
            LoadEntityList();
            LblClearFilter.Visible = TxtEntityFilter.Text.Length > 0;
        }

        /// <summary>
        /// 点击清空过滤栏标签时触发
        /// </summary>
        private void LblClearFilter_Click(object sender, EventArgs e)
        {
            TxtEntityFilter.Clear();
        }


        /// <summary>
        /// 实体列表选中项改变时触发
        /// </summary>
        private void ListEntity_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 根据当前所在页面确定要做的事情

            // 攻击修改界面
            if (TCSpawnSettings.SelectedTab == TPAttackModArgs)
            {
                OnAttackModifierInputChanged(sender, e);
            }
            // 攻击注入界面
            else if (TCSpawnSettings.SelectedTab == TPAttackInfusedArgs)
            {
                // 无事发生，因为要页面上点击按钮才会生成命令
            }
            // 生成参数界面 或其它
            else
            {
                // 触发输入改变事件
                SpawnEntityInputChanged(sender, e);
            }
        }

        #endregion -- 实体列表 --

        #region -- 生成记录 --

        /// <summary>
        /// 生成命令记录文件路径
        /// </summary>
        private readonly string SpawnCommandsRecordPath = Common.GetAppDataFile("SpawnCommands.txt");

        /// <summary>
        /// 生成命令记录
        /// </summary>
        private List<GameCommand> SpawnCommands;

        /// <summary>
        /// 初始化生成记录
        /// </summary>
        private void InitSpawnRecord()
        {
            if (File.Exists(SpawnCommandsRecordPath))
            {
                SpawnCommands = GameCommand.Parse(File.ReadAllText(SpawnCommandsRecordPath));
                ListSpawnLogs.Items.AddRange(SpawnCommands.Select(c => c.Name).ToArray());
            }
            else
            {
                SpawnCommands = new List<GameCommand>();
            }
        }

        /// <summary>
        /// 保存生成记录
        /// </summary>
        private void SaveSpawnRecord()
        {
            File.WriteAllText(SpawnCommandsRecordPath, GameCommand.ToString(SpawnCommands));
        }

        /// <summary>
        /// 生成记录列表选中项改变时触发
        /// </summary>
        private void ListSpawnLogs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListSpawnLogs.SelectedIndex >= 0)
            {
                BtnRemoveSpawnLog.Enabled = true;
                SetCommand(SpawnCommands[ListSpawnLogs.SelectedIndex].Command);
            }
            else
            {
                BtnRemoveSpawnLog.Enabled = false;
            }
        }

        /// <summary>
        /// 点击保存生成记录按钮时触发
        /// </summary>
        private void BtnSaveSpawnLog_Click(object sender, EventArgs e)
        {
            // 不再重新生成，直接记录当前命令行的内容
            //if (GenSpawnEntityCommand())
            {
                var cmdText = GetCommand();
                var cmd = new GameCommand($"{ListEntity.SelectedItem} | {cmdText}", cmdText);
                SpawnCommands.Add(cmd);
                ListSpawnLogs.Items.Add(cmd.Name);
                SaveSpawnRecord();
            }
        }

        /// <summary>
        /// 点击移除生成记录按钮时触发
        /// </summary>
        private void BtnRemoveSpawnLog_Click(object sender, EventArgs e)
        {
            if (ListSpawnLogs.SelectedIndex >= 0)
            {
                SpawnCommands.RemoveAt(ListSpawnLogs.SelectedIndex);
                ListSpawnLogs.Items.RemoveAt(ListSpawnLogs.SelectedIndex);
                SaveSpawnRecord();
            }
        }

        /// <summary>
        /// 点击清空生成记录按钮时触发
        /// </summary>
        private void LblClearSpawnLogs_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Resources.AskConfirmDeletion, Resources.Tips, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SpawnCommands.Clear();
                ListSpawnLogs.Items.Clear();
                SaveSpawnRecord();
            }
        }

        #endregion -- 生成记录 --

        #region -- 生成参数 --

        /// <summary>
        /// 生成页面输入改变时触发
        /// </summary>
        private void SpawnEntityInputChanged(object sender, EventArgs e)
        {
            if (ListEntity.SelectedIndex == -1) return;
            var selectedItem = ListEntity.SelectedItem as string;
            var id = ItemMap.ToId(selectedItem);

            if (CommandVersion.Check(CommandVersion.V1_3_1))
            {
                var args = id.ToString();
                void CheckAndConnect(NumericUpDown input, int value, string prefix)
                {
                    if (input.Value > value)
                        args += prefix + input.Value;
                }
                CheckAndConnect(NUDEntityAmout, 1, " x");
                CheckAndConnect(NUDEntityLevel, 1, " lv");
                CheckAndConnect(NUDEntityHp, -1, " hp");
                CheckAndConnect(NUDEntityMaxHp, 0, " maxhp");
                CheckAndConnect(NUDEntityAtk, -1, " atk");
                CheckAndConnect(NUDEntityDef, -1, " def");
                if (NUDEntityPosX.Value != 0 || NUDEntityPosY.Value != 0 || NUDEntityPosZ.Value != 0)
                    args += $" {NUDEntityPosX.Value} {NUDEntityPosY.Value} {NUDEntityPosZ.Value}";
                if (ChkNoAggressiveness.Checked)
                    args += " ai12001001";
                SetCommand("/spawn", args);
            }
            else
            {
                SetCommand("/spawn", $"{id} {NUDEntityAmout.Value} {NUDEntityLevel.Value}");
            }
        }

        #endregion -- 生成参数 --

        #region -- 攻击修改参数 --

        /// <summary>
        /// 攻击修改插件链接标签点击时触发
        /// </summary>
        private void LnkAttackModifierPlugin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UIUtil.OpenURL("https://github.com/NotThorny/AttackModifier");
        }

        /// <summary>
        /// 攻击修改输入改变事件
        /// </summary>
        private void OnAttackModifierInputChanged(object sender, EventArgs e)
        {
            if (ListEntity.SelectedIndex == -1) return;
            var selectedItem = ListEntity.SelectedItem as string;
            var id = ItemMap.ToId(selectedItem);
            char skill;
            if (RbAtE.Checked)
            {
                skill = 'e';
                TxtAtEntityE.Text = selectedItem;
            }
            else if (RbAtQ.Checked)
            {
                skill = 'q';
                TxtAtEntityQ.Text = selectedItem;
            }
            else
            {
                skill = 'n';
                TxtAtEntityN.Text = selectedItem;
            }
            SetCommand("/at", $"set {skill} {id}");
        }

        /// <summary>
        /// 攻击修改页面命令事件
        /// </summary>
        private void OnAttackModifierCommand(object sender, EventArgs e)
        {
            SetCommand("/at", (sender as Control).Tag as string);
        }

        #endregion -- 攻击修改参数 --

        #region -- 攻击注入参数 --

        /// <summary>
        /// 攻击注入插件链接标签点击时触发
        /// </summary>
        private void LnkAttackInfusedWithItem_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UIUtil.OpenURL("https://github.com/snoobi-seggs/AttackInfusedWithItem");
        }

        /// <summary>
        /// 攻击注入页面命令事件
        /// </summary>
        private void OnAttackInfusedCommand(object sender, EventArgs e)
        {
            SetCommand("/snoospawn", (sender as Control).Tag as string);
        }

        /// <summary>
        /// 点击攻击注入按钮时触发
        /// </summary>
        private void BtnAttackInfuse_Click(object sender, EventArgs e)
        {
            if (ListEntity.SelectedIndex == -1) return;
            var selectedItem = ListEntity.SelectedItem as string;
            var id = ItemMap.ToId(selectedItem);

            var args = string.Empty;
            var flag = false;
            void ConnectArg(NumericUpDown input)
            {
                if (flag || input.Value != 0)
                {
                    flag = true;
                    args = " " + input.Value + args;
                }
            }
            ConnectArg(NUDAiwiRotateZ);
            ConnectArg(NUDAiwiRotateY);
            ConnectArg(NUDAiwiRotateX);
            ConnectArg(NUDAiwiSpread);
            ConnectArg(NUDAiwiCount);
            ConnectArg(NUDAiwiHeight);
            ConnectArg(NUDAiwiRadius);
            SetCommand("/snoospawn", id.ToString() + args);
            //SetCommand("/at", $"{id} {NUDAiwiRadius.Value} {NUDAiwiHeight.Value} {NUDAiwiCount.Value} {NUDAiwiSpread.Value} {NUDAiwiRotateX.Value} {NUDAiwiRotateY.Value} {NUDAiwiRotateZ.Value}");
        }

        #endregion -- 攻击注入参数 --
    }
}