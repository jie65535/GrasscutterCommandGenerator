namespace GrasscutterTools.Pages
{
    partial class PageCustomCommands
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageCustomCommands));
            this.BtnExportCustomCommands = new System.Windows.Forms.Button();
            this.BtnLoadCustomCommands = new System.Windows.Forms.Button();
            this.LblCustomName = new System.Windows.Forms.Label();
            this.GrpCustomCommands = new System.Windows.Forms.GroupBox();
            this.LnkResetCustomCommands = new System.Windows.Forms.LinkLabel();
            this.FLPCustomCommands = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnRemoveCustomCommand = new System.Windows.Forms.Button();
            this.BtnSaveCustomCommand = new System.Windows.Forms.Button();
            this.TxtCustomName = new System.Windows.Forms.TextBox();
            this.BtnAddHotKey = new System.Windows.Forms.Button();
            this.LblClearFilter = new System.Windows.Forms.Label();
            this.GrpCustomCommands.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnExportCustomCommands
            // 
            resources.ApplyResources(this.BtnExportCustomCommands, "BtnExportCustomCommands");
            this.BtnExportCustomCommands.Name = "BtnExportCustomCommands";
            this.BtnExportCustomCommands.UseVisualStyleBackColor = true;
            this.BtnExportCustomCommands.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // BtnLoadCustomCommands
            // 
            resources.ApplyResources(this.BtnLoadCustomCommands, "BtnLoadCustomCommands");
            this.BtnLoadCustomCommands.Name = "BtnLoadCustomCommands";
            this.BtnLoadCustomCommands.UseVisualStyleBackColor = true;
            this.BtnLoadCustomCommands.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // LblCustomName
            // 
            resources.ApplyResources(this.LblCustomName, "LblCustomName");
            this.LblCustomName.Name = "LblCustomName";
            // 
            // GrpCustomCommands
            // 
            resources.ApplyResources(this.GrpCustomCommands, "GrpCustomCommands");
            this.GrpCustomCommands.Controls.Add(this.LnkResetCustomCommands);
            this.GrpCustomCommands.Controls.Add(this.FLPCustomCommands);
            this.GrpCustomCommands.Name = "GrpCustomCommands";
            this.GrpCustomCommands.TabStop = false;
            // 
            // LnkResetCustomCommands
            // 
            resources.ApplyResources(this.LnkResetCustomCommands, "LnkResetCustomCommands");
            this.LnkResetCustomCommands.Name = "LnkResetCustomCommands";
            this.LnkResetCustomCommands.TabStop = true;
            this.LnkResetCustomCommands.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkResetCustomCommands_LinkClicked);
            // 
            // FLPCustomCommands
            // 
            resources.ApplyResources(this.FLPCustomCommands, "FLPCustomCommands");
            this.FLPCustomCommands.Name = "FLPCustomCommands";
            // 
            // BtnRemoveCustomCommand
            // 
            resources.ApplyResources(this.BtnRemoveCustomCommand, "BtnRemoveCustomCommand");
            this.BtnRemoveCustomCommand.Name = "BtnRemoveCustomCommand";
            this.BtnRemoveCustomCommand.UseVisualStyleBackColor = true;
            this.BtnRemoveCustomCommand.Click += new System.EventHandler(this.BtnRemoveCustomCommand_Click);
            // 
            // BtnSaveCustomCommand
            // 
            resources.ApplyResources(this.BtnSaveCustomCommand, "BtnSaveCustomCommand");
            this.BtnSaveCustomCommand.Name = "BtnSaveCustomCommand";
            this.BtnSaveCustomCommand.UseVisualStyleBackColor = true;
            this.BtnSaveCustomCommand.Click += new System.EventHandler(this.BtnSaveCustomCommand_Click);
            // 
            // TxtCustomName
            // 
            resources.ApplyResources(this.TxtCustomName, "TxtCustomName");
            this.TxtCustomName.Name = "TxtCustomName";
            this.TxtCustomName.TextChanged += new System.EventHandler(this.TxtCustomName_TextChanged);
            this.TxtCustomName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCustomName_KeyDown);
            // 
            // BtnAddHotKey
            // 
            resources.ApplyResources(this.BtnAddHotKey, "BtnAddHotKey");
            this.BtnAddHotKey.Name = "BtnAddHotKey";
            this.BtnAddHotKey.UseVisualStyleBackColor = true;
            this.BtnAddHotKey.Click += new System.EventHandler(this.BtnAddHotKey_Click);
            // 
            // LblClearFilter
            // 
            resources.ApplyResources(this.LblClearFilter, "LblClearFilter");
            this.LblClearFilter.BackColor = System.Drawing.Color.White;
            this.LblClearFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblClearFilter.Name = "LblClearFilter";
            this.LblClearFilter.Click += new System.EventHandler(this.LblClearFilter_Click);
            // 
            // PageCustomCommands
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LblClearFilter);
            this.Controls.Add(this.BtnAddHotKey);
            this.Controls.Add(this.BtnExportCustomCommands);
            this.Controls.Add(this.BtnLoadCustomCommands);
            this.Controls.Add(this.LblCustomName);
            this.Controls.Add(this.GrpCustomCommands);
            this.Controls.Add(this.BtnRemoveCustomCommand);
            this.Controls.Add(this.BtnSaveCustomCommand);
            this.Controls.Add(this.TxtCustomName);
            this.Name = "PageCustomCommands";
            this.GrpCustomCommands.ResumeLayout(false);
            this.GrpCustomCommands.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnExportCustomCommands;
        private System.Windows.Forms.Button BtnLoadCustomCommands;
        private System.Windows.Forms.Label LblCustomName;
        private System.Windows.Forms.GroupBox GrpCustomCommands;
        private System.Windows.Forms.LinkLabel LnkResetCustomCommands;
        private System.Windows.Forms.FlowLayoutPanel FLPCustomCommands;
        private System.Windows.Forms.Button BtnRemoveCustomCommand;
        private System.Windows.Forms.Button BtnSaveCustomCommand;
        private System.Windows.Forms.TextBox TxtCustomName;
        private System.Windows.Forms.Button BtnAddHotKey;
        private System.Windows.Forms.Label LblClearFilter;
    }
}
