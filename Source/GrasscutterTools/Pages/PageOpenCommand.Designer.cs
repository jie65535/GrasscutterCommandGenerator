namespace GrasscutterTools.Pages
{
    partial class PageOpenCommand
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageOpenCommand));
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
            this.TxtHost = new System.Windows.Forms.ComboBox();
            this.BtnQueryServerStatus = new System.Windows.Forms.Button();
            this.LblHost = new System.Windows.Forms.Label();
            this.GrpServerStatus.SuspendLayout();
            this.GrpRemoteCommand.SuspendLayout();
            this.TPOpenCommandCheck.SuspendLayout();
            this.TPPlayerCheck.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDRemotePlayerId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDVerificationCode)).BeginInit();
            this.TPConsoleCheck.SuspendLayout();
            this.SuspendLayout();
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
            this.NUDRemotePlayerId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NUDRemotePlayerId_KeyDown);
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
            this.NUDVerificationCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NUDVerificationCode_KeyDown);
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
            this.TxtToken.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtToken_KeyDown);
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
            this.TxtHost.SelectedIndexChanged += new System.EventHandler(this.TxtHost_SelectedIndexChanged);
            this.TxtHost.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtHost_KeyDown);
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
            // PageOpenCommand
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LnkLinks);
            this.Controls.Add(this.LnkGOODHelp);
            this.Controls.Add(this.LnkInventoryKamera);
            this.Controls.Add(this.LblGOODHelp);
            this.Controls.Add(this.ButtonOpenGOODImport);
            this.Controls.Add(this.LblHostTip);
            this.Controls.Add(this.GrpServerStatus);
            this.Controls.Add(this.GrpRemoteCommand);
            this.Controls.Add(this.TxtHost);
            this.Controls.Add(this.BtnQueryServerStatus);
            this.Controls.Add(this.LblHost);
            this.Name = "PageOpenCommand";
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel LnkLinks;
        private System.Windows.Forms.LinkLabel LnkGOODHelp;
        private System.Windows.Forms.LinkLabel LnkInventoryKamera;
        private System.Windows.Forms.Label LblGOODHelp;
        private System.Windows.Forms.Button ButtonOpenGOODImport;
        private System.Windows.Forms.Label LblHostTip;
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
        private System.Windows.Forms.ComboBox TxtHost;
        private System.Windows.Forms.Button BtnQueryServerStatus;
        private System.Windows.Forms.Label LblHost;
    }
}
