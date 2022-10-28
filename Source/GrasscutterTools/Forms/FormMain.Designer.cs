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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.TxtCommand = new System.Windows.Forms.TextBox();
            this.BtnCopy = new System.Windows.Forms.Button();
            this.ChkAutoCopy = new System.Windows.Forms.CheckBox();
            this.GrpCommand = new System.Windows.Forms.GroupBox();
            this.BtnInvokeOpenCommand = new System.Windows.Forms.Button();
            this.TPRemoteCall = new System.Windows.Forms.TabPage();
            this.LnkLinks = new System.Windows.Forms.LinkLabel();
            this.LnkGOODHelp = new System.Windows.Forms.LinkLabel();
            this.LnkInventoryKamera = new System.Windows.Forms.LinkLabel();
            this.LblGOODHelp = new System.Windows.Forms.Label();
            this.ButtonOpenGOODImport = new System.Windows.Forms.Button();
            this.LblHostTip = new System.Windows.Forms.Label();
            this.GrpServerStatus = new System.Windows.Forms.GroupBox();
            this.LnkOpenCommandLabel = new System.Windows.Forms.LinkLabel();
            this.LblOpenCommandSupport = new System.Windows.Forms.Label();
            this.LblServerVersion = new System.Windows.Forms.Label();
            this.LblPlayerCount = new System.Windows.Forms.Label();
            this.LblServerVersionLabel = new System.Windows.Forms.Label();
            this.LblPlayerCountLabel = new System.Windows.Forms.Label();
            this.GrpRemoteCommand = new System.Windows.Forms.GroupBox();
            this.TPOpenCommandCheck = new System.Windows.Forms.TabControl();
            this.TPPlayerCheck = new System.Windows.Forms.TabPage();
            this.LnkRCHelp = new System.Windows.Forms.LinkLabel();
            this.NUDRemotePlayerId = new System.Windows.Forms.NumericUpDown();
            this.BtnConnectOpenCommand = new System.Windows.Forms.Button();
            this.LblVerificationCode = new System.Windows.Forms.Label();
            this.BtnSendVerificationCode = new System.Windows.Forms.Button();
            this.NUDVerificationCode = new System.Windows.Forms.NumericUpDown();
            this.LblRemotePlayerId = new System.Windows.Forms.Label();
            this.TPConsoleCheck = new System.Windows.Forms.TabPage();
            this.BtnConsoleConnect = new System.Windows.Forms.Button();
            this.TxtToken = new System.Windows.Forms.TextBox();
            this.LblToken = new System.Windows.Forms.Label();
            this.LblConsoleTip = new System.Windows.Forms.Label();
            this.TxtHost = new System.Windows.Forms.TextBox();
            this.BtnQueryServerStatus = new System.Windows.Forms.Button();
            this.LblHost = new System.Windows.Forms.Label();
            this.TPAbout = new System.Windows.Forms.TabPage();
            this.GrasscutterToolsSupport = new System.Windows.Forms.PictureBox();
            this.LnkGithub = new System.Windows.Forms.LinkLabel();
            this.LblSupportDescription = new System.Windows.Forms.Label();
            this.TPManage = new System.Windows.Forms.TabPage();
            this.GrpBanPlayer = new System.Windows.Forms.GroupBox();
            this.DTPBanEndTime = new System.Windows.Forms.DateTimePicker();
            this.BtnUnban = new System.Windows.Forms.Button();
            this.BtnBan = new System.Windows.Forms.Button();
            this.TxtBanReason = new GrasscutterTools.Controls.TextBoxXP();
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
            this.ChkInfiniteHP = new System.Windows.Forms.CheckBox();
            this.LblClearSpawnLogs = new System.Windows.Forms.Label();
            this.BtnSaveSpawnLog = new System.Windows.Forms.Button();
            this.BtnRemoveSpawnLog = new System.Windows.Forms.Button();
            this.GrpSpawnRecord = new System.Windows.Forms.GroupBox();
            this.ListSpawnLogs = new System.Windows.Forms.ListBox();
            this.GrpEntityType = new System.Windows.Forms.GroupBox();
            this.RbEntityAnimal = new System.Windows.Forms.RadioButton();
            this.RbEntityMonster = new System.Windows.Forms.RadioButton();
            this.LblSpawnDescription = new System.Windows.Forms.Label();
            this.LblEntityAmount = new System.Windows.Forms.Label();
            this.LblEntityLevel = new System.Windows.Forms.Label();
            this.NUDEntityAmout = new System.Windows.Forms.NumericUpDown();
            this.NUDEntityLevel = new System.Windows.Forms.NumericUpDown();
            this.TxtEntityFilter = new System.Windows.Forms.TextBox();
            this.ListEntity = new System.Windows.Forms.ListBox();
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
            this.TPCustom = new System.Windows.Forms.TabPage();
            this.BtnExportCustomCommands = new System.Windows.Forms.Button();
            this.BtnLoadCustomCommands = new System.Windows.Forms.Button();
            this.LblCustomName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LnkResetCustomCommands = new System.Windows.Forms.LinkLabel();
            this.FLPCustomCommands = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnRemoveCustomCommand = new System.Windows.Forms.Button();
            this.BtnSaveCustomCommand = new System.Windows.Forms.Button();
            this.TxtCustomName = new System.Windows.Forms.TextBox();
            this.TPHome = new System.Windows.Forms.TabPage();
            this.BtnOpenDropEditor = new System.Windows.Forms.Button();
            this.LnkNewVersion = new System.Windows.Forms.LinkLabel();
            this.LblAbout = new System.Windows.Forms.Label();
            this.BtnOpenTextMap = new System.Windows.Forms.Button();
            this.BtnOpenGachaBannerEditor = new System.Windows.Forms.Button();
            this.GrasscutterToolsIcon = new System.Windows.Forms.PictureBox();
            this.GrpSettings = new System.Windows.Forms.GroupBox();
            this.LblGCVersion = new System.Windows.Forms.Label();
            this.CmbGcVersions = new System.Windows.Forms.ComboBox();
            this.ChkTopMost = new System.Windows.Forms.CheckBox();
            this.CmbLanguage = new System.Windows.Forms.ComboBox();
            this.LblLanguage = new System.Windows.Forms.Label();
            this.NUDUid = new System.Windows.Forms.NumericUpDown();
            this.ChkIncludeUID = new System.Windows.Forms.CheckBox();
            this.LblDefaultUid = new System.Windows.Forms.Label();
            this.TCMain = new System.Windows.Forms.TabControl();
            this.TPMail = new System.Windows.Forms.TabPage();
            this.LblClearMailContent = new System.Windows.Forms.Label();
            this.BtnAddMailItem = new System.Windows.Forms.Button();
            this.BtnDeleteMailItem = new System.Windows.Forms.Button();
            this.TCMailRight = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.TxtMailSelectableItemFilter = new System.Windows.Forms.TextBox();
            this.ListMailSelectableItems = new System.Windows.Forms.ListBox();
            this.PanelMailItemArgs = new System.Windows.Forms.Panel();
            this.NUDMailItemLevel = new System.Windows.Forms.NumericUpDown();
            this.NUDMailItemCount = new System.Windows.Forms.NumericUpDown();
            this.LblMailItemCount = new System.Windows.Forms.Label();
            this.LblMailItemLevel = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
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
            this.GrpCommand.SuspendLayout();
            this.TPRemoteCall.SuspendLayout();
            this.GrpServerStatus.SuspendLayout();
            this.GrpRemoteCommand.SuspendLayout();
            this.TPOpenCommandCheck.SuspendLayout();
            this.TPPlayerCheck.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDRemotePlayerId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDVerificationCode)).BeginInit();
            this.TPConsoleCheck.SuspendLayout();
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
            this.TPWeapon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDWeaponRefinement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDWeaponAmout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDWeaponLevel)).BeginInit();
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
            this.TPSpawn.SuspendLayout();
            this.GrpSpawnRecord.SuspendLayout();
            this.GrpEntityType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDEntityAmout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDEntityLevel)).BeginInit();
            this.TPQuest.SuspendLayout();
            this.GrpQuestFilters.SuspendLayout();
            this.TPArtifact.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDSubAttributionTimes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDArtifactLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDArtifactStars)).BeginInit();
            this.TPCustom.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.TPHome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrasscutterToolsIcon)).BeginInit();
            this.GrpSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDUid)).BeginInit();
            this.TCMain.SuspendLayout();
            this.TPMail.SuspendLayout();
            this.TCMailRight.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.PanelMailItemArgs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDMailItemLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDMailItemCount)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.PanelMailListControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDMailRecipient)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtCommand
            // 
            resources.ApplyResources(this.TxtCommand, "TxtCommand");
            this.TxtCommand.Name = "TxtCommand";
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
            this.GrpCommand.Controls.Add(this.TxtCommand);
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
            this.TPRemoteCall.Controls.Add(this.LnkLinks);
            this.TPRemoteCall.Controls.Add(this.LnkGOODHelp);
            this.TPRemoteCall.Controls.Add(this.LnkInventoryKamera);
            this.TPRemoteCall.Controls.Add(this.LblGOODHelp);
            this.TPRemoteCall.Controls.Add(this.ButtonOpenGOODImport);
            this.TPRemoteCall.Controls.Add(this.LblHostTip);
            this.TPRemoteCall.Controls.Add(this.GrpServerStatus);
            this.TPRemoteCall.Controls.Add(this.GrpRemoteCommand);
            this.TPRemoteCall.Controls.Add(this.TxtHost);
            this.TPRemoteCall.Controls.Add(this.BtnQueryServerStatus);
            this.TPRemoteCall.Controls.Add(this.LblHost);
            resources.ApplyResources(this.TPRemoteCall, "TPRemoteCall");
            this.TPRemoteCall.Name = "TPRemoteCall";
            this.TPRemoteCall.UseVisualStyleBackColor = true;
            this.TPRemoteCall.Enter += new System.EventHandler(this.TPRemoteCall_Enter);
            // 
            // LnkLinks
            // 
            resources.ApplyResources(this.LnkLinks, "LnkLinks");
            this.LnkLinks.Name = "LnkLinks";
            this.LnkLinks.TabStop = true;
            this.LnkLinks.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkLinks_LinkClicked);
            // 
            // LnkGOODHelp
            // 
            resources.ApplyResources(this.LnkGOODHelp, "LnkGOODHelp");
            this.LnkGOODHelp.Cursor = System.Windows.Forms.Cursors.Help;
            this.LnkGOODHelp.Name = "LnkGOODHelp";
            this.LnkGOODHelp.TabStop = true;
            this.LnkGOODHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkGOODHelp_LinkClicked);
            // 
            // LnkInventoryKamera
            // 
            resources.ApplyResources(this.LnkInventoryKamera, "LnkInventoryKamera");
            this.LnkInventoryKamera.Name = "LnkInventoryKamera";
            this.LnkInventoryKamera.TabStop = true;
            this.LnkInventoryKamera.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkInventoryKamera_LinkClicked);
            // 
            // LblGOODHelp
            // 
            resources.ApplyResources(this.LblGOODHelp, "LblGOODHelp");
            this.LblGOODHelp.Name = "LblGOODHelp";
            // 
            // ButtonOpenGOODImport
            // 
            resources.ApplyResources(this.ButtonOpenGOODImport, "ButtonOpenGOODImport");
            this.ButtonOpenGOODImport.Name = "ButtonOpenGOODImport";
            this.ButtonOpenGOODImport.UseVisualStyleBackColor = true;
            this.ButtonOpenGOODImport.Click += new System.EventHandler(this.ButtonOpenGOODImport_Click);
            // 
            // LblHostTip
            // 
            resources.ApplyResources(this.LblHostTip, "LblHostTip");
            this.LblHostTip.ForeColor = System.Drawing.SystemColors.GrayText;
            this.LblHostTip.Name = "LblHostTip";
            // 
            // GrpServerStatus
            // 
            resources.ApplyResources(this.GrpServerStatus, "GrpServerStatus");
            this.GrpServerStatus.Controls.Add(this.LnkOpenCommandLabel);
            this.GrpServerStatus.Controls.Add(this.LblOpenCommandSupport);
            this.GrpServerStatus.Controls.Add(this.LblServerVersion);
            this.GrpServerStatus.Controls.Add(this.LblPlayerCount);
            this.GrpServerStatus.Controls.Add(this.LblServerVersionLabel);
            this.GrpServerStatus.Controls.Add(this.LblPlayerCountLabel);
            this.GrpServerStatus.Name = "GrpServerStatus";
            this.GrpServerStatus.TabStop = false;
            // 
            // LnkOpenCommandLabel
            // 
            resources.ApplyResources(this.LnkOpenCommandLabel, "LnkOpenCommandLabel");
            this.LnkOpenCommandLabel.Name = "LnkOpenCommandLabel";
            this.LnkOpenCommandLabel.TabStop = true;
            this.LnkOpenCommandLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkOpenCommandLabel_LinkClicked);
            // 
            // LblOpenCommandSupport
            // 
            resources.ApplyResources(this.LblOpenCommandSupport, "LblOpenCommandSupport");
            this.LblOpenCommandSupport.Name = "LblOpenCommandSupport";
            // 
            // LblServerVersion
            // 
            resources.ApplyResources(this.LblServerVersion, "LblServerVersion");
            this.LblServerVersion.Name = "LblServerVersion";
            // 
            // LblPlayerCount
            // 
            resources.ApplyResources(this.LblPlayerCount, "LblPlayerCount");
            this.LblPlayerCount.Name = "LblPlayerCount";
            // 
            // LblServerVersionLabel
            // 
            resources.ApplyResources(this.LblServerVersionLabel, "LblServerVersionLabel");
            this.LblServerVersionLabel.Name = "LblServerVersionLabel";
            // 
            // LblPlayerCountLabel
            // 
            resources.ApplyResources(this.LblPlayerCountLabel, "LblPlayerCountLabel");
            this.LblPlayerCountLabel.Name = "LblPlayerCountLabel";
            // 
            // GrpRemoteCommand
            // 
            resources.ApplyResources(this.GrpRemoteCommand, "GrpRemoteCommand");
            this.GrpRemoteCommand.Controls.Add(this.TPOpenCommandCheck);
            this.GrpRemoteCommand.Name = "GrpRemoteCommand";
            this.GrpRemoteCommand.TabStop = false;
            // 
            // TPOpenCommandCheck
            // 
            this.TPOpenCommandCheck.Controls.Add(this.TPPlayerCheck);
            this.TPOpenCommandCheck.Controls.Add(this.TPConsoleCheck);
            resources.ApplyResources(this.TPOpenCommandCheck, "TPOpenCommandCheck");
            this.TPOpenCommandCheck.Name = "TPOpenCommandCheck";
            this.TPOpenCommandCheck.SelectedIndex = 0;
            // 
            // TPPlayerCheck
            // 
            this.TPPlayerCheck.Controls.Add(this.LnkRCHelp);
            this.TPPlayerCheck.Controls.Add(this.NUDRemotePlayerId);
            this.TPPlayerCheck.Controls.Add(this.BtnConnectOpenCommand);
            this.TPPlayerCheck.Controls.Add(this.LblVerificationCode);
            this.TPPlayerCheck.Controls.Add(this.BtnSendVerificationCode);
            this.TPPlayerCheck.Controls.Add(this.NUDVerificationCode);
            this.TPPlayerCheck.Controls.Add(this.LblRemotePlayerId);
            resources.ApplyResources(this.TPPlayerCheck, "TPPlayerCheck");
            this.TPPlayerCheck.Name = "TPPlayerCheck";
            this.TPPlayerCheck.UseVisualStyleBackColor = true;
            // 
            // LnkRCHelp
            // 
            resources.ApplyResources(this.LnkRCHelp, "LnkRCHelp");
            this.LnkRCHelp.Name = "LnkRCHelp";
            this.LnkRCHelp.TabStop = true;
            this.LnkRCHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkRCHelp_LinkClicked);
            // 
            // NUDRemotePlayerId
            // 
            resources.ApplyResources(this.NUDRemotePlayerId, "NUDRemotePlayerId");
            this.NUDRemotePlayerId.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDRemotePlayerId.Name = "NUDRemotePlayerId";
            this.NUDRemotePlayerId.Value = new decimal(new int[] {
            10001,
            0,
            0,
            0});
            // 
            // BtnConnectOpenCommand
            // 
            resources.ApplyResources(this.BtnConnectOpenCommand, "BtnConnectOpenCommand");
            this.BtnConnectOpenCommand.Name = "BtnConnectOpenCommand";
            this.BtnConnectOpenCommand.UseVisualStyleBackColor = true;
            this.BtnConnectOpenCommand.Click += new System.EventHandler(this.BtnConnectOpenCommand_Click);
            // 
            // LblVerificationCode
            // 
            resources.ApplyResources(this.LblVerificationCode, "LblVerificationCode");
            this.LblVerificationCode.Name = "LblVerificationCode";
            // 
            // BtnSendVerificationCode
            // 
            resources.ApplyResources(this.BtnSendVerificationCode, "BtnSendVerificationCode");
            this.BtnSendVerificationCode.Name = "BtnSendVerificationCode";
            this.BtnSendVerificationCode.UseVisualStyleBackColor = true;
            this.BtnSendVerificationCode.Click += new System.EventHandler(this.BtnSendVerificationCode_Click);
            // 
            // NUDVerificationCode
            // 
            resources.ApplyResources(this.NUDVerificationCode, "NUDVerificationCode");
            this.NUDVerificationCode.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NUDVerificationCode.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NUDVerificationCode.Name = "NUDVerificationCode";
            this.NUDVerificationCode.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // LblRemotePlayerId
            // 
            resources.ApplyResources(this.LblRemotePlayerId, "LblRemotePlayerId");
            this.LblRemotePlayerId.Name = "LblRemotePlayerId";
            // 
            // TPConsoleCheck
            // 
            this.TPConsoleCheck.Controls.Add(this.BtnConsoleConnect);
            this.TPConsoleCheck.Controls.Add(this.TxtToken);
            this.TPConsoleCheck.Controls.Add(this.LblToken);
            this.TPConsoleCheck.Controls.Add(this.LblConsoleTip);
            resources.ApplyResources(this.TPConsoleCheck, "TPConsoleCheck");
            this.TPConsoleCheck.Name = "TPConsoleCheck";
            this.TPConsoleCheck.UseVisualStyleBackColor = true;
            // 
            // BtnConsoleConnect
            // 
            resources.ApplyResources(this.BtnConsoleConnect, "BtnConsoleConnect");
            this.BtnConsoleConnect.Name = "BtnConsoleConnect";
            this.BtnConsoleConnect.UseVisualStyleBackColor = true;
            this.BtnConsoleConnect.Click += new System.EventHandler(this.BtnConsoleConnect_Click);
            // 
            // TxtToken
            // 
            resources.ApplyResources(this.TxtToken, "TxtToken");
            this.TxtToken.Name = "TxtToken";
            // 
            // LblToken
            // 
            resources.ApplyResources(this.LblToken, "LblToken");
            this.LblToken.Name = "LblToken";
            // 
            // LblConsoleTip
            // 
            resources.ApplyResources(this.LblConsoleTip, "LblConsoleTip");
            this.LblConsoleTip.Name = "LblConsoleTip";
            // 
            // TxtHost
            // 
            resources.ApplyResources(this.TxtHost, "TxtHost");
            this.TxtHost.Name = "TxtHost";
            // 
            // BtnQueryServerStatus
            // 
            resources.ApplyResources(this.BtnQueryServerStatus, "BtnQueryServerStatus");
            this.BtnQueryServerStatus.Name = "BtnQueryServerStatus";
            this.BtnQueryServerStatus.UseVisualStyleBackColor = true;
            this.BtnQueryServerStatus.Click += new System.EventHandler(this.BtnQueryServerStatus_Click);
            // 
            // LblHost
            // 
            resources.ApplyResources(this.LblHost, "LblHost");
            this.LblHost.Name = "LblHost";
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
            // TxtBanReason
            // 
            this.TxtBanReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.TxtBanReason, "TxtBanReason");
            this.TxtBanReason.Maximum = 0F;
            this.TxtBanReason.Minimum = 0F;
            this.TxtBanReason.Name = "TxtBanReason";
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
            this.TPWeapon.Controls.Add(this.BtnGiveAllWeapons);
            this.TPWeapon.Controls.Add(this.TxtWeaponFilter);
            this.TPWeapon.Controls.Add(this.LblWeaponDescription);
            this.TPWeapon.Controls.Add(this.LblWeaponRefinement);
            this.TPWeapon.Controls.Add(this.LblWeaponAmount);
            this.TPWeapon.Controls.Add(this.LblWeaponLevel);
            this.TPWeapon.Controls.Add(this.NUDWeaponRefinement);
            this.TPWeapon.Controls.Add(this.NUDWeaponAmout);
            this.TPWeapon.Controls.Add(this.NUDWeaponLevel);
            this.TPWeapon.Controls.Add(this.ListWeapons);
            resources.ApplyResources(this.TPWeapon, "TPWeapon");
            this.TPWeapon.Name = "TPWeapon";
            this.TPWeapon.UseVisualStyleBackColor = true;
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
            1,
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
            1,
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
            this.ListWeapons.SelectedIndexChanged += new System.EventHandler(this.WeaponValueChanged);
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
            this.GrpSetConstellation.Controls.Add(this.LnkSetAllConst);
            this.GrpSetConstellation.Controls.Add(this.LnkSetConst);
            this.GrpSetConstellation.Controls.Add(this.NUDSetConstellation);
            resources.ApplyResources(this.GrpSetConstellation, "GrpSetConstellation");
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
            // 
            // BtnLockStat
            // 
            resources.ApplyResources(this.BtnLockStat, "BtnLockStat");
            this.BtnLockStat.Name = "BtnLockStat";
            this.BtnLockStat.UseVisualStyleBackColor = true;
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
            // 
            // CmbStat
            // 
            this.CmbStat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbStat.FormattingEnabled = true;
            resources.ApplyResources(this.CmbStat, "CmbStat");
            this.CmbStat.Name = "CmbStat";
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
            // 
            // LnkTalentE
            // 
            resources.ApplyResources(this.LnkTalentE, "LnkTalentE");
            this.LnkTalentE.Name = "LnkTalentE";
            this.LnkTalentE.TabStop = true;
            this.LnkTalentE.Tag = "e";
            // 
            // LnkTalentQ
            // 
            resources.ApplyResources(this.LnkTalentQ, "LnkTalentQ");
            this.LnkTalentQ.Name = "LnkTalentQ";
            this.LnkTalentQ.TabStop = true;
            this.LnkTalentQ.Tag = "q";
            // 
            // LnkTalentNormalATK
            // 
            resources.ApplyResources(this.LnkTalentNormalATK, "LnkTalentNormalATK");
            this.LnkTalentNormalATK.Name = "LnkTalentNormalATK";
            this.LnkTalentNormalATK.TabStop = true;
            this.LnkTalentNormalATK.Tag = "n";
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
            this.TPSpawn.Controls.Add(this.ChkInfiniteHP);
            this.TPSpawn.Controls.Add(this.LblClearSpawnLogs);
            this.TPSpawn.Controls.Add(this.BtnSaveSpawnLog);
            this.TPSpawn.Controls.Add(this.BtnRemoveSpawnLog);
            this.TPSpawn.Controls.Add(this.GrpSpawnRecord);
            this.TPSpawn.Controls.Add(this.GrpEntityType);
            this.TPSpawn.Controls.Add(this.LblSpawnDescription);
            this.TPSpawn.Controls.Add(this.LblEntityAmount);
            this.TPSpawn.Controls.Add(this.LblEntityLevel);
            this.TPSpawn.Controls.Add(this.NUDEntityAmout);
            this.TPSpawn.Controls.Add(this.NUDEntityLevel);
            this.TPSpawn.Controls.Add(this.TxtEntityFilter);
            this.TPSpawn.Controls.Add(this.ListEntity);
            resources.ApplyResources(this.TPSpawn, "TPSpawn");
            this.TPSpawn.Name = "TPSpawn";
            this.TPSpawn.UseVisualStyleBackColor = true;
            // 
            // ChkInfiniteHP
            // 
            resources.ApplyResources(this.ChkInfiniteHP, "ChkInfiniteHP");
            this.ChkInfiniteHP.Name = "ChkInfiniteHP";
            this.ChkInfiniteHP.UseVisualStyleBackColor = true;
            this.ChkInfiniteHP.CheckedChanged += new System.EventHandler(this.SpawnEntityInputChanged);
            // 
            // LblClearSpawnLogs
            // 
            resources.ApplyResources(this.LblClearSpawnLogs, "LblClearSpawnLogs");
            this.LblClearSpawnLogs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblClearSpawnLogs.Name = "LblClearSpawnLogs";
            this.LblClearSpawnLogs.Click += new System.EventHandler(this.LblClearSpawnLogs_Click);
            // 
            // BtnSaveSpawnLog
            // 
            resources.ApplyResources(this.BtnSaveSpawnLog, "BtnSaveSpawnLog");
            this.BtnSaveSpawnLog.Name = "BtnSaveSpawnLog";
            this.BtnSaveSpawnLog.UseVisualStyleBackColor = true;
            this.BtnSaveSpawnLog.Click += new System.EventHandler(this.BtnSaveSpawnLog_Click);
            // 
            // BtnRemoveSpawnLog
            // 
            resources.ApplyResources(this.BtnRemoveSpawnLog, "BtnRemoveSpawnLog");
            this.BtnRemoveSpawnLog.Name = "BtnRemoveSpawnLog";
            this.BtnRemoveSpawnLog.UseVisualStyleBackColor = true;
            this.BtnRemoveSpawnLog.Click += new System.EventHandler(this.BtnRemoveSpawnLog_Click);
            // 
            // GrpSpawnRecord
            // 
            resources.ApplyResources(this.GrpSpawnRecord, "GrpSpawnRecord");
            this.GrpSpawnRecord.Controls.Add(this.ListSpawnLogs);
            this.GrpSpawnRecord.Name = "GrpSpawnRecord";
            this.GrpSpawnRecord.TabStop = false;
            // 
            // ListSpawnLogs
            // 
            resources.ApplyResources(this.ListSpawnLogs, "ListSpawnLogs");
            this.ListSpawnLogs.FormattingEnabled = true;
            this.ListSpawnLogs.Name = "ListSpawnLogs";
            this.ListSpawnLogs.SelectedIndexChanged += new System.EventHandler(this.ListSpawnLogs_SelectedIndexChanged);
            // 
            // GrpEntityType
            // 
            resources.ApplyResources(this.GrpEntityType, "GrpEntityType");
            this.GrpEntityType.Controls.Add(this.RbEntityAnimal);
            this.GrpEntityType.Controls.Add(this.RbEntityMonster);
            this.GrpEntityType.Name = "GrpEntityType";
            this.GrpEntityType.TabStop = false;
            // 
            // RbEntityAnimal
            // 
            resources.ApplyResources(this.RbEntityAnimal, "RbEntityAnimal");
            this.RbEntityAnimal.Name = "RbEntityAnimal";
            this.RbEntityAnimal.UseVisualStyleBackColor = true;
            this.RbEntityAnimal.CheckedChanged += new System.EventHandler(this.RbEntity_CheckedChanged);
            // 
            // RbEntityMonster
            // 
            resources.ApplyResources(this.RbEntityMonster, "RbEntityMonster");
            this.RbEntityMonster.Name = "RbEntityMonster";
            this.RbEntityMonster.UseVisualStyleBackColor = true;
            this.RbEntityMonster.CheckedChanged += new System.EventHandler(this.RbEntity_CheckedChanged);
            // 
            // LblSpawnDescription
            // 
            resources.ApplyResources(this.LblSpawnDescription, "LblSpawnDescription");
            this.LblSpawnDescription.Name = "LblSpawnDescription";
            // 
            // LblEntityAmount
            // 
            resources.ApplyResources(this.LblEntityAmount, "LblEntityAmount");
            this.LblEntityAmount.Name = "LblEntityAmount";
            // 
            // LblEntityLevel
            // 
            resources.ApplyResources(this.LblEntityLevel, "LblEntityLevel");
            this.LblEntityLevel.Name = "LblEntityLevel";
            // 
            // NUDEntityAmout
            // 
            resources.ApplyResources(this.NUDEntityAmout, "NUDEntityAmout");
            this.NUDEntityAmout.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NUDEntityAmout.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDEntityAmout.Name = "NUDEntityAmout";
            this.NUDEntityAmout.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDEntityAmout.ValueChanged += new System.EventHandler(this.SpawnEntityInputChanged);
            // 
            // NUDEntityLevel
            // 
            resources.ApplyResources(this.NUDEntityLevel, "NUDEntityLevel");
            this.NUDEntityLevel.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.NUDEntityLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDEntityLevel.Name = "NUDEntityLevel";
            this.NUDEntityLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDEntityLevel.ValueChanged += new System.EventHandler(this.SpawnEntityInputChanged);
            // 
            // TxtEntityFilter
            // 
            resources.ApplyResources(this.TxtEntityFilter, "TxtEntityFilter");
            this.TxtEntityFilter.Name = "TxtEntityFilter";
            this.TxtEntityFilter.TextChanged += new System.EventHandler(this.TxtEntityFilter_TextChanged);
            // 
            // ListEntity
            // 
            resources.ApplyResources(this.ListEntity, "ListEntity");
            this.ListEntity.FormattingEnabled = true;
            this.ListEntity.Name = "ListEntity";
            this.ListEntity.SelectedIndexChanged += new System.EventHandler(this.SpawnEntityInputChanged);
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
            this.TPArtifact.Controls.Add(this.LblArtifactLevelTip);
            this.TPArtifact.Controls.Add(this.BtnAddSubAttr);
            this.TPArtifact.Controls.Add(this.LblArtifactName);
            this.TPArtifact.Controls.Add(this.LblArtifactPart);
            this.TPArtifact.Controls.Add(this.CmbArtifactPart);
            this.TPArtifact.Controls.Add(this.CmbArtifactSet);
            this.TPArtifact.Controls.Add(this.LblArtifactSet);
            this.TPArtifact.Controls.Add(this.NUDSubAttributionTimes);
            this.TPArtifact.Controls.Add(this.CmbSubAttributionValue);
            this.TPArtifact.Controls.Add(this.CmbSubAttribution);
            this.TPArtifact.Controls.Add(this.LblClearSubAttrCheckedList);
            this.TPArtifact.Controls.Add(this.ListSubAttributionChecked);
            this.TPArtifact.Controls.Add(this.LblArtifactLevel);
            this.TPArtifact.Controls.Add(this.LblSubAttribution);
            this.TPArtifact.Controls.Add(this.CmbMainAttribution);
            this.TPArtifact.Controls.Add(this.LblMainAttribution);
            this.TPArtifact.Controls.Add(this.NUDArtifactLevel);
            this.TPArtifact.Controls.Add(this.LblArtifactStars);
            this.TPArtifact.Controls.Add(this.NUDArtifactStars);
            resources.ApplyResources(this.TPArtifact, "TPArtifact");
            this.TPArtifact.Name = "TPArtifact";
            this.TPArtifact.UseVisualStyleBackColor = true;
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
            // TPCustom
            // 
            this.TPCustom.Controls.Add(this.BtnExportCustomCommands);
            this.TPCustom.Controls.Add(this.BtnLoadCustomCommands);
            this.TPCustom.Controls.Add(this.LblCustomName);
            this.TPCustom.Controls.Add(this.groupBox1);
            this.TPCustom.Controls.Add(this.BtnRemoveCustomCommand);
            this.TPCustom.Controls.Add(this.BtnSaveCustomCommand);
            this.TPCustom.Controls.Add(this.TxtCustomName);
            resources.ApplyResources(this.TPCustom, "TPCustom");
            this.TPCustom.Name = "TPCustom";
            this.TPCustom.UseVisualStyleBackColor = true;
            // 
            // BtnExportCustomCommands
            // 
            resources.ApplyResources(this.BtnExportCustomCommands, "BtnExportCustomCommands");
            this.BtnExportCustomCommands.Name = "BtnExportCustomCommands";
            this.BtnExportCustomCommands.UseVisualStyleBackColor = true;
            this.BtnExportCustomCommands.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // BtnLoadCustomCommands
            // 
            resources.ApplyResources(this.BtnLoadCustomCommands, "BtnLoadCustomCommands");
            this.BtnLoadCustomCommands.Name = "BtnLoadCustomCommands";
            this.BtnLoadCustomCommands.UseVisualStyleBackColor = true;
            this.BtnLoadCustomCommands.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // LblCustomName
            // 
            resources.ApplyResources(this.LblCustomName, "LblCustomName");
            this.LblCustomName.Name = "LblCustomName";
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.LnkResetCustomCommands);
            this.groupBox1.Controls.Add(this.FLPCustomCommands);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // LnkResetCustomCommands
            // 
            resources.ApplyResources(this.LnkResetCustomCommands, "LnkResetCustomCommands");
            this.LnkResetCustomCommands.Name = "LnkResetCustomCommands";
            this.LnkResetCustomCommands.TabStop = true;
            this.LnkResetCustomCommands.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkResetCustomCommands_LinkClicked);
            // 
            // FLPCustomCommands
            // 
            resources.ApplyResources(this.FLPCustomCommands, "FLPCustomCommands");
            this.FLPCustomCommands.Name = "FLPCustomCommands";
            // 
            // BtnRemoveCustomCommand
            // 
            resources.ApplyResources(this.BtnRemoveCustomCommand, "BtnRemoveCustomCommand");
            this.BtnRemoveCustomCommand.Name = "BtnRemoveCustomCommand";
            this.BtnRemoveCustomCommand.UseVisualStyleBackColor = true;
            this.BtnRemoveCustomCommand.Click += new System.EventHandler(this.BtnRemoveCustomCommand_Click);
            // 
            // BtnSaveCustomCommand
            // 
            resources.ApplyResources(this.BtnSaveCustomCommand, "BtnSaveCustomCommand");
            this.BtnSaveCustomCommand.Name = "BtnSaveCustomCommand";
            this.BtnSaveCustomCommand.UseVisualStyleBackColor = true;
            this.BtnSaveCustomCommand.Click += new System.EventHandler(this.BtnSaveCustomCommand_Click);
            // 
            // TxtCustomName
            // 
            resources.ApplyResources(this.TxtCustomName, "TxtCustomName");
            this.TxtCustomName.Name = "TxtCustomName";
            // 
            // TPHome
            // 
            this.TPHome.Controls.Add(this.BtnOpenDropEditor);
            this.TPHome.Controls.Add(this.LnkNewVersion);
            this.TPHome.Controls.Add(this.LblAbout);
            this.TPHome.Controls.Add(this.BtnOpenTextMap);
            this.TPHome.Controls.Add(this.BtnOpenGachaBannerEditor);
            this.TPHome.Controls.Add(this.GrasscutterToolsIcon);
            this.TPHome.Controls.Add(this.GrpSettings);
            resources.ApplyResources(this.TPHome, "TPHome");
            this.TPHome.Name = "TPHome";
            this.TPHome.UseVisualStyleBackColor = true;
            // 
            // BtnOpenDropEditor
            // 
            resources.ApplyResources(this.BtnOpenDropEditor, "BtnOpenDropEditor");
            this.BtnOpenDropEditor.Name = "BtnOpenDropEditor";
            this.BtnOpenDropEditor.UseVisualStyleBackColor = true;
            this.BtnOpenDropEditor.Click += new System.EventHandler(this.BtnOpenDropEditor_Click);
            // 
            // LnkNewVersion
            // 
            resources.ApplyResources(this.LnkNewVersion, "LnkNewVersion");
            this.LnkNewVersion.Name = "LnkNewVersion";
            this.LnkNewVersion.TabStop = true;
            this.LnkNewVersion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkNewVersion_LinkClicked);
            // 
            // LblAbout
            // 
            resources.ApplyResources(this.LblAbout, "LblAbout");
            this.LblAbout.Name = "LblAbout";
            // 
            // BtnOpenTextMap
            // 
            resources.ApplyResources(this.BtnOpenTextMap, "BtnOpenTextMap");
            this.BtnOpenTextMap.Name = "BtnOpenTextMap";
            this.BtnOpenTextMap.UseVisualStyleBackColor = true;
            this.BtnOpenTextMap.Click += new System.EventHandler(this.BtnOpenTextMap_Click);
            // 
            // BtnOpenGachaBannerEditor
            // 
            resources.ApplyResources(this.BtnOpenGachaBannerEditor, "BtnOpenGachaBannerEditor");
            this.BtnOpenGachaBannerEditor.Name = "BtnOpenGachaBannerEditor";
            this.BtnOpenGachaBannerEditor.UseVisualStyleBackColor = true;
            this.BtnOpenGachaBannerEditor.Click += new System.EventHandler(this.BtnOpenGachaBannerEditor_Click);
            // 
            // GrasscutterToolsIcon
            // 
            resources.ApplyResources(this.GrasscutterToolsIcon, "GrasscutterToolsIcon");
            this.GrasscutterToolsIcon.Image = global::GrasscutterTools.Properties.Resources.ImgIconGrasscutter;
            this.GrasscutterToolsIcon.Name = "GrasscutterToolsIcon";
            this.GrasscutterToolsIcon.TabStop = false;
            // 
            // GrpSettings
            // 
            resources.ApplyResources(this.GrpSettings, "GrpSettings");
            this.GrpSettings.Controls.Add(this.LblGCVersion);
            this.GrpSettings.Controls.Add(this.CmbGcVersions);
            this.GrpSettings.Controls.Add(this.ChkTopMost);
            this.GrpSettings.Controls.Add(this.CmbLanguage);
            this.GrpSettings.Controls.Add(this.LblLanguage);
            this.GrpSettings.Controls.Add(this.NUDUid);
            this.GrpSettings.Controls.Add(this.ChkIncludeUID);
            this.GrpSettings.Controls.Add(this.LblDefaultUid);
            this.GrpSettings.Name = "GrpSettings";
            this.GrpSettings.TabStop = false;
            // 
            // LblGCVersion
            // 
            resources.ApplyResources(this.LblGCVersion, "LblGCVersion");
            this.LblGCVersion.Name = "LblGCVersion";
            // 
            // CmbGcVersions
            // 
            this.CmbGcVersions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbGcVersions.FormattingEnabled = true;
            resources.ApplyResources(this.CmbGcVersions, "CmbGcVersions");
            this.CmbGcVersions.Name = "CmbGcVersions";
            // 
            // ChkTopMost
            // 
            resources.ApplyResources(this.ChkTopMost, "ChkTopMost");
            this.ChkTopMost.Name = "ChkTopMost";
            this.ChkTopMost.UseVisualStyleBackColor = true;
            // 
            // CmbLanguage
            // 
            this.CmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbLanguage.FormattingEnabled = true;
            resources.ApplyResources(this.CmbLanguage, "CmbLanguage");
            this.CmbLanguage.Name = "CmbLanguage";
            // 
            // LblLanguage
            // 
            resources.ApplyResources(this.LblLanguage, "LblLanguage");
            this.LblLanguage.Name = "LblLanguage";
            // 
            // NUDUid
            // 
            resources.ApplyResources(this.NUDUid, "NUDUid");
            this.NUDUid.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NUDUid.Name = "NUDUid";
            this.NUDUid.Value = new decimal(new int[] {
            10001,
            0,
            0,
            0});
            // 
            // ChkIncludeUID
            // 
            resources.ApplyResources(this.ChkIncludeUID, "ChkIncludeUID");
            this.ChkIncludeUID.Name = "ChkIncludeUID";
            this.ChkIncludeUID.UseVisualStyleBackColor = true;
            // 
            // LblDefaultUid
            // 
            resources.ApplyResources(this.LblDefaultUid, "LblDefaultUid");
            this.LblDefaultUid.Name = "LblDefaultUid";
            // 
            // TCMain
            // 
            resources.ApplyResources(this.TCMain, "TCMain");
            this.TCMain.Controls.Add(this.TPHome);
            this.TCMain.Controls.Add(this.TPCustom);
            this.TCMain.Controls.Add(this.TPArtifact);
            this.TCMain.Controls.Add(this.TPQuest);
            this.TCMain.Controls.Add(this.TPSpawn);
            this.TCMain.Controls.Add(this.TPAvatar);
            this.TCMain.Controls.Add(this.TPWeapon);
            this.TCMain.Controls.Add(this.TPItem);
            this.TCMain.Controls.Add(this.TPScene);
            this.TCMain.Controls.Add(this.TPManage);
            this.TCMain.Controls.Add(this.TPMail);
            this.TCMain.Controls.Add(this.TPAbout);
            this.TCMain.Controls.Add(this.TPRemoteCall);
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
            this.TCMailRight.Controls.Add(this.tabPage1);
            this.TCMailRight.Controls.Add(this.tabPage2);
            this.TCMailRight.Name = "TCMailRight";
            this.TCMailRight.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.TxtMailSelectableItemFilter);
            this.tabPage1.Controls.Add(this.ListMailSelectableItems);
            this.tabPage1.Controls.Add(this.PanelMailItemArgs);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // TxtMailSelectableItemFilter
            // 
            resources.ApplyResources(this.TxtMailSelectableItemFilter, "TxtMailSelectableItemFilter");
            this.TxtMailSelectableItemFilter.Name = "TxtMailSelectableItemFilter";
            this.TxtMailSelectableItemFilter.TextChanged += new System.EventHandler(this.TxtMailSelectableItemFilter_TextChanged);
            // 
            // ListMailSelectableItems
            // 
            resources.ApplyResources(this.ListMailSelectableItems, "ListMailSelectableItems");
            this.ListMailSelectableItems.FormattingEnabled = true;
            this.ListMailSelectableItems.Name = "ListMailSelectableItems";
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
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ListMailList);
            this.tabPage2.Controls.Add(this.PanelMailListControls);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.TPRemoteCall.ResumeLayout(false);
            this.TPRemoteCall.PerformLayout();
            this.GrpServerStatus.ResumeLayout(false);
            this.GrpServerStatus.PerformLayout();
            this.GrpRemoteCommand.ResumeLayout(false);
            this.TPOpenCommandCheck.ResumeLayout(false);
            this.TPPlayerCheck.ResumeLayout(false);
            this.TPPlayerCheck.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDRemotePlayerId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDVerificationCode)).EndInit();
            this.TPConsoleCheck.ResumeLayout(false);
            this.TPConsoleCheck.PerformLayout();
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
            this.TPWeapon.ResumeLayout(false);
            this.TPWeapon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDWeaponRefinement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDWeaponAmout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDWeaponLevel)).EndInit();
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
            this.TPSpawn.ResumeLayout(false);
            this.TPSpawn.PerformLayout();
            this.GrpSpawnRecord.ResumeLayout(false);
            this.GrpEntityType.ResumeLayout(false);
            this.GrpEntityType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDEntityAmout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDEntityLevel)).EndInit();
            this.TPQuest.ResumeLayout(false);
            this.TPQuest.PerformLayout();
            this.GrpQuestFilters.ResumeLayout(false);
            this.GrpQuestFilters.PerformLayout();
            this.TPArtifact.ResumeLayout(false);
            this.TPArtifact.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDSubAttributionTimes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDArtifactLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDArtifactStars)).EndInit();
            this.TPCustom.ResumeLayout(false);
            this.TPCustom.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.TPHome.ResumeLayout(false);
            this.TPHome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrasscutterToolsIcon)).EndInit();
            this.GrpSettings.ResumeLayout(false);
            this.GrpSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDUid)).EndInit();
            this.TCMain.ResumeLayout(false);
            this.TPMail.ResumeLayout(false);
            this.TPMail.PerformLayout();
            this.TCMailRight.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.PanelMailItemArgs.ResumeLayout(false);
            this.PanelMailItemArgs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDMailItemLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDMailItemCount)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.PanelMailListControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NUDMailRecipient)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TxtCommand;
        private System.Windows.Forms.Button BtnCopy;
        private System.Windows.Forms.CheckBox ChkAutoCopy;
        private System.Windows.Forms.GroupBox GrpCommand;
        private System.Windows.Forms.Button BtnInvokeOpenCommand;
        private System.Windows.Forms.TabPage TPRemoteCall;
        private System.Windows.Forms.GroupBox GrpServerStatus;
        private System.Windows.Forms.LinkLabel LnkOpenCommandLabel;
        private System.Windows.Forms.Label LblOpenCommandSupport;
        private System.Windows.Forms.Label LblServerVersion;
        private System.Windows.Forms.Label LblPlayerCount;
        private System.Windows.Forms.Label LblServerVersionLabel;
        private System.Windows.Forms.Label LblPlayerCountLabel;
        private System.Windows.Forms.GroupBox GrpRemoteCommand;
        private System.Windows.Forms.TabControl TPOpenCommandCheck;
        private System.Windows.Forms.TabPage TPPlayerCheck;
        private System.Windows.Forms.LinkLabel LnkRCHelp;
        private System.Windows.Forms.NumericUpDown NUDRemotePlayerId;
        private System.Windows.Forms.Button BtnConnectOpenCommand;
        private System.Windows.Forms.Label LblVerificationCode;
        private System.Windows.Forms.Button BtnSendVerificationCode;
        private System.Windows.Forms.NumericUpDown NUDVerificationCode;
        private System.Windows.Forms.Label LblRemotePlayerId;
        private System.Windows.Forms.TabPage TPConsoleCheck;
        private System.Windows.Forms.Button BtnConsoleConnect;
        private System.Windows.Forms.TextBox TxtToken;
        private System.Windows.Forms.Label LblToken;
        private System.Windows.Forms.Label LblConsoleTip;
        private System.Windows.Forms.TextBox TxtHost;
        private System.Windows.Forms.Button BtnQueryServerStatus;
        private System.Windows.Forms.Label LblHost;
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
        private System.Windows.Forms.TextBox TxtWeaponFilter;
        private System.Windows.Forms.Label LblWeaponDescription;
        private System.Windows.Forms.Label LblWeaponRefinement;
        private System.Windows.Forms.Label LblWeaponAmount;
        private System.Windows.Forms.Label LblWeaponLevel;
        private System.Windows.Forms.NumericUpDown NUDWeaponRefinement;
        private System.Windows.Forms.NumericUpDown NUDWeaponAmout;
        private System.Windows.Forms.NumericUpDown NUDWeaponLevel;
        private System.Windows.Forms.ListBox ListWeapons;
        private System.Windows.Forms.TabPage TPAvatar;
        private System.Windows.Forms.Label LblAvatar;
        private System.Windows.Forms.Label LblAvatarLevel;
        private System.Windows.Forms.NumericUpDown NUDAvatarLevel;
        private System.Windows.Forms.ComboBox CmbAvatar;
        private System.Windows.Forms.TabPage TPSpawn;
        private System.Windows.Forms.Button BtnSaveSpawnLog;
        private System.Windows.Forms.Button BtnRemoveSpawnLog;
        private System.Windows.Forms.GroupBox GrpSpawnRecord;
        private System.Windows.Forms.ListBox ListSpawnLogs;
        private System.Windows.Forms.GroupBox GrpEntityType;
        private System.Windows.Forms.RadioButton RbEntityAnimal;
        private System.Windows.Forms.RadioButton RbEntityMonster;
        private System.Windows.Forms.Label LblSpawnDescription;
        private System.Windows.Forms.Label LblEntityAmount;
        private System.Windows.Forms.Label LblEntityLevel;
        private System.Windows.Forms.NumericUpDown NUDEntityAmout;
        private System.Windows.Forms.NumericUpDown NUDEntityLevel;
        private System.Windows.Forms.TextBox TxtEntityFilter;
        private System.Windows.Forms.ListBox ListEntity;
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
        private System.Windows.Forms.Button BtnAddSubAttr;
        private System.Windows.Forms.Label LblArtifactName;
        private System.Windows.Forms.NumericUpDown NUDArtifactStars;
        private System.Windows.Forms.Label LblArtifactStars;
        private System.Windows.Forms.Label LblArtifactPart;
        private System.Windows.Forms.ComboBox CmbArtifactPart;
        private System.Windows.Forms.ComboBox CmbArtifactSet;
        private System.Windows.Forms.Label LblArtifactSet;
        private System.Windows.Forms.NumericUpDown NUDSubAttributionTimes;
        private System.Windows.Forms.ComboBox CmbSubAttributionValue;
        private System.Windows.Forms.ComboBox CmbSubAttribution;
        private System.Windows.Forms.Label LblClearSubAttrCheckedList;
        private System.Windows.Forms.ListBox ListSubAttributionChecked;
        private System.Windows.Forms.NumericUpDown NUDArtifactLevel;
        private System.Windows.Forms.Label LblArtifactLevel;
        private System.Windows.Forms.Label LblSubAttribution;
        private System.Windows.Forms.ComboBox CmbMainAttribution;
        private System.Windows.Forms.Label LblMainAttribution;
        private System.Windows.Forms.TabPage TPCustom;
        private System.Windows.Forms.Button BtnExportCustomCommands;
        private System.Windows.Forms.Button BtnLoadCustomCommands;
        private System.Windows.Forms.Label LblCustomName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel LnkResetCustomCommands;
        private System.Windows.Forms.FlowLayoutPanel FLPCustomCommands;
        private System.Windows.Forms.Button BtnRemoveCustomCommand;
        private System.Windows.Forms.Button BtnSaveCustomCommand;
        private System.Windows.Forms.TextBox TxtCustomName;
        private System.Windows.Forms.TabPage TPHome;
        private System.Windows.Forms.Label LblAbout;
        private System.Windows.Forms.Button BtnOpenTextMap;
        private System.Windows.Forms.Button BtnOpenGachaBannerEditor;
        private System.Windows.Forms.PictureBox GrasscutterToolsIcon;
        private System.Windows.Forms.GroupBox GrpSettings;
        private System.Windows.Forms.CheckBox ChkTopMost;
        private System.Windows.Forms.ComboBox CmbLanguage;
        private System.Windows.Forms.Label LblLanguage;
        private System.Windows.Forms.NumericUpDown NUDUid;
        private System.Windows.Forms.CheckBox ChkIncludeUID;
        private System.Windows.Forms.Label LblDefaultUid;
        private System.Windows.Forms.TabControl TCMain;
        private System.Windows.Forms.Label LblArtifactLevelTip;
        private System.Windows.Forms.Label LblClearSpawnLogs;
        private System.Windows.Forms.Label LblClearGiveItemLogs;
        private System.Windows.Forms.Label LblAvatarConstellation;
        private System.Windows.Forms.NumericUpDown NUDAvatarConstellation;
        private System.Windows.Forms.Button BtnGiveAllChar;
        private System.Windows.Forms.Label LblHostTip;
        private System.Windows.Forms.Button ButtonOpenGOODImport;
        private System.Windows.Forms.LinkLabel LnkInventoryKamera;
        private System.Windows.Forms.Label LblGOODHelp;
        private System.Windows.Forms.LinkLabel LnkGOODHelp;
        private System.Windows.Forms.LinkLabel LnkLinks;
        private System.Windows.Forms.Label LblGCVersion;
        private System.Windows.Forms.ComboBox CmbGcVersions;
        private System.Windows.Forms.Button BtnPermClear;
        private System.Windows.Forms.Button BtnPermList;
        private System.Windows.Forms.LinkLabel LnkNewVersion;
        private System.Windows.Forms.Button BtnGiveAllWeapons;
        private System.Windows.Forms.CheckBox ChkInfiniteHP;
        private System.Windows.Forms.NumericUpDown NUDAvatarSkillLevel;
        private System.Windows.Forms.Label LblAvatarSkillLevelLabel;
        private System.Windows.Forms.Label LblAvatarSkillLevelTip;
        private System.Windows.Forms.Button BtnOpenDropEditor;
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
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
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
    }
}
