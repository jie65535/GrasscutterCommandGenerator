namespace GrasscutterTools.Forms
{
    partial class FormShopEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormShopEditor));
            this.ListShop = new System.Windows.Forms.ListBox();
            this.ListGoods = new System.Windows.Forms.ListBox();
            this.ListItems = new System.Windows.Forms.ListBox();
            this.GrpShopList = new System.Windows.Forms.GroupBox();
            this.GrpGoodsList = new System.Windows.Forms.GroupBox();
            this.BtnClearGoods = new System.Windows.Forms.Button();
            this.BtnDeleteGoods = new System.Windows.Forms.Button();
            this.GrpItems = new System.Windows.Forms.GroupBox();
            this.LblClearItemFilter = new System.Windows.Forms.Label();
            this.TxtItemFilter = new System.Windows.Forms.TextBox();
            this.GrpGoodsInfo = new System.Windows.Forms.GroupBox();
            this.BtnSaveGoods = new System.Windows.Forms.Button();
            this.CmbRefreshType = new System.Windows.Forms.ComboBox();
            this.NUDRefreshParm = new System.Windows.Forms.NumericUpDown();
            this.DTPEndTime = new System.Windows.Forms.DateTimePicker();
            this.DTPBeginTime = new System.Windows.Forms.DateTimePicker();
            this.NUDGoodsId = new System.Windows.Forms.NumericUpDown();
            this.NUDMaxLevel = new System.Windows.Forms.NumericUpDown();
            this.NUDMinLevel = new System.Windows.Forms.NumericUpDown();
            this.NUDCostItem4 = new System.Windows.Forms.NumericUpDown();
            this.NUDCostItem3 = new System.Windows.Forms.NumericUpDown();
            this.NUDCostItem2 = new System.Windows.Forms.NumericUpDown();
            this.NUDCostItem1 = new System.Windows.Forms.NumericUpDown();
            this.NUDCostMcoin = new System.Windows.Forms.NumericUpDown();
            this.NUDCostScoin = new System.Windows.Forms.NumericUpDown();
            this.NUDCostHcoin = new System.Windows.Forms.NumericUpDown();
            this.NUDBuyLimit = new System.Windows.Forms.NumericUpDown();
            this.NUDCostItem4Count = new System.Windows.Forms.NumericUpDown();
            this.NUDCostItem3Count = new System.Windows.Forms.NumericUpDown();
            this.NUDCostItem2Count = new System.Windows.Forms.NumericUpDown();
            this.NUDCostItem1Count = new System.Windows.Forms.NumericUpDown();
            this.NUDGoodsItemCount = new System.Windows.Forms.NumericUpDown();
            this.TxtGoodsItem = new System.Windows.Forms.TextBox();
            this.LblRefreshModeLabel = new System.Windows.Forms.Label();
            this.LblBuyLevelLabel = new System.Windows.Forms.Label();
            this.LblEndTimeLabel = new System.Windows.Forms.Label();
            this.LblBeginTimeLabel = new System.Windows.Forms.Label();
            this.LblCostItem4Label = new System.Windows.Forms.Label();
            this.LblCostItem3Label = new System.Windows.Forms.Label();
            this.LblCostItem2Label = new System.Windows.Forms.Label();
            this.LblCostItem1Label = new System.Windows.Forms.Label();
            this.LblCostMcoinLabel = new System.Windows.Forms.Label();
            this.LblCostScoinLabel = new System.Windows.Forms.Label();
            this.LblCostHcoinLabel = new System.Windows.Forms.Label();
            this.LblBuyLimitLabel = new System.Windows.Forms.Label();
            this.LblGoodsIdLabel = new System.Windows.Forms.Label();
            this.LblGoodsItemLabel = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.LnkGenGoodsId = new System.Windows.Forms.LinkLabel();
            this.label18 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnLoad = new System.Windows.Forms.Button();
            this.TxtShopJsonPath = new System.Windows.Forms.TextBox();
            this.LblShopPathLabel = new System.Windows.Forms.Label();
            this.GrpShopList.SuspendLayout();
            this.GrpGoodsList.SuspendLayout();
            this.GrpItems.SuspendLayout();
            this.GrpGoodsInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDRefreshParm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDGoodsId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDMaxLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDMinLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDCostItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDCostItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDCostItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDCostItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDCostMcoin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDCostScoin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDCostHcoin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDBuyLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDCostItem4Count)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDCostItem3Count)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDCostItem2Count)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDCostItem1Count)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDGoodsItemCount)).BeginInit();
            this.SuspendLayout();
            // 
            // ListShop
            // 
            resources.ApplyResources(this.ListShop, "ListShop");
            this.ListShop.FormattingEnabled = true;
            this.ListShop.Name = "ListShop";
            this.ListShop.SelectedIndexChanged += new System.EventHandler(this.ListShop_SelectedIndexChanged);
            // 
            // ListGoods
            // 
            resources.ApplyResources(this.ListGoods, "ListGoods");
            this.ListGoods.FormattingEnabled = true;
            this.ListGoods.Name = "ListGoods";
            this.ListGoods.SelectedIndexChanged += new System.EventHandler(this.ListGoods_SelectedIndexChanged);
            // 
            // ListItems
            // 
            resources.ApplyResources(this.ListItems, "ListItems");
            this.ListItems.FormattingEnabled = true;
            this.ListItems.Name = "ListItems";
            this.ListItems.SelectedIndexChanged += new System.EventHandler(this.ListItems_SelectedIndexChanged);
            // 
            // GrpShopList
            // 
            this.GrpShopList.Controls.Add(this.ListShop);
            resources.ApplyResources(this.GrpShopList, "GrpShopList");
            this.GrpShopList.Name = "GrpShopList";
            this.GrpShopList.TabStop = false;
            // 
            // GrpGoodsList
            // 
            resources.ApplyResources(this.GrpGoodsList, "GrpGoodsList");
            this.GrpGoodsList.Controls.Add(this.BtnClearGoods);
            this.GrpGoodsList.Controls.Add(this.BtnDeleteGoods);
            this.GrpGoodsList.Controls.Add(this.ListGoods);
            this.GrpGoodsList.Name = "GrpGoodsList";
            this.GrpGoodsList.TabStop = false;
            // 
            // BtnClearGoods
            // 
            resources.ApplyResources(this.BtnClearGoods, "BtnClearGoods");
            this.BtnClearGoods.Name = "BtnClearGoods";
            this.BtnClearGoods.UseVisualStyleBackColor = true;
            this.BtnClearGoods.Click += new System.EventHandler(this.BtnClearGoods_Click);
            // 
            // BtnDeleteGoods
            // 
            resources.ApplyResources(this.BtnDeleteGoods, "BtnDeleteGoods");
            this.BtnDeleteGoods.Name = "BtnDeleteGoods";
            this.BtnDeleteGoods.UseVisualStyleBackColor = true;
            this.BtnDeleteGoods.Click += new System.EventHandler(this.BtnDeleteGoods_Click);
            // 
            // GrpItems
            // 
            resources.ApplyResources(this.GrpItems, "GrpItems");
            this.GrpItems.Controls.Add(this.LblClearItemFilter);
            this.GrpItems.Controls.Add(this.TxtItemFilter);
            this.GrpItems.Controls.Add(this.ListItems);
            this.GrpItems.Name = "GrpItems";
            this.GrpItems.TabStop = false;
            // 
            // LblClearItemFilter
            // 
            resources.ApplyResources(this.LblClearItemFilter, "LblClearItemFilter");
            this.LblClearItemFilter.BackColor = System.Drawing.Color.White;
            this.LblClearItemFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblClearItemFilter.Name = "LblClearItemFilter";
            this.LblClearItemFilter.Click += new System.EventHandler(this.LblClearItemFilter_Click);
            // 
            // TxtItemFilter
            // 
            resources.ApplyResources(this.TxtItemFilter, "TxtItemFilter");
            this.TxtItemFilter.Name = "TxtItemFilter";
            this.TxtItemFilter.TextChanged += new System.EventHandler(this.TxtItemFilter_TextChanged);
            // 
            // GrpGoodsInfo
            // 
            resources.ApplyResources(this.GrpGoodsInfo, "GrpGoodsInfo");
            this.GrpGoodsInfo.Controls.Add(this.BtnSaveGoods);
            this.GrpGoodsInfo.Controls.Add(this.CmbRefreshType);
            this.GrpGoodsInfo.Controls.Add(this.NUDRefreshParm);
            this.GrpGoodsInfo.Controls.Add(this.DTPEndTime);
            this.GrpGoodsInfo.Controls.Add(this.DTPBeginTime);
            this.GrpGoodsInfo.Controls.Add(this.NUDGoodsId);
            this.GrpGoodsInfo.Controls.Add(this.NUDMaxLevel);
            this.GrpGoodsInfo.Controls.Add(this.NUDMinLevel);
            this.GrpGoodsInfo.Controls.Add(this.NUDCostItem4);
            this.GrpGoodsInfo.Controls.Add(this.NUDCostItem3);
            this.GrpGoodsInfo.Controls.Add(this.NUDCostItem2);
            this.GrpGoodsInfo.Controls.Add(this.NUDCostItem1);
            this.GrpGoodsInfo.Controls.Add(this.NUDCostMcoin);
            this.GrpGoodsInfo.Controls.Add(this.NUDCostScoin);
            this.GrpGoodsInfo.Controls.Add(this.NUDCostHcoin);
            this.GrpGoodsInfo.Controls.Add(this.NUDBuyLimit);
            this.GrpGoodsInfo.Controls.Add(this.NUDCostItem4Count);
            this.GrpGoodsInfo.Controls.Add(this.NUDCostItem3Count);
            this.GrpGoodsInfo.Controls.Add(this.NUDCostItem2Count);
            this.GrpGoodsInfo.Controls.Add(this.NUDCostItem1Count);
            this.GrpGoodsInfo.Controls.Add(this.NUDGoodsItemCount);
            this.GrpGoodsInfo.Controls.Add(this.TxtGoodsItem);
            this.GrpGoodsInfo.Controls.Add(this.LblRefreshModeLabel);
            this.GrpGoodsInfo.Controls.Add(this.LblBuyLevelLabel);
            this.GrpGoodsInfo.Controls.Add(this.LblEndTimeLabel);
            this.GrpGoodsInfo.Controls.Add(this.LblBeginTimeLabel);
            this.GrpGoodsInfo.Controls.Add(this.LblCostItem4Label);
            this.GrpGoodsInfo.Controls.Add(this.LblCostItem3Label);
            this.GrpGoodsInfo.Controls.Add(this.LblCostItem2Label);
            this.GrpGoodsInfo.Controls.Add(this.LblCostItem1Label);
            this.GrpGoodsInfo.Controls.Add(this.LblCostMcoinLabel);
            this.GrpGoodsInfo.Controls.Add(this.LblCostScoinLabel);
            this.GrpGoodsInfo.Controls.Add(this.LblCostHcoinLabel);
            this.GrpGoodsInfo.Controls.Add(this.LblBuyLimitLabel);
            this.GrpGoodsInfo.Controls.Add(this.LblGoodsIdLabel);
            this.GrpGoodsInfo.Controls.Add(this.LblGoodsItemLabel);
            this.GrpGoodsInfo.Controls.Add(this.label13);
            this.GrpGoodsInfo.Controls.Add(this.label12);
            this.GrpGoodsInfo.Controls.Add(this.label11);
            this.GrpGoodsInfo.Controls.Add(this.label14);
            this.GrpGoodsInfo.Controls.Add(this.LnkGenGoodsId);
            this.GrpGoodsInfo.Controls.Add(this.label18);
            this.GrpGoodsInfo.Controls.Add(this.label1);
            this.GrpGoodsInfo.Name = "GrpGoodsInfo";
            this.GrpGoodsInfo.TabStop = false;
            // 
            // BtnSaveGoods
            // 
            resources.ApplyResources(this.BtnSaveGoods, "BtnSaveGoods");
            this.BtnSaveGoods.Name = "BtnSaveGoods";
            this.BtnSaveGoods.UseVisualStyleBackColor = true;
            this.BtnSaveGoods.Click += new System.EventHandler(this.BtnSaveGoods_Click);
            // 
            // CmbRefreshType
            // 
            resources.ApplyResources(this.CmbRefreshType, "CmbRefreshType");
            this.CmbRefreshType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbRefreshType.FormattingEnabled = true;
            this.CmbRefreshType.Items.AddRange(new object[] {
            resources.GetString("CmbRefreshType.Items"),
            resources.GetString("CmbRefreshType.Items1"),
            resources.GetString("CmbRefreshType.Items2"),
            resources.GetString("CmbRefreshType.Items3")});
            this.CmbRefreshType.Name = "CmbRefreshType";
            this.CmbRefreshType.SelectedIndexChanged += new System.EventHandler(this.CmbRefreshType_SelectedIndexChanged);
            // 
            // NUDRefreshParm
            // 
            resources.ApplyResources(this.NUDRefreshParm, "NUDRefreshParm");
            this.NUDRefreshParm.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NUDRefreshParm.Name = "NUDRefreshParm";
            // 
            // DTPEndTime
            // 
            resources.ApplyResources(this.DTPEndTime, "DTPEndTime");
            this.DTPEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPEndTime.Name = "DTPEndTime";
            this.DTPEndTime.Value = new System.DateTime(2035, 1, 1, 0, 0, 0, 0);
            // 
            // DTPBeginTime
            // 
            resources.ApplyResources(this.DTPBeginTime, "DTPBeginTime");
            this.DTPBeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPBeginTime.Name = "DTPBeginTime";
            this.DTPBeginTime.Value = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            // 
            // NUDGoodsId
            // 
            resources.ApplyResources(this.NUDGoodsId, "NUDGoodsId");
            this.NUDGoodsId.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDGoodsId.Name = "NUDGoodsId";
            this.NUDGoodsId.Value = new decimal(new int[] {
            101001,
            0,
            0,
            0});
            // 
            // NUDMaxLevel
            // 
            resources.ApplyResources(this.NUDMaxLevel, "NUDMaxLevel");
            this.NUDMaxLevel.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.NUDMaxLevel.Name = "NUDMaxLevel";
            this.NUDMaxLevel.Value = new decimal(new int[] {
            61,
            0,
            0,
            0});
            // 
            // NUDMinLevel
            // 
            resources.ApplyResources(this.NUDMinLevel, "NUDMinLevel");
            this.NUDMinLevel.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.NUDMinLevel.Name = "NUDMinLevel";
            this.NUDMinLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NUDCostItem4
            // 
            resources.ApplyResources(this.NUDCostItem4, "NUDCostItem4");
            this.NUDCostItem4.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDCostItem4.Name = "NUDCostItem4";
            // 
            // NUDCostItem3
            // 
            resources.ApplyResources(this.NUDCostItem3, "NUDCostItem3");
            this.NUDCostItem3.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDCostItem3.Name = "NUDCostItem3";
            // 
            // NUDCostItem2
            // 
            resources.ApplyResources(this.NUDCostItem2, "NUDCostItem2");
            this.NUDCostItem2.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDCostItem2.Name = "NUDCostItem2";
            // 
            // NUDCostItem1
            // 
            resources.ApplyResources(this.NUDCostItem1, "NUDCostItem1");
            this.NUDCostItem1.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDCostItem1.Name = "NUDCostItem1";
            // 
            // NUDCostMcoin
            // 
            resources.ApplyResources(this.NUDCostMcoin, "NUDCostMcoin");
            this.NUDCostMcoin.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDCostMcoin.Name = "NUDCostMcoin";
            // 
            // NUDCostScoin
            // 
            resources.ApplyResources(this.NUDCostScoin, "NUDCostScoin");
            this.NUDCostScoin.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDCostScoin.Name = "NUDCostScoin";
            // 
            // NUDCostHcoin
            // 
            resources.ApplyResources(this.NUDCostHcoin, "NUDCostHcoin");
            this.NUDCostHcoin.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDCostHcoin.Name = "NUDCostHcoin";
            // 
            // NUDBuyLimit
            // 
            resources.ApplyResources(this.NUDBuyLimit, "NUDBuyLimit");
            this.NUDBuyLimit.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDBuyLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDBuyLimit.Name = "NUDBuyLimit";
            this.NUDBuyLimit.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // NUDCostItem4Count
            // 
            resources.ApplyResources(this.NUDCostItem4Count, "NUDCostItem4Count");
            this.NUDCostItem4Count.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDCostItem4Count.Name = "NUDCostItem4Count";
            // 
            // NUDCostItem3Count
            // 
            resources.ApplyResources(this.NUDCostItem3Count, "NUDCostItem3Count");
            this.NUDCostItem3Count.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDCostItem3Count.Name = "NUDCostItem3Count";
            // 
            // NUDCostItem2Count
            // 
            resources.ApplyResources(this.NUDCostItem2Count, "NUDCostItem2Count");
            this.NUDCostItem2Count.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDCostItem2Count.Name = "NUDCostItem2Count";
            // 
            // NUDCostItem1Count
            // 
            resources.ApplyResources(this.NUDCostItem1Count, "NUDCostItem1Count");
            this.NUDCostItem1Count.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDCostItem1Count.Name = "NUDCostItem1Count";
            // 
            // NUDGoodsItemCount
            // 
            resources.ApplyResources(this.NUDGoodsItemCount, "NUDGoodsItemCount");
            this.NUDGoodsItemCount.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDGoodsItemCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDGoodsItemCount.Name = "NUDGoodsItemCount";
            this.NUDGoodsItemCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // TxtGoodsItem
            // 
            resources.ApplyResources(this.TxtGoodsItem, "TxtGoodsItem");
            this.TxtGoodsItem.Name = "TxtGoodsItem";
            // 
            // LblRefreshModeLabel
            // 
            resources.ApplyResources(this.LblRefreshModeLabel, "LblRefreshModeLabel");
            this.LblRefreshModeLabel.Name = "LblRefreshModeLabel";
            // 
            // LblBuyLevelLabel
            // 
            resources.ApplyResources(this.LblBuyLevelLabel, "LblBuyLevelLabel");
            this.LblBuyLevelLabel.Name = "LblBuyLevelLabel";
            // 
            // LblEndTimeLabel
            // 
            resources.ApplyResources(this.LblEndTimeLabel, "LblEndTimeLabel");
            this.LblEndTimeLabel.Name = "LblEndTimeLabel";
            // 
            // LblBeginTimeLabel
            // 
            resources.ApplyResources(this.LblBeginTimeLabel, "LblBeginTimeLabel");
            this.LblBeginTimeLabel.Name = "LblBeginTimeLabel";
            // 
            // LblCostItem4Label
            // 
            resources.ApplyResources(this.LblCostItem4Label, "LblCostItem4Label");
            this.LblCostItem4Label.Name = "LblCostItem4Label";
            // 
            // LblCostItem3Label
            // 
            resources.ApplyResources(this.LblCostItem3Label, "LblCostItem3Label");
            this.LblCostItem3Label.Name = "LblCostItem3Label";
            // 
            // LblCostItem2Label
            // 
            resources.ApplyResources(this.LblCostItem2Label, "LblCostItem2Label");
            this.LblCostItem2Label.Name = "LblCostItem2Label";
            // 
            // LblCostItem1Label
            // 
            resources.ApplyResources(this.LblCostItem1Label, "LblCostItem1Label");
            this.LblCostItem1Label.Name = "LblCostItem1Label";
            // 
            // LblCostMcoinLabel
            // 
            resources.ApplyResources(this.LblCostMcoinLabel, "LblCostMcoinLabel");
            this.LblCostMcoinLabel.Name = "LblCostMcoinLabel";
            // 
            // LblCostScoinLabel
            // 
            resources.ApplyResources(this.LblCostScoinLabel, "LblCostScoinLabel");
            this.LblCostScoinLabel.Name = "LblCostScoinLabel";
            // 
            // LblCostHcoinLabel
            // 
            resources.ApplyResources(this.LblCostHcoinLabel, "LblCostHcoinLabel");
            this.LblCostHcoinLabel.Name = "LblCostHcoinLabel";
            // 
            // LblBuyLimitLabel
            // 
            resources.ApplyResources(this.LblBuyLimitLabel, "LblBuyLimitLabel");
            this.LblBuyLimitLabel.Name = "LblBuyLimitLabel";
            // 
            // LblGoodsIdLabel
            // 
            resources.ApplyResources(this.LblGoodsIdLabel, "LblGoodsIdLabel");
            this.LblGoodsIdLabel.Name = "LblGoodsIdLabel";
            // 
            // LblGoodsItemLabel
            // 
            resources.ApplyResources(this.LblGoodsItemLabel, "LblGoodsItemLabel");
            this.LblGoodsItemLabel.Name = "LblGoodsItemLabel";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // LnkGenGoodsId
            // 
            resources.ApplyResources(this.LnkGenGoodsId, "LnkGenGoodsId");
            this.LnkGenGoodsId.Name = "LnkGenGoodsId";
            this.LnkGenGoodsId.TabStop = true;
            this.LnkGenGoodsId.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkGenGoodsId_LinkClicked);
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // BtnSave
            // 
            resources.ApplyResources(this.BtnSave, "BtnSave");
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnLoad
            // 
            resources.ApplyResources(this.BtnLoad, "BtnLoad");
            this.BtnLoad.Name = "BtnLoad";
            this.BtnLoad.UseVisualStyleBackColor = true;
            this.BtnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // TxtShopJsonPath
            // 
            resources.ApplyResources(this.TxtShopJsonPath, "TxtShopJsonPath");
            this.TxtShopJsonPath.Name = "TxtShopJsonPath";
            // 
            // LblShopPathLabel
            // 
            resources.ApplyResources(this.LblShopPathLabel, "LblShopPathLabel");
            this.LblShopPathLabel.Name = "LblShopPathLabel";
            // 
            // FormShopEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnLoad);
            this.Controls.Add(this.TxtShopJsonPath);
            this.Controls.Add(this.LblShopPathLabel);
            this.Controls.Add(this.GrpGoodsInfo);
            this.Controls.Add(this.GrpItems);
            this.Controls.Add(this.GrpGoodsList);
            this.Controls.Add(this.GrpShopList);
            this.Name = "FormShopEditor";
            this.GrpShopList.ResumeLayout(false);
            this.GrpGoodsList.ResumeLayout(false);
            this.GrpItems.ResumeLayout(false);
            this.GrpItems.PerformLayout();
            this.GrpGoodsInfo.ResumeLayout(false);
            this.GrpGoodsInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDRefreshParm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDGoodsId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDMaxLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDMinLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDCostItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDCostItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDCostItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDCostItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDCostMcoin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDCostScoin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDCostHcoin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDBuyLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDCostItem4Count)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDCostItem3Count)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDCostItem2Count)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDCostItem1Count)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDGoodsItemCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListShop;
        private System.Windows.Forms.ListBox ListGoods;
        private System.Windows.Forms.ListBox ListItems;
        private System.Windows.Forms.GroupBox GrpShopList;
        private System.Windows.Forms.GroupBox GrpGoodsList;
        private System.Windows.Forms.GroupBox GrpItems;
        private System.Windows.Forms.GroupBox GrpGoodsInfo;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnLoad;
        private System.Windows.Forms.TextBox TxtShopJsonPath;
        private System.Windows.Forms.Label LblShopPathLabel;
        private System.Windows.Forms.NumericUpDown NUDGoodsItemCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtGoodsItem;
        private System.Windows.Forms.Label LblGoodsItemLabel;
        private System.Windows.Forms.NumericUpDown NUDCostItem3;
        private System.Windows.Forms.NumericUpDown NUDCostItem2;
        private System.Windows.Forms.NumericUpDown NUDCostItem1;
        private System.Windows.Forms.NumericUpDown NUDCostMcoin;
        private System.Windows.Forms.NumericUpDown NUDCostScoin;
        private System.Windows.Forms.NumericUpDown NUDCostHcoin;
        private System.Windows.Forms.NumericUpDown NUDBuyLimit;
        private System.Windows.Forms.NumericUpDown NUDMaxLevel;
        private System.Windows.Forms.NumericUpDown NUDMinLevel;
        private System.Windows.Forms.NumericUpDown NUDCostItem4;
        private System.Windows.Forms.Label LblGoodsIdLabel;
        private System.Windows.Forms.NumericUpDown NUDGoodsId;
        private System.Windows.Forms.Label LblBuyLimitLabel;
        private System.Windows.Forms.Label LblCostItem4Label;
        private System.Windows.Forms.Label LblCostItem3Label;
        private System.Windows.Forms.Label LblCostItem2Label;
        private System.Windows.Forms.Label LblCostItem1Label;
        private System.Windows.Forms.Label LblCostMcoinLabel;
        private System.Windows.Forms.Label LblCostScoinLabel;
        private System.Windows.Forms.Label LblCostHcoinLabel;
        private System.Windows.Forms.NumericUpDown NUDCostItem4Count;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown NUDCostItem3Count;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown NUDCostItem2Count;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown NUDCostItem1Count;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker DTPEndTime;
        private System.Windows.Forms.DateTimePicker DTPBeginTime;
        private System.Windows.Forms.Label LblEndTimeLabel;
        private System.Windows.Forms.Label LblBeginTimeLabel;
        private System.Windows.Forms.Label LblBuyLevelLabel;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.LinkLabel LnkGenGoodsId;
        private System.Windows.Forms.ComboBox CmbRefreshType;
        private System.Windows.Forms.NumericUpDown NUDRefreshParm;
        private System.Windows.Forms.Label LblRefreshModeLabel;
        private System.Windows.Forms.Button BtnSaveGoods;
        private System.Windows.Forms.TextBox TxtItemFilter;
        private System.Windows.Forms.Button BtnClearGoods;
        private System.Windows.Forms.Button BtnDeleteGoods;
        private System.Windows.Forms.Label LblClearItemFilter;
    }
}