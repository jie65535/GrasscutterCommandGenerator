namespace GrasscutterTools.Pages
{
    partial class PageAvatar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageAvatar));
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
            this.SuspendLayout();
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
            this.CmbAvatar.SelectedIndexChanged += new System.EventHandler(this.GiveAvatarInputChanged);
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
            this.NUDAvatarLevel.ValueChanged += new System.EventHandler(this.GiveAvatarInputChanged);
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
            this.NUDAvatarConstellation.ValueChanged += new System.EventHandler(this.GiveAvatarInputChanged);
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
            this.NUDAvatarSkillLevel.ValueChanged += new System.EventHandler(this.GiveAvatarInputChanged);
            // 
            // PageAvatar
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GrpSetConstellation);
            this.Controls.Add(this.GrpSetStats);
            this.Controls.Add(this.GrpTalentLevel);
            this.Controls.Add(this.GrpGiveAvatar);
            this.Name = "PageAvatar";
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpSetConstellation;
        private System.Windows.Forms.LinkLabel LnkSetAllConst;
        private System.Windows.Forms.LinkLabel LnkSetConst;
        private System.Windows.Forms.NumericUpDown NUDSetConstellation;
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
        private System.Windows.Forms.ComboBox CmbSwitchElement;
        private System.Windows.Forms.LinkLabel LnkSwitchElement;
        private System.Windows.Forms.ComboBox CmbAvatar;
        private System.Windows.Forms.Label LblAvatarSkillLevelTip;
        private System.Windows.Forms.NumericUpDown NUDAvatarLevel;
        private System.Windows.Forms.Button BtnGiveAllChar;
        private System.Windows.Forms.Label LblAvatarLevel;
        private System.Windows.Forms.Label LblAvatarSkillLevelLabel;
        private System.Windows.Forms.Label LblAvatar;
        private System.Windows.Forms.Label LblAvatarConstellation;
        private System.Windows.Forms.NumericUpDown NUDAvatarConstellation;
        private System.Windows.Forms.NumericUpDown NUDAvatarSkillLevel;
    }
}
