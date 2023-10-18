namespace GrasscutterTools.Pages
{
    partial class PageHotKey
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageHotKey));
            this.LvHotKeyList = new System.Windows.Forms.ListView();
            this.ColTag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColHotKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColCommand = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GrpHotKeyList = new System.Windows.Forms.GroupBox();
            this.ChkEnableGlobal = new System.Windows.Forms.CheckBox();
            this.BtnRemove = new System.Windows.Forms.Button();
            this.BtnAddOrUpdate = new System.Windows.Forms.Button();
            this.TxtHotKey = new System.Windows.Forms.TextBox();
            this.LblHotKeyLabel = new System.Windows.Forms.Label();
            this.TxtTag = new System.Windows.Forms.TextBox();
            this.LblTagLabel = new System.Windows.Forms.Label();
            this.LblClearFilter = new System.Windows.Forms.Label();
            this.GrpHotKeyList.SuspendLayout();
            this.SuspendLayout();
            // 
            // LvHotKeyList
            // 
            this.LvHotKeyList.CheckBoxes = true;
            this.LvHotKeyList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColTag,
            this.ColHotKey,
            this.ColCommand});
            resources.ApplyResources(this.LvHotKeyList, "LvHotKeyList");
            this.LvHotKeyList.HideSelection = false;
            this.LvHotKeyList.Name = "LvHotKeyList";
            this.LvHotKeyList.UseCompatibleStateImageBehavior = false;
            this.LvHotKeyList.View = System.Windows.Forms.View.Details;
            this.LvHotKeyList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.LvHotKeyList_ItemCheck);
            this.LvHotKeyList.SelectedIndexChanged += new System.EventHandler(this.LvHotKeyList_SelectedIndexChanged);
            // 
            // ColTag
            // 
            resources.ApplyResources(this.ColTag, "ColTag");
            // 
            // ColHotKey
            // 
            resources.ApplyResources(this.ColHotKey, "ColHotKey");
            // 
            // ColCommand
            // 
            resources.ApplyResources(this.ColCommand, "ColCommand");
            // 
            // GrpHotKeyList
            // 
            resources.ApplyResources(this.GrpHotKeyList, "GrpHotKeyList");
            this.GrpHotKeyList.Controls.Add(this.ChkEnableGlobal);
            this.GrpHotKeyList.Controls.Add(this.LvHotKeyList);
            this.GrpHotKeyList.Name = "GrpHotKeyList";
            this.GrpHotKeyList.TabStop = false;
            // 
            // ChkEnableGlobal
            // 
            resources.ApplyResources(this.ChkEnableGlobal, "ChkEnableGlobal");
            this.ChkEnableGlobal.Checked = true;
            this.ChkEnableGlobal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkEnableGlobal.Name = "ChkEnableGlobal";
            this.ChkEnableGlobal.UseVisualStyleBackColor = true;
            this.ChkEnableGlobal.CheckedChanged += new System.EventHandler(this.ChkEnableGlobal_CheckedChanged);
            // 
            // BtnRemove
            // 
            resources.ApplyResources(this.BtnRemove, "BtnRemove");
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.UseVisualStyleBackColor = true;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // BtnAddOrUpdate
            // 
            resources.ApplyResources(this.BtnAddOrUpdate, "BtnAddOrUpdate");
            this.BtnAddOrUpdate.Name = "BtnAddOrUpdate";
            this.BtnAddOrUpdate.UseVisualStyleBackColor = true;
            this.BtnAddOrUpdate.Click += new System.EventHandler(this.BtnAddOrUpdate_Click);
            // 
            // TxtHotKey
            // 
            resources.ApplyResources(this.TxtHotKey, "TxtHotKey");
            this.TxtHotKey.BackColor = System.Drawing.Color.White;
            this.TxtHotKey.Name = "TxtHotKey";
            this.TxtHotKey.ReadOnly = true;
            this.TxtHotKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtHotKey_KeyDown);
            // 
            // LblHotKeyLabel
            // 
            resources.ApplyResources(this.LblHotKeyLabel, "LblHotKeyLabel");
            this.LblHotKeyLabel.Name = "LblHotKeyLabel";
            // 
            // TxtTag
            // 
            resources.ApplyResources(this.TxtTag, "TxtTag");
            this.TxtTag.Name = "TxtTag";
            this.TxtTag.TextChanged += new System.EventHandler(this.TxtTag_TextChanged);
            // 
            // LblTagLabel
            // 
            resources.ApplyResources(this.LblTagLabel, "LblTagLabel");
            this.LblTagLabel.Name = "LblTagLabel";
            // 
            // LblClearFilter
            // 
            resources.ApplyResources(this.LblClearFilter, "LblClearFilter");
            this.LblClearFilter.BackColor = System.Drawing.Color.White;
            this.LblClearFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblClearFilter.Name = "LblClearFilter";
            this.LblClearFilter.Click += new System.EventHandler(this.LblClearFilter_Click);
            // 
            // PageHotKey
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LblClearFilter);
            this.Controls.Add(this.BtnRemove);
            this.Controls.Add(this.BtnAddOrUpdate);
            this.Controls.Add(this.GrpHotKeyList);
            this.Controls.Add(this.TxtHotKey);
            this.Controls.Add(this.TxtTag);
            this.Controls.Add(this.LblHotKeyLabel);
            this.Controls.Add(this.LblTagLabel);
            this.Name = "PageHotKey";
            this.GrpHotKeyList.ResumeLayout(false);
            this.GrpHotKeyList.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView LvHotKeyList;
        private System.Windows.Forms.ColumnHeader ColHotKey;
        private System.Windows.Forms.ColumnHeader ColTag;
        private System.Windows.Forms.ColumnHeader ColCommand;
        private System.Windows.Forms.GroupBox GrpHotKeyList;
        private System.Windows.Forms.Button BtnRemove;
        private System.Windows.Forms.Button BtnAddOrUpdate;
        private System.Windows.Forms.TextBox TxtHotKey;
        private System.Windows.Forms.Label LblHotKeyLabel;
        private System.Windows.Forms.TextBox TxtTag;
        private System.Windows.Forms.Label LblTagLabel;
        private System.Windows.Forms.CheckBox ChkEnableGlobal;
        private System.Windows.Forms.Label LblClearFilter;
    }
}
