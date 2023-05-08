namespace GrasscutterTools.Forms
{
    partial class FormActivityEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnLoad = new System.Windows.Forms.Button();
            this.ActivityConfigJsonPath = new System.Windows.Forms.TextBox();
            this.LblActivityConfigJsonPath = new System.Windows.Forms.Label();
            this.GrpAllActivity = new System.Windows.Forms.GroupBox();
            this.ListAllActivity = new System.Windows.Forms.ListView();
            this.GrpFileActivity = new System.Windows.Forms.GroupBox();
            this.GrpActivityInfo = new System.Windows.Forms.GroupBox();
            this.LblActivityTitle = new System.Windows.Forms.Label();
            this.LblActivityParmEditTip = new System.Windows.Forms.Label();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnAddOrUpdate = new System.Windows.Forms.Button();
            this.DTPEndTime = new System.Windows.Forms.DateTimePicker();
            this.DTPBeginTime = new System.Windows.Forms.DateTimePicker();
            this.TxtMeetCondList = new System.Windows.Forms.TextBox();
            this.NUDScheduleId = new System.Windows.Forms.NumericUpDown();
            this.NUDActivityType = new System.Windows.Forms.NumericUpDown();
            this.NUDActivityId = new System.Windows.Forms.NumericUpDown();
            this.LblEndTime = new System.Windows.Forms.Label();
            this.LblBeginTime = new System.Windows.Forms.Label();
            this.LblMeetCondList = new System.Windows.Forms.Label();
            this.LblScheduleId = new System.Windows.Forms.Label();
            this.LblActivityType = new System.Windows.Forms.Label();
            this.LblActivityId = new System.Windows.Forms.Label();
            this.ColumnActivityName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnActivityId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ListActivityConfigItems = new System.Windows.Forms.ListView();
            this.ColActivityId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColActivityTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColActivityBeginTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColActivityEndTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GrpAllActivity.SuspendLayout();
            this.GrpFileActivity.SuspendLayout();
            this.GrpActivityInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDScheduleId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDActivityType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDActivityId)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnSave.Location = new System.Drawing.Point(776, 12);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(100, 23);
            this.BtnSave.TabIndex = 3;
            this.BtnSave.Text = "保存";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnLoad
            // 
            this.BtnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnLoad.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnLoad.Location = new System.Drawing.Point(671, 12);
            this.BtnLoad.Name = "BtnLoad";
            this.BtnLoad.Size = new System.Drawing.Size(100, 23);
            this.BtnLoad.TabIndex = 2;
            this.BtnLoad.Text = "加载";
            this.BtnLoad.UseVisualStyleBackColor = true;
            this.BtnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // ActivityConfigJsonPath
            // 
            this.ActivityConfigJsonPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ActivityConfigJsonPath.Location = new System.Drawing.Point(176, 12);
            this.ActivityConfigJsonPath.Name = "ActivityConfigJsonPath";
            this.ActivityConfigJsonPath.Size = new System.Drawing.Size(489, 23);
            this.ActivityConfigJsonPath.TabIndex = 1;
            // 
            // LblActivityConfigJsonPath
            // 
            this.LblActivityConfigJsonPath.AutoSize = true;
            this.LblActivityConfigJsonPath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblActivityConfigJsonPath.Location = new System.Drawing.Point(17, 15);
            this.LblActivityConfigJsonPath.Name = "LblActivityConfigJsonPath";
            this.LblActivityConfigJsonPath.Size = new System.Drawing.Size(153, 17);
            this.LblActivityConfigJsonPath.TabIndex = 0;
            this.LblActivityConfigJsonPath.Text = "ActivityConfig.json 路径：";
            // 
            // GrpAllActivity
            // 
            this.GrpAllActivity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpAllActivity.Controls.Add(this.ListAllActivity);
            this.GrpAllActivity.Location = new System.Drawing.Point(612, 41);
            this.GrpAllActivity.Name = "GrpAllActivity";
            this.GrpAllActivity.Size = new System.Drawing.Size(260, 328);
            this.GrpAllActivity.TabIndex = 6;
            this.GrpAllActivity.TabStop = false;
            this.GrpAllActivity.Text = "已知活动 by dplek";
            // 
            // ListAllActivity
            // 
            this.ListAllActivity.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnActivityId,
            this.ColumnActivityName});
            this.ListAllActivity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListAllActivity.FullRowSelect = true;
            this.ListAllActivity.HideSelection = false;
            this.ListAllActivity.Location = new System.Drawing.Point(3, 19);
            this.ListAllActivity.MultiSelect = false;
            this.ListAllActivity.Name = "ListAllActivity";
            this.ListAllActivity.Size = new System.Drawing.Size(254, 306);
            this.ListAllActivity.TabIndex = 0;
            this.ListAllActivity.UseCompatibleStateImageBehavior = false;
            this.ListAllActivity.View = System.Windows.Forms.View.Details;
            this.ListAllActivity.SelectedIndexChanged += new System.EventHandler(this.ListAllActivity_SelectedIndexChanged);
            // 
            // GrpFileActivity
            // 
            this.GrpFileActivity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpFileActivity.Controls.Add(this.ListActivityConfigItems);
            this.GrpFileActivity.Location = new System.Drawing.Point(12, 41);
            this.GrpFileActivity.Name = "GrpFileActivity";
            this.GrpFileActivity.Size = new System.Drawing.Size(260, 328);
            this.GrpFileActivity.TabIndex = 4;
            this.GrpFileActivity.TabStop = false;
            this.GrpFileActivity.Text = "当前文件";
            // 
            // GrpActivityInfo
            // 
            this.GrpActivityInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpActivityInfo.Controls.Add(this.LblActivityTitle);
            this.GrpActivityInfo.Controls.Add(this.LblActivityParmEditTip);
            this.GrpActivityInfo.Controls.Add(this.BtnDelete);
            this.GrpActivityInfo.Controls.Add(this.BtnAddOrUpdate);
            this.GrpActivityInfo.Controls.Add(this.DTPEndTime);
            this.GrpActivityInfo.Controls.Add(this.DTPBeginTime);
            this.GrpActivityInfo.Controls.Add(this.TxtMeetCondList);
            this.GrpActivityInfo.Controls.Add(this.NUDScheduleId);
            this.GrpActivityInfo.Controls.Add(this.NUDActivityType);
            this.GrpActivityInfo.Controls.Add(this.NUDActivityId);
            this.GrpActivityInfo.Controls.Add(this.LblEndTime);
            this.GrpActivityInfo.Controls.Add(this.LblBeginTime);
            this.GrpActivityInfo.Controls.Add(this.LblMeetCondList);
            this.GrpActivityInfo.Controls.Add(this.LblScheduleId);
            this.GrpActivityInfo.Controls.Add(this.LblActivityType);
            this.GrpActivityInfo.Controls.Add(this.LblActivityId);
            this.GrpActivityInfo.Location = new System.Drawing.Point(278, 41);
            this.GrpActivityInfo.Name = "GrpActivityInfo";
            this.GrpActivityInfo.Size = new System.Drawing.Size(328, 328);
            this.GrpActivityInfo.TabIndex = 5;
            this.GrpActivityInfo.TabStop = false;
            this.GrpActivityInfo.Text = "活动信息";
            // 
            // LblActivityTitle
            // 
            this.LblActivityTitle.AutoEllipsis = true;
            this.LblActivityTitle.ForeColor = System.Drawing.SystemColors.GrayText;
            this.LblActivityTitle.Location = new System.Drawing.Point(173, 45);
            this.LblActivityTitle.Name = "LblActivityTitle";
            this.LblActivityTitle.Size = new System.Drawing.Size(134, 17);
            this.LblActivityTitle.TabIndex = 2;
            this.LblActivityTitle.Text = "活动名称";
            // 
            // LblActivityParmEditTip
            // 
            this.LblActivityParmEditTip.AutoSize = true;
            this.LblActivityParmEditTip.ForeColor = System.Drawing.SystemColors.GrayText;
            this.LblActivityParmEditTip.Location = new System.Drawing.Point(40, 251);
            this.LblActivityParmEditTip.Name = "LblActivityParmEditTip";
            this.LblActivityParmEditTip.Size = new System.Drawing.Size(248, 17);
            this.LblActivityParmEditTip.TabIndex = 13;
            this.LblActivityParmEditTip.Text = "提示：通常情况下你只需要修改活动进行时间";
            // 
            // BtnDelete
            // 
            this.BtnDelete.Enabled = false;
            this.BtnDelete.Location = new System.Drawing.Point(199, 271);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(89, 30);
            this.BtnDelete.TabIndex = 15;
            this.BtnDelete.Text = "- 删除";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnAddOrUpdate
            // 
            this.BtnAddOrUpdate.Location = new System.Drawing.Point(43, 271);
            this.BtnAddOrUpdate.Name = "BtnAddOrUpdate";
            this.BtnAddOrUpdate.Size = new System.Drawing.Size(150, 30);
            this.BtnAddOrUpdate.TabIndex = 14;
            this.BtnAddOrUpdate.Text = "√ 添加或更新";
            this.BtnAddOrUpdate.UseVisualStyleBackColor = true;
            this.BtnAddOrUpdate.Click += new System.EventHandler(this.BtnAddOrUpdate_Click);
            // 
            // DTPEndTime
            // 
            this.DTPEndTime.Location = new System.Drawing.Point(107, 188);
            this.DTPEndTime.Name = "DTPEndTime";
            this.DTPEndTime.Size = new System.Drawing.Size(200, 23);
            this.DTPEndTime.TabIndex = 12;
            // 
            // DTPBeginTime
            // 
            this.DTPBeginTime.Location = new System.Drawing.Point(107, 159);
            this.DTPBeginTime.Name = "DTPBeginTime";
            this.DTPBeginTime.Size = new System.Drawing.Size(200, 23);
            this.DTPBeginTime.TabIndex = 10;
            // 
            // TxtMeetCondList
            // 
            this.TxtMeetCondList.Location = new System.Drawing.Point(107, 130);
            this.TxtMeetCondList.Name = "TxtMeetCondList";
            this.TxtMeetCondList.Size = new System.Drawing.Size(200, 23);
            this.TxtMeetCondList.TabIndex = 8;
            // 
            // NUDScheduleId
            // 
            this.NUDScheduleId.Location = new System.Drawing.Point(107, 101);
            this.NUDScheduleId.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDScheduleId.Name = "NUDScheduleId";
            this.NUDScheduleId.Size = new System.Drawing.Size(80, 23);
            this.NUDScheduleId.TabIndex = 6;
            // 
            // NUDActivityType
            // 
            this.NUDActivityType.Location = new System.Drawing.Point(107, 72);
            this.NUDActivityType.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDActivityType.Name = "NUDActivityType";
            this.NUDActivityType.Size = new System.Drawing.Size(60, 23);
            this.NUDActivityType.TabIndex = 4;
            // 
            // NUDActivityId
            // 
            this.NUDActivityId.Location = new System.Drawing.Point(107, 43);
            this.NUDActivityId.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDActivityId.Name = "NUDActivityId";
            this.NUDActivityId.Size = new System.Drawing.Size(60, 23);
            this.NUDActivityId.TabIndex = 1;
            this.NUDActivityId.ValueChanged += new System.EventHandler(this.NUDActivityId_ValueChanged);
            // 
            // LblEndTime
            // 
            this.LblEndTime.AutoSize = true;
            this.LblEndTime.Location = new System.Drawing.Point(21, 193);
            this.LblEndTime.Name = "LblEndTime";
            this.LblEndTime.Size = new System.Drawing.Size(80, 17);
            this.LblEndTime.TabIndex = 11;
            this.LblEndTime.Text = "活动结束时间";
            // 
            // LblBeginTime
            // 
            this.LblBeginTime.AutoSize = true;
            this.LblBeginTime.Location = new System.Drawing.Point(21, 164);
            this.LblBeginTime.Name = "LblBeginTime";
            this.LblBeginTime.Size = new System.Drawing.Size(80, 17);
            this.LblBeginTime.TabIndex = 9;
            this.LblBeginTime.Text = "活动开始时间";
            // 
            // LblMeetCondList
            // 
            this.LblMeetCondList.AutoSize = true;
            this.LblMeetCondList.Location = new System.Drawing.Point(21, 133);
            this.LblMeetCondList.Name = "LblMeetCondList";
            this.LblMeetCondList.Size = new System.Drawing.Size(80, 17);
            this.LblMeetCondList.TabIndex = 7;
            this.LblMeetCondList.Text = "满足条件列表";
            // 
            // LblScheduleId
            // 
            this.LblScheduleId.AutoSize = true;
            this.LblScheduleId.Location = new System.Drawing.Point(21, 103);
            this.LblScheduleId.Name = "LblScheduleId";
            this.LblScheduleId.Size = new System.Drawing.Size(45, 17);
            this.LblScheduleId.TabIndex = 5;
            this.LblScheduleId.Text = "计划ID";
            // 
            // LblActivityType
            // 
            this.LblActivityType.AutoSize = true;
            this.LblActivityType.Location = new System.Drawing.Point(21, 74);
            this.LblActivityType.Name = "LblActivityType";
            this.LblActivityType.Size = new System.Drawing.Size(56, 17);
            this.LblActivityType.TabIndex = 3;
            this.LblActivityType.Text = "活动类型";
            // 
            // LblActivityId
            // 
            this.LblActivityId.AutoSize = true;
            this.LblActivityId.Location = new System.Drawing.Point(21, 45);
            this.LblActivityId.Name = "LblActivityId";
            this.LblActivityId.Size = new System.Drawing.Size(45, 17);
            this.LblActivityId.TabIndex = 0;
            this.LblActivityId.Text = "活动ID";
            // 
            // ColumnActivityName
            // 
            this.ColumnActivityName.Text = "活动名称";
            this.ColumnActivityName.Width = 300;
            // 
            // ColumnActivityId
            // 
            this.ColumnActivityId.Text = "ID";
            this.ColumnActivityId.Width = 50;
            // 
            // ListActivityConfigItems
            // 
            this.ListActivityConfigItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColActivityId,
            this.ColActivityTitle,
            this.ColActivityBeginTime,
            this.ColActivityEndTime});
            this.ListActivityConfigItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListActivityConfigItems.FullRowSelect = true;
            this.ListActivityConfigItems.HideSelection = false;
            this.ListActivityConfigItems.Location = new System.Drawing.Point(3, 19);
            this.ListActivityConfigItems.MultiSelect = false;
            this.ListActivityConfigItems.Name = "ListActivityConfigItems";
            this.ListActivityConfigItems.Size = new System.Drawing.Size(254, 306);
            this.ListActivityConfigItems.TabIndex = 0;
            this.ListActivityConfigItems.UseCompatibleStateImageBehavior = false;
            this.ListActivityConfigItems.View = System.Windows.Forms.View.Details;
            this.ListActivityConfigItems.SelectedIndexChanged += new System.EventHandler(this.ListActivityConfigItems_SelectedIndexChanged);
            // 
            // ColActivityId
            // 
            this.ColActivityId.Text = "ID";
            this.ColActivityId.Width = 50;
            // 
            // ColActivityTitle
            // 
            this.ColActivityTitle.Text = "活动名称";
            this.ColActivityTitle.Width = 150;
            // 
            // ColActivityBeginTime
            // 
            this.ColActivityBeginTime.Text = "开始时间";
            this.ColActivityBeginTime.Width = 120;
            // 
            // ColActivityEndTime
            // 
            this.ColActivityEndTime.Text = "结束时间";
            this.ColActivityEndTime.Width = 120;
            // 
            // FormActivityEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 381);
            this.Controls.Add(this.GrpAllActivity);
            this.Controls.Add(this.GrpActivityInfo);
            this.Controls.Add(this.GrpFileActivity);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnLoad);
            this.Controls.Add(this.ActivityConfigJsonPath);
            this.Controls.Add(this.LblActivityConfigJsonPath);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(900, 420);
            this.Name = "FormActivityEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ActivityConfig.json Editor";
            this.GrpAllActivity.ResumeLayout(false);
            this.GrpFileActivity.ResumeLayout(false);
            this.GrpActivityInfo.ResumeLayout(false);
            this.GrpActivityInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDScheduleId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDActivityType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDActivityId)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnLoad;
        private System.Windows.Forms.TextBox ActivityConfigJsonPath;
        private System.Windows.Forms.Label LblActivityConfigJsonPath;
        private System.Windows.Forms.GroupBox GrpAllActivity;
        private System.Windows.Forms.GroupBox GrpFileActivity;
        private System.Windows.Forms.GroupBox GrpActivityInfo;
        private System.Windows.Forms.ListView ListAllActivity;
        private System.Windows.Forms.Label LblEndTime;
        private System.Windows.Forms.Label LblBeginTime;
        private System.Windows.Forms.Label LblMeetCondList;
        private System.Windows.Forms.Label LblScheduleId;
        private System.Windows.Forms.Label LblActivityType;
        private System.Windows.Forms.Label LblActivityId;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnAddOrUpdate;
        private System.Windows.Forms.DateTimePicker DTPEndTime;
        private System.Windows.Forms.DateTimePicker DTPBeginTime;
        private System.Windows.Forms.TextBox TxtMeetCondList;
        private System.Windows.Forms.NumericUpDown NUDScheduleId;
        private System.Windows.Forms.NumericUpDown NUDActivityType;
        private System.Windows.Forms.NumericUpDown NUDActivityId;
        private System.Windows.Forms.Label LblActivityParmEditTip;
        private System.Windows.Forms.Label LblActivityTitle;
        private System.Windows.Forms.ColumnHeader ColumnActivityId;
        private System.Windows.Forms.ColumnHeader ColumnActivityName;
        private System.Windows.Forms.ListView ListActivityConfigItems;
        private System.Windows.Forms.ColumnHeader ColActivityId;
        private System.Windows.Forms.ColumnHeader ColActivityTitle;
        private System.Windows.Forms.ColumnHeader ColActivityBeginTime;
        private System.Windows.Forms.ColumnHeader ColActivityEndTime;
    }
}