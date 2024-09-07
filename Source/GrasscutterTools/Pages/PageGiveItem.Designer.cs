namespace GrasscutterTools.Pages
{
    partial class PageGiveItem
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageGiveItem));
            this.LblClearGiveItemLogs = new System.Windows.Forms.Label();
            this.BtnSaveGiveItemLog = new System.Windows.Forms.Button();
            this.BtnRemoveGiveItemLog = new System.Windows.Forms.Button();
            this.GrpGiveItemRecord = new System.Windows.Forms.GroupBox();
            this.ListGiveItemLogs = new System.Windows.Forms.ListBox();
            this.ChkDrop = new System.Windows.Forms.CheckBox();
            this.TxtGameItemFilter = new System.Windows.Forms.TextBox();
            this.ListGameItems = new System.Windows.Forms.ListBox();
            this.LblGameItemAmount = new System.Windows.Forms.Label();
            this.LblGameItemLevel = new System.Windows.Forms.Label();
            this.NUDGameItemAmout = new System.Windows.Forms.NumericUpDown();
            this.NUDGameItemLevel = new System.Windows.Forms.NumericUpDown();
            this.LblGiveCommandDescription = new System.Windows.Forms.Label();
            this.CmbFilterItem = new System.Windows.Forms.ComboBox();
            this.MenuItemFilter = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.LblClearFilter = new System.Windows.Forms.Label();
            this.GrpGiveItemRecord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDGameItemAmout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDGameItemLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // LblClearGiveItemLogs
            // 
            resources.ApplyResources(this.LblClearGiveItemLogs, "LblClearGiveItemLogs");
            this.LblClearGiveItemLogs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblClearGiveItemLogs.Name = "LblClearGiveItemLogs";
            this.LblClearGiveItemLogs.Click += new System.EventHandler(this.LblClearGiveItemLogs_Click);
            // 
            // BtnSaveGiveItemLog
            // 
            resources.ApplyResources(this.BtnSaveGiveItemLog, "BtnSaveGiveItemLog");
            this.BtnSaveGiveItemLog.Name = "BtnSaveGiveItemLog";
            this.BtnSaveGiveItemLog.UseVisualStyleBackColor = true;
            this.BtnSaveGiveItemLog.Click += new System.EventHandler(this.BtnSaveGiveItemLog_Click);
            // 
            // BtnRemoveGiveItemLog
            // 
            resources.ApplyResources(this.BtnRemoveGiveItemLog, "BtnRemoveGiveItemLog");
            this.BtnRemoveGiveItemLog.Name = "BtnRemoveGiveItemLog";
            this.BtnRemoveGiveItemLog.UseVisualStyleBackColor = true;
            this.BtnRemoveGiveItemLog.Click += new System.EventHandler(this.BtnRemoveGiveItemLog_Click);
            // 
            // GrpGiveItemRecord
            // 
            resources.ApplyResources(this.GrpGiveItemRecord, "GrpGiveItemRecord");
            this.GrpGiveItemRecord.Controls.Add(this.ListGiveItemLogs);
            this.GrpGiveItemRecord.Name = "GrpGiveItemRecord";
            this.GrpGiveItemRecord.TabStop = false;
            // 
            // ListGiveItemLogs
            // 
            resources.ApplyResources(this.ListGiveItemLogs, "ListGiveItemLogs");
            this.ListGiveItemLogs.FormattingEnabled = true;
            this.ListGiveItemLogs.Name = "ListGiveItemLogs";
            this.ListGiveItemLogs.SelectedIndexChanged += new System.EventHandler(this.ListGiveItemLogs_SelectedIndexChanged);
            // 
            // ChkDrop
            // 
            resources.ApplyResources(this.ChkDrop, "ChkDrop");
            this.ChkDrop.Name = "ChkDrop";
            this.ChkDrop.UseVisualStyleBackColor = true;
            this.ChkDrop.CheckedChanged += new System.EventHandler(this.GiveItemsInputChanged);
            // 
            // TxtGameItemFilter
            // 
            resources.ApplyResources(this.TxtGameItemFilter, "TxtGameItemFilter");
            this.TxtGameItemFilter.Name = "TxtGameItemFilter";
            this.TxtGameItemFilter.TextChanged += new System.EventHandler(this.TxtGameItemFilter_TextChanged);
            // 
            // ListGameItems
            // 
            resources.ApplyResources(this.ListGameItems, "ListGameItems");
            this.ListGameItems.FormattingEnabled = true;
            this.ListGameItems.Name = "ListGameItems";
            this.ListGameItems.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.ListGameItems_MeasureItem);
            this.ListGameItems.SelectedIndexChanged += new System.EventHandler(this.GiveItemsInputChanged);
            // 
            // LblGameItemAmount
            // 
            resources.ApplyResources(this.LblGameItemAmount, "LblGameItemAmount");
            this.LblGameItemAmount.Name = "LblGameItemAmount";
            // 
            // LblGameItemLevel
            // 
            resources.ApplyResources(this.LblGameItemLevel, "LblGameItemLevel");
            this.LblGameItemLevel.Name = "LblGameItemLevel";
            // 
            // NUDGameItemAmout
            // 
            resources.ApplyResources(this.NUDGameItemAmout, "NUDGameItemAmout");
            this.NUDGameItemAmout.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NUDGameItemAmout.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDGameItemAmout.Name = "NUDGameItemAmout";
            this.NUDGameItemAmout.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDGameItemAmout.ValueChanged += new System.EventHandler(this.GiveItemsInputChanged);
            // 
            // NUDGameItemLevel
            // 
            resources.ApplyResources(this.NUDGameItemLevel, "NUDGameItemLevel");
            this.NUDGameItemLevel.Maximum = new decimal(new int[] {
            21,
            0,
            0,
            0});
            this.NUDGameItemLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDGameItemLevel.Name = "NUDGameItemLevel";
            this.NUDGameItemLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDGameItemLevel.ValueChanged += new System.EventHandler(this.GiveItemsInputChanged);
            // 
            // LblGiveCommandDescription
            // 
            resources.ApplyResources(this.LblGiveCommandDescription, "LblGiveCommandDescription");
            this.LblGiveCommandDescription.Name = "LblGiveCommandDescription";
            // 
            // CmbFilterItem
            // 
            this.CmbFilterItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.CmbFilterItem, "CmbFilterItem");
            this.CmbFilterItem.Name = "CmbFilterItem";
            this.CmbFilterItem.SelectedIndexChanged += new System.EventHandler(this.CmbFilterItem_SelectedIndexChanged);
            // 
            // MenuItemFilter
            // 
            this.MenuItemFilter.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MenuItemFilter.Name = "MenuSpawnEntityFilter";
            resources.ApplyResources(this.MenuItemFilter, "MenuItemFilter");
            // 
            // LblClearFilter
            // 
            resources.ApplyResources(this.LblClearFilter, "LblClearFilter");
            this.LblClearFilter.BackColor = System.Drawing.Color.White;
            this.LblClearFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblClearFilter.Name = "LblClearFilter";
            this.LblClearFilter.Click += new System.EventHandler(this.LblClearFilter_Click);
            // 
            // PageGiveItem
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LblClearFilter);
            this.Controls.Add(this.CmbFilterItem);
            this.Controls.Add(this.LblClearGiveItemLogs);
            this.Controls.Add(this.BtnSaveGiveItemLog);
            this.Controls.Add(this.BtnRemoveGiveItemLog);
            this.Controls.Add(this.GrpGiveItemRecord);
            this.Controls.Add(this.ChkDrop);
            this.Controls.Add(this.TxtGameItemFilter);
            this.Controls.Add(this.ListGameItems);
            this.Controls.Add(this.LblGameItemAmount);
            this.Controls.Add(this.LblGameItemLevel);
            this.Controls.Add(this.NUDGameItemAmout);
            this.Controls.Add(this.NUDGameItemLevel);
            this.Controls.Add(this.LblGiveCommandDescription);
            this.Name = "PageGiveItem";
            this.GrpGiveItemRecord.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NUDGameItemAmout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDGameItemLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblClearGiveItemLogs;
        private System.Windows.Forms.Button BtnSaveGiveItemLog;
        private System.Windows.Forms.Button BtnRemoveGiveItemLog;
        private System.Windows.Forms.GroupBox GrpGiveItemRecord;
        private System.Windows.Forms.ListBox ListGiveItemLogs;
        private System.Windows.Forms.CheckBox ChkDrop;
        private System.Windows.Forms.TextBox TxtGameItemFilter;
        private System.Windows.Forms.ListBox ListGameItems;
        private System.Windows.Forms.Label LblGameItemAmount;
        private System.Windows.Forms.Label LblGameItemLevel;
        private System.Windows.Forms.NumericUpDown NUDGameItemAmout;
        private System.Windows.Forms.NumericUpDown NUDGameItemLevel;
        private System.Windows.Forms.Label LblGiveCommandDescription;
        private System.Windows.Forms.ComboBox CmbFilterItem;
        private System.Windows.Forms.ContextMenuStrip MenuItemFilter;
        private System.Windows.Forms.Label LblClearFilter;
    }
}
