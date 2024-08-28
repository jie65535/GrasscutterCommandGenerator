namespace GrasscutterTools.Pages
{
    partial class PageTools
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
            this.BtnUpdateResources = new System.Windows.Forms.Button();
            this.LblProjectResRoot = new System.Windows.Forms.Label();
            this.TxtProjectResRoot = new System.Windows.Forms.TextBox();
            this.LblGcResRoot = new System.Windows.Forms.Label();
            this.TxtGcResRoot = new System.Windows.Forms.TextBox();
            this.BtnUpdateAllResources = new System.Windows.Forms.Button();
            this.BtnUpdateActivity = new System.Windows.Forms.Button();
            this.BtnUpdateBannerTitles = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnUpdateResources
            // 
            this.BtnUpdateResources.Location = new System.Drawing.Point(41, 195);
            this.BtnUpdateResources.Name = "BtnUpdateResources";
            this.BtnUpdateResources.Size = new System.Drawing.Size(100, 30);
            this.BtnUpdateResources.TabIndex = 0;
            this.BtnUpdateResources.Text = "Update res";
            this.BtnUpdateResources.UseVisualStyleBackColor = true;
            this.BtnUpdateResources.Click += new System.EventHandler(this.BtnUpdateResources_Click);
            // 
            // LblProjectResRoot
            // 
            this.LblProjectResRoot.AutoSize = true;
            this.LblProjectResRoot.Location = new System.Drawing.Point(38, 34);
            this.LblProjectResRoot.Name = "LblProjectResRoot";
            this.LblProjectResRoot.Size = new System.Drawing.Size(141, 17);
            this.LblProjectResRoot.TabIndex = 1;
            this.LblProjectResRoot.Text = "项目 Resources/ 路径：";
            // 
            // TxtProjectResRoot
            // 
            this.TxtProjectResRoot.Location = new System.Drawing.Point(185, 31);
            this.TxtProjectResRoot.Name = "TxtProjectResRoot";
            this.TxtProjectResRoot.Size = new System.Drawing.Size(413, 23);
            this.TxtProjectResRoot.TabIndex = 2;
            // 
            // LblGcResRoot
            // 
            this.LblGcResRoot.AutoSize = true;
            this.LblGcResRoot.Location = new System.Drawing.Point(44, 63);
            this.LblGcResRoot.Name = "LblGcResRoot";
            this.LblGcResRoot.Size = new System.Drawing.Size(135, 17);
            this.LblGcResRoot.TabIndex = 3;
            this.LblGcResRoot.Text = "GC_Resources/ 路径：";
            // 
            // TxtGcResRoot
            // 
            this.TxtGcResRoot.Location = new System.Drawing.Point(185, 60);
            this.TxtGcResRoot.Name = "TxtGcResRoot";
            this.TxtGcResRoot.Size = new System.Drawing.Size(413, 23);
            this.TxtGcResRoot.TabIndex = 4;
            // 
            // BtnUpdateAllResources
            // 
            this.BtnUpdateAllResources.Location = new System.Drawing.Point(41, 100);
            this.BtnUpdateAllResources.Name = "BtnUpdateAllResources";
            this.BtnUpdateAllResources.Size = new System.Drawing.Size(150, 30);
            this.BtnUpdateAllResources.TabIndex = 0;
            this.BtnUpdateAllResources.Text = "Update All Resources";
            this.BtnUpdateAllResources.UseVisualStyleBackColor = true;
            this.BtnUpdateAllResources.Click += new System.EventHandler(this.BtnUpdateAllResources_Click);
            // 
            // BtnUpdateActivity
            // 
            this.BtnUpdateActivity.Location = new System.Drawing.Point(197, 100);
            this.BtnUpdateActivity.Name = "BtnUpdateActivity";
            this.BtnUpdateActivity.Size = new System.Drawing.Size(150, 30);
            this.BtnUpdateActivity.TabIndex = 0;
            this.BtnUpdateActivity.Text = "Update Activity";
            this.BtnUpdateActivity.UseVisualStyleBackColor = true;
            this.BtnUpdateActivity.Click += new System.EventHandler(this.BtnUpdateActivity_Click);
            // 
            // BtnUpdateBannerTitles
            // 
            this.BtnUpdateBannerTitles.Location = new System.Drawing.Point(353, 100);
            this.BtnUpdateBannerTitles.Name = "BtnUpdateBannerTitles";
            this.BtnUpdateBannerTitles.Size = new System.Drawing.Size(150, 30);
            this.BtnUpdateBannerTitles.TabIndex = 0;
            this.BtnUpdateBannerTitles.Text = "Update Banner Titles";
            this.BtnUpdateBannerTitles.UseVisualStyleBackColor = true;
            this.BtnUpdateBannerTitles.Click += new System.EventHandler(this.BtnUpdateBannerTitles_Click);
            // 
            // PageTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TxtGcResRoot);
            this.Controls.Add(this.LblGcResRoot);
            this.Controls.Add(this.TxtProjectResRoot);
            this.Controls.Add(this.LblProjectResRoot);
            this.Controls.Add(this.BtnUpdateBannerTitles);
            this.Controls.Add(this.BtnUpdateActivity);
            this.Controls.Add(this.BtnUpdateAllResources);
            this.Controls.Add(this.BtnUpdateResources);
            this.Name = "PageTools";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnUpdateResources;
        private System.Windows.Forms.Label LblProjectResRoot;
        private System.Windows.Forms.TextBox TxtProjectResRoot;
        private System.Windows.Forms.Label LblGcResRoot;
        private System.Windows.Forms.TextBox TxtGcResRoot;
        private System.Windows.Forms.Button BtnUpdateAllResources;
        private System.Windows.Forms.Button BtnUpdateActivity;
        private System.Windows.Forms.Button BtnUpdateBannerTitles;
    }
}
