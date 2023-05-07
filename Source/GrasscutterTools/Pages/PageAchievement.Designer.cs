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
            this.ListAchievements = new System.Windows.Forms.ListBox();
            this.GrpAchievements = new System.Windows.Forms.GroupBox();
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
            this.ListAchievements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListAchievements.FormattingEnabled = true;
            this.ListAchievements.ItemHeight = 17;
            this.ListAchievements.Location = new System.Drawing.Point(6, 51);
            this.ListAchievements.Name = "ListAchievements";
            this.ListAchievements.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListAchievements.Size = new System.Drawing.Size(628, 106);
            this.ListAchievements.TabIndex = 0;
            // 
            // GrpAchievements
            // 
            this.GrpAchievements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpAchievements.Controls.Add(this.TxtAchievementFilter);
            this.GrpAchievements.Controls.Add(this.LnkRevokeAll);
            this.GrpAchievements.Controls.Add(this.ListAchievements);
            this.GrpAchievements.Controls.Add(this.LnkGrantAll);
            this.GrpAchievements.Location = new System.Drawing.Point(3, 3);
            this.GrpAchievements.Name = "GrpAchievements";
            this.GrpAchievements.Size = new System.Drawing.Size(640, 167);
            this.GrpAchievements.TabIndex = 1;
            this.GrpAchievements.TabStop = false;
            this.GrpAchievements.Text = "成就列表（GC v1.4.7 起）";
            // 
            // TxtAchievementFilter
            // 
            this.TxtAchievementFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtAchievementFilter.Location = new System.Drawing.Point(6, 22);
            this.TxtAchievementFilter.Name = "TxtAchievementFilter";
            this.TxtAchievementFilter.Size = new System.Drawing.Size(628, 23);
            this.TxtAchievementFilter.TabIndex = 8;
            this.TxtAchievementFilter.TextChanged += new System.EventHandler(this.TxtAchievementFilter_TextChanged);
            // 
            // LnkRevokeAll
            // 
            this.LnkRevokeAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LnkRevokeAll.AutoSize = true;
            this.LnkRevokeAll.Location = new System.Drawing.Point(578, 0);
            this.LnkRevokeAll.Name = "LnkRevokeAll";
            this.LnkRevokeAll.Size = new System.Drawing.Size(56, 17);
            this.LnkRevokeAll.TabIndex = 7;
            this.LnkRevokeAll.TabStop = true;
            this.LnkRevokeAll.Text = "全部撤销";
            this.LnkRevokeAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkRevokeAll_LinkClicked);
            // 
            // LnkGrantAll
            // 
            this.LnkGrantAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LnkGrantAll.AutoSize = true;
            this.LnkGrantAll.Location = new System.Drawing.Point(516, 0);
            this.LnkGrantAll.Name = "LnkGrantAll";
            this.LnkGrantAll.Size = new System.Drawing.Size(56, 17);
            this.LnkGrantAll.TabIndex = 6;
            this.LnkGrantAll.TabStop = true;
            this.LnkGrantAll.Text = "全部达成";
            this.LnkGrantAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkGrantAll_LinkClicked);
            // 
            // GrpAchievementCommands
            // 
            this.GrpAchievementCommands.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpAchievementCommands.Controls.Add(this.NUDProgress);
            this.GrpAchievementCommands.Controls.Add(this.BtnProgress);
            this.GrpAchievementCommands.Controls.Add(this.BtnRevoke);
            this.GrpAchievementCommands.Controls.Add(this.BtnGrant);
            this.GrpAchievementCommands.Location = new System.Drawing.Point(3, 176);
            this.GrpAchievementCommands.Name = "GrpAchievementCommands";
            this.GrpAchievementCommands.Size = new System.Drawing.Size(640, 60);
            this.GrpAchievementCommands.TabIndex = 2;
            this.GrpAchievementCommands.TabStop = false;
            this.GrpAchievementCommands.Text = "成就控制（在列表中选择目标项）";
            // 
            // NUDProgress
            // 
            this.NUDProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NUDProgress.Location = new System.Drawing.Point(579, 25);
            this.NUDProgress.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDProgress.Name = "NUDProgress";
            this.NUDProgress.Size = new System.Drawing.Size(55, 23);
            this.NUDProgress.TabIndex = 5;
            this.NUDProgress.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // BtnProgress
            // 
            this.BtnProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnProgress.Location = new System.Drawing.Point(473, 25);
            this.BtnProgress.Name = "BtnProgress";
            this.BtnProgress.Size = new System.Drawing.Size(100, 23);
            this.BtnProgress.TabIndex = 4;
            this.BtnProgress.Text = "修改进度";
            this.BtnProgress.UseVisualStyleBackColor = true;
            this.BtnProgress.Click += new System.EventHandler(this.BtnProgress_Click);
            // 
            // BtnRevoke
            // 
            this.BtnRevoke.Location = new System.Drawing.Point(112, 25);
            this.BtnRevoke.Name = "BtnRevoke";
            this.BtnRevoke.Size = new System.Drawing.Size(100, 23);
            this.BtnRevoke.TabIndex = 1;
            this.BtnRevoke.Text = "撤销";
            this.BtnRevoke.UseVisualStyleBackColor = true;
            this.BtnRevoke.Click += new System.EventHandler(this.BtnRevoke_Click);
            // 
            // BtnGrant
            // 
            this.BtnGrant.Location = new System.Drawing.Point(6, 25);
            this.BtnGrant.Name = "BtnGrant";
            this.BtnGrant.Size = new System.Drawing.Size(100, 23);
            this.BtnGrant.TabIndex = 0;
            this.BtnGrant.Text = "达成";
            this.BtnGrant.UseVisualStyleBackColor = true;
            this.BtnGrant.Click += new System.EventHandler(this.BtnGrant_Click);
            // 
            // PageAchievement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
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
    }
}
