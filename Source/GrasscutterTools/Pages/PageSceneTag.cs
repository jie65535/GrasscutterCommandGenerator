/**
 *  Grasscutter Tools
 *  Copyright (C) 2023 jie65535
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
using System.Windows.Forms;
using GrasscutterTools.Game;
using GrasscutterTools.Properties;

namespace GrasscutterTools.Pages
{
    internal partial class PageSceneTag : BasePage
    {
        public override string Text => Resources.PageSceneTagTitle;

        public PageSceneTag()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化场景标签
        /// </summary>
        public override void OnLoad()
        {
            TvSceneTags.BeginUpdate();
            TvSceneTags.Nodes.Clear();

            foreach (var sceneTagGroup in GameData.SceneTags)
            {
                // 将场景作为标签分类
                var sceneName = int.TryParse(sceneTagGroup.Key, out var sceneId)
                    ? GameData.Scenes[sceneId]
                    : sceneTagGroup.Key;
                var node = TvSceneTags.Nodes.Add(sceneTagGroup.Key, sceneName);

                // 添加所有标签
                var tags = sceneTagGroup.Value;
                for (var i = 0; i < tags.Count; i++)
                    node.Nodes.Add(tags.Ids[i].ToString(), tags.Names[i]);
            }
            TvSceneTags.EndUpdate();
        }

        ///// <summary>
        ///// 场景标签树视图选中后触发
        ///// </summary>
        //private void TvSceneTags_AfterSelect(object sender, TreeViewEventArgs e)
        //{
        //    // 忽略未知操作
        //    if (e.Action == TreeViewAction.Unknown || !e.Node.IsSelected)
        //        return;

        //    // 处理根节点选中
        //    var selectedNode = e.Node;
        //    if (selectedNode.Level == 0)
        //    {
        //        if (ChkOnSceneSelectedEnter.Checked)
        //        {
        //            SetCommand("/tp", $"0 400 0 {selectedNode.Name}");
        //        }
        //    }
        //    else
        //    {
        //        // 确认是否为默认状态
        //        var isDefault = selectedNode.Text.Contains("(Default)");
        //        var tagId = selectedNode.Name;
        //        // 根据选项决定动作
        //        var sub = isDefault 
        //            ? RbOnDefaultSelectedCheck.Checked
        //                ? "add" : "remove" 
        //            : RbOnSelectedCheck.Checked
        //                ? "add" : "remove";
        //        SetCommand("/tag", $"{sub} {tagId}");
        //    }
        //}

        /// <summary>
        /// 点击解锁全部时触发
        /// </summary>
        private void BtnUnlockAll_Click(object sender, EventArgs e)
        {
            SetCommand("/tag", "unlockall");
        }

        /// <summary>
        /// 点击还原预设时触发
        /// </summary>
        private void BtnResetAll_Click(object sender, EventArgs e)
        {
            SetCommand("/tag", "reset");
        }

        /// <summary>
        /// 场景标签节点点击时触发
        /// </summary>
        private void TvSceneTags_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // 处理根节点选中
            var selectedNode = e.Node;
            if (selectedNode.Level == 0)
            {
                if (ChkOnSceneSelectedEnter.Checked)
                {
                    SetCommand("/tp", $"0 400 0 {selectedNode.Name}");
                }
            }
            else
            {
                // 确认是否为默认状态
                var isDefault = selectedNode.Text.Contains("(Default)");
                var tagId = selectedNode.Name;
                // 根据选项决定动作
                var isAdd = isDefault ? RbOnDefaultSelectedCheck.Checked : RbOnSelectedCheck.Checked;
                // 如果是右键则相反
                if (e.Button == MouseButtons.Right)
                    isAdd = !isAdd;
                var sub = isAdd ? "add" : "remove";
                SetCommand("/tag", $"{sub} {tagId}");
                // 设置为选中节点
                TvSceneTags.SelectedNode = selectedNode;
            }
        }
    }
}
