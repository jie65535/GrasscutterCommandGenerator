namespace GrasscutterTools.Pages
{
    partial class PageAchievement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageAchievement));
            this.ListAchievements = new System.Windows.Forms.ListBox();
            this.GrpAchievements = new System.Windows.Forms.GroupBox();
            this.LblClearFilter = new System.Windows.Forms.Label();
            this.TxtAchievementFilter = new System.Windows.Forms.TextBox();
            this.LnkRevokeAll = new System.Windows.Forms.LinkLabel();
            this.LnkGrantAll = new System.Windows.Forms.LinkLabel();
            this.GrpAchievementCommands = new System.Windows.Forms.GroupBox();
            this.NUDProgress = new System.Windows.Forms.NumericUpDown();
            this.BtnProgress = new System.Windows.Forms.Button();
            this.BtnRevoke = new System.Windows.Forms.Button();
            this.BtnGrant = new System.Windows.Forms.Button();
            this.GrpAchievements.SuspendLayout();
            this.GrpAchievementCommands.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // ListAchievements
            // 
            resources.ApplyResources(this.ListAchievements, "ListAchievements");
            this.ListAchievements.FormattingEnabled = true;
            this.ListAchievements.Name = "ListAchievements";
            this.ListAchievements.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListAchievements.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.ListAchievements_MeasureItem);
            // 
            // GrpAchievements
            // 
            resources.ApplyResources(this.GrpAchievements, "GrpAchievements");
            this.GrpAchievements.Controls.Add(this.LblClearFilter);
            this.GrpAchievements.Controls.Add(this.TxtAchievementFilter);
            this.GrpAchievements.Controls.Add(this.LnkRevokeAll);
            this.GrpAchievements.Controls.Add(this.ListAchievements);
            this.GrpAchievements.Controls.Add(this.LnkGrantAll);
            this.GrpAchievements.Name = "GrpAchievements";
            this.GrpAchievements.TabStop = false;
            // 
            // LblClearFilter
            // 
            resources.ApplyResources(this.LblClearFilter, "LblClearFilter");
            this.LblClearFilter.BackColor = System.Drawing.Color.White;
            this.LblClearFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblClearFilter.Name = "LblClearFilter";
            this.LblClearFilter.Click += new System.EventHandler(this.LblClearFilter_Click);
            // 
            // TxtAchievementFilter
            // 
            resources.ApplyResources(this.TxtAchievementFilter, "TxtAchievementFilter");
            this.TxtAchievementFilter.Name = "TxtAchievementFilter";
            this.TxtAchievementFilter.TextChanged += new System.EventHandler(this.TxtAchievementFilter_TextChanged);
            // 
            // LnkRevokeAll
            // 
            resources.ApplyResources(this.LnkRevokeAll, "LnkRevokeAll");
            this.LnkRevokeAll.Name = "LnkRevokeAll";
            this.LnkRevokeAll.TabStop = true;
            this.LnkRevokeAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkRevokeAll_LinkClicked);
            // 
            // LnkGrantAll
            // 
            resources.ApplyResources(this.LnkGrantAll, "LnkGrantAll");
            this.LnkGrantAll.Name = "LnkGrantAll";
            this.LnkGrantAll.TabStop = true;
            this.LnkGrantAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkGrantAll_LinkClicked);
            // 
            // GrpAchievementCommands
            // 
            resources.ApplyResources(this.GrpAchievementCommands, "GrpAchievementCommands");
            this.GrpAchievementCommands.Controls.Add(this.NUDProgress);
            this.GrpAchievementCommands.Controls.Add(this.BtnProgress);
            this.GrpAchievementCommands.Controls.Add(this.BtnRevoke);
            this.GrpAchievementCommands.Controls.Add(this.BtnGrant);
            this.GrpAchievementCommands.Name = "GrpAchievementCommands";
            this.GrpAchievementCommands.TabStop = false;
            // 
            // NUDProgress
            // 
            resources.ApplyResources(this.NUDProgress, "NUDProgress");
            this.NUDProgress.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDProgress.Name = "NUDProgress";
            this.NUDProgress.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // BtnProgress
            // 
            resources.ApplyResources(this.BtnProgress, "BtnProgress");
            this.BtnProgress.Name = "BtnProgress";
            this.BtnProgress.UseVisualStyleBackColor = true;
            this.BtnProgress.Click += new System.EventHandler(this.BtnProgress_Click);
            // 
            // BtnRevoke
            // 
            resources.ApplyResources(this.BtnRevoke, "BtnRevoke");
            this.BtnRevoke.Name = "BtnRevoke";
            this.BtnRevoke.UseVisualStyleBackColor = true;
            this.BtnRevoke.Click += new System.EventHandler(this.BtnRevoke_Click);
            // 
            // BtnGrant
            // 
            resources.ApplyResources(this.BtnGrant, "BtnGrant");
            this.BtnGrant.Name = "BtnGrant";
            this.BtnGrant.UseVisualStyleBackColor = true;
            this.BtnGrant.Click += new System.EventHandler(this.BtnGrant_Click);
            // 
            // PageAchievement
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GrpAchievementCommands);
            this.Controls.Add(this.GrpAchievements);
            this.Name = "PageAchievement";
            this.GrpAchievements.ResumeLayout(false);
            this.GrpAchievements.PerformLayout();
            this.GrpAchievementCommands.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NUDProgress)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ListAchievements;
        private System.Windows.Forms.GroupBox GrpAchievements;
        private System.Windows.Forms.GroupBox GrpAchievementCommands;
        private System.Windows.Forms.Button BtnProgress;
        private System.Windows.Forms.Button BtnRevoke;
        private System.Windows.Forms.Button BtnGrant;
        private System.Windows.Forms.NumericUpDown NUDProgress;
        private System.Windows.Forms.TextBox TxtAchievementFilter;
        private System.Windows.Forms.LinkLabel LnkRevokeAll;
        private System.Windows.Forms.LinkLabel LnkGrantAll;
        private System.Windows.Forms.Label LblClearFilter;
    }
}
