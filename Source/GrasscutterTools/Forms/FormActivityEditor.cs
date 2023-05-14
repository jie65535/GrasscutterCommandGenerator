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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using GrasscutterTools.Game;
using GrasscutterTools.Game.Activity;
using GrasscutterTools.Properties;
using GrasscutterTools.Utils;

using Newtonsoft.Json;

namespace GrasscutterTools.Forms
{
    public partial class FormActivityEditor : Form
    {
        #region - 成员 -

        private List<ActivityConfigItem> ActivityConfigItems = new List<ActivityConfigItem>();

        #endregion - 成员 -

        #region - 构造与窗体事件 -

        public FormActivityEditor()
        {
            InitializeComponent();

            Icon = Resources.IconGrasscutter;

            DTPBeginTime.Value = DateTime.Today;
            DTPEndTime.Value = DateTime.Today.AddMonths(1);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadAllActivity();

            try
            {
                // 加载文件路径
                var path = Settings.Default.ActivityConfigJsonPath;
                ActivityConfigJsonPath.Text = path;
                if (!string.IsNullOrEmpty(path) && File.Exists(path))
                    LoadActivityConfig(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            Settings.Default.ActivityConfigJsonPath = ActivityConfigJsonPath.Text;

            base.OnFormClosed(e);
        }

        #endregion - 构造与窗体事件 -

        #region - ActivityConfig.json 文件相关 -

        /// <summary>
        /// 加载按钮点击时触发
        /// </summary>
        private void BtnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                var path = ActivityConfigJsonPath.Text.Trim();
                if (path == string.Empty)
                {
                    var dialog = new OpenFileDialog
                    {
                        FileName = "ActivityConfig.json",
                        Filter = "ActivityConfig.Json (*.json)|*.json|All files (*.*)|*.*",
                    };
                    var result = dialog.ShowDialog();
                    if (result == DialogResult.OK)
                        path = ActivityConfigJsonPath.Text = dialog.FileName;
                    else
                        return;
                }

                // 反序列化
                LoadActivityConfig(path);
                MessageBox.Show("OK", Resources.Tips, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 加载活动配置
        /// </summary>
        /// <param name="path">ActivityConfig.json 文件路径</param>
        private void LoadActivityConfig(string path)
        {
            ActivityConfigItems = JsonConvert.DeserializeObject<List<ActivityConfigItem>>(File.ReadAllText(path)) ?? new List<ActivityConfigItem>();
            ListActivityConfigItems.BeginUpdate();
            ListActivityConfigItems.Items.Clear();
            ListActivityConfigItems.Items.AddRange(ActivityConfigItems.Select(Convert).ToArray());
            ListActivityConfigItems.EndUpdate();
        }

        private ListViewItem Convert(ActivityConfigItem item)
        {
            return new ListViewItem(new[]
            {
                item.ActivityId.ToString(),
                GameData.Activity[item.ActivityId],
                item.BeginTime.ToShortDateString(),
                item.EndTime.ToShortDateString(),
            });
        }

        /// <summary>
        /// 保存按钮点击时触发
        /// </summary>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var path = ActivityConfigJsonPath.Text.Trim();
                if (path == string.Empty)
                {
                    var dialog = new SaveFileDialog
                    {
                        FileName = "ActivityConfig.json",
                        Filter = "ActivityConfig.json (*.json)|*.json|All files (*.*)|*.*",
                    };
                    var result = dialog.ShowDialog();
                    if (result == DialogResult.OK)
                        path = ActivityConfigJsonPath.Text = dialog.FileName;
                    else
                        return;
                }

                // 序列化
                File.WriteAllText(path, JsonConvert.SerializeObject(ActivityConfigItems, Formatting.Indented));
                MessageBox.Show("OK", Resources.Tips, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion - ActivityConfig.json 文件相关 -

        #region - 活动列表 -

        /// <summary>
        /// 加载所有活动
        /// </summary>
        private void LoadAllActivity()
        {
            ListAllActivity.BeginUpdate();
            foreach (var grp in GameData.Activity)
            {
                var grpControl = ListAllActivity.Groups.Add(grp.Key, grp.Key);
                for (var i = 0; i < grp.Value.Count; i++)
                {
                    ListAllActivity.Items.Add(new ListViewItem(new[]
                    {
                        grp.Value.Ids[i].ToString(), grp.Value.Names[i]
                    }, grpControl));
                }
            }
            ListAllActivity.EndUpdate();
        }

        /// <summary>
        /// 所有活动列表选中项改变时触发
        /// </summary>
        private void ListAllActivity_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ListAllActivity.SelectedItems.Count == 0)
                    return;
                NUDActivityId.Text = ListAllActivity.SelectedItems[0].Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 活动ID改变时触发
        /// </summary>
        private void NUDActivityId_ValueChanged(object sender, EventArgs e)
        {
            // 更新活动名称到提示文本
            var activityId = (int)NUDActivityId.Value;
            LblActivityTitle.Text = GameData.Activity[activityId];

            // 检查是否在列表中，允许删除
            var item = ActivityConfigItems.Find(it => it.ActivityId == activityId);
            BtnDelete.Enabled = item != null;
        }

        /// <summary>
        /// 点击添加或更新按钮时触发
        /// </summary>
        private async void BtnAddOrUpdate_Click(object sender, EventArgs e)
        {
            var activityId = (int)NUDActivityId.Value;
            var isNew = false;
            var item = ActivityConfigItems.Find(it => it.ActivityId == activityId);
            if (item == null)
            {
                item = new ActivityConfigItem();
                isNew = true;
            }

            item.ActivityId = activityId;
            item.ActivityType = (int)NUDActivityType.Value;
            item.ScheduleId = (int)NUDScheduleId.Value;
            try
            {
                item.MeetCondList = !string.IsNullOrEmpty(TxtMeetCondList.Text)
                    ? TxtMeetCondList.Text.Split(',').Select(it => int.Parse(it.Trim())).ToList()
                    : new List<int>();
            }
            catch (Exception)
            {
                item.MeetCondList = new List<int>();
            }

            if (DTPBeginTime.Value > DTPEndTime.Value)
            {
                // ?
            }

            item.BeginTime = DTPBeginTime.Value.Date;
            item.EndTime = DTPEndTime.Value.Date.AddDays(1).AddSeconds(-1);

            if (isNew)
            {
                ActivityConfigItems.Add(item);
                ListActivityConfigItems.Items.Add(Convert(item));
            }

            BtnDelete.Enabled = true;
            await UIUtil.ButtonComplete(BtnAddOrUpdate);
        }

        /// <summary>
        /// 点击删除按钮时触发
        /// </summary>
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var activityId = (int)NUDActivityId.Value;
            var index = ActivityConfigItems.FindIndex(it => it.ActivityId == activityId);
            if (index != -1)
            {
                ListActivityConfigItems.Items.RemoveAt(index);
                ActivityConfigItems.RemoveAt(index);
            }
            BtnDelete.Enabled = false;
        }

        /// <summary>
        /// 当前文件活动配置列表选中项改变时触发
        /// </summary>
        private void ListActivityConfigItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListActivityConfigItems.SelectedItems.Count == 0)
                return;
            var index = ListActivityConfigItems.SelectedIndices[0];
            var configItem = ActivityConfigItems[index];
            NUDActivityId.Value = configItem.ActivityId;
            NUDActivityType.Value = configItem.ActivityType;
            NUDScheduleId.Value = configItem.ScheduleId;
            TxtMeetCondList.Text = configItem.MeetCondList?.Count > 0
                ? string.Join(",", configItem.MeetCondList)
                : string.Empty;
            DTPBeginTime.Value = configItem.BeginTime;
            DTPEndTime.Value = configItem.EndTime;
        }

        #endregion - 活动列表 -
    }
}