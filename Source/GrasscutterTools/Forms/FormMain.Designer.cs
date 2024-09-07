namespace GrasscutterTools.Forms
{
    partial class FormMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.NavContainer = new System.Windows.Forms.SplitContainer();
            this.ListPages = new System.Windows.Forms.ListBox();
            this.CmbCommand = new System.Windows.Forms.ComboBox();
            this.BtnCopy = new System.Windows.Forms.Button();
            this.ChkAutoCopy = new System.Windows.Forms.CheckBox();
            this.GrpCommand = new System.Windows.Forms.GroupBox();
            this.LblClearFilter = new System.Windows.Forms.Label();
            this.BtnInvokeOpenCommand = new System.Windows.Forms.Button();
            this.MenuSpawnEntityFilter = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.NavContainer)).BeginInit();
            this.NavContainer.Panel1.SuspendLayout();
            this.NavContainer.SuspendLayout();
            this.GrpCommand.SuspendLayout();
            this.SuspendLayout();
            // 
            // NavContainer
            // 
            resources.ApplyResources(this.NavContainer, "NavContainer");
            this.NavContainer.Name = "NavContainer";
            // 
            // NavContainer.Panel1
            // 
            this.NavContainer.Panel1.Controls.Add(this.ListPages);
            // 
            // ListPages
            // 
            this.ListPages.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ListPages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.ListPages, "ListPages");
            this.ListPages.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ListPages.FormattingEnabled = true;
            this.ListPages.Name = "ListPages";
            this.ListPages.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListPages_DrawItem);
            this.ListPages.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.ListPages_MeasureItem);
            this.ListPages.SelectedIndexChanged += new System.EventHandler(this.ListPages_SelectedIndexChanged);
            this.ListPages.SizeChanged += new System.EventHandler(this.ListPages_SizeChanged);
            // 
            // CmbCommand
            // 
            resources.ApplyResources(this.CmbCommand, "CmbCommand");
            this.CmbCommand.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CmbCommand.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbCommand.Name = "CmbCommand";
            this.CmbCommand.TextChanged += new System.EventHandler(this.CmbCommand_TextChanged);
            this.CmbCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCommand_KeyDown);
            // 
            // BtnCopy
            // 
            resources.ApplyResources(this.BtnCopy, "BtnCopy");
            this.BtnCopy.Name = "BtnCopy";
            this.BtnCopy.UseVisualStyleBackColor = true;
            this.BtnCopy.Click += new System.EventHandler(this.BtnCopy_Click);
            // 
            // ChkAutoCopy
            // 
            resources.ApplyResources(this.ChkAutoCopy, "ChkAutoCopy");
            this.ChkAutoCopy.Name = "ChkAutoCopy";
            this.ChkAutoCopy.UseVisualStyleBackColor = true;
            // 
            // GrpCommand
            // 
            resources.ApplyResources(this.GrpCommand, "GrpCommand");
            this.GrpCommand.Controls.Add(this.LblClearFilter);
            this.GrpCommand.Controls.Add(this.BtnInvokeOpenCommand);
            this.GrpCommand.Controls.Add(this.BtnCopy);
            this.GrpCommand.Controls.Add(this.ChkAutoCopy);
            this.GrpCommand.Controls.Add(this.CmbCommand);
            this.GrpCommand.Name = "GrpCommand";
            this.GrpCommand.TabStop = false;
            // 
            // LblClearFilter
            // 
            resources.ApplyResources(this.LblClearFilter, "LblClearFilter");
            this.LblClearFilter.BackColor = System.Drawing.Color.White;
            this.LblClearFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblClearFilter.Name = "LblClearFilter";
            this.LblClearFilter.Click += new System.EventHandler(this.LblClearFilter_Click);
            // 
            // BtnInvokeOpenCommand
            // 
            resources.ApplyResources(this.BtnInvokeOpenCommand, "BtnInvokeOpenCommand");
            this.BtnInvokeOpenCommand.Name = "BtnInvokeOpenCommand";
            this.BtnInvokeOpenCommand.UseVisualStyleBackColor = true;
            this.BtnInvokeOpenCommand.Click += new System.EventHandler(this.BtnInvokeOpenCommand_Click);
            // 
            // MenuSpawnEntityFilter
            // 
            this.MenuSpawnEntityFilter.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MenuSpawnEntityFilter.Name = "MenuSpawnEntityFilter";
            resources.ApplyResources(this.MenuSpawnEntityFilter, "MenuSpawnEntityFilter");
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NavContainer);
            this.Controls.Add(this.GrpCommand);
            this.KeyPreview = true;
            this.Name = "FormMain";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.NavContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NavContainer)).EndInit();
            this.NavContainer.ResumeLayout(false);
            this.GrpCommand.ResumeLayout(false);
            this.GrpCommand.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbCommand;
        private System.Windows.Forms.Button BtnCopy;
        private System.Windows.Forms.CheckBox ChkAutoCopy;
        private System.Windows.Forms.GroupBox GrpCommand;
        private System.Windows.Forms.Button BtnInvokeOpenCommand;
        private System.Windows.Forms.ContextMenuStrip MenuSpawnEntityFilter;
        private System.Windows.Forms.ListBox ListPages;
        private System.Windows.Forms.SplitContainer NavContainer;
        private System.Windows.Forms.Label LblClearFilter;
    }
}
