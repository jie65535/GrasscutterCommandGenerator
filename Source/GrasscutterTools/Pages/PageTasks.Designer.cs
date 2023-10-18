namespace GrasscutterTools.Pages
{
    partial class PageTasks
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageTasks));
            this.GrpTasks = new System.Windows.Forms.GroupBox();
            this.ListTasks = new System.Windows.Forms.ListView();
            this.ColTag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColContent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColDelay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GrpTask = new System.Windows.Forms.GroupBox();
            this.LblClearFilter = new System.Windows.Forms.Label();
            this.BtnRemove = new System.Windows.Forms.Button();
            this.BtnAccept = new System.Windows.Forms.Button();
            this.NUDTriggerCount = new System.Windows.Forms.NumericUpDown();
            this.LblTriggerCount = new System.Windows.Forms.Label();
            this.DTPDelay = new System.Windows.Forms.DateTimePicker();
            this.LblDelay = new System.Windows.Forms.Label();
            this.TxtTag = new System.Windows.Forms.TextBox();
            this.LblTag = new System.Windows.Forms.Label();
            this.GrpTasks.SuspendLayout();
            this.GrpTask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDTriggerCount)).BeginInit();
            this.SuspendLayout();
            // 
            // GrpTasks
            // 
            resources.ApplyResources(this.GrpTasks, "GrpTasks");
            this.GrpTasks.Controls.Add(this.ListTasks);
            this.GrpTasks.Name = "GrpTasks";
            this.GrpTasks.TabStop = false;
            // 
            // ListTasks
            // 
            this.ListTasks.AllowColumnReorder = true;
            this.ListTasks.CheckBoxes = true;
            this.ListTasks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColTag,
            this.ColContent,
            this.ColDelay,
            this.ColCount});
            resources.ApplyResources(this.ListTasks, "ListTasks");
            this.ListTasks.HideSelection = false;
            this.ListTasks.MultiSelect = false;
            this.ListTasks.Name = "ListTasks";
            this.ListTasks.UseCompatibleStateImageBehavior = false;
            this.ListTasks.View = System.Windows.Forms.View.Details;
            this.ListTasks.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ListTasks_ItemChecked);
            this.ListTasks.SelectedIndexChanged += new System.EventHandler(this.ListTasks_SelectedIndexChanged);
            // 
            // ColTag
            // 
            resources.ApplyResources(this.ColTag, "ColTag");
            // 
            // ColContent
            // 
            resources.ApplyResources(this.ColContent, "ColContent");
            // 
            // ColDelay
            // 
            resources.ApplyResources(this.ColDelay, "ColDelay");
            // 
            // ColCount
            // 
            resources.ApplyResources(this.ColCount, "ColCount");
            // 
            // GrpTask
            // 
            resources.ApplyResources(this.GrpTask, "GrpTask");
            this.GrpTask.Controls.Add(this.LblClearFilter);
            this.GrpTask.Controls.Add(this.BtnRemove);
            this.GrpTask.Controls.Add(this.BtnAccept);
            this.GrpTask.Controls.Add(this.NUDTriggerCount);
            this.GrpTask.Controls.Add(this.LblTriggerCount);
            this.GrpTask.Controls.Add(this.DTPDelay);
            this.GrpTask.Controls.Add(this.LblDelay);
            this.GrpTask.Controls.Add(this.TxtTag);
            this.GrpTask.Controls.Add(this.LblTag);
            this.GrpTask.Name = "GrpTask";
            this.GrpTask.TabStop = false;
            // 
            // LblClearFilter
            // 
            resources.ApplyResources(this.LblClearFilter, "LblClearFilter");
            this.LblClearFilter.BackColor = System.Drawing.Color.White;
            this.LblClearFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblClearFilter.Name = "LblClearFilter";
            this.LblClearFilter.Click += new System.EventHandler(this.LblClearFilter_Click);
            // 
            // BtnRemove
            // 
            resources.ApplyResources(this.BtnRemove, "BtnRemove");
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.UseVisualStyleBackColor = true;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // BtnAccept
            // 
            resources.ApplyResources(this.BtnAccept, "BtnAccept");
            this.BtnAccept.Name = "BtnAccept";
            this.BtnAccept.UseVisualStyleBackColor = true;
            this.BtnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // NUDTriggerCount
            // 
            resources.ApplyResources(this.NUDTriggerCount, "NUDTriggerCount");
            this.NUDTriggerCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NUDTriggerCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.NUDTriggerCount.Name = "NUDTriggerCount";
            this.NUDTriggerCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // LblTriggerCount
            // 
            resources.ApplyResources(this.LblTriggerCount, "LblTriggerCount");
            this.LblTriggerCount.Name = "LblTriggerCount";
            // 
            // DTPDelay
            // 
            resources.ApplyResources(this.DTPDelay, "DTPDelay");
            this.DTPDelay.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DTPDelay.Name = "DTPDelay";
            this.DTPDelay.ShowUpDown = true;
            this.DTPDelay.Value = new System.DateTime(2022, 12, 10, 0, 1, 0, 0);
            // 
            // LblDelay
            // 
            resources.ApplyResources(this.LblDelay, "LblDelay");
            this.LblDelay.Name = "LblDelay";
            // 
            // TxtTag
            // 
            resources.ApplyResources(this.TxtTag, "TxtTag");
            this.TxtTag.Name = "TxtTag";
            this.TxtTag.TextChanged += new System.EventHandler(this.TxtTag_TextChanged);
            // 
            // LblTag
            // 
            resources.ApplyResources(this.LblTag, "LblTag");
            this.LblTag.Name = "LblTag";
            // 
            // PageTasks
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GrpTask);
            this.Controls.Add(this.GrpTasks);
            this.Name = "PageTasks";
            this.GrpTasks.ResumeLayout(false);
            this.GrpTask.ResumeLayout(false);
            this.GrpTask.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDTriggerCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpTasks;
        private System.Windows.Forms.GroupBox GrpTask;
        private System.Windows.Forms.DateTimePicker DTPDelay;
        private System.Windows.Forms.Label LblDelay;
        private System.Windows.Forms.TextBox TxtTag;
        private System.Windows.Forms.Label LblTag;
        private System.Windows.Forms.NumericUpDown NUDTriggerCount;
        private System.Windows.Forms.Label LblTriggerCount;
        private System.Windows.Forms.Button BtnRemove;
        private System.Windows.Forms.Button BtnAccept;
        private System.Windows.Forms.ListView ListTasks;
        private System.Windows.Forms.ColumnHeader ColTag;
        private System.Windows.Forms.ColumnHeader ColContent;
        private System.Windows.Forms.ColumnHeader ColDelay;
        private System.Windows.Forms.ColumnHeader ColCount;
        private System.Windows.Forms.Label LblClearFilter;
    }
}
