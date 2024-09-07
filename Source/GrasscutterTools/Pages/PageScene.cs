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

using GrasscutterTools.Game;
using GrasscutterTools.Properties;
using GrasscutterTools.Utils;

namespace GrasscutterTools.Pages
{
    internal partial class PageScene : BasePage
    {
        public override string Text => Resources.PageSceneTitle;

        public PageScene()
        {
            InitializeComponent();
        }

        private string[] _scenes;

        private string[] Scenes
        {
            get => _scenes;
            set
            {
                if (_scenes == value)
                    return;
                _scenes = value;
                ListScenes.Items.Clear();
                ListScenes.Items.AddRange(value);
            }
        }

        /// <summary>
        /// 初始化场景列表
        /// </summary>
        public override void OnLoad()
        {
            Scenes = GameData.Scenes.Lines;
        }

        /// <summary>
        /// 选中场景时触发
        /// </summary>
        private void RbListScene_CheckedChanged(object sender, EventArgs e)
        {
            if (RbListScene.Checked)
                Scenes = GameData.Scenes.Lines;
        }

        /// <summary>
        /// 选中秘境时触发
        /// </summary>
        private void RbListDungeons_CheckedChanged(object sender, EventArgs e)
        {
            if (RbListDungeons.Checked)
                Scenes = GameData.Dungeons.Lines;
        }

        /// <summary>
        /// 选中过场时触发
        /// </summary>
        private void RbListCutScene_CheckedChanged(object sender, EventArgs e)
        {
            if (RbListCutScene.Checked)
                Scenes = GameData.CutScenes.Lines;
        }

        /// <summary>
        /// 场景列表过滤器输入项改变时触发
        /// </summary>
        private void TxtSceneFilter_TextChanged(object sender, EventArgs e)
        {
            UIUtil.ListBoxFilter(ListScenes, Scenes, TxtSceneFilter.Text);
            LblClearFilter.Visible = TxtSceneFilter.Text.Length > 0;
        }

        /// <summary>
        /// 点击清空过滤栏标签时触发
        /// </summary>
        private void LblClearFilter_Click(object sender, EventArgs e)
        {
            TxtSceneFilter.Clear();
        }

        /// <summary>
        /// 场景列表选中项改变时触发
        /// </summary>
        private void ListScenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListScenes.SelectedIndex < 0)
            {
                ChkIncludeSceneId.Enabled = false;
                return;
            }
            ChkIncludeSceneId.Enabled = true;

            // 可以直接弃用 scene 命令
            var name = ListScenes.SelectedItem as string;
            var id = ItemMap.ToId(name);
            if (RbListScene.Checked)
            {
                if (CommandVersion.Check(CommandVersion.V1_2_2))
                {
                    SetCommand("/tp", $"0 400 0 {id}");
                }
                else
                {
                    SetCommand("/scene", id.ToString());
                }
            }
            else if (RbListDungeons.Checked)
            {
                SetCommand("/dungeon", id.ToString());
            }
            else if (RbListCutScene.Checked)
            {
                SetCommand("/cutscene", id.ToString());
            }
        }

        /// <summary>
        /// 点击传送按钮时触发
        /// </summary>
        private void BtnTeleport_Click(object sender, EventArgs e)
        {
            string args = $"{NUDTpX.Value} {NUDTpY.Value} {NUDTpZ.Value}";
            if (ChkIncludeSceneId.Checked && RbListScene.Checked && ListScenes.SelectedIndex != -1)
                args += $" {GameData.Scenes.Ids[ListScenes.SelectedIndex]}";
            SetCommand("/tp", args);
        }

        /// <summary>
        /// 冻结游戏时间
        /// </summary>
        private void BtnFreezeTime_Click(object sender, EventArgs e)
        {
            SetCommand("/prop", "is_game_time_locked  on");
        }

        private void ListScenes_MeasureItem(object sender, System.Windows.Forms.MeasureItemEventArgs e)
        {
            e.ItemHeight = ListScenes.Font.Height * 3 / 2;
        }
    }
}