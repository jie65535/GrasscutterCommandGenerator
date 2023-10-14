namespace GrasscutterTools.Pages
{
    partial class PageWeather
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
            this.TvSceneWeathers = new System.Windows.Forms.TreeView();
            this.LblPageTitle = new System.Windows.Forms.Label();
            this.CmbClimateType = new System.Windows.Forms.ComboBox();
            this.LblClimateType = new System.Windows.Forms.Label();
            this.BtnLockWeather = new System.Windows.Forms.Button();
            this.BtnUnlockWeather = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnExportWeather = new System.Windows.Forms.Button();
            this.BtnImportWeather = new System.Windows.Forms.Button();
            this.BtnCreatePullRequest = new System.Windows.Forms.Button();
            this.LblPullRequestTip = new System.Windows.Forms.Label();
            this.LblClimateTip = new System.Windows.Forms.Label();
            this.TxtWeatherFilter = new System.Windows.Forms.TextBox();
            this.ListFilteredWeathers = new System.Windows.Forms.ListBox();
            this.LblClearFilter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TvSceneWeathers
            // 
            this.TvSceneWeathers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TvSceneWeathers.FullRowSelect = true;
            this.TvSceneWeathers.Location = new System.Drawing.Point(343, 32);
            this.TvSceneWeathers.Name = "TvSceneWeathers";
            this.TvSceneWeathers.ShowLines = false;
            this.TvSceneWeathers.Size = new System.Drawing.Size(300, 204);
            this.TvSceneWeathers.TabIndex = 102;
            this.TvSceneWeathers.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvSceneWeathers_AfterSelect);
            // 
            // LblPageTitle
            // 
            this.LblPageTitle.AutoSize = true;
            this.LblPageTitle.Location = new System.Drawing.Point(3, 3);
            this.LblPageTitle.Name = "LblPageTitle";
            this.LblPageTitle.Size = new System.Drawing.Size(56, 17);
            this.LblPageTitle.TabIndex = 0;
            this.LblPageTitle.Text = "场景天气";
            // 
            // CmbClimateType
            // 
            this.CmbClimateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbClimateType.FormattingEnabled = true;
            this.CmbClimateType.Location = new System.Drawing.Point(81, 33);
            this.CmbClimateType.Name = "CmbClimateType";
            this.CmbClimateType.Size = new System.Drawing.Size(121, 25);
            this.CmbClimateType.TabIndex = 2;
            this.CmbClimateType.SelectedIndexChanged += new System.EventHandler(this.CmbClimateType_SelectedIndexChanged);
            // 
            // LblClimateType
            // 
            this.LblClimateType.AutoSize = true;
            this.LblClimateType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblClimateType.Location = new System.Drawing.Point(19, 36);
            this.LblClimateType.Name = "LblClimateType";
            this.LblClimateType.Size = new System.Drawing.Size(56, 17);
            this.LblClimateType.TabIndex = 1;
            this.LblClimateType.Text = "设置气候";
            // 
            // BtnLockWeather
            // 
            this.BtnLockWeather.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnLockWeather.Location = new System.Drawing.Point(6, 211);
            this.BtnLockWeather.Name = "BtnLockWeather";
            this.BtnLockWeather.Size = new System.Drawing.Size(150, 25);
            this.BtnLockWeather.TabIndex = 10;
            this.BtnLockWeather.Tag = "on";
            this.BtnLockWeather.Text = "锁定天气";
            this.BtnLockWeather.UseVisualStyleBackColor = true;
            this.BtnLockWeather.Click += new System.EventHandler(this.BtnLockWeather_Click);
            // 
            // BtnUnlockWeather
            // 
            this.BtnUnlockWeather.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnUnlockWeather.Location = new System.Drawing.Point(162, 211);
            this.BtnUnlockWeather.Name = "BtnUnlockWeather";
            this.BtnUnlockWeather.Size = new System.Drawing.Size(150, 25);
            this.BtnUnlockWeather.TabIndex = 11;
            this.BtnUnlockWeather.Tag = "off";
            this.BtnUnlockWeather.Text = "解锁天气";
            this.BtnUnlockWeather.UseVisualStyleBackColor = true;
            this.BtnUnlockWeather.Click += new System.EventHandler(this.BtnLockWeather_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 55);
            this.label1.TabIndex = 4;
            this.label1.Text = "天气数据目前暂未翻译，在此邀请你参与天气数据翻译，导出天气原始数据，在游戏内测试天气效果，修改数据文件通过提交更改按钮在 Github 创建 Pull Reque" +
    "st，即可参与贡献！";
            // 
            // BtnExportWeather
            // 
            this.BtnExportWeather.Location = new System.Drawing.Point(3, 136);
            this.BtnExportWeather.Name = "BtnExportWeather";
            this.BtnExportWeather.Size = new System.Drawing.Size(150, 25);
            this.BtnExportWeather.TabIndex = 5;
            this.BtnExportWeather.Text = "导出原始天气";
            this.BtnExportWeather.UseVisualStyleBackColor = true;
            this.BtnExportWeather.Click += new System.EventHandler(this.BtnExportWeather_Click);
            // 
            // BtnImportWeather
            // 
            this.BtnImportWeather.Location = new System.Drawing.Point(159, 136);
            this.BtnImportWeather.Name = "BtnImportWeather";
            this.BtnImportWeather.Size = new System.Drawing.Size(150, 25);
            this.BtnImportWeather.TabIndex = 6;
            this.BtnImportWeather.Text = "导入天气";
            this.BtnImportWeather.UseVisualStyleBackColor = true;
            this.BtnImportWeather.Click += new System.EventHandler(this.BtnImportWeather_Click);
            // 
            // BtnCreatePullRequest
            // 
            this.BtnCreatePullRequest.Location = new System.Drawing.Point(3, 167);
            this.BtnCreatePullRequest.Name = "BtnCreatePullRequest";
            this.BtnCreatePullRequest.Size = new System.Drawing.Size(150, 25);
            this.BtnCreatePullRequest.TabIndex = 7;
            this.BtnCreatePullRequest.Text = "提交修改 (Github)";
            this.BtnCreatePullRequest.UseVisualStyleBackColor = true;
            this.BtnCreatePullRequest.Click += new System.EventHandler(this.BtnCreatePullRequest_Click);
            // 
            // LblPullRequestTip
            // 
            this.LblPullRequestTip.AutoSize = true;
            this.LblPullRequestTip.ForeColor = System.Drawing.SystemColors.GrayText;
            this.LblPullRequestTip.Location = new System.Drawing.Point(156, 171);
            this.LblPullRequestTip.Name = "LblPullRequestTip";
            this.LblPullRequestTip.Size = new System.Drawing.Size(128, 17);
            this.LblPullRequestTip.TabIndex = 8;
            this.LblPullRequestTip.Text = "你也可以提交到群文件";
            // 
            // LblClimateTip
            // 
            this.LblClimateTip.AutoSize = true;
            this.LblClimateTip.ForeColor = System.Drawing.SystemColors.GrayText;
            this.LblClimateTip.Location = new System.Drawing.Point(208, 36);
            this.LblClimateTip.Name = "LblClimateTip";
            this.LblClimateTip.Size = new System.Drawing.Size(104, 17);
            this.LblClimateTip.TabIndex = 3;
            this.LblClimateTip.Text = "天气包含默认气候";
            // 
            // TxtWeatherFilter
            // 
            this.TxtWeatherFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtWeatherFilter.Location = new System.Drawing.Point(343, 3);
            this.TxtWeatherFilter.Name = "TxtWeatherFilter";
            this.TxtWeatherFilter.Size = new System.Drawing.Size(300, 23);
            this.TxtWeatherFilter.TabIndex = 100;
            this.TxtWeatherFilter.TextChanged += new System.EventHandler(this.TxtWeatherFilter_TextChanged);
            // 
            // ListFilteredWeathers
            // 
            this.ListFilteredWeathers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListFilteredWeathers.FormattingEnabled = true;
            this.ListFilteredWeathers.ItemHeight = 17;
            this.ListFilteredWeathers.Location = new System.Drawing.Point(343, 26);
            this.ListFilteredWeathers.Name = "ListFilteredWeathers";
            this.ListFilteredWeathers.Size = new System.Drawing.Size(300, 191);
            this.ListFilteredWeathers.TabIndex = 101;
            this.ListFilteredWeathers.Visible = false;
            this.ListFilteredWeathers.SelectedIndexChanged += new System.EventHandler(this.ListFilteredWeathers_SelectedIndexChanged);
            // 
            // LblClearFilter
            // 
            this.LblClearFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblClearFilter.AutoSize = true;
            this.LblClearFilter.BackColor = System.Drawing.Color.White;
            this.LblClearFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblClearFilter.Location = new System.Drawing.Point(626, 6);
            this.LblClearFilter.Name = "LblClearFilter";
            this.LblClearFilter.Size = new System.Drawing.Size(16, 17);
            this.LblClearFilter.TabIndex = 103;
            this.LblClearFilter.Text = "X";
            this.LblClearFilter.Visible = false;
            this.LblClearFilter.Click += new System.EventHandler(this.LblClearFilter_Click);
            // 
            // PageWeather
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LblClearFilter);
            this.Controls.Add(this.ListFilteredWeathers);
            this.Controls.Add(this.TxtWeatherFilter);
            this.Controls.Add(this.LblClimateTip);
            this.Controls.Add(this.LblPullRequestTip);
            this.Controls.Add(this.BtnCreatePullRequest);
            this.Controls.Add(this.BtnImportWeather);
            this.Controls.Add(this.BtnExportWeather);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnUnlockWeather);
            this.Controls.Add(this.BtnLockWeather);
            this.Controls.Add(this.CmbClimateType);
            this.Controls.Add(this.LblClimateType);
            this.Controls.Add(this.LblPageTitle);
            this.Controls.Add(this.TvSceneWeathers);
            this.Name = "PageWeather";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView TvSceneWeathers;
        private System.Windows.Forms.Label LblPageTitle;
        private System.Windows.Forms.ComboBox CmbClimateType;
        private System.Windows.Forms.Label LblClimateType;
        private System.Windows.Forms.Button BtnLockWeather;
        private System.Windows.Forms.Button BtnUnlockWeather;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnExportWeather;
        private System.Windows.Forms.Button BtnImportWeather;
        private System.Windows.Forms.Button BtnCreatePullRequest;
        private System.Windows.Forms.Label LblPullRequestTip;
        private System.Windows.Forms.Label LblClimateTip;
        private System.Windows.Forms.TextBox TxtWeatherFilter;
        private System.Windows.Forms.ListBox ListFilteredWeathers;
        private System.Windows.Forms.Label LblClearFilter;
    }
}
