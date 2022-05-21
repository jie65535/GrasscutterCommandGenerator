
namespace GrasscutterTools.Forms
{
    partial class FormGachaBannerEditor2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGachaBannerEditor2));
            this.GrpBannerValues = new System.Windows.Forms.GroupBox();
            this.ChkAutoStripRateUpFromFallback = new System.Windows.Forms.CheckBox();
            this.LblOptions = new System.Windows.Forms.Label();
            this.ChkRemoveC6FormPool = new System.Windows.Forms.CheckBox();
            this.LnkOpenOldEditor = new System.Windows.Forms.LinkLabel();
            this.DTPEndTime = new System.Windows.Forms.DateTimePicker();
            this.DTPBeginTime = new System.Windows.Forms.DateTimePicker();
            this.CmbPrefab = new System.Windows.Forms.ComboBox();
            this.LblEventChance4Tip = new System.Windows.Forms.Label();
            this.LblEventChance5Tip = new System.Windows.Forms.Label();
            this.NUDEventChance4 = new System.Windows.Forms.NumericUpDown();
            this.NUDEventChance5 = new System.Windows.Forms.NumericUpDown();
            this.LblGachaType = new System.Windows.Forms.Label();
            this.LblEventChance4 = new System.Windows.Forms.Label();
            this.LblEventChance5 = new System.Windows.Forms.Label();
            this.LblSortId = new System.Windows.Forms.Label();
            this.NUDGachaType = new System.Windows.Forms.NumericUpDown();
            this.NUDSortId = new System.Windows.Forms.NumericUpDown();
            this.LblGachaTypeTip = new System.Windows.Forms.Label();
            this.LblEndTime = new System.Windows.Forms.Label();
            this.LblScheduleId = new System.Windows.Forms.Label();
            this.LblBeginTime = new System.Windows.Forms.Label();
            this.NUDScheduleId = new System.Windows.Forms.NumericUpDown();
            this.LblScheduleIdTip = new System.Windows.Forms.Label();
            this.CmbBannerType = new System.Windows.Forms.ComboBox();
            this.LblSortIdTip = new System.Windows.Forms.Label();
            this.LblBannerType = new System.Windows.Forms.Label();
            this.RbCostItem224 = new System.Windows.Forms.RadioButton();
            this.LblCostItem = new System.Windows.Forms.Label();
            this.LblPrefabPath = new System.Windows.Forms.Label();
            this.RbCostItem223 = new System.Windows.Forms.RadioButton();
            this.GrpFallbackPool = new System.Windows.Forms.GroupBox();
            this.ListFallbackItems = new System.Windows.Forms.ListView();
            this.ColFallbackId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColFallbackName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GrpUpPool = new System.Windows.Forms.GroupBox();
            this.ListUpItems = new System.Windows.Forms.ListView();
            this.ColUpId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColUpName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GrpJson = new System.Windows.Forms.GroupBox();
            this.BtnGen = new System.Windows.Forms.Button();
            this.TxtJson = new System.Windows.Forms.TextBox();
            this.BtnParse = new System.Windows.Forms.Button();
            this.GrpWeights = new System.Windows.Forms.GroupBox();
            this.LnkWeightHelp = new System.Windows.Forms.LinkLabel();
            this.TxtWeight4 = new System.Windows.Forms.TextBox();
            this.TxtWeight5 = new System.Windows.Forms.TextBox();
            this.LblWeight4 = new System.Windows.Forms.Label();
            this.LblWeight5 = new System.Windows.Forms.Label();
            this.GrpBalance = new System.Windows.Forms.GroupBox();
            this.TxtPoolWeight4 = new System.Windows.Forms.TextBox();
            this.TxtPoolWeight5 = new System.Windows.Forms.TextBox();
            this.LblPoolWeight4 = new System.Windows.Forms.Label();
            this.LblPoolWeight5 = new System.Windows.Forms.Label();
            this.GrpBannerValues.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDEventChance4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDEventChance5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDGachaType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDSortId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDScheduleId)).BeginInit();
            this.GrpFallbackPool.SuspendLayout();
            this.GrpUpPool.SuspendLayout();
            this.GrpJson.SuspendLayout();
            this.GrpWeights.SuspendLayout();
            this.GrpBalance.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpBannerValues
            // 
            resources.ApplyResources(this.GrpBannerValues, "GrpBannerValues");
            this.GrpBannerValues.Controls.Add(this.ChkAutoStripRateUpFromFallback);
            this.GrpBannerValues.Controls.Add(this.LblOptions);
            this.GrpBannerValues.Controls.Add(this.ChkRemoveC6FormPool);
            this.GrpBannerValues.Controls.Add(this.LnkOpenOldEditor);
            this.GrpBannerValues.Controls.Add(this.DTPEndTime);
            this.GrpBannerValues.Controls.Add(this.DTPBeginTime);
            this.GrpBannerValues.Controls.Add(this.CmbPrefab);
            this.GrpBannerValues.Controls.Add(this.LblEventChance4Tip);
            this.GrpBannerValues.Controls.Add(this.LblEventChance5Tip);
            this.GrpBannerValues.Controls.Add(this.NUDEventChance4);
            this.GrpBannerValues.Controls.Add(this.NUDEventChance5);
            this.GrpBannerValues.Controls.Add(this.LblGachaType);
            this.GrpBannerValues.Controls.Add(this.LblEventChance4);
            this.GrpBannerValues.Controls.Add(this.LblEventChance5);
            this.GrpBannerValues.Controls.Add(this.LblSortId);
            this.GrpBannerValues.Controls.Add(this.NUDGachaType);
            this.GrpBannerValues.Controls.Add(this.NUDSortId);
            this.GrpBannerValues.Controls.Add(this.LblGachaTypeTip);
            this.GrpBannerValues.Controls.Add(this.LblEndTime);
            this.GrpBannerValues.Controls.Add(this.LblScheduleId);
            this.GrpBannerValues.Controls.Add(this.LblBeginTime);
            this.GrpBannerValues.Controls.Add(this.NUDScheduleId);
            this.GrpBannerValues.Controls.Add(this.LblScheduleIdTip);
            this.GrpBannerValues.Controls.Add(this.CmbBannerType);
            this.GrpBannerValues.Controls.Add(this.LblSortIdTip);
            this.GrpBannerValues.Controls.Add(this.LblBannerType);
            this.GrpBannerValues.Controls.Add(this.RbCostItem224);
            this.GrpBannerValues.Controls.Add(this.LblCostItem);
            this.GrpBannerValues.Controls.Add(this.LblPrefabPath);
            this.GrpBannerValues.Controls.Add(this.RbCostItem223);
            this.GrpBannerValues.Name = "GrpBannerValues";
            this.GrpBannerValues.TabStop = false;
            // 
            // ChkAutoStripRateUpFromFallback
            // 
            resources.ApplyResources(this.ChkAutoStripRateUpFromFallback, "ChkAutoStripRateUpFromFallback");
            this.ChkAutoStripRateUpFromFallback.Name = "ChkAutoStripRateUpFromFallback";
            this.ChkAutoStripRateUpFromFallback.UseVisualStyleBackColor = true;
            // 
            // LblOptions
            // 
            resources.ApplyResources(this.LblOptions, "LblOptions");
            this.LblOptions.Name = "LblOptions";
            // 
            // ChkRemoveC6FormPool
            // 
            resources.ApplyResources(this.ChkRemoveC6FormPool, "ChkRemoveC6FormPool");
            this.ChkRemoveC6FormPool.Name = "ChkRemoveC6FormPool";
            this.ChkRemoveC6FormPool.UseVisualStyleBackColor = true;
            // 
            // LnkOpenOldEditor
            // 
            resources.ApplyResources(this.LnkOpenOldEditor, "LnkOpenOldEditor");
            this.LnkOpenOldEditor.Name = "LnkOpenOldEditor";
            this.LnkOpenOldEditor.TabStop = true;
            this.LnkOpenOldEditor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkOpenOldEditor_LinkClicked);
            // 
            // DTPEndTime
            // 
            resources.ApplyResources(this.DTPEndTime, "DTPEndTime");
            this.DTPEndTime.MaxDate = new System.DateTime(2038, 1, 19, 0, 0, 0, 0);
            this.DTPEndTime.MinDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            this.DTPEndTime.Name = "DTPEndTime";
            // 
            // DTPBeginTime
            // 
            resources.ApplyResources(this.DTPBeginTime, "DTPBeginTime");
            this.DTPBeginTime.MaxDate = new System.DateTime(2038, 1, 19, 0, 0, 0, 0);
            this.DTPBeginTime.MinDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            this.DTPBeginTime.Name = "DTPBeginTime";
            // 
            // CmbPrefab
            // 
            resources.ApplyResources(this.CmbPrefab, "CmbPrefab");
            this.CmbPrefab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPrefab.FormattingEnabled = true;
            this.CmbPrefab.Name = "CmbPrefab";
            // 
            // LblEventChance4Tip
            // 
            resources.ApplyResources(this.LblEventChance4Tip, "LblEventChance4Tip");
            this.LblEventChance4Tip.Name = "LblEventChance4Tip";
            // 
            // LblEventChance5Tip
            // 
            resources.ApplyResources(this.LblEventChance5Tip, "LblEventChance5Tip");
            this.LblEventChance5Tip.Name = "LblEventChance5Tip";
            // 
            // NUDEventChance4
            // 
            resources.ApplyResources(this.NUDEventChance4, "NUDEventChance4");
            this.NUDEventChance4.Name = "NUDEventChance4";
            this.NUDEventChance4.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // NUDEventChance5
            // 
            resources.ApplyResources(this.NUDEventChance5, "NUDEventChance5");
            this.NUDEventChance5.Name = "NUDEventChance5";
            this.NUDEventChance5.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // LblGachaType
            // 
            resources.ApplyResources(this.LblGachaType, "LblGachaType");
            this.LblGachaType.Name = "LblGachaType";
            // 
            // LblEventChance4
            // 
            resources.ApplyResources(this.LblEventChance4, "LblEventChance4");
            this.LblEventChance4.Name = "LblEventChance4";
            // 
            // LblEventChance5
            // 
            resources.ApplyResources(this.LblEventChance5, "LblEventChance5");
            this.LblEventChance5.Name = "LblEventChance5";
            // 
            // LblSortId
            // 
            resources.ApplyResources(this.LblSortId, "LblSortId");
            this.LblSortId.Name = "LblSortId";
            // 
            // NUDGachaType
            // 
            resources.ApplyResources(this.NUDGachaType, "NUDGachaType");
            this.NUDGachaType.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NUDGachaType.Name = "NUDGachaType";
            this.NUDGachaType.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            // 
            // NUDSortId
            // 
            resources.ApplyResources(this.NUDSortId, "NUDSortId");
            this.NUDSortId.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NUDSortId.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NUDSortId.Name = "NUDSortId";
            this.NUDSortId.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // LblGachaTypeTip
            // 
            resources.ApplyResources(this.LblGachaTypeTip, "LblGachaTypeTip");
            this.LblGachaTypeTip.Name = "LblGachaTypeTip";
            // 
            // LblEndTime
            // 
            resources.ApplyResources(this.LblEndTime, "LblEndTime");
            this.LblEndTime.Name = "LblEndTime";
            // 
            // LblScheduleId
            // 
            resources.ApplyResources(this.LblScheduleId, "LblScheduleId");
            this.LblScheduleId.Name = "LblScheduleId";
            // 
            // LblBeginTime
            // 
            resources.ApplyResources(this.LblBeginTime, "LblBeginTime");
            this.LblBeginTime.Name = "LblBeginTime";
            // 
            // NUDScheduleId
            // 
            resources.ApplyResources(this.NUDScheduleId, "NUDScheduleId");
            this.NUDScheduleId.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NUDScheduleId.Name = "NUDScheduleId";
            this.NUDScheduleId.Value = new decimal(new int[] {
            800,
            0,
            0,
            0});
            // 
            // LblScheduleIdTip
            // 
            resources.ApplyResources(this.LblScheduleIdTip, "LblScheduleIdTip");
            this.LblScheduleIdTip.Name = "LblScheduleIdTip";
            // 
            // CmbBannerType
            // 
            resources.ApplyResources(this.CmbBannerType, "CmbBannerType");
            this.CmbBannerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBannerType.FormattingEnabled = true;
            this.CmbBannerType.Items.AddRange(new object[] {
            resources.GetString("CmbBannerType.Items"),
            resources.GetString("CmbBannerType.Items1"),
            resources.GetString("CmbBannerType.Items2")});
            this.CmbBannerType.Name = "CmbBannerType";
            // 
            // LblSortIdTip
            // 
            resources.ApplyResources(this.LblSortIdTip, "LblSortIdTip");
            this.LblSortIdTip.Name = "LblSortIdTip";
            // 
            // LblBannerType
            // 
            resources.ApplyResources(this.LblBannerType, "LblBannerType");
            this.LblBannerType.Name = "LblBannerType";
            // 
            // RbCostItem224
            // 
            resources.ApplyResources(this.RbCostItem224, "RbCostItem224");
            this.RbCostItem224.Checked = true;
            this.RbCostItem224.Name = "RbCostItem224";
            this.RbCostItem224.TabStop = true;
            this.RbCostItem224.UseVisualStyleBackColor = true;
            // 
            // LblCostItem
            // 
            resources.ApplyResources(this.LblCostItem, "LblCostItem");
            this.LblCostItem.Name = "LblCostItem";
            // 
            // LblPrefabPath
            // 
            resources.ApplyResources(this.LblPrefabPath, "LblPrefabPath");
            this.LblPrefabPath.Name = "LblPrefabPath";
            // 
            // RbCostItem223
            // 
            resources.ApplyResources(this.RbCostItem223, "RbCostItem223");
            this.RbCostItem223.Name = "RbCostItem223";
            this.RbCostItem223.TabStop = true;
            this.RbCostItem223.UseVisualStyleBackColor = true;
            // 
            // GrpFallbackPool
            // 
            resources.ApplyResources(this.GrpFallbackPool, "GrpFallbackPool");
            this.GrpFallbackPool.Controls.Add(this.ListFallbackItems);
            this.GrpFallbackPool.Name = "GrpFallbackPool";
            this.GrpFallbackPool.TabStop = false;
            // 
            // ListFallbackItems
            // 
            resources.ApplyResources(this.ListFallbackItems, "ListFallbackItems");
            this.ListFallbackItems.CheckBoxes = true;
            this.ListFallbackItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColFallbackId,
            this.ColFallbackName});
            this.ListFallbackItems.FullRowSelect = true;
            this.ListFallbackItems.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("ListFallbackItems.Groups"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("ListFallbackItems.Groups1"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("ListFallbackItems.Groups2"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("ListFallbackItems.Groups3"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("ListFallbackItems.Groups4"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("ListFallbackItems.Groups5")))});
            this.ListFallbackItems.HideSelection = false;
            this.ListFallbackItems.Name = "ListFallbackItems";
            this.ListFallbackItems.UseCompatibleStateImageBehavior = false;
            this.ListFallbackItems.View = System.Windows.Forms.View.Details;
            // 
            // ColFallbackId
            // 
            resources.ApplyResources(this.ColFallbackId, "ColFallbackId");
            // 
            // ColFallbackName
            // 
            resources.ApplyResources(this.ColFallbackName, "ColFallbackName");
            // 
            // GrpUpPool
            // 
            resources.ApplyResources(this.GrpUpPool, "GrpUpPool");
            this.GrpUpPool.Controls.Add(this.ListUpItems);
            this.GrpUpPool.Name = "GrpUpPool";
            this.GrpUpPool.TabStop = false;
            // 
            // ListUpItems
            // 
            resources.ApplyResources(this.ListUpItems, "ListUpItems");
            this.ListUpItems.CheckBoxes = true;
            this.ListUpItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColUpId,
            this.ColUpName});
            this.ListUpItems.FullRowSelect = true;
            this.ListUpItems.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("ListUpItems.Groups"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("ListUpItems.Groups1"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("ListUpItems.Groups2"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("ListUpItems.Groups3")))});
            this.ListUpItems.HideSelection = false;
            this.ListUpItems.Name = "ListUpItems";
            this.ListUpItems.UseCompatibleStateImageBehavior = false;
            this.ListUpItems.View = System.Windows.Forms.View.Details;
            // 
            // ColUpId
            // 
            resources.ApplyResources(this.ColUpId, "ColUpId");
            // 
            // ColUpName
            // 
            resources.ApplyResources(this.ColUpName, "ColUpName");
            // 
            // GrpJson
            // 
            resources.ApplyResources(this.GrpJson, "GrpJson");
            this.GrpJson.Controls.Add(this.BtnGen);
            this.GrpJson.Controls.Add(this.TxtJson);
            this.GrpJson.Controls.Add(this.BtnParse);
            this.GrpJson.Name = "GrpJson";
            this.GrpJson.TabStop = false;
            // 
            // BtnGen
            // 
            resources.ApplyResources(this.BtnGen, "BtnGen");
            this.BtnGen.Name = "BtnGen";
            this.BtnGen.UseVisualStyleBackColor = true;
            this.BtnGen.Click += new System.EventHandler(this.BtnGen_Click);
            // 
            // TxtJson
            // 
            resources.ApplyResources(this.TxtJson, "TxtJson");
            this.TxtJson.Name = "TxtJson";
            // 
            // BtnParse
            // 
            resources.ApplyResources(this.BtnParse, "BtnParse");
            this.BtnParse.Name = "BtnParse";
            this.BtnParse.UseVisualStyleBackColor = true;
            this.BtnParse.Click += new System.EventHandler(this.BtnParse_Click);
            // 
            // GrpWeights
            // 
            resources.ApplyResources(this.GrpWeights, "GrpWeights");
            this.GrpWeights.Controls.Add(this.LnkWeightHelp);
            this.GrpWeights.Controls.Add(this.TxtWeight4);
            this.GrpWeights.Controls.Add(this.TxtWeight5);
            this.GrpWeights.Controls.Add(this.LblWeight4);
            this.GrpWeights.Controls.Add(this.LblWeight5);
            this.GrpWeights.Name = "GrpWeights";
            this.GrpWeights.TabStop = false;
            // 
            // LnkWeightHelp
            // 
            resources.ApplyResources(this.LnkWeightHelp, "LnkWeightHelp");
            this.LnkWeightHelp.Name = "LnkWeightHelp";
            this.LnkWeightHelp.TabStop = true;
            this.LnkWeightHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkWeightHelp_LinkClicked);
            // 
            // TxtWeight4
            // 
            resources.ApplyResources(this.TxtWeight4, "TxtWeight4");
            this.TxtWeight4.Name = "TxtWeight4";
            // 
            // TxtWeight5
            // 
            resources.ApplyResources(this.TxtWeight5, "TxtWeight5");
            this.TxtWeight5.Name = "TxtWeight5";
            // 
            // LblWeight4
            // 
            resources.ApplyResources(this.LblWeight4, "LblWeight4");
            this.LblWeight4.Name = "LblWeight4";
            // 
            // LblWeight5
            // 
            resources.ApplyResources(this.LblWeight5, "LblWeight5");
            this.LblWeight5.Name = "LblWeight5";
            // 
            // GrpBalance
            // 
            resources.ApplyResources(this.GrpBalance, "GrpBalance");
            this.GrpBalance.Controls.Add(this.TxtPoolWeight4);
            this.GrpBalance.Controls.Add(this.TxtPoolWeight5);
            this.GrpBalance.Controls.Add(this.LblPoolWeight4);
            this.GrpBalance.Controls.Add(this.LblPoolWeight5);
            this.GrpBalance.Name = "GrpBalance";
            this.GrpBalance.TabStop = false;
            // 
            // TxtPoolWeight4
            // 
            resources.ApplyResources(this.TxtPoolWeight4, "TxtPoolWeight4");
            this.TxtPoolWeight4.Name = "TxtPoolWeight4";
            // 
            // TxtPoolWeight5
            // 
            resources.ApplyResources(this.TxtPoolWeight5, "TxtPoolWeight5");
            this.TxtPoolWeight5.Name = "TxtPoolWeight5";
            // 
            // LblPoolWeight4
            // 
            resources.ApplyResources(this.LblPoolWeight4, "LblPoolWeight4");
            this.LblPoolWeight4.Name = "LblPoolWeight4";
            // 
            // LblPoolWeight5
            // 
            resources.ApplyResources(this.LblPoolWeight5, "LblPoolWeight5");
            this.LblPoolWeight5.Name = "LblPoolWeight5";
            // 
            // FormGachaBannerEditor2
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GrpBalance);
            this.Controls.Add(this.GrpWeights);
            this.Controls.Add(this.GrpJson);
            this.Controls.Add(this.GrpFallbackPool);
            this.Controls.Add(this.GrpUpPool);
            this.Controls.Add(this.GrpBannerValues);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormGachaBannerEditor2";
            this.GrpBannerValues.ResumeLayout(false);
            this.GrpBannerValues.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDEventChance4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDEventChance5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDGachaType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDSortId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDScheduleId)).EndInit();
            this.GrpFallbackPool.ResumeLayout(false);
            this.GrpUpPool.ResumeLayout(false);
            this.GrpJson.ResumeLayout(false);
            this.GrpJson.PerformLayout();
            this.GrpWeights.ResumeLayout(false);
            this.GrpWeights.PerformLayout();
            this.GrpBalance.ResumeLayout(false);
            this.GrpBalance.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox GrpBannerValues;
        private System.Windows.Forms.Label LblEventChance5Tip;
        private System.Windows.Forms.NumericUpDown NUDEventChance5;
        private System.Windows.Forms.Label LblGachaType;
        private System.Windows.Forms.Label LblEventChance5;
        private System.Windows.Forms.Label LblSortId;
        private System.Windows.Forms.NumericUpDown NUDGachaType;
        private System.Windows.Forms.NumericUpDown NUDSortId;
        private System.Windows.Forms.Label LblGachaTypeTip;
        private System.Windows.Forms.Label LblEndTime;
        private System.Windows.Forms.Label LblScheduleId;
        private System.Windows.Forms.Label LblBeginTime;
        private System.Windows.Forms.NumericUpDown NUDScheduleId;
        private System.Windows.Forms.Label LblScheduleIdTip;
        private System.Windows.Forms.ComboBox CmbBannerType;
        private System.Windows.Forms.Label LblSortIdTip;
        private System.Windows.Forms.Label LblBannerType;
        private System.Windows.Forms.RadioButton RbCostItem224;
        private System.Windows.Forms.Label LblCostItem;
        private System.Windows.Forms.Label LblPrefabPath;
        private System.Windows.Forms.RadioButton RbCostItem223;
        private System.Windows.Forms.GroupBox GrpFallbackPool;
        private System.Windows.Forms.GroupBox GrpUpPool;
        private System.Windows.Forms.GroupBox GrpJson;
        private System.Windows.Forms.TextBox TxtJson;
        private System.Windows.Forms.Button BtnGen;
        private System.Windows.Forms.Button BtnParse;
        private System.Windows.Forms.ComboBox CmbPrefab;
        private System.Windows.Forms.Label LblEventChance4;
        private System.Windows.Forms.Label LblEventChance4Tip;
        private System.Windows.Forms.NumericUpDown NUDEventChance4;
        private System.Windows.Forms.DateTimePicker DTPEndTime;
        private System.Windows.Forms.DateTimePicker DTPBeginTime;
        private System.Windows.Forms.ListView ListFallbackItems;
        private System.Windows.Forms.ListView ListUpItems;
        private System.Windows.Forms.ColumnHeader ColFallbackId;
        private System.Windows.Forms.ColumnHeader ColFallbackName;
        private System.Windows.Forms.ColumnHeader ColUpId;
        private System.Windows.Forms.ColumnHeader ColUpName;
        private System.Windows.Forms.GroupBox GrpWeights;
        private System.Windows.Forms.GroupBox GrpBalance;
        private System.Windows.Forms.TextBox TxtWeight4;
        private System.Windows.Forms.TextBox TxtWeight5;
        private System.Windows.Forms.Label LblWeight4;
        private System.Windows.Forms.Label LblWeight5;
        private System.Windows.Forms.LinkLabel LnkWeightHelp;
        private System.Windows.Forms.LinkLabel LnkOpenOldEditor;
        private System.Windows.Forms.TextBox TxtPoolWeight4;
        private System.Windows.Forms.TextBox TxtPoolWeight5;
        private System.Windows.Forms.Label LblPoolWeight4;
        private System.Windows.Forms.Label LblPoolWeight5;
        private System.Windows.Forms.CheckBox ChkRemoveC6FormPool;
        private System.Windows.Forms.CheckBox ChkAutoStripRateUpFromFallback;
        private System.Windows.Forms.Label LblOptions;
    }
}