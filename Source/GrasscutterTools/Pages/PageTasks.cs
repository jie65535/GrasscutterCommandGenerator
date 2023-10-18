using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using GrasscutterTools.Properties;
using GrasscutterTools.Utils;

using Newtonsoft.Json;

namespace GrasscutterTools.Pages
{
    internal partial class PageTasks : BasePage
    {
        public override string Text => Resources.PageTasksTitle;

        public PageTasks()
        {
            InitializeComponent();
            ListTasks.FullRowSelect = true;
            if (DesignMode) return;

            InitTasks();
        }

        /// <summary>
        /// 循环任务
        /// </summary>
        private class LoopTask
        {
            /// <summary>
            /// 任务标签
            /// </summary>
            public string Tag { get; set; }

            /// <summary>
            /// 任务内容
            /// </summary>
            public string Content { get; set; }

            /// <summary>
            /// 延迟时间（秒）
            /// </summary>
            public int DelayS { get; set; }

            /// <summary>
            /// 触发次数  -1为无限循环
            /// </summary>
            public int TriggerCount { get; set; }
        }

        /// <summary>
        /// 任务列表路径
        /// </summary>
        private readonly string TasksJsonPath = Common.GetAppDataFile("Tasks.json");

        /// <summary>
        /// 任务集合
        /// </summary>
        private List<LoopTask> Tasks;

        /// <summary>
        /// 运行中的任务集合
        /// </summary>
        private readonly ConcurrentDictionary<string, CancellationTokenSource> RunningTasks = new ConcurrentDictionary<string, CancellationTokenSource>();

        /// <summary>
        /// 初始化任务集合
        /// </summary>
        private void InitTasks()
        {
            if (File.Exists(TasksJsonPath))
            {
                try
                {
                    Tasks = JsonConvert.DeserializeObject<List<LoopTask>>(File.ReadAllText(TasksJsonPath));
                    ListTasks.Items.AddRange(Tasks.Select(TaskToViewItem).ToArray());
                }
                catch (Exception ex)
                {
                    Tasks = new List<LoopTask>();
                    Logger.W(Name, "Parsing Tasks json failed", ex);
                }
            }
            else
            {
                Tasks = new List<LoopTask>();
            }
        }

        /// <summary>
        /// 关闭时触发
        /// </summary>
        public override void OnClosed()
        {
            // 取消所有正在运行的任务
            foreach (var cs in RunningTasks.Values)
                cs.Cancel();
            // 清空列表
            RunningTasks.Clear();

            // 保存任务列表
            File.WriteAllText(TasksJsonPath, JsonConvert.SerializeObject(Tasks));
        }

        /// <summary>
        /// 任务转为列表项
        /// </summary>
        /// <param name="task">任务</param>
        /// <returns>列表项</returns>
        private static ListViewItem TaskToViewItem(LoopTask task) => new ListViewItem(new string[]
        {
            task.Tag,
            task.Content,
            TimeSpan.FromSeconds(task.DelayS).ToString(),
            task.TriggerCount.ToString(),
        });

        /// <summary>
        /// 列表选中项改变时触发
        /// </summary>
        private void ListTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListTasks.SelectedIndices.Count == 0) return;
            int i = ListTasks.SelectedIndices[0];
            var task = Tasks[i];
            TxtTag.Text = task.Tag;
            DTPDelay.Value = DateTime.Today.Add(TimeSpan.FromSeconds(task.DelayS));
            NUDTriggerCount.Value = task.TriggerCount;
            // 设置命令
            SetCommand(task.Content);
        }

        /// <summary>
        /// 点击确定按钮时触发
        /// </summary>
        private void BtnAccept_Click(object sender, EventArgs e)
        {
            var tag = TxtTag.Text.Trim();
            var commands = GetCommand();
            var delay = DTPDelay.Value.TimeOfDay;
            var count = (int)NUDTriggerCount.Value;
            if (string.IsNullOrEmpty(tag) || string.IsNullOrEmpty(commands) || delay.Ticks == 0)
            {
                MessageBox.Show(Resources.EmptyInputTip, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 查找是否已经存在
            var i = Tasks.FindIndex(t => t.Tag == tag);
            if (i == -1)
            {
                // 新建任务
                var t = new LoopTask
                {
                    Tag = tag,
                    Content = commands,
                    DelayS = (int)delay.TotalSeconds,
                    TriggerCount = count,
                };
                ListTasks.Items.Add(TaskToViewItem(t));
                Tasks.Add(t);
            }
            else
            {
                // 已存在的任务，确认是否正在运行中
                if (ListTasks.Items[i].Checked || RunningTasks.ContainsKey(tag))
                {
                    MessageBox.Show(Resources.TaskRunningCannotOperated, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 否则修改任务内容
                var task = Tasks[i];
                task.Content = commands;
                task.DelayS = (int)delay.TotalSeconds;
                task.TriggerCount = count;
                ListTasks.Items[i] = TaskToViewItem(task);
            }
        }

        /// <summary>
        /// 点击删除按钮时触发
        /// </summary>
        private void BtnRemove_Click(object sender, EventArgs e)
        {
            var tag = TxtTag.Text.Trim();
            // 查找是否已经存在
            var i = Tasks.FindIndex(t => t.Tag == tag);
            if (i == -1) return;

            if (ListTasks.Items[i].Checked || RunningTasks.ContainsKey(tag))
            {
                MessageBox.Show(Resources.TaskRunningCannotOperated, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 删除实例
            ListTasks.Items.RemoveAt(i);
            Tasks.RemoveAt(i);
        }

        /// <summary>
        /// 任务前复选框改变时触发
        /// </summary>
        private void ListTasks_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            try
            {
                var item = e.Item;
                if (item.Index < 0 || item.Index >= Tasks.Count)
                    return;
                var task = Tasks[item.Index];
                // 先将旧的任务取消
                if (RunningTasks.TryRemove(task.Tag, out var source))
                    source.Cancel();

                if (item.Checked)
                {
                    var cancelSource = new CancellationTokenSource();
                    RunningTasks.TryAdd(task.Tag, cancelSource);
                    var token = cancelSource.Token;
                    Task.Run(async () =>
                    {
                        try
                        {
                            Logger.I(Name, $"Task \"{task.Tag}\" started");
                            // 循环执行命令
                            for (int c = 0;
                                !token.IsCancellationRequested
                                && (c < task.TriggerCount || task.TriggerCount <= 0);
                                c++)
                            {
                                // 延迟
                                await Task.Delay(task.DelayS * 1000, token);
                                // 使用UI线程执行
                                var ret = Invoke(new Func<string, Task<bool>>(RunRawCommands), task.Content);
                                if (ret is Task<bool> b && b.Result == false)
                                    break;
                                // 执行
                                //if (!await RunRawCommands(task.Content))
                                //    break;
                            }
                        }
                        finally
                        {
                            // 任务结束后取消勾选状态
                            BeginInvoke(new Action(() => item.Checked = false));
                            Logger.I(Name, $"Task \"{task.Tag}\" stoped");
                        }
                    }, token);
                }
            }
            catch (Exception ex)
            {
                Logger.E(Name, "Start or Stop Task failed.", ex);
                MessageBox.Show(ex.ToString(), Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 任务标签输入栏改变时触发
        /// </summary>
        private void TxtTag_TextChanged(object sender, EventArgs e)
        {
            LblClearFilter.Visible = TxtTag.Text.Length > 0;
        }

        /// <summary>
        /// 点击清空任务标签输入栏标签时触发
        /// </summary>
        private void LblClearFilter_Click(object sender, EventArgs e)
        {
            TxtTag.Clear();
        }
    }
}