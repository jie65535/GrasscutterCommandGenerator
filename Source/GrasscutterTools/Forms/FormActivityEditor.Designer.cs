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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormActivityEditor));
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnLoad = new System.Windows.Forms.Button();
            this.ActivityConfigJsonPath = new System.Windows.Forms.TextBox();
            this.LblActivityConfigJsonPath = new System.Windows.Forms.Label();
            this.GrpAllActivity = new System.Windows.Forms.GroupBox();
            this.ListAllActivity = new System.Windows.Forms.ListView();
            this.ColumnActivityId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnActivityName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GrpFileActivity = new System.Windows.Forms.GroupBox();
            this.ListActivityConfigItems = new System.Windows.Forms.ListView();
            this.ColActivityId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColActivityTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColActivityBeginTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColActivityEndTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            resources.ApplyResources(this.BtnSave, "BtnSave");
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnLoad
            // 
            resources.ApplyResources(this.BtnLoad, "BtnLoad");
            this.BtnLoad.Name = "BtnLoad";
            this.BtnLoad.UseVisualStyleBackColor = true;
            this.BtnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // ActivityConfigJsonPath
            // 
            resources.ApplyResources(this.ActivityConfigJsonPath, "ActivityConfigJsonPath");
            this.ActivityConfigJsonPath.Name = "ActivityConfigJsonPath";
            // 
            // LblActivityConfigJsonPath
            // 
            resources.ApplyResources(this.LblActivityConfigJsonPath, "LblActivityConfigJsonPath");
            this.LblActivityConfigJsonPath.Name = "LblActivityConfigJsonPath";
            // 
            // GrpAllActivity
            // 
            resources.ApplyResources(this.GrpAllActivity, "GrpAllActivity");
            this.GrpAllActivity.Controls.Add(this.ListAllActivity);
            this.GrpAllActivity.Name = "GrpAllActivity";
            this.GrpAllActivity.TabStop = false;
            // 
            // ListAllActivity
            // 
            resources.ApplyResources(this.ListAllActivity, "ListAllActivity");
            this.ListAllActivity.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnActivityId,
            this.ColumnActivityName});
            this.ListAllActivity.FullRowSelect = true;
            this.ListAllActivity.HideSelection = false;
            this.ListAllActivity.MultiSelect = false;
            this.ListAllActivity.Name = "ListAllActivity";
            this.ListAllActivity.UseCompatibleStateImageBehavior = false;
            this.ListAllActivity.View = System.Windows.Forms.View.Details;
            this.ListAllActivity.SelectedIndexChanged += new System.EventHandler(this.ListAllActivity_SelectedIndexChanged);
            // 
            // ColumnActivityId
            // 
            resources.ApplyResources(this.ColumnActivityId, "ColumnActivityId");
            // 
            // ColumnActivityName
            // 
            resources.ApplyResources(this.ColumnActivityName, "ColumnActivityName");
            // 
            // GrpFileActivity
            // 
            resources.ApplyResources(this.GrpFileActivity, "GrpFileActivity");
            this.GrpFileActivity.Controls.Add(this.ListActivityConfigItems);
            this.GrpFileActivity.Name = "GrpFileActivity";
            this.GrpFileActivity.TabStop = false;
            // 
            // ListActivityConfigItems
            // 
            resources.ApplyResources(this.ListActivityConfigItems, "ListActivityConfigItems");
            this.ListActivityConfigItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColActivityId,
            this.ColActivityTitle,
            this.ColActivityBeginTime,
            this.ColActivityEndTime});
            this.ListActivityConfigItems.FullRowSelect = true;
            this.ListActivityConfigItems.HideSelection = false;
            this.ListActivityConfigItems.MultiSelect = false;
            this.ListActivityConfigItems.Name = "ListActivityConfigItems";
            this.ListActivityConfigItems.UseCompatibleStateImageBehavior = false;
            this.ListActivityConfigItems.View = System.Windows.Forms.View.Details;
            this.ListActivityConfigItems.SelectedIndexChanged += new System.EventHandler(this.ListActivityConfigItems_SelectedIndexChanged);
            // 
            // ColActivityId
            // 
            resources.ApplyResources(this.ColActivityId, "ColActivityId");
            // 
            // ColActivityTitle
            // 
            resources.ApplyResources(this.ColActivityTitle, "ColActivityTitle");
            // 
            // ColActivityBeginTime
            // 
            resources.ApplyResources(this.ColActivityBeginTime, "ColActivityBeginTime");
            // 
            // ColActivityEndTime
            // 
            resources.ApplyResources(this.ColActivityEndTime, "ColActivityEndTime");
            // 
            // GrpActivityInfo
            // 
            resources.ApplyResources(this.GrpActivityInfo, "GrpActivityInfo");
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
            this.GrpActivityInfo.Name = "GrpActivityInfo";
            this.GrpActivityInfo.TabStop = false;
            // 
            // LblActivityTitle
            // 
            resources.ApplyResources(this.LblActivityTitle, "LblActivityTitle");
            this.LblActivityTitle.AutoEllipsis = true;
            this.LblActivityTitle.ForeColor = System.Drawing.SystemColors.GrayText;
            this.LblActivityTitle.Name = "LblActivityTitle";
            // 
            // LblActivityParmEditTip
            // 
            resources.ApplyResources(this.LblActivityParmEditTip, "LblActivityParmEditTip");
            this.LblActivityParmEditTip.ForeColor = System.Drawing.SystemColors.GrayText;
            this.LblActivityParmEditTip.Name = "LblActivityParmEditTip";
            // 
            // BtnDelete
            // 
            resources.ApplyResources(this.BtnDelete, "BtnDelete");
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnAddOrUpdate
            // 
            resources.ApplyResources(this.BtnAddOrUpdate, "BtnAddOrUpdate");
            this.BtnAddOrUpdate.Name = "BtnAddOrUpdate";
            this.BtnAddOrUpdate.UseVisualStyleBackColor = true;
            this.BtnAddOrUpdate.Click += new System.EventHandler(this.BtnAddOrUpdate_Click);
            // 
            // DTPEndTime
            // 
            resources.ApplyResources(this.DTPEndTime, "DTPEndTime");
            this.DTPEndTime.Name = "DTPEndTime";
            // 
            // DTPBeginTime
            // 
            resources.ApplyResources(this.DTPBeginTime, "DTPBeginTime");
            this.DTPBeginTime.Name = "DTPBeginTime";
            // 
            // TxtMeetCondList
            // 
            resources.ApplyResources(this.TxtMeetCondList, "TxtMeetCondList");
            this.TxtMeetCondList.Name = "TxtMeetCondList";
            // 
            // NUDScheduleId
            // 
            resources.ApplyResources(this.NUDScheduleId, "NUDScheduleId");
            this.NUDScheduleId.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDScheduleId.Name = "NUDScheduleId";
            // 
            // NUDActivityType
            // 
            resources.ApplyResources(this.NUDActivityType, "NUDActivityType");
            this.NUDActivityType.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDActivityType.Name = "NUDActivityType";
            // 
            // NUDActivityId
            // 
            resources.ApplyResources(this.NUDActivityId, "NUDActivityId");
            this.NUDActivityId.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDActivityId.Name = "NUDActivityId";
            this.NUDActivityId.ValueChanged += new System.EventHandler(this.NUDActivityId_ValueChanged);
            // 
            // LblEndTime
            // 
            resources.ApplyResources(this.LblEndTime, "LblEndTime");
            this.LblEndTime.Name = "LblEndTime";
            // 
            // LblBeginTime
            // 
            resources.ApplyResources(this.LblBeginTime, "LblBeginTime");
            this.LblBeginTime.Name = "LblBeginTime";
            // 
            // LblMeetCondList
            // 
            resources.ApplyResources(this.LblMeetCondList, "LblMeetCondList");
            this.LblMeetCondList.Name = "LblMeetCondList";
            // 
            // LblScheduleId
            // 
            resources.ApplyResources(this.LblScheduleId, "LblScheduleId");
            this.LblScheduleId.Name = "LblScheduleId";
            // 
            // LblActivityType
            // 
            resources.ApplyResources(this.LblActivityType, "LblActivityType");
            this.LblActivityType.Name = "LblActivityType";
            // 
            // LblActivityId
            // 
            resources.ApplyResources(this.LblActivityId, "LblActivityId");
            this.LblActivityId.Name = "LblActivityId";
            // 
            // FormActivityEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GrpAllActivity);
            this.Controls.Add(this.GrpActivityInfo);
            this.Controls.Add(this.GrpFileActivity);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnLoad);
            this.Controls.Add(this.ActivityConfigJsonPath);
            this.Controls.Add(this.LblActivityConfigJsonPath);
            this.Name = "FormActivityEditor";
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