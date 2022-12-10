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
            this.GrpTasks = new System.Windows.Forms.GroupBox();
            this.ListTasks = new System.Windows.Forms.ListView();
            this.ColTag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColContent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColDelay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GrpTask = new System.Windows.Forms.GroupBox();
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
            this.GrpTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpTasks.Controls.Add(this.ListTasks);
            this.GrpTasks.Location = new System.Drawing.Point(3, 3);
            this.GrpTasks.Name = "GrpTasks";
            this.GrpTasks.Size = new System.Drawing.Size(640, 183);
            this.GrpTasks.TabIndex = 0;
            this.GrpTasks.TabStop = false;
            this.GrpTasks.Text = "任务列表";
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
            this.ListTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListTasks.HideSelection = false;
            this.ListTasks.Location = new System.Drawing.Point(3, 19);
            this.ListTasks.MultiSelect = false;
            this.ListTasks.Name = "ListTasks";
            this.ListTasks.Size = new System.Drawing.Size(634, 161);
            this.ListTasks.TabIndex = 0;
            this.ListTasks.UseCompatibleStateImageBehavior = false;
            this.ListTasks.View = System.Windows.Forms.View.Details;
            this.ListTasks.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ListTasks_ItemChecked);
            this.ListTasks.SelectedIndexChanged += new System.EventHandler(this.ListTasks_SelectedIndexChanged);
            // 
            // ColTag
            // 
            this.ColTag.Text = "标签";
            this.ColTag.Width = 150;
            // 
            // ColContent
            // 
            this.ColContent.Text = "内容";
            this.ColContent.Width = 330;
            // 
            // ColDelay
            // 
            this.ColDelay.Text = "延迟";
            // 
            // ColCount
            // 
            this.ColCount.Text = "次数";
            // 
            // GrpTask
            // 
            this.GrpTask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpTask.Controls.Add(this.BtnRemove);
            this.GrpTask.Controls.Add(this.BtnAccept);
            this.GrpTask.Controls.Add(this.NUDTriggerCount);
            this.GrpTask.Controls.Add(this.LblTriggerCount);
            this.GrpTask.Controls.Add(this.DTPDelay);
            this.GrpTask.Controls.Add(this.LblDelay);
            this.GrpTask.Controls.Add(this.TxtTag);
            this.GrpTask.Controls.Add(this.LblTag);
            this.GrpTask.Location = new System.Drawing.Point(3, 186);
            this.GrpTask.Name = "GrpTask";
            this.GrpTask.Size = new System.Drawing.Size(640, 50);
            this.GrpTask.TabIndex = 1;
            this.GrpTask.TabStop = false;
            this.GrpTask.Text = "任务";
            // 
            // BtnRemove
            // 
            this.BtnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnRemove.Location = new System.Drawing.Point(534, 18);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(100, 23);
            this.BtnRemove.TabIndex = 7;
            this.BtnRemove.Text = "× 删除";
            this.BtnRemove.UseVisualStyleBackColor = true;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // BtnAccept
            // 
            this.BtnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAccept.Location = new System.Drawing.Point(428, 18);
            this.BtnAccept.Name = "BtnAccept";
            this.BtnAccept.Size = new System.Drawing.Size(100, 23);
            this.BtnAccept.TabIndex = 6;
            this.BtnAccept.Text = "√ 确定";
            this.BtnAccept.UseVisualStyleBackColor = true;
            this.BtnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // NUDTriggerCount
            // 
            this.NUDTriggerCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NUDTriggerCount.Location = new System.Drawing.Point(372, 19);
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
            this.NUDTriggerCount.Size = new System.Drawing.Size(50, 23);
            this.NUDTriggerCount.TabIndex = 5;
            this.NUDTriggerCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // LblTriggerCount
            // 
            this.LblTriggerCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblTriggerCount.AutoSize = true;
            this.LblTriggerCount.Location = new System.Drawing.Point(334, 22);
            this.LblTriggerCount.Name = "LblTriggerCount";
            this.LblTriggerCount.Size = new System.Drawing.Size(32, 17);
            this.LblTriggerCount.TabIndex = 4;
            this.LblTriggerCount.Text = "次数";
            // 
            // DTPDelay
            // 
            this.DTPDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DTPDelay.CustomFormat = "";
            this.DTPDelay.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DTPDelay.Location = new System.Drawing.Point(258, 19);
            this.DTPDelay.Name = "DTPDelay";
            this.DTPDelay.ShowUpDown = true;
            this.DTPDelay.Size = new System.Drawing.Size(70, 23);
            this.DTPDelay.TabIndex = 3;
            this.DTPDelay.Value = new System.DateTime(2022, 12, 10, 0, 1, 0, 0);
            // 
            // LblDelay
            // 
            this.LblDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblDelay.AutoSize = true;
            this.LblDelay.Location = new System.Drawing.Point(220, 22);
            this.LblDelay.Name = "LblDelay";
            this.LblDelay.Size = new System.Drawing.Size(32, 17);
            this.LblDelay.TabIndex = 2;
            this.LblDelay.Text = "延迟";
            // 
            // TxtTag
            // 
            this.TxtTag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtTag.Location = new System.Drawing.Point(49, 18);
            this.TxtTag.Name = "TxtTag";
            this.TxtTag.Size = new System.Drawing.Size(165, 23);
            this.TxtTag.TabIndex = 1;
            // 
            // LblTag
            // 
            this.LblTag.AutoSize = true;
            this.LblTag.Location = new System.Drawing.Point(11, 21);
            this.LblTag.Name = "LblTag";
            this.LblTag.Size = new System.Drawing.Size(32, 17);
            this.LblTag.TabIndex = 0;
            this.LblTag.Text = "标签";
            // 
            // PageTasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
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
    }
}
