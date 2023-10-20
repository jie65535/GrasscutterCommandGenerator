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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageWeather));
            this.TvSceneWeathers = new System.Windows.Forms.TreeView();
            this.LblPageTitle = new System.Windows.Forms.Label();
            this.CmbClimateType = new System.Windows.Forms.ComboBox();
            this.LblClimateType = new System.Windows.Forms.Label();
            this.BtnLockWeather = new System.Windows.Forms.Button();
            this.BtnUnlockWeather = new System.Windows.Forms.Button();
            this.LblClimateTip = new System.Windows.Forms.Label();
            this.TxtWeatherFilter = new System.Windows.Forms.TextBox();
            this.ListFilteredWeathers = new System.Windows.Forms.ListBox();
            this.LblClearFilter = new System.Windows.Forms.Label();
            this.LnkCheckWeather = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // TvSceneWeathers
            // 
            resources.ApplyResources(this.TvSceneWeathers, "TvSceneWeathers");
            this.TvSceneWeathers.FullRowSelect = true;
            this.TvSceneWeathers.Name = "TvSceneWeathers";
            this.TvSceneWeathers.ShowLines = false;
            this.TvSceneWeathers.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvSceneWeathers_AfterSelect);
            // 
            // LblPageTitle
            // 
            resources.ApplyResources(this.LblPageTitle, "LblPageTitle");
            this.LblPageTitle.Name = "LblPageTitle";
            // 
            // CmbClimateType
            // 
            this.CmbClimateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbClimateType.FormattingEnabled = true;
            resources.ApplyResources(this.CmbClimateType, "CmbClimateType");
            this.CmbClimateType.Name = "CmbClimateType";
            this.CmbClimateType.SelectedIndexChanged += new System.EventHandler(this.CmbClimateType_SelectedIndexChanged);
            // 
            // LblClimateType
            // 
            resources.ApplyResources(this.LblClimateType, "LblClimateType");
            this.LblClimateType.Name = "LblClimateType";
            // 
            // BtnLockWeather
            // 
            resources.ApplyResources(this.BtnLockWeather, "BtnLockWeather");
            this.BtnLockWeather.Name = "BtnLockWeather";
            this.BtnLockWeather.Tag = "on";
            this.BtnLockWeather.UseVisualStyleBackColor = true;
            this.BtnLockWeather.Click += new System.EventHandler(this.BtnLockWeather_Click);
            // 
            // BtnUnlockWeather
            // 
            resources.ApplyResources(this.BtnUnlockWeather, "BtnUnlockWeather");
            this.BtnUnlockWeather.Name = "BtnUnlockWeather";
            this.BtnUnlockWeather.Tag = "off";
            this.BtnUnlockWeather.UseVisualStyleBackColor = true;
            this.BtnUnlockWeather.Click += new System.EventHandler(this.BtnLockWeather_Click);
            // 
            // LblClimateTip
            // 
            resources.ApplyResources(this.LblClimateTip, "LblClimateTip");
            this.LblClimateTip.ForeColor = System.Drawing.SystemColors.GrayText;
            this.LblClimateTip.Name = "LblClimateTip";
            // 
            // TxtWeatherFilter
            // 
            resources.ApplyResources(this.TxtWeatherFilter, "TxtWeatherFilter");
            this.TxtWeatherFilter.Name = "TxtWeatherFilter";
            this.TxtWeatherFilter.TextChanged += new System.EventHandler(this.TxtWeatherFilter_TextChanged);
            // 
            // ListFilteredWeathers
            // 
            resources.ApplyResources(this.ListFilteredWeathers, "ListFilteredWeathers");
            this.ListFilteredWeathers.FormattingEnabled = true;
            this.ListFilteredWeathers.Name = "ListFilteredWeathers";
            this.ListFilteredWeathers.SelectedIndexChanged += new System.EventHandler(this.ListFilteredWeathers_SelectedIndexChanged);
            // 
            // LblClearFilter
            // 
            resources.ApplyResources(this.LblClearFilter, "LblClearFilter");
            this.LblClearFilter.BackColor = System.Drawing.Color.White;
            this.LblClearFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblClearFilter.Name = "LblClearFilter";
            this.LblClearFilter.Click += new System.EventHandler(this.LblClearFilter_Click);
            // 
            // LnkCheckWeather
            // 
            resources.ApplyResources(this.LnkCheckWeather, "LnkCheckWeather");
            this.LnkCheckWeather.Name = "LnkCheckWeather";
            this.LnkCheckWeather.TabStop = true;
            this.LnkCheckWeather.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkCheckWeather_LinkClicked);
            // 
            // PageWeather
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LnkCheckWeather);
            this.Controls.Add(this.LblClearFilter);
            this.Controls.Add(this.ListFilteredWeathers);
            this.Controls.Add(this.TxtWeatherFilter);
            this.Controls.Add(this.LblClimateTip);
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
        private System.Windows.Forms.Label LblClimateTip;
        private System.Windows.Forms.TextBox TxtWeatherFilter;
        private System.Windows.Forms.ListBox ListFilteredWeathers;
        private System.Windows.Forms.Label LblClearFilter;
        private System.Windows.Forms.LinkLabel LnkCheckWeather;
    }
}
