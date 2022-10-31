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
            this.ListShop = new System.Windows.Forms.ListBox();
            this.ListGoods = new System.Windows.Forms.ListBox();
            this.ListItems = new System.Windows.Forms.ListBox();
            this.GrpShopList = new System.Windows.Forms.GroupBox();
            this.GrpGoodsList = new System.Windows.Forms.GroupBox();
            this.GrpItems = new System.Windows.Forms.GroupBox();
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
            this.TxtItemFilter = new System.Windows.Forms.TextBox();
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
            this.ListShop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListShop.FormattingEnabled = true;
            this.ListShop.ItemHeight = 17;
            this.ListShop.Location = new System.Drawing.Point(3, 19);
            this.ListShop.Name = "ListShop";
            this.ListShop.Size = new System.Drawing.Size(244, 169);
            this.ListShop.TabIndex = 0;
            this.ListShop.SelectedIndexChanged += new System.EventHandler(this.ListShop_SelectedIndexChanged);
            // 
            // ListGoods
            // 
            this.ListGoods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListGoods.FormattingEnabled = true;
            this.ListGoods.ItemHeight = 17;
            this.ListGoods.Location = new System.Drawing.Point(3, 19);
            this.ListGoods.Name = "ListGoods";
            this.ListGoods.Size = new System.Drawing.Size(244, 289);
            this.ListGoods.TabIndex = 1;
            this.ListGoods.SelectedIndexChanged += new System.EventHandler(this.ListGoods_SelectedIndexChanged);
            // 
            // ListItems
            // 
            this.ListItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListItems.FormattingEnabled = true;
            this.ListItems.ItemHeight = 17;
            this.ListItems.Location = new System.Drawing.Point(6, 51);
            this.ListItems.Name = "ListItems";
            this.ListItems.Size = new System.Drawing.Size(238, 446);
            this.ListItems.TabIndex = 2;
            this.ListItems.SelectedIndexChanged += new System.EventHandler(this.ListItems_SelectedIndexChanged);
            // 
            // GrpShopList
            // 
            this.GrpShopList.Controls.Add(this.ListShop);
            this.GrpShopList.Location = new System.Drawing.Point(12, 41);
            this.GrpShopList.Name = "GrpShopList";
            this.GrpShopList.Size = new System.Drawing.Size(250, 191);
            this.GrpShopList.TabIndex = 3;
            this.GrpShopList.TabStop = false;
            this.GrpShopList.Text = "商店列表";
            // 
            // GrpGoodsList
            // 
            this.GrpGoodsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.GrpGoodsList.Controls.Add(this.ListGoods);
            this.GrpGoodsList.Location = new System.Drawing.Point(12, 238);
            this.GrpGoodsList.Name = "GrpGoodsList";
            this.GrpGoodsList.Size = new System.Drawing.Size(250, 311);
            this.GrpGoodsList.TabIndex = 4;
            this.GrpGoodsList.TabStop = false;
            this.GrpGoodsList.Text = "商品列表";
            // 
            // GrpItems
            // 
            this.GrpItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpItems.Controls.Add(this.TxtItemFilter);
            this.GrpItems.Controls.Add(this.ListItems);
            this.GrpItems.Location = new System.Drawing.Point(622, 41);
            this.GrpItems.Name = "GrpItems";
            this.GrpItems.Size = new System.Drawing.Size(250, 508);
            this.GrpItems.TabIndex = 6;
            this.GrpItems.TabStop = false;
            this.GrpItems.Text = "物品列表";
            // 
            // GrpGoodsInfo
            // 
            this.GrpGoodsInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.GrpGoodsInfo.Location = new System.Drawing.Point(268, 41);
            this.GrpGoodsInfo.Name = "GrpGoodsInfo";
            this.GrpGoodsInfo.Size = new System.Drawing.Size(348, 508);
            this.GrpGoodsInfo.TabIndex = 5;
            this.GrpGoodsInfo.TabStop = false;
            this.GrpGoodsInfo.Text = "商品信息";
            // 
            // BtnSaveGoods
            // 
            this.BtnSaveGoods.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnSaveGoods.Location = new System.Drawing.Point(114, 472);
            this.BtnSaveGoods.Name = "BtnSaveGoods";
            this.BtnSaveGoods.Size = new System.Drawing.Size(120, 30);
            this.BtnSaveGoods.TabIndex = 30;
            this.BtnSaveGoods.Text = "√ 保存";
            this.BtnSaveGoods.UseVisualStyleBackColor = true;
            this.BtnSaveGoods.Click += new System.EventHandler(this.BtnSaveGoods_Click);
            // 
            // CmbRefreshType
            // 
            this.CmbRefreshType.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CmbRefreshType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbRefreshType.FormattingEnabled = true;
            this.CmbRefreshType.Items.AddRange(new object[] {
            "无",
            "天",
            "周",
            "月"});
            this.CmbRefreshType.Location = new System.Drawing.Point(175, 207);
            this.CmbRefreshType.Name = "CmbRefreshType";
            this.CmbRefreshType.Size = new System.Drawing.Size(104, 25);
            this.CmbRefreshType.TabIndex = 10;
            this.CmbRefreshType.SelectedIndexChanged += new System.EventHandler(this.CmbRefreshType_SelectedIndexChanged);
            // 
            // NUDRefreshParm
            // 
            this.NUDRefreshParm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NUDRefreshParm.Location = new System.Drawing.Point(119, 209);
            this.NUDRefreshParm.Name = "NUDRefreshParm";
            this.NUDRefreshParm.Size = new System.Drawing.Size(50, 23);
            this.NUDRefreshParm.TabIndex = 9;
            // 
            // DTPEndTime
            // 
            this.DTPEndTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DTPEndTime.CustomFormat = "yyyy\'/\'MM\'/\'dd HH\':\'mm\':\'ss";
            this.DTPEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPEndTime.Location = new System.Drawing.Point(119, 180);
            this.DTPEndTime.Name = "DTPEndTime";
            this.DTPEndTime.Size = new System.Drawing.Size(160, 23);
            this.DTPEndTime.TabIndex = 8;
            // 
            // DTPBeginTime
            // 
            this.DTPBeginTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DTPBeginTime.CustomFormat = "yyyy\'/\'MM\'/\'dd HH\':\'mm\':\'ss";
            this.DTPBeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPBeginTime.Location = new System.Drawing.Point(119, 151);
            this.DTPBeginTime.Name = "DTPBeginTime";
            this.DTPBeginTime.Size = new System.Drawing.Size(160, 23);
            this.DTPBeginTime.TabIndex = 7;
            // 
            // NUDGoodsId
            // 
            this.NUDGoodsId.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NUDGoodsId.Location = new System.Drawing.Point(119, 32);
            this.NUDGoodsId.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDGoodsId.Name = "NUDGoodsId";
            this.NUDGoodsId.Size = new System.Drawing.Size(120, 23);
            this.NUDGoodsId.TabIndex = 0;
            this.NUDGoodsId.Value = new decimal(new int[] {
            101001,
            0,
            0,
            0});
            // 
            // NUDMaxLevel
            // 
            this.NUDMaxLevel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NUDMaxLevel.Location = new System.Drawing.Point(198, 122);
            this.NUDMaxLevel.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.NUDMaxLevel.Name = "NUDMaxLevel";
            this.NUDMaxLevel.Size = new System.Drawing.Size(50, 23);
            this.NUDMaxLevel.TabIndex = 6;
            this.NUDMaxLevel.Value = new decimal(new int[] {
            61,
            0,
            0,
            0});
            // 
            // NUDMinLevel
            // 
            this.NUDMinLevel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NUDMinLevel.Location = new System.Drawing.Point(119, 122);
            this.NUDMinLevel.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.NUDMinLevel.Name = "NUDMinLevel";
            this.NUDMinLevel.Size = new System.Drawing.Size(50, 23);
            this.NUDMinLevel.TabIndex = 5;
            this.NUDMinLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NUDCostItem4
            // 
            this.NUDCostItem4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NUDCostItem4.Location = new System.Drawing.Point(119, 412);
            this.NUDCostItem4.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDCostItem4.Name = "NUDCostItem4";
            this.NUDCostItem4.Size = new System.Drawing.Size(80, 23);
            this.NUDCostItem4.TabIndex = 20;
            // 
            // NUDCostItem3
            // 
            this.NUDCostItem3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NUDCostItem3.Location = new System.Drawing.Point(119, 383);
            this.NUDCostItem3.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDCostItem3.Name = "NUDCostItem3";
            this.NUDCostItem3.Size = new System.Drawing.Size(80, 23);
            this.NUDCostItem3.TabIndex = 18;
            // 
            // NUDCostItem2
            // 
            this.NUDCostItem2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NUDCostItem2.Location = new System.Drawing.Point(119, 354);
            this.NUDCostItem2.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDCostItem2.Name = "NUDCostItem2";
            this.NUDCostItem2.Size = new System.Drawing.Size(80, 23);
            this.NUDCostItem2.TabIndex = 16;
            // 
            // NUDCostItem1
            // 
            this.NUDCostItem1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NUDCostItem1.Location = new System.Drawing.Point(119, 325);
            this.NUDCostItem1.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDCostItem1.Name = "NUDCostItem1";
            this.NUDCostItem1.Size = new System.Drawing.Size(80, 23);
            this.NUDCostItem1.TabIndex = 14;
            // 
            // NUDCostMcoin
            // 
            this.NUDCostMcoin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NUDCostMcoin.Location = new System.Drawing.Point(119, 296);
            this.NUDCostMcoin.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDCostMcoin.Name = "NUDCostMcoin";
            this.NUDCostMcoin.Size = new System.Drawing.Size(120, 23);
            this.NUDCostMcoin.TabIndex = 13;
            // 
            // NUDCostScoin
            // 
            this.NUDCostScoin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NUDCostScoin.Location = new System.Drawing.Point(119, 267);
            this.NUDCostScoin.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDCostScoin.Name = "NUDCostScoin";
            this.NUDCostScoin.Size = new System.Drawing.Size(120, 23);
            this.NUDCostScoin.TabIndex = 12;
            // 
            // NUDCostHcoin
            // 
            this.NUDCostHcoin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NUDCostHcoin.Location = new System.Drawing.Point(119, 238);
            this.NUDCostHcoin.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDCostHcoin.Name = "NUDCostHcoin";
            this.NUDCostHcoin.Size = new System.Drawing.Size(120, 23);
            this.NUDCostHcoin.TabIndex = 11;
            // 
            // NUDBuyLimit
            // 
            this.NUDBuyLimit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NUDBuyLimit.Location = new System.Drawing.Point(119, 90);
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
            this.NUDBuyLimit.Size = new System.Drawing.Size(120, 23);
            this.NUDBuyLimit.TabIndex = 4;
            this.NUDBuyLimit.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // NUDCostItem4Count
            // 
            this.NUDCostItem4Count.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NUDCostItem4Count.Location = new System.Drawing.Point(219, 412);
            this.NUDCostItem4Count.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDCostItem4Count.Name = "NUDCostItem4Count";
            this.NUDCostItem4Count.Size = new System.Drawing.Size(60, 23);
            this.NUDCostItem4Count.TabIndex = 21;
            // 
            // NUDCostItem3Count
            // 
            this.NUDCostItem3Count.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NUDCostItem3Count.Location = new System.Drawing.Point(219, 383);
            this.NUDCostItem3Count.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDCostItem3Count.Name = "NUDCostItem3Count";
            this.NUDCostItem3Count.Size = new System.Drawing.Size(60, 23);
            this.NUDCostItem3Count.TabIndex = 19;
            // 
            // NUDCostItem2Count
            // 
            this.NUDCostItem2Count.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NUDCostItem2Count.Location = new System.Drawing.Point(219, 354);
            this.NUDCostItem2Count.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDCostItem2Count.Name = "NUDCostItem2Count";
            this.NUDCostItem2Count.Size = new System.Drawing.Size(60, 23);
            this.NUDCostItem2Count.TabIndex = 17;
            // 
            // NUDCostItem1Count
            // 
            this.NUDCostItem1Count.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NUDCostItem1Count.Location = new System.Drawing.Point(219, 325);
            this.NUDCostItem1Count.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDCostItem1Count.Name = "NUDCostItem1Count";
            this.NUDCostItem1Count.Size = new System.Drawing.Size(60, 23);
            this.NUDCostItem1Count.TabIndex = 15;
            // 
            // NUDGoodsItemCount
            // 
            this.NUDGoodsItemCount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NUDGoodsItemCount.Location = new System.Drawing.Point(257, 61);
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
            this.NUDGoodsItemCount.Size = new System.Drawing.Size(70, 23);
            this.NUDGoodsItemCount.TabIndex = 3;
            this.NUDGoodsItemCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // TxtGoodsItem
            // 
            this.TxtGoodsItem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtGoodsItem.Location = new System.Drawing.Point(95, 61);
            this.TxtGoodsItem.Name = "TxtGoodsItem";
            this.TxtGoodsItem.Size = new System.Drawing.Size(144, 23);
            this.TxtGoodsItem.TabIndex = 2;
            // 
            // LblRefreshModeLabel
            // 
            this.LblRefreshModeLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblRefreshModeLabel.AutoSize = true;
            this.LblRefreshModeLabel.Location = new System.Drawing.Point(45, 211);
            this.LblRefreshModeLabel.Name = "LblRefreshModeLabel";
            this.LblRefreshModeLabel.Size = new System.Drawing.Size(68, 17);
            this.LblRefreshModeLabel.TabIndex = 15;
            this.LblRefreshModeLabel.Text = "刷新方式：";
            // 
            // LblBuyLevelLabel
            // 
            this.LblBuyLevelLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblBuyLevelLabel.AutoSize = true;
            this.LblBuyLevelLabel.Location = new System.Drawing.Point(45, 125);
            this.LblBuyLevelLabel.Name = "LblBuyLevelLabel";
            this.LblBuyLevelLabel.Size = new System.Drawing.Size(68, 17);
            this.LblBuyLevelLabel.TabIndex = 12;
            this.LblBuyLevelLabel.Text = "限购等级：";
            // 
            // LblEndTimeLabel
            // 
            this.LblEndTimeLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblEndTimeLabel.AutoSize = true;
            this.LblEndTimeLabel.Location = new System.Drawing.Point(45, 185);
            this.LblEndTimeLabel.Name = "LblEndTimeLabel";
            this.LblEndTimeLabel.Size = new System.Drawing.Size(68, 17);
            this.LblEndTimeLabel.TabIndex = 9;
            this.LblEndTimeLabel.Text = "下架时间：";
            // 
            // LblBeginTimeLabel
            // 
            this.LblBeginTimeLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblBeginTimeLabel.AutoSize = true;
            this.LblBeginTimeLabel.Location = new System.Drawing.Point(45, 156);
            this.LblBeginTimeLabel.Name = "LblBeginTimeLabel";
            this.LblBeginTimeLabel.Size = new System.Drawing.Size(68, 17);
            this.LblBeginTimeLabel.TabIndex = 8;
            this.LblBeginTimeLabel.Text = "上架时间：";
            // 
            // LblCostItem4Label
            // 
            this.LblCostItem4Label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblCostItem4Label.AutoSize = true;
            this.LblCostItem4Label.Location = new System.Drawing.Point(38, 412);
            this.LblCostItem4Label.Name = "LblCostItem4Label";
            this.LblCostItem4Label.Size = new System.Drawing.Size(75, 17);
            this.LblCostItem4Label.TabIndex = 7;
            this.LblCostItem4Label.Text = "消耗物品4：";
            // 
            // LblCostItem3Label
            // 
            this.LblCostItem3Label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblCostItem3Label.AutoSize = true;
            this.LblCostItem3Label.Location = new System.Drawing.Point(38, 383);
            this.LblCostItem3Label.Name = "LblCostItem3Label";
            this.LblCostItem3Label.Size = new System.Drawing.Size(75, 17);
            this.LblCostItem3Label.TabIndex = 7;
            this.LblCostItem3Label.Text = "消耗物品3：";
            // 
            // LblCostItem2Label
            // 
            this.LblCostItem2Label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblCostItem2Label.AutoSize = true;
            this.LblCostItem2Label.Location = new System.Drawing.Point(38, 356);
            this.LblCostItem2Label.Name = "LblCostItem2Label";
            this.LblCostItem2Label.Size = new System.Drawing.Size(75, 17);
            this.LblCostItem2Label.TabIndex = 7;
            this.LblCostItem2Label.Text = "消耗物品2：";
            // 
            // LblCostItem1Label
            // 
            this.LblCostItem1Label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblCostItem1Label.AutoSize = true;
            this.LblCostItem1Label.Location = new System.Drawing.Point(38, 327);
            this.LblCostItem1Label.Name = "LblCostItem1Label";
            this.LblCostItem1Label.Size = new System.Drawing.Size(75, 17);
            this.LblCostItem1Label.TabIndex = 7;
            this.LblCostItem1Label.Text = "消耗物品1：";
            // 
            // LblCostMcoinLabel
            // 
            this.LblCostMcoinLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblCostMcoinLabel.AutoSize = true;
            this.LblCostMcoinLabel.Location = new System.Drawing.Point(21, 298);
            this.LblCostMcoinLabel.Name = "LblCostMcoinLabel";
            this.LblCostMcoinLabel.Size = new System.Drawing.Size(92, 17);
            this.LblCostMcoinLabel.TabIndex = 7;
            this.LblCostMcoinLabel.Text = "消耗创世结晶：";
            // 
            // LblCostScoinLabel
            // 
            this.LblCostScoinLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblCostScoinLabel.AutoSize = true;
            this.LblCostScoinLabel.Location = new System.Drawing.Point(45, 269);
            this.LblCostScoinLabel.Name = "LblCostScoinLabel";
            this.LblCostScoinLabel.Size = new System.Drawing.Size(68, 17);
            this.LblCostScoinLabel.TabIndex = 7;
            this.LblCostScoinLabel.Text = "消耗摩拉：";
            // 
            // LblCostHcoinLabel
            // 
            this.LblCostHcoinLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblCostHcoinLabel.AutoSize = true;
            this.LblCostHcoinLabel.Location = new System.Drawing.Point(45, 240);
            this.LblCostHcoinLabel.Name = "LblCostHcoinLabel";
            this.LblCostHcoinLabel.Size = new System.Drawing.Size(68, 17);
            this.LblCostHcoinLabel.TabIndex = 7;
            this.LblCostHcoinLabel.Text = "消耗原石：";
            // 
            // LblBuyLimitLabel
            // 
            this.LblBuyLimitLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblBuyLimitLabel.AutoSize = true;
            this.LblBuyLimitLabel.Location = new System.Drawing.Point(45, 92);
            this.LblBuyLimitLabel.Name = "LblBuyLimitLabel";
            this.LblBuyLimitLabel.Size = new System.Drawing.Size(68, 17);
            this.LblBuyLimitLabel.TabIndex = 6;
            this.LblBuyLimitLabel.Text = "限购数量：";
            // 
            // LblGoodsIdLabel
            // 
            this.LblGoodsIdLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblGoodsIdLabel.AutoSize = true;
            this.LblGoodsIdLabel.Location = new System.Drawing.Point(56, 34);
            this.LblGoodsIdLabel.Name = "LblGoodsIdLabel";
            this.LblGoodsIdLabel.Size = new System.Drawing.Size(57, 17);
            this.LblGoodsIdLabel.TabIndex = 4;
            this.LblGoodsIdLabel.Text = "商品ID：";
            // 
            // LblGoodsItemLabel
            // 
            this.LblGoodsItemLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblGoodsItemLabel.AutoSize = true;
            this.LblGoodsItemLabel.Location = new System.Drawing.Point(45, 64);
            this.LblGoodsItemLabel.Name = "LblGoodsItemLabel";
            this.LblGoodsItemLabel.Size = new System.Drawing.Size(44, 17);
            this.LblGoodsItemLabel.TabIndex = 0;
            this.LblGoodsItemLabel.Text = "商品：";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(207, 386);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 17);
            this.label13.TabIndex = 2;
            this.label13.Text = "x";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(207, 357);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 17);
            this.label12.TabIndex = 2;
            this.label12.Text = "x";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(207, 328);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 17);
            this.label11.TabIndex = 2;
            this.label11.Text = "x";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(207, 415);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 17);
            this.label14.TabIndex = 2;
            this.label14.Text = "x";
            // 
            // LnkGenGoodsId
            // 
            this.LnkGenGoodsId.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LnkGenGoodsId.AutoSize = true;
            this.LnkGenGoodsId.Location = new System.Drawing.Point(247, 34);
            this.LnkGenGoodsId.Name = "LnkGenGoodsId";
            this.LnkGenGoodsId.Size = new System.Drawing.Size(45, 17);
            this.LnkGenGoodsId.TabIndex = 1;
            this.LnkGenGoodsId.TabStop = true;
            this.LnkGenGoodsId.Text = "生成ID";
            this.LnkGenGoodsId.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkGenGoodsId_LinkClicked);
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(175, 124);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(17, 17);
            this.label18.TabIndex = 13;
            this.label18.Text = "~";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(245, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "x";
            // 
            // BtnSave
            // 
            this.BtnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnSave.Location = new System.Drawing.Point(720, 12);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(100, 23);
            this.BtnSave.TabIndex = 2;
            this.BtnSave.Text = "保存";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnLoad
            // 
            this.BtnLoad.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnLoad.Location = new System.Drawing.Point(615, 12);
            this.BtnLoad.Name = "BtnLoad";
            this.BtnLoad.Size = new System.Drawing.Size(100, 23);
            this.BtnLoad.TabIndex = 1;
            this.BtnLoad.Text = "加载";
            this.BtnLoad.UseVisualStyleBackColor = true;
            this.BtnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // TxtShopJsonPath
            // 
            this.TxtShopJsonPath.Location = new System.Drawing.Point(122, 12);
            this.TxtShopJsonPath.Name = "TxtShopJsonPath";
            this.TxtShopJsonPath.Size = new System.Drawing.Size(487, 23);
            this.TxtShopJsonPath.TabIndex = 0;
            // 
            // LblShopPathLabel
            // 
            this.LblShopPathLabel.AutoSize = true;
            this.LblShopPathLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblShopPathLabel.Location = new System.Drawing.Point(11, 15);
            this.LblShopPathLabel.Name = "LblShopPathLabel";
            this.LblShopPathLabel.Size = new System.Drawing.Size(105, 17);
            this.LblShopPathLabel.TabIndex = 7;
            this.LblShopPathLabel.Text = "Shop.json 路径：";
            // 
            // TxtItemFilter
            // 
            this.TxtItemFilter.Location = new System.Drawing.Point(6, 22);
            this.TxtItemFilter.Name = "TxtItemFilter";
            this.TxtItemFilter.Size = new System.Drawing.Size(238, 23);
            this.TxtItemFilter.TabIndex = 3;
            this.TxtItemFilter.TextChanged += new System.EventHandler(this.TxtItemFilter_TextChanged);
            // 
            // FormShopEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnLoad);
            this.Controls.Add(this.TxtShopJsonPath);
            this.Controls.Add(this.LblShopPathLabel);
            this.Controls.Add(this.GrpGoodsInfo);
            this.Controls.Add(this.GrpItems);
            this.Controls.Add(this.GrpGoodsList);
            this.Controls.Add(this.GrpShopList);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "FormShopEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shop.json Editor";
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
    }
}