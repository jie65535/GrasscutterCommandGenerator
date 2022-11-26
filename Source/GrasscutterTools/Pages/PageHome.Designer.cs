namespace GrasscutterTools.Pages
{
    partial class PageHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageHome));
            this.BtnOpenShopEditor = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.GrasscutterToolsIcon)).BeginInit();
            this.GrpSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDUid)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnOpenShopEditor
            // 
            resources.ApplyResources(this.BtnOpenShopEditor, "BtnOpenShopEditor");
            this.BtnOpenShopEditor.Name = "BtnOpenShopEditor";
            this.BtnOpenShopEditor.UseVisualStyleBackColor = true;
            this.BtnOpenShopEditor.Click += new System.EventHandler(this.BtnOpenShopEditor_Click);
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
            // PageHome
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LblAbout);
            this.Controls.Add(this.BtnOpenTextMap);
            this.Controls.Add(this.BtnOpenGachaBannerEditor);
            this.Controls.Add(this.BtnOpenDropEditor);
            this.Controls.Add(this.BtnOpenShopEditor);
            this.Controls.Add(this.GrasscutterToolsIcon);
            this.Controls.Add(this.GrpSettings);
            this.Controls.Add(this.LnkNewVersion);
            this.Name = "PageHome";
            ((System.ComponentModel.ISupportInitialize)(this.GrasscutterToolsIcon)).EndInit();
            this.GrpSettings.ResumeLayout(false);
            this.GrpSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDUid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnOpenShopEditor;
        private System.Windows.Forms.Button BtnOpenDropEditor;
        private System.Windows.Forms.LinkLabel LnkNewVersion;
        private System.Windows.Forms.Label LblAbout;
        private System.Windows.Forms.Button BtnOpenTextMap;
        private System.Windows.Forms.Button BtnOpenGachaBannerEditor;
        private System.Windows.Forms.PictureBox GrasscutterToolsIcon;
        private System.Windows.Forms.GroupBox GrpSettings;
        private System.Windows.Forms.Label LblGCVersion;
        private System.Windows.Forms.ComboBox CmbGcVersions;
        private System.Windows.Forms.CheckBox ChkTopMost;
        private System.Windows.Forms.ComboBox CmbLanguage;
        private System.Windows.Forms.Label LblLanguage;
        private System.Windows.Forms.NumericUpDown NUDUid;
        private System.Windows.Forms.CheckBox ChkIncludeUID;
        private System.Windows.Forms.Label LblDefaultUid;
    }
}
