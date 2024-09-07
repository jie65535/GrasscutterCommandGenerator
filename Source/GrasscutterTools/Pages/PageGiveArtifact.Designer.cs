namespace GrasscutterTools.Pages
{
    partial class PageGiveArtifact
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageGiveArtifact));
            this.LnkCharacterBuilder = new System.Windows.Forms.LinkLabel();
            this.LblArtifactLevelTip = new System.Windows.Forms.Label();
            this.BtnAddSubAttr = new System.Windows.Forms.Button();
            this.LblArtifactName = new System.Windows.Forms.Label();
            this.LblArtifactPart = new System.Windows.Forms.Label();
            this.CmbArtifactPart = new System.Windows.Forms.ComboBox();
            this.CmbArtifactSet = new System.Windows.Forms.ComboBox();
            this.LblArtifactSet = new System.Windows.Forms.Label();
            this.NUDSubAttributionTimes = new System.Windows.Forms.NumericUpDown();
            this.CmbSubAttributionValue = new System.Windows.Forms.ComboBox();
            this.CmbSubAttribution = new System.Windows.Forms.ComboBox();
            this.LblClearSubAttrCheckedList = new System.Windows.Forms.Label();
            this.ListSubAttributionChecked = new System.Windows.Forms.ListBox();
            this.LblArtifactLevel = new System.Windows.Forms.Label();
            this.LblSubAttribution = new System.Windows.Forms.Label();
            this.CmbMainAttribution = new System.Windows.Forms.ComboBox();
            this.LblMainAttribution = new System.Windows.Forms.Label();
            this.NUDArtifactLevel = new System.Windows.Forms.NumericUpDown();
            this.LblArtifactStars = new System.Windows.Forms.Label();
            this.NUDArtifactStars = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.NUDSubAttributionTimes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDArtifactLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDArtifactStars)).BeginInit();
            this.SuspendLayout();
            // 
            // LnkCharacterBuilder
            // 
            resources.ApplyResources(this.LnkCharacterBuilder, "LnkCharacterBuilder");
            this.LnkCharacterBuilder.Name = "LnkCharacterBuilder";
            this.LnkCharacterBuilder.TabStop = true;
            this.LnkCharacterBuilder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkCharacterBuilder_LinkClicked);
            // 
            // LblArtifactLevelTip
            // 
            resources.ApplyResources(this.LblArtifactLevelTip, "LblArtifactLevelTip");
            this.LblArtifactLevelTip.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LblArtifactLevelTip.Name = "LblArtifactLevelTip";
            // 
            // BtnAddSubAttr
            // 
            resources.ApplyResources(this.BtnAddSubAttr, "BtnAddSubAttr");
            this.BtnAddSubAttr.Name = "BtnAddSubAttr";
            this.BtnAddSubAttr.UseVisualStyleBackColor = true;
            this.BtnAddSubAttr.Click += new System.EventHandler(this.BtnAddSubAttr_Click);
            // 
            // LblArtifactName
            // 
            resources.ApplyResources(this.LblArtifactName, "LblArtifactName");
            this.LblArtifactName.Name = "LblArtifactName";
            // 
            // LblArtifactPart
            // 
            resources.ApplyResources(this.LblArtifactPart, "LblArtifactPart");
            this.LblArtifactPart.Name = "LblArtifactPart";
            // 
            // CmbArtifactPart
            // 
            resources.ApplyResources(this.CmbArtifactPart, "CmbArtifactPart");
            this.CmbArtifactPart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbArtifactPart.DropDownWidth = 125;
            this.CmbArtifactPart.FormattingEnabled = true;
            this.CmbArtifactPart.Name = "CmbArtifactPart";
            this.CmbArtifactPart.SelectedIndexChanged += new System.EventHandler(this.CmbArtifactPart_SelectedIndexChanged);
            // 
            // CmbArtifactSet
            // 
            resources.ApplyResources(this.CmbArtifactSet, "CmbArtifactSet");
            this.CmbArtifactSet.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CmbArtifactSet.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbArtifactSet.FormattingEnabled = true;
            this.CmbArtifactSet.Name = "CmbArtifactSet";
            this.CmbArtifactSet.SelectedIndexChanged += new System.EventHandler(this.CmbArtifactSet_SelectedIndexChanged);
            // 
            // LblArtifactSet
            // 
            resources.ApplyResources(this.LblArtifactSet, "LblArtifactSet");
            this.LblArtifactSet.Name = "LblArtifactSet";
            // 
            // NUDSubAttributionTimes
            // 
            resources.ApplyResources(this.NUDSubAttributionTimes, "NUDSubAttributionTimes");
            this.NUDSubAttributionTimes.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NUDSubAttributionTimes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDSubAttributionTimes.Name = "NUDSubAttributionTimes";
            this.NUDSubAttributionTimes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // CmbSubAttributionValue
            // 
            resources.ApplyResources(this.CmbSubAttributionValue, "CmbSubAttributionValue");
            this.CmbSubAttributionValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSubAttributionValue.FormattingEnabled = true;
            this.CmbSubAttributionValue.Name = "CmbSubAttributionValue";
            // 
            // CmbSubAttribution
            // 
            resources.ApplyResources(this.CmbSubAttribution, "CmbSubAttribution");
            this.CmbSubAttribution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSubAttribution.FormattingEnabled = true;
            this.CmbSubAttribution.Name = "CmbSubAttribution";
            this.CmbSubAttribution.SelectedIndexChanged += new System.EventHandler(this.CmbSubAttribution_SelectedIndexChanged);
            // 
            // LblClearSubAttrCheckedList
            // 
            resources.ApplyResources(this.LblClearSubAttrCheckedList, "LblClearSubAttrCheckedList");
            this.LblClearSubAttrCheckedList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblClearSubAttrCheckedList.Name = "LblClearSubAttrCheckedList";
            this.LblClearSubAttrCheckedList.Click += new System.EventHandler(this.LblClearSubAttrCheckedList_Click);
            // 
            // ListSubAttributionChecked
            // 
            resources.ApplyResources(this.ListSubAttributionChecked, "ListSubAttributionChecked");
            this.ListSubAttributionChecked.FormattingEnabled = true;
            this.ListSubAttributionChecked.Name = "ListSubAttributionChecked";
            this.ListSubAttributionChecked.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.ListSubAttributionChecked_MeasureItem);
            this.ListSubAttributionChecked.SelectedIndexChanged += new System.EventHandler(this.ListSubAttributionChecked_SelectedIndexChanged);
            // 
            // LblArtifactLevel
            // 
            resources.ApplyResources(this.LblArtifactLevel, "LblArtifactLevel");
            this.LblArtifactLevel.Name = "LblArtifactLevel";
            // 
            // LblSubAttribution
            // 
            resources.ApplyResources(this.LblSubAttribution, "LblSubAttribution");
            this.LblSubAttribution.Name = "LblSubAttribution";
            // 
            // CmbMainAttribution
            // 
            resources.ApplyResources(this.CmbMainAttribution, "CmbMainAttribution");
            this.CmbMainAttribution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMainAttribution.FormattingEnabled = true;
            this.CmbMainAttribution.Name = "CmbMainAttribution";
            this.CmbMainAttribution.SelectedIndexChanged += new System.EventHandler(this.ArtifactInputChanged);
            // 
            // LblMainAttribution
            // 
            resources.ApplyResources(this.LblMainAttribution, "LblMainAttribution");
            this.LblMainAttribution.Name = "LblMainAttribution";
            // 
            // NUDArtifactLevel
            // 
            resources.ApplyResources(this.NUDArtifactLevel, "NUDArtifactLevel");
            this.NUDArtifactLevel.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.NUDArtifactLevel.Name = "NUDArtifactLevel";
            this.NUDArtifactLevel.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.NUDArtifactLevel.ValueChanged += new System.EventHandler(this.ArtifactInputChanged);
            // 
            // LblArtifactStars
            // 
            resources.ApplyResources(this.LblArtifactStars, "LblArtifactStars");
            this.LblArtifactStars.Name = "LblArtifactStars";
            // 
            // NUDArtifactStars
            // 
            resources.ApplyResources(this.NUDArtifactStars, "NUDArtifactStars");
            this.NUDArtifactStars.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NUDArtifactStars.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDArtifactStars.Name = "NUDArtifactStars";
            this.NUDArtifactStars.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NUDArtifactStars.ValueChanged += new System.EventHandler(this.ArtifactInputChanged);
            // 
            // PageGiveArtifact
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LnkCharacterBuilder);
            this.Controls.Add(this.LblArtifactLevelTip);
            this.Controls.Add(this.BtnAddSubAttr);
            this.Controls.Add(this.LblArtifactName);
            this.Controls.Add(this.LblArtifactPart);
            this.Controls.Add(this.CmbArtifactPart);
            this.Controls.Add(this.CmbArtifactSet);
            this.Controls.Add(this.LblArtifactSet);
            this.Controls.Add(this.NUDSubAttributionTimes);
            this.Controls.Add(this.CmbSubAttributionValue);
            this.Controls.Add(this.CmbSubAttribution);
            this.Controls.Add(this.LblClearSubAttrCheckedList);
            this.Controls.Add(this.ListSubAttributionChecked);
            this.Controls.Add(this.LblArtifactLevel);
            this.Controls.Add(this.LblSubAttribution);
            this.Controls.Add(this.CmbMainAttribution);
            this.Controls.Add(this.LblMainAttribution);
            this.Controls.Add(this.NUDArtifactLevel);
            this.Controls.Add(this.LblArtifactStars);
            this.Controls.Add(this.NUDArtifactStars);
            this.Name = "PageGiveArtifact";
            ((System.ComponentModel.ISupportInitialize)(this.NUDSubAttributionTimes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDArtifactLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDArtifactStars)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel LnkCharacterBuilder;
        private System.Windows.Forms.Label LblArtifactLevelTip;
        private System.Windows.Forms.Button BtnAddSubAttr;
        private System.Windows.Forms.Label LblArtifactName;
        private System.Windows.Forms.Label LblArtifactPart;
        private System.Windows.Forms.ComboBox CmbArtifactPart;
        private System.Windows.Forms.ComboBox CmbArtifactSet;
        private System.Windows.Forms.Label LblArtifactSet;
        private System.Windows.Forms.NumericUpDown NUDSubAttributionTimes;
        private System.Windows.Forms.ComboBox CmbSubAttributionValue;
        private System.Windows.Forms.ComboBox CmbSubAttribution;
        private System.Windows.Forms.Label LblClearSubAttrCheckedList;
        private System.Windows.Forms.ListBox ListSubAttributionChecked;
        private System.Windows.Forms.Label LblArtifactLevel;
        private System.Windows.Forms.Label LblSubAttribution;
        private System.Windows.Forms.ComboBox CmbMainAttribution;
        private System.Windows.Forms.Label LblMainAttribution;
        private System.Windows.Forms.NumericUpDown NUDArtifactLevel;
        private System.Windows.Forms.Label LblArtifactStars;
        private System.Windows.Forms.NumericUpDown NUDArtifactStars;
    }
}
