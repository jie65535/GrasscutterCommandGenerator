namespace GrasscutterTools.Pages
{
    partial class PageSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageSettings));
            this.LblPageTitle = new System.Windows.Forms.Label();
            this.NUDUid = new System.Windows.Forms.NumericUpDown();
            this.ChkIncludeUID = new System.Windows.Forms.CheckBox();
            this.LblIncludeUidTip = new System.Windows.Forms.Label();
            this.GrpPageList = new System.Windows.Forms.GroupBox();
            this.BtnResetPageList = new System.Windows.Forms.Button();
            this.BtnMoveDown = new System.Windows.Forms.Button();
            this.BtnMoveUp = new System.Windows.Forms.Button();
            this.ChkListPages = new System.Windows.Forms.CheckedListBox();
            this.LblGCVersion = new System.Windows.Forms.Label();
            this.CmbGcVersions = new System.Windows.Forms.ComboBox();
            this.LblGcVersionTip = new System.Windows.Forms.Label();
            this.ChkTopMost = new System.Windows.Forms.CheckBox();
            this.LblWindowOpacity = new System.Windows.Forms.Label();
            this.TbWindowOpacity = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.NUDUid)).BeginInit();
            this.GrpPageList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TbWindowOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // LblPageTitle
            // 
            resources.ApplyResources(this.LblPageTitle, "LblPageTitle");
            this.LblPageTitle.Name = "LblPageTitle";
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
            // LblIncludeUidTip
            // 
            resources.ApplyResources(this.LblIncludeUidTip, "LblIncludeUidTip");
            this.LblIncludeUidTip.ForeColor = System.Drawing.SystemColors.GrayText;
            this.LblIncludeUidTip.Name = "LblIncludeUidTip";
            // 
            // GrpPageList
            // 
            resources.ApplyResources(this.GrpPageList, "GrpPageList");
            this.GrpPageList.Controls.Add(this.BtnResetPageList);
            this.GrpPageList.Controls.Add(this.BtnMoveDown);
            this.GrpPageList.Controls.Add(this.BtnMoveUp);
            this.GrpPageList.Controls.Add(this.ChkListPages);
            this.GrpPageList.Name = "GrpPageList";
            this.GrpPageList.TabStop = false;
            // 
            // BtnResetPageList
            // 
            resources.ApplyResources(this.BtnResetPageList, "BtnResetPageList");
            this.BtnResetPageList.Name = "BtnResetPageList";
            this.BtnResetPageList.UseVisualStyleBackColor = true;
            this.BtnResetPageList.Click += new System.EventHandler(this.BtnResetPageList_Click);
            // 
            // BtnMoveDown
            // 
            resources.ApplyResources(this.BtnMoveDown, "BtnMoveDown");
            this.BtnMoveDown.Name = "BtnMoveDown";
            this.BtnMoveDown.UseVisualStyleBackColor = true;
            this.BtnMoveDown.Click += new System.EventHandler(this.BtnMoveDown_Click);
            // 
            // BtnMoveUp
            // 
            resources.ApplyResources(this.BtnMoveUp, "BtnMoveUp");
            this.BtnMoveUp.Name = "BtnMoveUp";
            this.BtnMoveUp.UseVisualStyleBackColor = true;
            this.BtnMoveUp.Click += new System.EventHandler(this.BtnMoveUp_Click);
            // 
            // ChkListPages
            // 
            resources.ApplyResources(this.ChkListPages, "ChkListPages");
            this.ChkListPages.FormattingEnabled = true;
            this.ChkListPages.Name = "ChkListPages";
            this.ChkListPages.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ChkListPages_ItemCheck);
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
            // LblGcVersionTip
            // 
            resources.ApplyResources(this.LblGcVersionTip, "LblGcVersionTip");
            this.LblGcVersionTip.ForeColor = System.Drawing.SystemColors.GrayText;
            this.LblGcVersionTip.Name = "LblGcVersionTip";
            // 
            // ChkTopMost
            // 
            resources.ApplyResources(this.ChkTopMost, "ChkTopMost");
            this.ChkTopMost.Name = "ChkTopMost";
            this.ChkTopMost.UseVisualStyleBackColor = true;
            // 
            // LblWindowOpacity
            // 
            resources.ApplyResources(this.LblWindowOpacity, "LblWindowOpacity");
            this.LblWindowOpacity.Name = "LblWindowOpacity";
            // 
            // TbWindowOpacity
            // 
            resources.ApplyResources(this.TbWindowOpacity, "TbWindowOpacity");
            this.TbWindowOpacity.Maximum = 100;
            this.TbWindowOpacity.Minimum = 5;
            this.TbWindowOpacity.Name = "TbWindowOpacity";
            this.TbWindowOpacity.TickFrequency = 20;
            this.TbWindowOpacity.Value = 100;
            // 
            // PageSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TbWindowOpacity);
            this.Controls.Add(this.LblWindowOpacity);
            this.Controls.Add(this.ChkTopMost);
            this.Controls.Add(this.LblGcVersionTip);
            this.Controls.Add(this.LblGCVersion);
            this.Controls.Add(this.CmbGcVersions);
            this.Controls.Add(this.GrpPageList);
            this.Controls.Add(this.LblIncludeUidTip);
            this.Controls.Add(this.NUDUid);
            this.Controls.Add(this.ChkIncludeUID);
            this.Controls.Add(this.LblPageTitle);
            this.Name = "PageSettings";
            ((System.ComponentModel.ISupportInitialize)(this.NUDUid)).EndInit();
            this.GrpPageList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TbWindowOpacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblPageTitle;
        private System.Windows.Forms.NumericUpDown NUDUid;
        private System.Windows.Forms.CheckBox ChkIncludeUID;
        private System.Windows.Forms.Label LblIncludeUidTip;
        private System.Windows.Forms.GroupBox GrpPageList;
        private System.Windows.Forms.Button BtnMoveDown;
        private System.Windows.Forms.Button BtnMoveUp;
        private System.Windows.Forms.CheckedListBox ChkListPages;
        private System.Windows.Forms.Label LblGCVersion;
        private System.Windows.Forms.ComboBox CmbGcVersions;
        private System.Windows.Forms.Label LblGcVersionTip;
        private System.Windows.Forms.CheckBox ChkTopMost;
        private System.Windows.Forms.Label LblWindowOpacity;
        private System.Windows.Forms.TrackBar TbWindowOpacity;
        private System.Windows.Forms.Button BtnResetPageList;
    }
}
