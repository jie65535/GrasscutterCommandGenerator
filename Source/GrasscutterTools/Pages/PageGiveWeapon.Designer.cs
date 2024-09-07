namespace GrasscutterTools.Pages
{
    partial class PageGiveWeapon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageGiveWeapon));
            this.BtnGiveAllWeapons = new System.Windows.Forms.Button();
            this.TxtWeaponFilter = new System.Windows.Forms.TextBox();
            this.LblWeaponDescription = new System.Windows.Forms.Label();
            this.LblWeaponRefinement = new System.Windows.Forms.Label();
            this.LblWeaponAmount = new System.Windows.Forms.Label();
            this.LblWeaponLevel = new System.Windows.Forms.Label();
            this.NUDWeaponRefinement = new System.Windows.Forms.NumericUpDown();
            this.NUDWeaponAmout = new System.Windows.Forms.NumericUpDown();
            this.NUDWeaponLevel = new System.Windows.Forms.NumericUpDown();
            this.ListWeapons = new System.Windows.Forms.ListBox();
            this.LblClearFilter = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NUDWeaponRefinement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDWeaponAmout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDWeaponLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnGiveAllWeapons
            // 
            resources.ApplyResources(this.BtnGiveAllWeapons, "BtnGiveAllWeapons");
            this.BtnGiveAllWeapons.Name = "BtnGiveAllWeapons";
            this.BtnGiveAllWeapons.UseVisualStyleBackColor = true;
            this.BtnGiveAllWeapons.Click += new System.EventHandler(this.BtnGiveAllWeapons_Click);
            // 
            // TxtWeaponFilter
            // 
            resources.ApplyResources(this.TxtWeaponFilter, "TxtWeaponFilter");
            this.TxtWeaponFilter.Name = "TxtWeaponFilter";
            this.TxtWeaponFilter.TextChanged += new System.EventHandler(this.TxtWeaponFilter_TextChanged);
            // 
            // LblWeaponDescription
            // 
            resources.ApplyResources(this.LblWeaponDescription, "LblWeaponDescription");
            this.LblWeaponDescription.Name = "LblWeaponDescription";
            // 
            // LblWeaponRefinement
            // 
            resources.ApplyResources(this.LblWeaponRefinement, "LblWeaponRefinement");
            this.LblWeaponRefinement.Name = "LblWeaponRefinement";
            // 
            // LblWeaponAmount
            // 
            resources.ApplyResources(this.LblWeaponAmount, "LblWeaponAmount");
            this.LblWeaponAmount.Name = "LblWeaponAmount";
            // 
            // LblWeaponLevel
            // 
            resources.ApplyResources(this.LblWeaponLevel, "LblWeaponLevel");
            this.LblWeaponLevel.Name = "LblWeaponLevel";
            // 
            // NUDWeaponRefinement
            // 
            resources.ApplyResources(this.NUDWeaponRefinement, "NUDWeaponRefinement");
            this.NUDWeaponRefinement.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NUDWeaponRefinement.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDWeaponRefinement.Name = "NUDWeaponRefinement";
            this.NUDWeaponRefinement.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NUDWeaponRefinement.ValueChanged += new System.EventHandler(this.WeaponValueChanged);
            // 
            // NUDWeaponAmout
            // 
            resources.ApplyResources(this.NUDWeaponAmout, "NUDWeaponAmout");
            this.NUDWeaponAmout.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDWeaponAmout.Name = "NUDWeaponAmout";
            this.NUDWeaponAmout.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDWeaponAmout.ValueChanged += new System.EventHandler(this.WeaponValueChanged);
            // 
            // NUDWeaponLevel
            // 
            resources.ApplyResources(this.NUDWeaponLevel, "NUDWeaponLevel");
            this.NUDWeaponLevel.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.NUDWeaponLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDWeaponLevel.Name = "NUDWeaponLevel";
            this.NUDWeaponLevel.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.NUDWeaponLevel.ValueChanged += new System.EventHandler(this.WeaponValueChanged);
            // 
            // ListWeapons
            // 
            resources.ApplyResources(this.ListWeapons, "ListWeapons");
            this.ListWeapons.FormattingEnabled = true;
            this.ListWeapons.Name = "ListWeapons";
            this.ListWeapons.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.ListWeapons_MeasureItem);
            this.ListWeapons.SelectedIndexChanged += new System.EventHandler(this.WeaponValueChanged);
            // 
            // LblClearFilter
            // 
            resources.ApplyResources(this.LblClearFilter, "LblClearFilter");
            this.LblClearFilter.BackColor = System.Drawing.Color.White;
            this.LblClearFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblClearFilter.Name = "LblClearFilter";
            this.LblClearFilter.Click += new System.EventHandler(this.LblClearFilter_Click);
            // 
            // PageGiveWeapon
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LblClearFilter);
            this.Controls.Add(this.ListWeapons);
            this.Controls.Add(this.TxtWeaponFilter);
            this.Controls.Add(this.NUDWeaponRefinement);
            this.Controls.Add(this.LblWeaponRefinement);
            this.Controls.Add(this.NUDWeaponLevel);
            this.Controls.Add(this.LblWeaponLevel);
            this.Controls.Add(this.NUDWeaponAmout);
            this.Controls.Add(this.LblWeaponAmount);
            this.Controls.Add(this.BtnGiveAllWeapons);
            this.Controls.Add(this.LblWeaponDescription);
            this.Name = "PageGiveWeapon";
            ((System.ComponentModel.ISupportInitialize)(this.NUDWeaponRefinement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDWeaponAmout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDWeaponLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnGiveAllWeapons;
        private System.Windows.Forms.TextBox TxtWeaponFilter;
        private System.Windows.Forms.Label LblWeaponDescription;
        private System.Windows.Forms.Label LblWeaponRefinement;
        private System.Windows.Forms.Label LblWeaponAmount;
        private System.Windows.Forms.Label LblWeaponLevel;
        private System.Windows.Forms.NumericUpDown NUDWeaponRefinement;
        private System.Windows.Forms.NumericUpDown NUDWeaponAmout;
        private System.Windows.Forms.NumericUpDown NUDWeaponLevel;
        private System.Windows.Forms.ListBox ListWeapons;
        private System.Windows.Forms.Label LblClearFilter;
    }
}
