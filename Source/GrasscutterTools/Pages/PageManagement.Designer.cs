namespace GrasscutterTools.Pages
{
    partial class PageManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageManagement));
            this.GrpBanPlayer = new System.Windows.Forms.GroupBox();
            this.TxtBanReason = new System.Windows.Forms.TextBox();
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
            this.GrpBanPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDBanUID)).BeginInit();
            this.GrpAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDAccountUid)).BeginInit();
            this.GrpPermission.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDPermUID)).BeginInit();
            this.SuspendLayout();
            // 
            // GrpBanPlayer
            // 
            resources.ApplyResources(this.GrpBanPlayer, "GrpBanPlayer");
            this.GrpBanPlayer.Controls.Add(this.TxtBanReason);
            this.GrpBanPlayer.Controls.Add(this.DTPBanEndTime);
            this.GrpBanPlayer.Controls.Add(this.BtnUnban);
            this.GrpBanPlayer.Controls.Add(this.BtnBan);
            this.GrpBanPlayer.Controls.Add(this.NUDBanUID);
            this.GrpBanPlayer.Controls.Add(this.LblBanUID);
            this.GrpBanPlayer.Name = "GrpBanPlayer";
            this.GrpBanPlayer.TabStop = false;
            // 
            // TxtBanReason
            // 
            resources.ApplyResources(this.TxtBanReason, "TxtBanReason");
            this.TxtBanReason.Name = "TxtBanReason";
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
            // PageManagement
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GrpBanPlayer);
            this.Controls.Add(this.GrpAccount);
            this.Controls.Add(this.GrpPermission);
            this.Name = "PageManagement";
            this.GrpBanPlayer.ResumeLayout(false);
            this.GrpBanPlayer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDBanUID)).EndInit();
            this.GrpAccount.ResumeLayout(false);
            this.GrpAccount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDAccountUid)).EndInit();
            this.GrpPermission.ResumeLayout(false);
            this.GrpPermission.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDPermUID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpBanPlayer;
        private System.Windows.Forms.DateTimePicker DTPBanEndTime;
        private System.Windows.Forms.Button BtnUnban;
        private System.Windows.Forms.Button BtnBan;
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
        private System.Windows.Forms.Button BtnPermClear;
        private System.Windows.Forms.Button BtmPermRemove;
        private System.Windows.Forms.Button BtnPermList;
        private System.Windows.Forms.Button BtnPermAdd;
        private System.Windows.Forms.Label LblPerm;
        private System.Windows.Forms.Label LblPermUID;
        private System.Windows.Forms.TextBox TxtBanReason;
    }
}
