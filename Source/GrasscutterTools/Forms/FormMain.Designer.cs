namespace GrasscutterTools.Forms
{
    partial class FormMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.CmbCommand = new System.Windows.Forms.ComboBox();
            this.BtnCopy = new System.Windows.Forms.Button();
            this.ChkAutoCopy = new System.Windows.Forms.CheckBox();
            this.GrpCommand = new System.Windows.Forms.GroupBox();
            this.BtnInvokeOpenCommand = new System.Windows.Forms.Button();
            this.TPRemoteCall = new System.Windows.Forms.TabPage();
            this.TPAbout = new System.Windows.Forms.TabPage();
            this.GrasscutterToolsSupport = new System.Windows.Forms.PictureBox();
            this.LnkGithub = new System.Windows.Forms.LinkLabel();
            this.LblSupportDescription = new System.Windows.Forms.Label();
            this.TPManage = new System.Windows.Forms.TabPage();
            this.GrpBanPlayer = new System.Windows.Forms.GroupBox();
            this.DTPBanEndTime = new System.Windows.Forms.DateTimePicker();
            this.BtnUnban = new System.Windows.Forms.Button();
            this.BtnBan = new System.Windows.Forms.Button();
            this.NUDBanUID = new System.Windows.Forms.NumericUpDown();
            this.LblBanUID = new System.Windows.Forms.Label();
            this.GrpAccount = new System.Windows.Forms.GroupBox();
            this.ChkAccountSetUid = new System.Windows.Forms.CheckBox();
            this.NUDAccountUid = new System.Windows.Forms.NumericUpDown();
            this.BtnDeleteAccount = new System.Windows.Forms.Button();
            this.BtnCreateAccount = new System.Windows.Forms.Button();
            this.LblAccountUserName = new System.Windows.Forms.Label();
            this.TxtAccountUserName = new System.Windows.Forms.TextBox();
            this.GrpPermission = new System.Windows.Forms.GroupBox();
            this.CmbPerm = new System.Windows.Forms.ComboBox();
            this.NUDPermUID = new System.Windows.Forms.NumericUpDown();
            this.BtnPermClear = new System.Windows.Forms.Button();
            this.BtmPermRemove = new System.Windows.Forms.Button();
            this.BtnPermList = new System.Windows.Forms.Button();
            this.BtnPermAdd = new System.Windows.Forms.Button();
            this.LblPerm = new System.Windows.Forms.Label();
            this.LblPermUID = new System.Windows.Forms.Label();
            this.TPScene = new System.Windows.Forms.TabPage();
            this.RbListDungeons = new System.Windows.Forms.RadioButton();
            this.RbListScene = new System.Windows.Forms.RadioButton();
            this.TxtSceneFilter = new System.Windows.Forms.TextBox();
            this.ChkIncludeSceneId = new System.Windows.Forms.CheckBox();
            this.LblTpZ = new System.Windows.Forms.Label();
            this.LblTpY = new System.Windows.Forms.Label();
            this.BtnTeleport = new System.Windows.Forms.Button();
            this.LblTpX = new System.Windows.Forms.Label();
            this.NUDTpZ = new System.Windows.Forms.NumericUpDown();
            this.NUDTpY = new System.Windows.Forms.NumericUpDown();
            this.NUDTpX = new System.Windows.Forms.NumericUpDown();
            this.CmbClimateType = new System.Windows.Forms.ComboBox();
            this.LblClimateType = new System.Windows.Forms.Label();
            this.LblSceneDescription = new System.Windows.Forms.Label();
            this.ListScenes = new System.Windows.Forms.ListBox();
            this.LblTp = new System.Windows.Forms.Label();
            this.TPItem = new System.Windows.Forms.TabPage();
            this.LblClearGiveItemLogs = new System.Windows.Forms.Label();
            this.BtnSaveGiveItemLog = new System.Windows.Forms.Button();
            this.BtnRemoveGiveItemLog = new System.Windows.Forms.Button();
            this.GrpGiveItemRecord = new System.Windows.Forms.GroupBox();
            this.ListGiveItemLogs = new System.Windows.Forms.ListBox();
            this.ChkDrop = new System.Windows.Forms.CheckBox();
            this.TxtGameItemFilter = new System.Windows.Forms.TextBox();
            this.ListGameItems = new System.Windows.Forms.ListBox();
            this.LblGameItemAmount = new System.Windows.Forms.Label();
            this.LblGameItemLevel = new System.Windows.Forms.Label();
            this.NUDGameItemAmout = new System.Windows.Forms.NumericUpDown();
            this.NUDGameItemLevel = new System.Windows.Forms.NumericUpDown();
            this.LblGiveCommandDescription = new System.Windows.Forms.Label();
            this.TPWeapon = new System.Windows.Forms.TabPage();
            this.TPAvatar = new System.Windows.Forms.TabPage();
            this.GrpSetConstellation = new System.Windows.Forms.GroupBox();
            this.LnkSetAllConst = new System.Windows.Forms.LinkLabel();
            this.LnkSetConst = new System.Windows.Forms.LinkLabel();
            this.NUDSetConstellation = new System.Windows.Forms.NumericUpDown();
            this.GrpSetStats = new System.Windows.Forms.GroupBox();
            this.BtnUnlockStat = new System.Windows.Forms.Button();
            this.BtnLockStat = new System.Windows.Forms.Button();
            this.LblStatTip = new System.Windows.Forms.Label();
            this.LblStatPercent = new System.Windows.Forms.Label();
            this.NUDStat = new System.Windows.Forms.NumericUpDown();
            this.CmbStat = new System.Windows.Forms.ComboBox();
            this.GrpTalentLevel = new System.Windows.Forms.GroupBox();
            this.LnkTalentAll = new System.Windows.Forms.LinkLabel();
            this.LnkTalentE = new System.Windows.Forms.LinkLabel();
            this.LnkTalentQ = new System.Windows.Forms.LinkLabel();
            this.LnkTalentNormalATK = new System.Windows.Forms.LinkLabel();
            this.NUDTalentLevel = new System.Windows.Forms.NumericUpDown();
            this.GrpGiveAvatar = new System.Windows.Forms.GroupBox();
            this.CmbSwitchElement = new System.Windows.Forms.ComboBox();
            this.LnkSwitchElement = new System.Windows.Forms.LinkLabel();
            this.CmbAvatar = new System.Windows.Forms.ComboBox();
            this.LblAvatarSkillLevelTip = new System.Windows.Forms.Label();
            this.NUDAvatarLevel = new System.Windows.Forms.NumericUpDown();
            this.BtnGiveAllChar = new System.Windows.Forms.Button();
            this.LblAvatarLevel = new System.Windows.Forms.Label();
            this.LblAvatarSkillLevelLabel = new System.Windows.Forms.Label();
            this.LblAvatar = new System.Windows.Forms.Label();
            this.LblAvatarConstellation = new System.Windows.Forms.Label();
            this.NUDAvatarConstellation = new System.Windows.Forms.NumericUpDown();
            this.NUDAvatarSkillLevel = new System.Windows.Forms.NumericUpDown();
            this.TPSpawn = new System.Windows.Forms.TabPage();
            this.TPQuest = new System.Windows.Forms.TabPage();
            this.GrpQuestFilters = new System.Windows.Forms.GroupBox();
            this.ChkQuestFilterTEST = new System.Windows.Forms.CheckBox();
            this.ChkQuestFilterUNRELEASED = new System.Windows.Forms.CheckBox();
            this.ChkQuestFilterHIDDEN = new System.Windows.Forms.CheckBox();
            this.BtnFinishQuest = new System.Windows.Forms.Button();
            this.BtnAddQuest = new System.Windows.Forms.Button();
            this.LblQuestDescription = new System.Windows.Forms.Label();
            this.TxtQuestFilter = new System.Windows.Forms.TextBox();
            this.ListQuest = new System.Windows.Forms.ListBox();
            this.TPArtifact = new System.Windows.Forms.TabPage();
            this.TPCustom = new System.Windows.Forms.TabPage();
            this.TPHome = new System.Windows.Forms.TabPage();
            this.TCMain = new System.Windows.Forms.TabControl();
            this.TPMail = new System.Windows.Forms.TabPage();
            this.LblClearMailContent = new System.Windows.Forms.Label();
            this.BtnAddMailItem = new System.Windows.Forms.Button();
            this.BtnDeleteMailItem = new System.Windows.Forms.Button();
            this.TCMailRight = new System.Windows.Forms.TabControl();
            this.TPMailSelectableItemList = new System.Windows.Forms.TabPage();
            this.ListMailSelectableItems = new System.Windows.Forms.ListBox();
            this.TxtMailSelectableItemFilter = new System.Windows.Forms.TextBox();
            this.PanelMailItemArgs = new System.Windows.Forms.Panel();
            this.NUDMailItemLevel = new System.Windows.Forms.NumericUpDown();
            this.NUDMailItemCount = new System.Windows.Forms.NumericUpDown();
            this.LblMailItemCount = new System.Windows.Forms.Label();
            this.LblMailItemLevel = new System.Windows.Forms.Label();
            this.TPMailList = new System.Windows.Forms.TabPage();
            this.ListMailList = new System.Windows.Forms.ListBox();
            this.PanelMailListControls = new System.Windows.Forms.Panel();
            this.BtnClearMail = new System.Windows.Forms.Button();
            this.BtnRemoveMail = new System.Windows.Forms.Button();
            this.BtnSendMail = new System.Windows.Forms.Button();
            this.ListMailItems = new System.Windows.Forms.ListBox();
            this.LblMailItemsLabel = new System.Windows.Forms.Label();
            this.NUDMailRecipient = new System.Windows.Forms.NumericUpDown();
            this.RbMailSendToPlayer = new System.Windows.Forms.RadioButton();
            this.RbMailSendToAll = new System.Windows.Forms.RadioButton();
            this.LblMailRecipientLabel = new System.Windows.Forms.Label();
            this.TxtMailContent = new System.Windows.Forms.TextBox();
            this.LblMailContentLabel = new System.Windows.Forms.Label();
            this.TxtMailTitle = new System.Windows.Forms.TextBox();
            this.LblMailTitleLabel = new System.Windows.Forms.Label();
            this.TxtMailSender = new System.Windows.Forms.TextBox();
            this.LblMailSenderLabel = new System.Windows.Forms.Label();
            this.MenuSpawnEntityFilter = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TxtBanReason = new GrasscutterTools.Controls.TextBoxXP();
            this.GrpCommand.SuspendLayout();
            this.TPAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrasscutterToolsSupport)).BeginInit();
            this.TPManage.SuspendLayout();
            this.GrpBanPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDBanUID)).BeginInit();
            this.GrpAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDAccountUid)).BeginInit();
            this.GrpPermission.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDPermUID)).BeginInit();
            this.TPScene.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDTpZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDTpY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDTpX)).BeginInit();
            this.TPItem.SuspendLayout();
            this.GrpGiveItemRecord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDGameItemAmout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDGameItemLevel)).BeginInit();
            this.TPAvatar.SuspendLayout();
            this.GrpSetConstellation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDSetConstellation)).BeginInit();
            this.GrpSetStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDStat)).BeginInit();
            this.GrpTalentLevel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDTalentLevel)).BeginInit();
            this.GrpGiveAvatar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDAvatarLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDAvatarConstellation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDAvatarSkillLevel)).BeginInit();
            this.TPQuest.SuspendLayout();
            this.GrpQuestFilters.SuspendLayout();
            this.TCMain.SuspendLayout();
            this.TPMail.SuspendLayout();
            this.TCMailRight.SuspendLayout();
            this.TPMailSelectableItemList.SuspendLayout();
            this.PanelMailItemArgs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDMailItemLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDMailItemCount)).BeginInit();
            this.TPMailList.SuspendLayout();
            this.PanelMailListControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDMailRecipient)).BeginInit();
            this.SuspendLayout();
            // 
            // CmbCommand
            // 
            resources.ApplyResources(this.CmbCommand, "CmbCommand");
            this.CmbCommand.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CmbCommand.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbCommand.Name = "CmbCommand";
            this.CmbCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCommand_KeyDown);
            // 
            // BtnCopy
            // 
            resources.ApplyResources(this.BtnCopy, "BtnCopy");
            this.BtnCopy.Name = "BtnCopy";
            this.BtnCopy.UseVisualStyleBackColor = true;
            this.BtnCopy.Click += new System.EventHandler(this.BtnCopy_Click);
            // 
            // ChkAutoCopy
            // 
            resources.ApplyResources(this.ChkAutoCopy, "ChkAutoCopy");
            this.ChkAutoCopy.Name = "ChkAutoCopy";
            this.ChkAutoCopy.UseVisualStyleBackColor = true;
            // 
            // GrpCommand
            // 
            resources.ApplyResources(this.GrpCommand, "GrpCommand");
            this.GrpCommand.Controls.Add(this.BtnInvokeOpenCommand);
            this.GrpCommand.Controls.Add(this.BtnCopy);
            this.GrpCommand.Controls.Add(this.ChkAutoCopy);
            this.GrpCommand.Controls.Add(this.CmbCommand);
            this.GrpCommand.Name = "GrpCommand";
            this.GrpCommand.TabStop = false;
            // 
            // BtnInvokeOpenCommand
            // 
            resources.ApplyResources(this.BtnInvokeOpenCommand, "BtnInvokeOpenCommand");
            this.BtnInvokeOpenCommand.Name = "BtnInvokeOpenCommand";
            this.BtnInvokeOpenCommand.UseVisualStyleBackColor = true;
            this.BtnInvokeOpenCommand.Click += new System.EventHandler(this.BtnInvokeOpenCommand_Click);
            // 
            // TPRemoteCall
            // 
            resources.ApplyResources(this.TPRemoteCall, "TPRemoteCall");
            this.TPRemoteCall.Name = "TPRemoteCall";
            this.TPRemoteCall.UseVisualStyleBackColor = true;
            // 
            // TPAbout
            // 
            this.TPAbout.Controls.Add(this.GrasscutterToolsSupport);
            this.TPAbout.Controls.Add(this.LnkGithub);
            this.TPAbout.Controls.Add(this.LblSupportDescription);
            resources.ApplyResources(this.TPAbout, "TPAbout");
            this.TPAbout.Name = "TPAbout";
            this.TPAbout.UseVisualStyleBackColor = true;
            // 
            // GrasscutterToolsSupport
            // 
            resources.ApplyResources(this.GrasscutterToolsSupport, "GrasscutterToolsSupport");
            this.GrasscutterToolsSupport.Image = global::GrasscutterTools.Properties.Resources.ImgSupport;
            this.GrasscutterToolsSupport.Name = "GrasscutterToolsSupport";
            this.GrasscutterToolsSupport.TabStop = false;
            // 
            // LnkGithub
            // 
            resources.ApplyResources(this.LnkGithub, "LnkGithub");
            this.LnkGithub.Name = "LnkGithub";
            this.LnkGithub.TabStop = true;
            this.LnkGithub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkGithub_LinkClicked);
            // 
            // LblSupportDescription
            // 
            resources.ApplyResources(this.LblSupportDescription, "LblSupportDescription");
            this.LblSupportDescription.Name = "LblSupportDescription";
            // 
            // TPManage
            // 
            this.TPManage.Controls.Add(this.GrpBanPlayer);
            this.TPManage.Controls.Add(this.GrpAccount);
            this.TPManage.Controls.Add(this.GrpPermission);
            resources.ApplyResources(this.TPManage, "TPManage");
            this.TPManage.Name = "TPManage";
            this.TPManage.UseVisualStyleBackColor = true;
            // 
            // GrpBanPlayer
            // 
            resources.ApplyResources(this.GrpBanPlayer, "GrpBanPlayer");
            this.GrpBanPlayer.Controls.Add(this.DTPBanEndTime);
            this.GrpBanPlayer.Controls.Add(this.BtnUnban);
            this.GrpBanPlayer.Controls.Add(this.BtnBan);
            this.GrpBanPlayer.Controls.Add(this.TxtBanReason);
            this.GrpBanPlayer.Controls.Add(this.NUDBanUID);
            this.GrpBanPlayer.Controls.Add(this.LblBanUID);
            this.GrpBanPlayer.Name = "GrpBanPlayer";
            this.GrpBanPlayer.TabStop = false;
            // 
            // DTPBanEndTime
            // 
            this.DTPBanEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.DTPBanEndTime, "DTPBanEndTime");
            this.DTPBanEndTime.MaxDate = new System.DateTime(2034, 12, 31, 0, 0, 0, 0);
            this.DTPBanEndTime.MinDate = new System.DateTime(2022, 6, 28, 0, 0, 0, 0);
            this.DTPBanEndTime.Name = "DTPBanEndTime";
            this.DTPBanEndTime.Value = new System.DateTime(2025, 12, 31, 0, 0, 0, 0);
            // 
            // BtnUnban
            // 
            resources.ApplyResources(this.BtnUnban, "BtnUnban");
            this.BtnUnban.Name = "BtnUnban";
            this.BtnUnban.UseVisualStyleBackColor = true;
            this.BtnUnban.Click += new System.EventHandler(this.BtnUnban_Click);
            // 
            // BtnBan
            // 
            resources.ApplyResources(this.BtnBan, "BtnBan");
            this.BtnBan.Name = "BtnBan";
            this.BtnBan.UseVisualStyleBackColor = true;
            this.BtnBan.Click += new System.EventHandler(this.BtnBan_Click);
            // 
            // NUDBanUID
            // 
            resources.ApplyResources(this.NUDBanUID, "NUDBanUID");
            this.NUDBanUID.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDBanUID.Name = "NUDBanUID";
            this.NUDBanUID.Value = new decimal(new int[] {
            10001,
            0,
            0,
            0});
            // 
            // LblBanUID
            // 
            resources.ApplyResources(this.LblBanUID, "LblBanUID");
            this.LblBanUID.Name = "LblBanUID";
            // 
            // GrpAccount
            // 
            resources.ApplyResources(this.GrpAccount, "GrpAccount");
            this.GrpAccount.Controls.Add(this.ChkAccountSetUid);
            this.GrpAccount.Controls.Add(this.NUDAccountUid);
            this.GrpAccount.Controls.Add(this.BtnDeleteAccount);
            this.GrpAccount.Controls.Add(this.BtnCreateAccount);
            this.GrpAccount.Controls.Add(this.LblAccountUserName);
            this.GrpAccount.Controls.Add(this.TxtAccountUserName);
            this.GrpAccount.Name = "GrpAccount";
            this.GrpAccount.TabStop = false;
            // 
            // ChkAccountSetUid
            // 
            resources.ApplyResources(this.ChkAccountSetUid, "ChkAccountSetUid");
            this.ChkAccountSetUid.Name = "ChkAccountSetUid";
            this.ChkAccountSetUid.UseVisualStyleBackColor = true;
            // 
            // NUDAccountUid
            // 
            resources.ApplyResources(this.NUDAccountUid, "NUDAccountUid");
            this.NUDAccountUid.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDAccountUid.Name = "NUDAccountUid";
            this.NUDAccountUid.Value = new decimal(new int[] {
            10001,
            0,
            0,
            0});
            // 
            // BtnDeleteAccount
            // 
            resources.ApplyResources(this.BtnDeleteAccount, "BtnDeleteAccount");
            this.BtnDeleteAccount.Name = "BtnDeleteAccount";
            this.BtnDeleteAccount.Tag = "delete";
            this.BtnDeleteAccount.UseVisualStyleBackColor = true;
            this.BtnDeleteAccount.Click += new System.EventHandler(this.AccountButtonClicked);
            // 
            // BtnCreateAccount
            // 
            resources.ApplyResources(this.BtnCreateAccount, "BtnCreateAccount");
            this.BtnCreateAccount.Name = "BtnCreateAccount";
            this.BtnCreateAccount.Tag = "create";
            this.BtnCreateAccount.UseVisualStyleBackColor = true;
            this.BtnCreateAccount.Click += new System.EventHandler(this.AccountButtonClicked);
            // 
            // LblAccountUserName
            // 
            resources.ApplyResources(this.LblAccountUserName, "LblAccountUserName");
            this.LblAccountUserName.Name = "LblAccountUserName";
            // 
            // TxtAccountUserName
            // 
            resources.ApplyResources(this.TxtAccountUserName, "TxtAccountUserName");
            this.TxtAccountUserName.Name = "TxtAccountUserName";
            // 
            // GrpPermission
            // 
            resources.ApplyResources(this.GrpPermission, "GrpPermission");
            this.GrpPermission.Controls.Add(this.CmbPerm);
            this.GrpPermission.Controls.Add(this.NUDPermUID);
            this.GrpPermission.Controls.Add(this.BtnPermClear);
            this.GrpPermission.Controls.Add(this.BtmPermRemove);
            this.GrpPermission.Controls.Add(this.BtnPermList);
            this.GrpPermission.Controls.Add(this.BtnPermAdd);
            this.GrpPermission.Controls.Add(this.LblPerm);
            this.GrpPermission.Controls.Add(this.LblPermUID);
            this.GrpPermission.Name = "GrpPermission";
            this.GrpPermission.TabStop = false;
            // 
            // CmbPerm
            // 
            this.CmbPerm.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CmbPerm.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbPerm.FormattingEnabled = true;
            resources.ApplyResources(this.CmbPerm, "CmbPerm");
            this.CmbPerm.Name = "CmbPerm";
            // 
            // NUDPermUID
            // 
            resources.ApplyResources(this.NUDPermUID, "NUDPermUID");
            this.NUDPermUID.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDPermUID.Name = "NUDPermUID";
            this.NUDPermUID.Value = new decimal(new int[] {
            10001,
            0,
            0,
            0});
            // 
            // BtnPermClear
            // 
            resources.ApplyResources(this.BtnPermClear, "BtnPermClear");
            this.BtnPermClear.Name = "BtnPermClear";
            this.BtnPermClear.Tag = "clear";
            this.BtnPermClear.UseVisualStyleBackColor = true;
            this.BtnPermClear.Click += new System.EventHandler(this.BtnPermClick);
            // 
            // BtmPermRemove
            // 
            resources.ApplyResources(this.BtmPermRemove, "BtmPermRemove");
            this.BtmPermRemove.Name = "BtmPermRemove";
            this.BtmPermRemove.Tag = "remove";
            this.BtmPermRemove.UseVisualStyleBackColor = true;
            this.BtmPermRemove.Click += new System.EventHandler(this.BtnPermClick);
            // 
            // BtnPermList
            // 
            resources.ApplyResources(this.BtnPermList, "BtnPermList");
            this.BtnPermList.Name = "BtnPermList";
            this.BtnPermList.Tag = "list";
            this.BtnPermList.UseVisualStyleBackColor = true;
            this.BtnPermList.Click += new System.EventHandler(this.BtnPermClick);
            // 
            // BtnPermAdd
            // 
            resources.ApplyResources(this.BtnPermAdd, "BtnPermAdd");
            this.BtnPermAdd.Name = "BtnPermAdd";
            this.BtnPermAdd.Tag = "add";
            this.BtnPermAdd.UseVisualStyleBackColor = true;
            this.BtnPermAdd.Click += new System.EventHandler(this.BtnPermClick);
            // 
            // LblPerm
            // 
            resources.ApplyResources(this.LblPerm, "LblPerm");
            this.LblPerm.Name = "LblPerm";
            // 
            // LblPermUID
            // 
            resources.ApplyResources(this.LblPermUID, "LblPermUID");
            this.LblPermUID.Name = "LblPermUID";
            // 
            // TPScene
            // 
            this.TPScene.Controls.Add(this.RbListDungeons);
            this.TPScene.Controls.Add(this.RbListScene);
            this.TPScene.Controls.Add(this.TxtSceneFilter);
            this.TPScene.Controls.Add(this.ChkIncludeSceneId);
            this.TPScene.Controls.Add(this.LblTpZ);
            this.TPScene.Controls.Add(this.LblTpY);
            this.TPScene.Controls.Add(this.BtnTeleport);
            this.TPScene.Controls.Add(this.LblTpX);
            this.TPScene.Controls.Add(this.NUDTpZ);
            this.TPScene.Controls.Add(this.NUDTpY);
            this.TPScene.Controls.Add(this.NUDTpX);
            this.TPScene.Controls.Add(this.CmbClimateType);
            this.TPScene.Controls.Add(this.LblClimateType);
            this.TPScene.Controls.Add(this.LblSceneDescription);
            this.TPScene.Controls.Add(this.ListScenes);
            this.TPScene.Controls.Add(this.LblTp);
            resources.ApplyResources(this.TPScene, "TPScene");
            this.TPScene.Name = "TPScene";
            this.TPScene.UseVisualStyleBackColor = true;
            // 
            // RbListDungeons
            // 
            resources.ApplyResources(this.RbListDungeons, "RbListDungeons");
            this.RbListDungeons.Name = "RbListDungeons";
            this.RbListDungeons.UseVisualStyleBackColor = true;
            this.RbListDungeons.CheckedChanged += new System.EventHandler(this.RbListDungeons_CheckedChanged);
            // 
            // RbListScene
            // 
            resources.ApplyResources(this.RbListScene, "RbListScene");
            this.RbListScene.Checked = true;
            this.RbListScene.Name = "RbListScene";
            this.RbListScene.TabStop = true;
            this.RbListScene.UseVisualStyleBackColor = true;
            this.RbListScene.CheckedChanged += new System.EventHandler(this.RbListScene_CheckedChanged);
            // 
            // TxtSceneFilter
            // 
            resources.ApplyResources(this.TxtSceneFilter, "TxtSceneFilter");
            this.TxtSceneFilter.Name = "TxtSceneFilter";
            this.TxtSceneFilter.TextChanged += new System.EventHandler(this.TxtSceneFilter_TextChanged);
            // 
            // ChkIncludeSceneId
            // 
            resources.ApplyResources(this.ChkIncludeSceneId, "ChkIncludeSceneId");
            this.ChkIncludeSceneId.Name = "ChkIncludeSceneId";
            this.ChkIncludeSceneId.UseVisualStyleBackColor = true;
            // 
            // LblTpZ
            // 
            resources.ApplyResources(this.LblTpZ, "LblTpZ");
            this.LblTpZ.Name = "LblTpZ";
            // 
            // LblTpY
            // 
            resources.ApplyResources(this.LblTpY, "LblTpY");
            this.LblTpY.Name = "LblTpY";
            // 
            // BtnTeleport
            // 
            resources.ApplyResources(this.BtnTeleport, "BtnTeleport");
            this.BtnTeleport.Name = "BtnTeleport";
            this.BtnTeleport.UseVisualStyleBackColor = true;
            this.BtnTeleport.Click += new System.EventHandler(this.BtnTeleport_Click);
            // 
            // LblTpX
            // 
            resources.ApplyResources(this.LblTpX, "LblTpX");
            this.LblTpX.Name = "LblTpX";
            // 
            // NUDTpZ
            // 
            resources.ApplyResources(this.NUDTpZ, "NUDTpZ");
            this.NUDTpZ.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.NUDTpZ.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDTpZ.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.NUDTpZ.Name = "NUDTpZ";
            // 
            // NUDTpY
            // 
            resources.ApplyResources(this.NUDTpY, "NUDTpY");
            this.NUDTpY.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.NUDTpY.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDTpY.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.NUDTpY.Name = "NUDTpY";
            this.NUDTpY.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // NUDTpX
            // 
            resources.ApplyResources(this.NUDTpX, "NUDTpX");
            this.NUDTpX.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.NUDTpX.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDTpX.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.NUDTpX.Name = "NUDTpX";
            // 
            // CmbClimateType
            // 
            resources.ApplyResources(this.CmbClimateType, "CmbClimateType");
            this.CmbClimateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbClimateType.FormattingEnabled = true;
            this.CmbClimateType.Name = "CmbClimateType";
            this.CmbClimateType.SelectedIndexChanged += new System.EventHandler(this.CmbClimateType_SelectedIndexChanged);
            // 
            // LblClimateType
            // 
            resources.ApplyResources(this.LblClimateType, "LblClimateType");
            this.LblClimateType.Name = "LblClimateType";
            // 
            // LblSceneDescription
            // 
            resources.ApplyResources(this.LblSceneDescription, "LblSceneDescription");
            this.LblSceneDescription.Name = "LblSceneDescription";
            // 
            // ListScenes
            // 
            resources.ApplyResources(this.ListScenes, "ListScenes");
            this.ListScenes.FormattingEnabled = true;
            this.ListScenes.Name = "ListScenes";
            this.ListScenes.SelectedIndexChanged += new System.EventHandler(this.ListScenes_SelectedIndexChanged);
            // 
            // LblTp
            // 
            resources.ApplyResources(this.LblTp, "LblTp");
            this.LblTp.Name = "LblTp";
            // 
            // TPItem
            // 
            this.TPItem.Controls.Add(this.LblClearGiveItemLogs);
            this.TPItem.Controls.Add(this.BtnSaveGiveItemLog);
            this.TPItem.Controls.Add(this.BtnRemoveGiveItemLog);
            this.TPItem.Controls.Add(this.GrpGiveItemRecord);
            this.TPItem.Controls.Add(this.ChkDrop);
            this.TPItem.Controls.Add(this.TxtGameItemFilter);
            this.TPItem.Controls.Add(this.ListGameItems);
            this.TPItem.Controls.Add(this.LblGameItemAmount);
            this.TPItem.Controls.Add(this.LblGameItemLevel);
            this.TPItem.Controls.Add(this.NUDGameItemAmout);
            this.TPItem.Controls.Add(this.NUDGameItemLevel);
            this.TPItem.Controls.Add(this.LblGiveCommandDescription);
            resources.ApplyResources(this.TPItem, "TPItem");
            this.TPItem.Name = "TPItem";
            this.TPItem.UseVisualStyleBackColor = true;
            // 
            // LblClearGiveItemLogs
            // 
            resources.ApplyResources(this.LblClearGiveItemLogs, "LblClearGiveItemLogs");
            this.LblClearGiveItemLogs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblClearGiveItemLogs.Name = "LblClearGiveItemLogs";
            this.LblClearGiveItemLogs.Click += new System.EventHandler(this.LblClearGiveItemLogs_Click);
            // 
            // BtnSaveGiveItemLog
            // 
            resources.ApplyResources(this.BtnSaveGiveItemLog, "BtnSaveGiveItemLog");
            this.BtnSaveGiveItemLog.Name = "BtnSaveGiveItemLog";
            this.BtnSaveGiveItemLog.UseVisualStyleBackColor = true;
            this.BtnSaveGiveItemLog.Click += new System.EventHandler(this.BtnSaveGiveItemLog_Click);
            // 
            // BtnRemoveGiveItemLog
            // 
            resources.ApplyResources(this.BtnRemoveGiveItemLog, "BtnRemoveGiveItemLog");
            this.BtnRemoveGiveItemLog.Name = "BtnRemoveGiveItemLog";
            this.BtnRemoveGiveItemLog.UseVisualStyleBackColor = true;
            this.BtnRemoveGiveItemLog.Click += new System.EventHandler(this.BtnRemoveGiveItemLog_Click);
            // 
            // GrpGiveItemRecord
            // 
            resources.ApplyResources(this.GrpGiveItemRecord, "GrpGiveItemRecord");
            this.GrpGiveItemRecord.Controls.Add(this.ListGiveItemLogs);
            this.GrpGiveItemRecord.Name = "GrpGiveItemRecord";
            this.GrpGiveItemRecord.TabStop = false;
            // 
            // ListGiveItemLogs
            // 
            resources.ApplyResources(this.ListGiveItemLogs, "ListGiveItemLogs");
            this.ListGiveItemLogs.FormattingEnabled = true;
            this.ListGiveItemLogs.Name = "ListGiveItemLogs";
            this.ListGiveItemLogs.SelectedIndexChanged += new System.EventHandler(this.ListGiveItemLogs_SelectedIndexChanged);
            // 
            // ChkDrop
            // 
            resources.ApplyResources(this.ChkDrop, "ChkDrop");
            this.ChkDrop.Name = "ChkDrop";
            this.ChkDrop.UseVisualStyleBackColor = true;
            this.ChkDrop.CheckedChanged += new System.EventHandler(this.GiveItemsInputChanged);
            // 
            // TxtGameItemFilter
            // 
            resources.ApplyResources(this.TxtGameItemFilter, "TxtGameItemFilter");
            this.TxtGameItemFilter.Name = "TxtGameItemFilter";
            this.TxtGameItemFilter.TextChanged += new System.EventHandler(this.TxtGameItemFilter_TextChanged);
            // 
            // ListGameItems
            // 
            resources.ApplyResources(this.ListGameItems, "ListGameItems");
            this.ListGameItems.FormattingEnabled = true;
            this.ListGameItems.Name = "ListGameItems";
            this.ListGameItems.SelectedIndexChanged += new System.EventHandler(this.GiveItemsInputChanged);
            // 
            // LblGameItemAmount
            // 
            resources.ApplyResources(this.LblGameItemAmount, "LblGameItemAmount");
            this.LblGameItemAmount.Name = "LblGameItemAmount";
            // 
            // LblGameItemLevel
            // 
            resources.ApplyResources(this.LblGameItemLevel, "LblGameItemLevel");
            this.LblGameItemLevel.Name = "LblGameItemLevel";
            // 
            // NUDGameItemAmout
            // 
            resources.ApplyResources(this.NUDGameItemAmout, "NUDGameItemAmout");
            this.NUDGameItemAmout.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NUDGameItemAmout.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDGameItemAmout.Name = "NUDGameItemAmout";
            this.NUDGameItemAmout.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDGameItemAmout.ValueChanged += new System.EventHandler(this.GiveItemsInputChanged);
            // 
            // NUDGameItemLevel
            // 
            resources.ApplyResources(this.NUDGameItemLevel, "NUDGameItemLevel");
            this.NUDGameItemLevel.Maximum = new decimal(new int[] {
            21,
            0,
            0,
            0});
            this.NUDGameItemLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDGameItemLevel.Name = "NUDGameItemLevel";
            this.NUDGameItemLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDGameItemLevel.ValueChanged += new System.EventHandler(this.GiveItemsInputChanged);
            // 
            // LblGiveCommandDescription
            // 
            resources.ApplyResources(this.LblGiveCommandDescription, "LblGiveCommandDescription");
            this.LblGiveCommandDescription.Name = "LblGiveCommandDescription";
            // 
            // TPWeapon
            // 
            resources.ApplyResources(this.TPWeapon, "TPWeapon");
            this.TPWeapon.Name = "TPWeapon";
            this.TPWeapon.UseVisualStyleBackColor = true;
            // 
            // TPAvatar
            // 
            this.TPAvatar.Controls.Add(this.GrpSetConstellation);
            this.TPAvatar.Controls.Add(this.GrpSetStats);
            this.TPAvatar.Controls.Add(this.GrpTalentLevel);
            this.TPAvatar.Controls.Add(this.GrpGiveAvatar);
            resources.ApplyResources(this.TPAvatar, "TPAvatar");
            this.TPAvatar.Name = "TPAvatar";
            this.TPAvatar.UseVisualStyleBackColor = true;
            // 
            // GrpSetConstellation
            // 
            resources.ApplyResources(this.GrpSetConstellation, "GrpSetConstellation");
            this.GrpSetConstellation.Controls.Add(this.LnkSetAllConst);
            this.GrpSetConstellation.Controls.Add(this.LnkSetConst);
            this.GrpSetConstellation.Controls.Add(this.NUDSetConstellation);
            this.GrpSetConstellation.Name = "GrpSetConstellation";
            this.GrpSetConstellation.TabStop = false;
            // 
            // LnkSetAllConst
            // 
            resources.ApplyResources(this.LnkSetAllConst, "LnkSetAllConst");
            this.LnkSetAllConst.Name = "LnkSetAllConst";
            this.LnkSetAllConst.TabStop = true;
            this.LnkSetAllConst.Tag = "";
            this.LnkSetAllConst.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkSetConst_LinkClicked);
            // 
            // LnkSetConst
            // 
            resources.ApplyResources(this.LnkSetConst, "LnkSetConst");
            this.LnkSetConst.Name = "LnkSetConst";
            this.LnkSetConst.TabStop = true;
            this.LnkSetConst.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkSetConst_LinkClicked);
            // 
            // NUDSetConstellation
            // 
            resources.ApplyResources(this.NUDSetConstellation, "NUDSetConstellation");
            this.NUDSetConstellation.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.NUDSetConstellation.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.NUDSetConstellation.Name = "NUDSetConstellation";
            this.NUDSetConstellation.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // GrpSetStats
            // 
            resources.ApplyResources(this.GrpSetStats, "GrpSetStats");
            this.GrpSetStats.Controls.Add(this.BtnUnlockStat);
            this.GrpSetStats.Controls.Add(this.BtnLockStat);
            this.GrpSetStats.Controls.Add(this.LblStatTip);
            this.GrpSetStats.Controls.Add(this.LblStatPercent);
            this.GrpSetStats.Controls.Add(this.NUDStat);
            this.GrpSetStats.Controls.Add(this.CmbStat);
            this.GrpSetStats.Name = "GrpSetStats";
            this.GrpSetStats.TabStop = false;
            // 
            // BtnUnlockStat
            // 
            resources.ApplyResources(this.BtnUnlockStat, "BtnUnlockStat");
            this.BtnUnlockStat.Name = "BtnUnlockStat";
            this.BtnUnlockStat.UseVisualStyleBackColor = true;
            this.BtnUnlockStat.Click += new System.EventHandler(this.BtnUnlockStat_Click);
            // 
            // BtnLockStat
            // 
            resources.ApplyResources(this.BtnLockStat, "BtnLockStat");
            this.BtnLockStat.Name = "BtnLockStat";
            this.BtnLockStat.UseVisualStyleBackColor = true;
            this.BtnLockStat.Click += new System.EventHandler(this.BtnLockStat_Click);
            // 
            // LblStatTip
            // 
            this.LblStatTip.AutoEllipsis = true;
            this.LblStatTip.ForeColor = System.Drawing.SystemColors.GrayText;
            resources.ApplyResources(this.LblStatTip, "LblStatTip");
            this.LblStatTip.Name = "LblStatTip";
            // 
            // LblStatPercent
            // 
            resources.ApplyResources(this.LblStatPercent, "LblStatPercent");
            this.LblStatPercent.Name = "LblStatPercent";
            // 
            // NUDStat
            // 
            resources.ApplyResources(this.NUDStat, "NUDStat");
            this.NUDStat.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.NUDStat.Name = "NUDStat";
            this.NUDStat.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.NUDStat.ValueChanged += new System.EventHandler(this.SetStatsInputChanged);
            // 
            // CmbStat
            // 
            this.CmbStat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbStat.FormattingEnabled = true;
            resources.ApplyResources(this.CmbStat, "CmbStat");
            this.CmbStat.Name = "CmbStat";
            this.CmbStat.SelectedIndexChanged += new System.EventHandler(this.SetStatsInputChanged);
            // 
            // GrpTalentLevel
            // 
            resources.ApplyResources(this.GrpTalentLevel, "GrpTalentLevel");
            this.GrpTalentLevel.Controls.Add(this.LnkTalentAll);
            this.GrpTalentLevel.Controls.Add(this.LnkTalentE);
            this.GrpTalentLevel.Controls.Add(this.LnkTalentQ);
            this.GrpTalentLevel.Controls.Add(this.LnkTalentNormalATK);
            this.GrpTalentLevel.Controls.Add(this.NUDTalentLevel);
            this.GrpTalentLevel.Name = "GrpTalentLevel";
            this.GrpTalentLevel.TabStop = false;
            // 
            // LnkTalentAll
            // 
            resources.ApplyResources(this.LnkTalentAll, "LnkTalentAll");
            this.LnkTalentAll.Name = "LnkTalentAll";
            this.LnkTalentAll.TabStop = true;
            this.LnkTalentAll.Tag = "all";
            this.LnkTalentAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkSetTalentClicked);
            // 
            // LnkTalentE
            // 
            resources.ApplyResources(this.LnkTalentE, "LnkTalentE");
            this.LnkTalentE.Name = "LnkTalentE";
            this.LnkTalentE.TabStop = true;
            this.LnkTalentE.Tag = "e";
            this.LnkTalentE.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkSetTalentClicked);
            // 
            // LnkTalentQ
            // 
            resources.ApplyResources(this.LnkTalentQ, "LnkTalentQ");
            this.LnkTalentQ.Name = "LnkTalentQ";
            this.LnkTalentQ.TabStop = true;
            this.LnkTalentQ.Tag = "q";
            this.LnkTalentQ.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkSetTalentClicked);
            // 
            // LnkTalentNormalATK
            // 
            resources.ApplyResources(this.LnkTalentNormalATK, "LnkTalentNormalATK");
            this.LnkTalentNormalATK.Name = "LnkTalentNormalATK";
            this.LnkTalentNormalATK.TabStop = true;
            this.LnkTalentNormalATK.Tag = "n";
            this.LnkTalentNormalATK.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkSetTalentClicked);
            // 
            // NUDTalentLevel
            // 
            resources.ApplyResources(this.NUDTalentLevel, "NUDTalentLevel");
            this.NUDTalentLevel.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.NUDTalentLevel.Name = "NUDTalentLevel";
            this.NUDTalentLevel.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // GrpGiveAvatar
            // 
            resources.ApplyResources(this.GrpGiveAvatar, "GrpGiveAvatar");
            this.GrpGiveAvatar.Controls.Add(this.CmbSwitchElement);
            this.GrpGiveAvatar.Controls.Add(this.LnkSwitchElement);
            this.GrpGiveAvatar.Controls.Add(this.CmbAvatar);
            this.GrpGiveAvatar.Controls.Add(this.LblAvatarSkillLevelTip);
            this.GrpGiveAvatar.Controls.Add(this.NUDAvatarLevel);
            this.GrpGiveAvatar.Controls.Add(this.BtnGiveAllChar);
            this.GrpGiveAvatar.Controls.Add(this.LblAvatarLevel);
            this.GrpGiveAvatar.Controls.Add(this.LblAvatarSkillLevelLabel);
            this.GrpGiveAvatar.Controls.Add(this.LblAvatar);
            this.GrpGiveAvatar.Controls.Add(this.LblAvatarConstellation);
            this.GrpGiveAvatar.Controls.Add(this.NUDAvatarConstellation);
            this.GrpGiveAvatar.Controls.Add(this.NUDAvatarSkillLevel);
            this.GrpGiveAvatar.Name = "GrpGiveAvatar";
            this.GrpGiveAvatar.TabStop = false;
            // 
            // CmbSwitchElement
            // 
            this.CmbSwitchElement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSwitchElement.FormattingEnabled = true;
            this.CmbSwitchElement.Items.AddRange(new object[] {
            resources.GetString("CmbSwitchElement.Items"),
            resources.GetString("CmbSwitchElement.Items1"),
            resources.GetString("CmbSwitchElement.Items2"),
            resources.GetString("CmbSwitchElement.Items3"),
            resources.GetString("CmbSwitchElement.Items4"),
            resources.GetString("CmbSwitchElement.Items5"),
            resources.GetString("CmbSwitchElement.Items6"),
            resources.GetString("CmbSwitchElement.Items7")});
            resources.ApplyResources(this.CmbSwitchElement, "CmbSwitchElement");
            this.CmbSwitchElement.Name = "CmbSwitchElement";
            this.CmbSwitchElement.SelectedIndexChanged += new System.EventHandler(this.CmbSwitchElement_SelectedIndexChanged);
            // 
            // LnkSwitchElement
            // 
            resources.ApplyResources(this.LnkSwitchElement, "LnkSwitchElement");
            this.LnkSwitchElement.Name = "LnkSwitchElement";
            this.LnkSwitchElement.TabStop = true;
            this.LnkSwitchElement.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkSwitchElement_LinkClicked);
            // 
            // CmbAvatar
            // 
            this.CmbAvatar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbAvatar.FormattingEnabled = true;
            resources.ApplyResources(this.CmbAvatar, "CmbAvatar");
            this.CmbAvatar.Name = "CmbAvatar";
            this.CmbAvatar.SelectedIndexChanged += new System.EventHandler(this.CmbAvatar_SelectedIndexChanged);
            // 
            // LblAvatarSkillLevelTip
            // 
            resources.ApplyResources(this.LblAvatarSkillLevelTip, "LblAvatarSkillLevelTip");
            this.LblAvatarSkillLevelTip.ForeColor = System.Drawing.SystemColors.GrayText;
            this.LblAvatarSkillLevelTip.Name = "LblAvatarSkillLevelTip";
            // 
            // NUDAvatarLevel
            // 
            resources.ApplyResources(this.NUDAvatarLevel, "NUDAvatarLevel");
            this.NUDAvatarLevel.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.NUDAvatarLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDAvatarLevel.Name = "NUDAvatarLevel";
            this.NUDAvatarLevel.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.NUDAvatarLevel.ValueChanged += new System.EventHandler(this.NUDAvatarLevel_ValueChanged);
            // 
            // BtnGiveAllChar
            // 
            resources.ApplyResources(this.BtnGiveAllChar, "BtnGiveAllChar");
            this.BtnGiveAllChar.Name = "BtnGiveAllChar";
            this.BtnGiveAllChar.UseVisualStyleBackColor = true;
            this.BtnGiveAllChar.Click += new System.EventHandler(this.BtnGiveAllChar_Click);
            // 
            // LblAvatarLevel
            // 
            resources.ApplyResources(this.LblAvatarLevel, "LblAvatarLevel");
            this.LblAvatarLevel.Name = "LblAvatarLevel";
            // 
            // LblAvatarSkillLevelLabel
            // 
            resources.ApplyResources(this.LblAvatarSkillLevelLabel, "LblAvatarSkillLevelLabel");
            this.LblAvatarSkillLevelLabel.Name = "LblAvatarSkillLevelLabel";
            // 
            // LblAvatar
            // 
            resources.ApplyResources(this.LblAvatar, "LblAvatar");
            this.LblAvatar.Name = "LblAvatar";
            // 
            // LblAvatarConstellation
            // 
            resources.ApplyResources(this.LblAvatarConstellation, "LblAvatarConstellation");
            this.LblAvatarConstellation.Name = "LblAvatarConstellation";
            // 
            // NUDAvatarConstellation
            // 
            resources.ApplyResources(this.NUDAvatarConstellation, "NUDAvatarConstellation");
            this.NUDAvatarConstellation.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.NUDAvatarConstellation.Name = "NUDAvatarConstellation";
            this.NUDAvatarConstellation.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.NUDAvatarConstellation.ValueChanged += new System.EventHandler(this.NUDAvatarConstellation_ValueChanged);
            // 
            // NUDAvatarSkillLevel
            // 
            resources.ApplyResources(this.NUDAvatarSkillLevel, "NUDAvatarSkillLevel");
            this.NUDAvatarSkillLevel.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.NUDAvatarSkillLevel.Name = "NUDAvatarSkillLevel";
            this.NUDAvatarSkillLevel.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NUDAvatarSkillLevel.ValueChanged += new System.EventHandler(this.NUDAvatarConstellation_ValueChanged);
            // 
            // TPSpawn
            // 
            resources.ApplyResources(this.TPSpawn, "TPSpawn");
            this.TPSpawn.Name = "TPSpawn";
            this.TPSpawn.UseVisualStyleBackColor = true;
            // 
            // TPQuest
            // 
            this.TPQuest.Controls.Add(this.GrpQuestFilters);
            this.TPQuest.Controls.Add(this.BtnFinishQuest);
            this.TPQuest.Controls.Add(this.BtnAddQuest);
            this.TPQuest.Controls.Add(this.LblQuestDescription);
            this.TPQuest.Controls.Add(this.TxtQuestFilter);
            this.TPQuest.Controls.Add(this.ListQuest);
            resources.ApplyResources(this.TPQuest, "TPQuest");
            this.TPQuest.Name = "TPQuest";
            this.TPQuest.UseVisualStyleBackColor = true;
            // 
            // GrpQuestFilters
            // 
            resources.ApplyResources(this.GrpQuestFilters, "GrpQuestFilters");
            this.GrpQuestFilters.Controls.Add(this.ChkQuestFilterTEST);
            this.GrpQuestFilters.Controls.Add(this.ChkQuestFilterUNRELEASED);
            this.GrpQuestFilters.Controls.Add(this.ChkQuestFilterHIDDEN);
            this.GrpQuestFilters.Name = "GrpQuestFilters";
            this.GrpQuestFilters.TabStop = false;
            // 
            // ChkQuestFilterTEST
            // 
            resources.ApplyResources(this.ChkQuestFilterTEST, "ChkQuestFilterTEST");
            this.ChkQuestFilterTEST.Name = "ChkQuestFilterTEST";
            this.ChkQuestFilterTEST.Tag = "(test)";
            this.ChkQuestFilterTEST.UseVisualStyleBackColor = true;
            this.ChkQuestFilterTEST.CheckedChanged += new System.EventHandler(this.QuestFilterChanged);
            // 
            // ChkQuestFilterUNRELEASED
            // 
            resources.ApplyResources(this.ChkQuestFilterUNRELEASED, "ChkQuestFilterUNRELEASED");
            this.ChkQuestFilterUNRELEASED.Name = "ChkQuestFilterUNRELEASED";
            this.ChkQuestFilterUNRELEASED.Tag = "$UNRELEASED";
            this.ChkQuestFilterUNRELEASED.UseVisualStyleBackColor = true;
            this.ChkQuestFilterUNRELEASED.CheckedChanged += new System.EventHandler(this.QuestFilterChanged);
            // 
            // ChkQuestFilterHIDDEN
            // 
            resources.ApplyResources(this.ChkQuestFilterHIDDEN, "ChkQuestFilterHIDDEN");
            this.ChkQuestFilterHIDDEN.Name = "ChkQuestFilterHIDDEN";
            this.ChkQuestFilterHIDDEN.Tag = "$HIDDEN";
            this.ChkQuestFilterHIDDEN.UseVisualStyleBackColor = true;
            this.ChkQuestFilterHIDDEN.CheckedChanged += new System.EventHandler(this.QuestFilterChanged);
            // 
            // BtnFinishQuest
            // 
            resources.ApplyResources(this.BtnFinishQuest, "BtnFinishQuest");
            this.BtnFinishQuest.Name = "BtnFinishQuest";
            this.BtnFinishQuest.Tag = "finish";
            this.BtnFinishQuest.UseVisualStyleBackColor = true;
            this.BtnFinishQuest.Click += new System.EventHandler(this.QuestButsClicked);
            // 
            // BtnAddQuest
            // 
            resources.ApplyResources(this.BtnAddQuest, "BtnAddQuest");
            this.BtnAddQuest.Name = "BtnAddQuest";
            this.BtnAddQuest.Tag = "add";
            this.BtnAddQuest.UseVisualStyleBackColor = true;
            this.BtnAddQuest.Click += new System.EventHandler(this.QuestButsClicked);
            // 
            // LblQuestDescription
            // 
            resources.ApplyResources(this.LblQuestDescription, "LblQuestDescription");
            this.LblQuestDescription.Name = "LblQuestDescription";
            // 
            // TxtQuestFilter
            // 
            resources.ApplyResources(this.TxtQuestFilter, "TxtQuestFilter");
            this.TxtQuestFilter.Name = "TxtQuestFilter";
            this.TxtQuestFilter.TextChanged += new System.EventHandler(this.QuestFilterChanged);
            // 
            // ListQuest
            // 
            resources.ApplyResources(this.ListQuest, "ListQuest");
            this.ListQuest.FormattingEnabled = true;
            this.ListQuest.Name = "ListQuest";
            // 
            // TPArtifact
            // 
            resources.ApplyResources(this.TPArtifact, "TPArtifact");
            this.TPArtifact.Name = "TPArtifact";
            this.TPArtifact.UseVisualStyleBackColor = true;
            // 
            // TPCustom
            // 
            resources.ApplyResources(this.TPCustom, "TPCustom");
            this.TPCustom.Name = "TPCustom";
            this.TPCustom.UseVisualStyleBackColor = true;
            // 
            // TPHome
            // 
            resources.ApplyResources(this.TPHome, "TPHome");
            this.TPHome.Name = "TPHome";
            this.TPHome.UseVisualStyleBackColor = true;
            // 
            // TCMain
            // 
            resources.ApplyResources(this.TCMain, "TCMain");
            this.TCMain.Controls.Add(this.TPHome);
            this.TCMain.Controls.Add(this.TPRemoteCall);
            this.TCMain.Controls.Add(this.TPCustom);
            this.TCMain.Controls.Add(this.TPArtifact);
            this.TCMain.Controls.Add(this.TPSpawn);
            this.TCMain.Controls.Add(this.TPItem);
            this.TCMain.Controls.Add(this.TPAvatar);
            this.TCMain.Controls.Add(this.TPWeapon);
            this.TCMain.Controls.Add(this.TPManage);
            this.TCMain.Controls.Add(this.TPMail);
            this.TCMain.Controls.Add(this.TPQuest);
            this.TCMain.Controls.Add(this.TPScene);
            this.TCMain.Controls.Add(this.TPAbout);
            this.TCMain.Name = "TCMain";
            this.TCMain.SelectedIndex = 0;
            // 
            // TPMail
            // 
            this.TPMail.Controls.Add(this.LblClearMailContent);
            this.TPMail.Controls.Add(this.BtnAddMailItem);
            this.TPMail.Controls.Add(this.BtnDeleteMailItem);
            this.TPMail.Controls.Add(this.TCMailRight);
            this.TPMail.Controls.Add(this.BtnSendMail);
            this.TPMail.Controls.Add(this.ListMailItems);
            this.TPMail.Controls.Add(this.LblMailItemsLabel);
            this.TPMail.Controls.Add(this.NUDMailRecipient);
            this.TPMail.Controls.Add(this.RbMailSendToPlayer);
            this.TPMail.Controls.Add(this.RbMailSendToAll);
            this.TPMail.Controls.Add(this.LblMailRecipientLabel);
            this.TPMail.Controls.Add(this.TxtMailContent);
            this.TPMail.Controls.Add(this.LblMailContentLabel);
            this.TPMail.Controls.Add(this.TxtMailTitle);
            this.TPMail.Controls.Add(this.LblMailTitleLabel);
            this.TPMail.Controls.Add(this.TxtMailSender);
            this.TPMail.Controls.Add(this.LblMailSenderLabel);
            resources.ApplyResources(this.TPMail, "TPMail");
            this.TPMail.Name = "TPMail";
            this.TPMail.UseVisualStyleBackColor = true;
            // 
            // LblClearMailContent
            // 
            resources.ApplyResources(this.LblClearMailContent, "LblClearMailContent");
            this.LblClearMailContent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblClearMailContent.Name = "LblClearMailContent";
            this.LblClearMailContent.Click += new System.EventHandler(this.LblClearMailContent_Click);
            // 
            // BtnAddMailItem
            // 
            resources.ApplyResources(this.BtnAddMailItem, "BtnAddMailItem");
            this.BtnAddMailItem.Name = "BtnAddMailItem";
            this.BtnAddMailItem.UseVisualStyleBackColor = true;
            this.BtnAddMailItem.Click += new System.EventHandler(this.BtnAddMailItem_Click);
            // 
            // BtnDeleteMailItem
            // 
            resources.ApplyResources(this.BtnDeleteMailItem, "BtnDeleteMailItem");
            this.BtnDeleteMailItem.Name = "BtnDeleteMailItem";
            this.BtnDeleteMailItem.UseVisualStyleBackColor = true;
            this.BtnDeleteMailItem.Click += new System.EventHandler(this.BtnDeleteMailItem_Click);
            // 
            // TCMailRight
            // 
            resources.ApplyResources(this.TCMailRight, "TCMailRight");
            this.TCMailRight.Controls.Add(this.TPMailSelectableItemList);
            this.TCMailRight.Controls.Add(this.TPMailList);
            this.TCMailRight.Name = "TCMailRight";
            this.TCMailRight.SelectedIndex = 0;
            // 
            // TPMailSelectableItemList
            // 
            this.TPMailSelectableItemList.Controls.Add(this.ListMailSelectableItems);
            this.TPMailSelectableItemList.Controls.Add(this.TxtMailSelectableItemFilter);
            this.TPMailSelectableItemList.Controls.Add(this.PanelMailItemArgs);
            resources.ApplyResources(this.TPMailSelectableItemList, "TPMailSelectableItemList");
            this.TPMailSelectableItemList.Name = "TPMailSelectableItemList";
            this.TPMailSelectableItemList.UseVisualStyleBackColor = true;
            // 
            // ListMailSelectableItems
            // 
            resources.ApplyResources(this.ListMailSelectableItems, "ListMailSelectableItems");
            this.ListMailSelectableItems.FormattingEnabled = true;
            this.ListMailSelectableItems.Name = "ListMailSelectableItems";
            // 
            // TxtMailSelectableItemFilter
            // 
            resources.ApplyResources(this.TxtMailSelectableItemFilter, "TxtMailSelectableItemFilter");
            this.TxtMailSelectableItemFilter.Name = "TxtMailSelectableItemFilter";
            this.TxtMailSelectableItemFilter.TextChanged += new System.EventHandler(this.TxtMailSelectableItemFilter_TextChanged);
            // 
            // PanelMailItemArgs
            // 
            this.PanelMailItemArgs.Controls.Add(this.NUDMailItemLevel);
            this.PanelMailItemArgs.Controls.Add(this.NUDMailItemCount);
            this.PanelMailItemArgs.Controls.Add(this.LblMailItemCount);
            this.PanelMailItemArgs.Controls.Add(this.LblMailItemLevel);
            resources.ApplyResources(this.PanelMailItemArgs, "PanelMailItemArgs");
            this.PanelMailItemArgs.Name = "PanelMailItemArgs";
            // 
            // NUDMailItemLevel
            // 
            resources.ApplyResources(this.NUDMailItemLevel, "NUDMailItemLevel");
            this.NUDMailItemLevel.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.NUDMailItemLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDMailItemLevel.Name = "NUDMailItemLevel";
            this.NUDMailItemLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NUDMailItemCount
            // 
            resources.ApplyResources(this.NUDMailItemCount, "NUDMailItemCount");
            this.NUDMailItemCount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NUDMailItemCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDMailItemCount.Name = "NUDMailItemCount";
            this.NUDMailItemCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LblMailItemCount
            // 
            resources.ApplyResources(this.LblMailItemCount, "LblMailItemCount");
            this.LblMailItemCount.Name = "LblMailItemCount";
            // 
            // LblMailItemLevel
            // 
            resources.ApplyResources(this.LblMailItemLevel, "LblMailItemLevel");
            this.LblMailItemLevel.Name = "LblMailItemLevel";
            // 
            // TPMailList
            // 
            this.TPMailList.Controls.Add(this.ListMailList);
            this.TPMailList.Controls.Add(this.PanelMailListControls);
            resources.ApplyResources(this.TPMailList, "TPMailList");
            this.TPMailList.Name = "TPMailList";
            this.TPMailList.UseVisualStyleBackColor = true;
            // 
            // ListMailList
            // 
            resources.ApplyResources(this.ListMailList, "ListMailList");
            this.ListMailList.FormattingEnabled = true;
            this.ListMailList.Name = "ListMailList";
            this.ListMailList.SelectedIndexChanged += new System.EventHandler(this.ListMailList_SelectedIndexChanged);
            // 
            // PanelMailListControls
            // 
            this.PanelMailListControls.Controls.Add(this.BtnClearMail);
            this.PanelMailListControls.Controls.Add(this.BtnRemoveMail);
            resources.ApplyResources(this.PanelMailListControls, "PanelMailListControls");
            this.PanelMailListControls.Name = "PanelMailListControls";
            // 
            // BtnClearMail
            // 
            resources.ApplyResources(this.BtnClearMail, "BtnClearMail");
            this.BtnClearMail.Name = "BtnClearMail";
            this.BtnClearMail.UseVisualStyleBackColor = true;
            this.BtnClearMail.Click += new System.EventHandler(this.BtnClearMail_Click);
            // 
            // BtnRemoveMail
            // 
            resources.ApplyResources(this.BtnRemoveMail, "BtnRemoveMail");
            this.BtnRemoveMail.Name = "BtnRemoveMail";
            this.BtnRemoveMail.UseVisualStyleBackColor = true;
            this.BtnRemoveMail.Click += new System.EventHandler(this.BtnRemoveMail_Click);
            // 
            // BtnSendMail
            // 
            resources.ApplyResources(this.BtnSendMail, "BtnSendMail");
            this.BtnSendMail.Name = "BtnSendMail";
            this.BtnSendMail.UseVisualStyleBackColor = true;
            this.BtnSendMail.Click += new System.EventHandler(this.BtnSendMail_Click);
            // 
            // ListMailItems
            // 
            resources.ApplyResources(this.ListMailItems, "ListMailItems");
            this.ListMailItems.FormattingEnabled = true;
            this.ListMailItems.Name = "ListMailItems";
            // 
            // LblMailItemsLabel
            // 
            resources.ApplyResources(this.LblMailItemsLabel, "LblMailItemsLabel");
            this.LblMailItemsLabel.Name = "LblMailItemsLabel";
            // 
            // NUDMailRecipient
            // 
            resources.ApplyResources(this.NUDMailRecipient, "NUDMailRecipient");
            this.NUDMailRecipient.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDMailRecipient.Name = "NUDMailRecipient";
            this.NUDMailRecipient.Value = new decimal(new int[] {
            10001,
            0,
            0,
            0});
            // 
            // RbMailSendToPlayer
            // 
            resources.ApplyResources(this.RbMailSendToPlayer, "RbMailSendToPlayer");
            this.RbMailSendToPlayer.Name = "RbMailSendToPlayer";
            this.RbMailSendToPlayer.UseVisualStyleBackColor = true;
            // 
            // RbMailSendToAll
            // 
            resources.ApplyResources(this.RbMailSendToAll, "RbMailSendToAll");
            this.RbMailSendToAll.Checked = true;
            this.RbMailSendToAll.Name = "RbMailSendToAll";
            this.RbMailSendToAll.TabStop = true;
            this.RbMailSendToAll.UseVisualStyleBackColor = true;
            // 
            // LblMailRecipientLabel
            // 
            resources.ApplyResources(this.LblMailRecipientLabel, "LblMailRecipientLabel");
            this.LblMailRecipientLabel.Name = "LblMailRecipientLabel";
            // 
            // TxtMailContent
            // 
            resources.ApplyResources(this.TxtMailContent, "TxtMailContent");
            this.TxtMailContent.Name = "TxtMailContent";
            // 
            // LblMailContentLabel
            // 
            resources.ApplyResources(this.LblMailContentLabel, "LblMailContentLabel");
            this.LblMailContentLabel.Name = "LblMailContentLabel";
            // 
            // TxtMailTitle
            // 
            resources.ApplyResources(this.TxtMailTitle, "TxtMailTitle");
            this.TxtMailTitle.Name = "TxtMailTitle";
            // 
            // LblMailTitleLabel
            // 
            resources.ApplyResources(this.LblMailTitleLabel, "LblMailTitleLabel");
            this.LblMailTitleLabel.Name = "LblMailTitleLabel";
            // 
            // TxtMailSender
            // 
            resources.ApplyResources(this.TxtMailSender, "TxtMailSender");
            this.TxtMailSender.Name = "TxtMailSender";
            // 
            // LblMailSenderLabel
            // 
            resources.ApplyResources(this.LblMailSenderLabel, "LblMailSenderLabel");
            this.LblMailSenderLabel.Name = "LblMailSenderLabel";
            // 
            // MenuSpawnEntityFilter
            // 
            this.MenuSpawnEntityFilter.Name = "MenuSpawnEntityFilter";
            resources.ApplyResources(this.MenuSpawnEntityFilter, "MenuSpawnEntityFilter");
            // 
            // TxtBanReason
            // 
            this.TxtBanReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.TxtBanReason, "TxtBanReason");
            this.TxtBanReason.Maximum = 0F;
            this.TxtBanReason.Minimum = 0F;
            this.TxtBanReason.Name = "TxtBanReason";
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TCMain);
            this.Controls.Add(this.GrpCommand);
            this.KeyPreview = true;
            this.Name = "FormMain";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.GrpCommand.ResumeLayout(false);
            this.GrpCommand.PerformLayout();
            this.TPAbout.ResumeLayout(false);
            this.TPAbout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrasscutterToolsSupport)).EndInit();
            this.TPManage.ResumeLayout(false);
            this.GrpBanPlayer.ResumeLayout(false);
            this.GrpBanPlayer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDBanUID)).EndInit();
            this.GrpAccount.ResumeLayout(false);
            this.GrpAccount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDAccountUid)).EndInit();
            this.GrpPermission.ResumeLayout(false);
            this.GrpPermission.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDPermUID)).EndInit();
            this.TPScene.ResumeLayout(false);
            this.TPScene.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDTpZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDTpY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDTpX)).EndInit();
            this.TPItem.ResumeLayout(false);
            this.TPItem.PerformLayout();
            this.GrpGiveItemRecord.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NUDGameItemAmout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDGameItemLevel)).EndInit();
            this.TPAvatar.ResumeLayout(false);
            this.GrpSetConstellation.ResumeLayout(false);
            this.GrpSetConstellation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDSetConstellation)).EndInit();
            this.GrpSetStats.ResumeLayout(false);
            this.GrpSetStats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDStat)).EndInit();
            this.GrpTalentLevel.ResumeLayout(false);
            this.GrpTalentLevel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDTalentLevel)).EndInit();
            this.GrpGiveAvatar.ResumeLayout(false);
            this.GrpGiveAvatar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDAvatarLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDAvatarConstellation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDAvatarSkillLevel)).EndInit();
            this.TPQuest.ResumeLayout(false);
            this.TPQuest.PerformLayout();
            this.GrpQuestFilters.ResumeLayout(false);
            this.GrpQuestFilters.PerformLayout();
            this.TCMain.ResumeLayout(false);
            this.TPMail.ResumeLayout(false);
            this.TPMail.PerformLayout();
            this.TCMailRight.ResumeLayout(false);
            this.TPMailSelectableItemList.ResumeLayout(false);
            this.TPMailSelectableItemList.PerformLayout();
            this.PanelMailItemArgs.ResumeLayout(false);
            this.PanelMailItemArgs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDMailItemLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDMailItemCount)).EndInit();
            this.TPMailList.ResumeLayout(false);
            this.PanelMailListControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NUDMailRecipient)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbCommand;
        private System.Windows.Forms.Button BtnCopy;
        private System.Windows.Forms.CheckBox ChkAutoCopy;
        private System.Windows.Forms.GroupBox GrpCommand;
        private System.Windows.Forms.Button BtnInvokeOpenCommand;
        private System.Windows.Forms.TabPage TPRemoteCall;
        private System.Windows.Forms.TabPage TPAbout;
        private System.Windows.Forms.PictureBox GrasscutterToolsSupport;
        private System.Windows.Forms.LinkLabel LnkGithub;
        private System.Windows.Forms.Label LblSupportDescription;
        private System.Windows.Forms.TabPage TPManage;
        private System.Windows.Forms.GroupBox GrpBanPlayer;
        private System.Windows.Forms.DateTimePicker DTPBanEndTime;
        private System.Windows.Forms.Button BtnUnban;
        private System.Windows.Forms.Button BtnBan;
        private Controls.TextBoxXP TxtBanReason;
        private System.Windows.Forms.NumericUpDown NUDBanUID;
        private System.Windows.Forms.Label LblBanUID;
        private System.Windows.Forms.GroupBox GrpAccount;
        private System.Windows.Forms.CheckBox ChkAccountSetUid;
        private System.Windows.Forms.NumericUpDown NUDAccountUid;
        private System.Windows.Forms.Button BtnDeleteAccount;
        private System.Windows.Forms.Button BtnCreateAccount;
        private System.Windows.Forms.Label LblAccountUserName;
        private System.Windows.Forms.TextBox TxtAccountUserName;
        private System.Windows.Forms.GroupBox GrpPermission;
        private System.Windows.Forms.ComboBox CmbPerm;
        private System.Windows.Forms.NumericUpDown NUDPermUID;
        private System.Windows.Forms.Button BtmPermRemove;
        private System.Windows.Forms.Button BtnPermAdd;
        private System.Windows.Forms.Label LblPerm;
        private System.Windows.Forms.Label LblPermUID;
        private System.Windows.Forms.TabPage TPScene;
        private System.Windows.Forms.TextBox TxtSceneFilter;
        private System.Windows.Forms.CheckBox ChkIncludeSceneId;
        private System.Windows.Forms.Label LblTp;
        private System.Windows.Forms.Label LblTpZ;
        private System.Windows.Forms.Label LblTpY;
        private System.Windows.Forms.Button BtnTeleport;
        private System.Windows.Forms.Label LblTpX;
        private System.Windows.Forms.NumericUpDown NUDTpZ;
        private System.Windows.Forms.NumericUpDown NUDTpY;
        private System.Windows.Forms.NumericUpDown NUDTpX;
        private System.Windows.Forms.ComboBox CmbClimateType;
        private System.Windows.Forms.Label LblClimateType;
        private System.Windows.Forms.Label LblSceneDescription;
        private System.Windows.Forms.ListBox ListScenes;
        private System.Windows.Forms.TabPage TPItem;
        private System.Windows.Forms.Button BtnSaveGiveItemLog;
        private System.Windows.Forms.Button BtnRemoveGiveItemLog;
        private System.Windows.Forms.GroupBox GrpGiveItemRecord;
        private System.Windows.Forms.ListBox ListGiveItemLogs;
        private System.Windows.Forms.CheckBox ChkDrop;
        private System.Windows.Forms.TextBox TxtGameItemFilter;
        private System.Windows.Forms.ListBox ListGameItems;
        private System.Windows.Forms.Label LblGameItemAmount;
        private System.Windows.Forms.Label LblGameItemLevel;
        private System.Windows.Forms.NumericUpDown NUDGameItemAmout;
        private System.Windows.Forms.NumericUpDown NUDGameItemLevel;
        private System.Windows.Forms.Label LblGiveCommandDescription;
        private System.Windows.Forms.TabPage TPWeapon;
        private System.Windows.Forms.TabPage TPAvatar;
        private System.Windows.Forms.Label LblAvatar;
        private System.Windows.Forms.Label LblAvatarLevel;
        private System.Windows.Forms.NumericUpDown NUDAvatarLevel;
        private System.Windows.Forms.ComboBox CmbAvatar;
        private System.Windows.Forms.TabPage TPSpawn;
        private System.Windows.Forms.TabPage TPQuest;
        private System.Windows.Forms.GroupBox GrpQuestFilters;
        private System.Windows.Forms.CheckBox ChkQuestFilterTEST;
        private System.Windows.Forms.CheckBox ChkQuestFilterUNRELEASED;
        private System.Windows.Forms.CheckBox ChkQuestFilterHIDDEN;
        private System.Windows.Forms.Button BtnFinishQuest;
        private System.Windows.Forms.Button BtnAddQuest;
        private System.Windows.Forms.Label LblQuestDescription;
        private System.Windows.Forms.TextBox TxtQuestFilter;
        private System.Windows.Forms.ListBox ListQuest;
        private System.Windows.Forms.TabPage TPArtifact;
        private System.Windows.Forms.TabPage TPCustom;
        private System.Windows.Forms.TabPage TPHome;
        private System.Windows.Forms.TabControl TCMain;
        private System.Windows.Forms.Label LblClearGiveItemLogs;
        private System.Windows.Forms.Label LblAvatarConstellation;
        private System.Windows.Forms.NumericUpDown NUDAvatarConstellation;
        private System.Windows.Forms.Button BtnGiveAllChar;
        private System.Windows.Forms.Button BtnPermClear;
        private System.Windows.Forms.Button BtnPermList;
        private System.Windows.Forms.NumericUpDown NUDAvatarSkillLevel;
        private System.Windows.Forms.Label LblAvatarSkillLevelLabel;
        private System.Windows.Forms.Label LblAvatarSkillLevelTip;
        private System.Windows.Forms.TabPage TPMail;
        private System.Windows.Forms.TextBox TxtMailContent;
        private System.Windows.Forms.Label LblMailContentLabel;
        private System.Windows.Forms.TextBox TxtMailTitle;
        private System.Windows.Forms.Label LblMailTitleLabel;
        private System.Windows.Forms.TextBox TxtMailSender;
        private System.Windows.Forms.Label LblMailSenderLabel;
        private System.Windows.Forms.ListBox ListMailItems;
        private System.Windows.Forms.Label LblMailItemsLabel;
        private System.Windows.Forms.NumericUpDown NUDMailRecipient;
        private System.Windows.Forms.RadioButton RbMailSendToPlayer;
        private System.Windows.Forms.RadioButton RbMailSendToAll;
        private System.Windows.Forms.Label LblMailRecipientLabel;
        private System.Windows.Forms.Button BtnSendMail;
        private System.Windows.Forms.TextBox TxtMailSelectableItemFilter;
        private System.Windows.Forms.ListBox ListMailSelectableItems;
        private System.Windows.Forms.NumericUpDown NUDMailItemLevel;
        private System.Windows.Forms.Label LblMailItemLevel;
        private System.Windows.Forms.NumericUpDown NUDMailItemCount;
        private System.Windows.Forms.Label LblMailItemCount;
        private System.Windows.Forms.TabControl TCMailRight;
        private System.Windows.Forms.TabPage TPMailSelectableItemList;
        private System.Windows.Forms.TabPage TPMailList;
        private System.Windows.Forms.ListBox ListMailList;
        private System.Windows.Forms.Button BtnClearMail;
        private System.Windows.Forms.Button BtnRemoveMail;
        private System.Windows.Forms.Button BtnAddMailItem;
        private System.Windows.Forms.Button BtnDeleteMailItem;
        private System.Windows.Forms.Label LblClearMailContent;
        private System.Windows.Forms.GroupBox GrpSetStats;
        private System.Windows.Forms.Button BtnUnlockStat;
        private System.Windows.Forms.Button BtnLockStat;
        private System.Windows.Forms.Label LblStatTip;
        private System.Windows.Forms.Label LblStatPercent;
        private System.Windows.Forms.NumericUpDown NUDStat;
        private System.Windows.Forms.ComboBox CmbStat;
        private System.Windows.Forms.GroupBox GrpTalentLevel;
        private System.Windows.Forms.LinkLabel LnkTalentAll;
        private System.Windows.Forms.LinkLabel LnkTalentE;
        private System.Windows.Forms.LinkLabel LnkTalentQ;
        private System.Windows.Forms.LinkLabel LnkTalentNormalATK;
        private System.Windows.Forms.NumericUpDown NUDTalentLevel;
        private System.Windows.Forms.GroupBox GrpGiveAvatar;
        private System.Windows.Forms.Panel PanelMailItemArgs;
        private System.Windows.Forms.Panel PanelMailListControls;
        private System.Windows.Forms.GroupBox GrpSetConstellation;
        private System.Windows.Forms.LinkLabel LnkSetAllConst;
        private System.Windows.Forms.LinkLabel LnkSetConst;
        private System.Windows.Forms.NumericUpDown NUDSetConstellation;
        private System.Windows.Forms.ContextMenuStrip MenuSpawnEntityFilter;
        private System.Windows.Forms.ComboBox CmbSwitchElement;
        private System.Windows.Forms.LinkLabel LnkSwitchElement;
        private System.Windows.Forms.RadioButton RbListDungeons;
        private System.Windows.Forms.RadioButton RbListScene;
    }
}
