namespace GrasscutterTools.Forms
{
    partial class FormTextMapBrowser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTextMapBrowser));
            this.TxtTextMapFilter = new System.Windows.Forms.TextBox();
            this.BtnSelectRecoursePath = new System.Windows.Forms.Button();
            this.CmbLanguage = new System.Windows.Forms.ComboBox();
            this.LblLanguage = new System.Windows.Forms.Label();
            this.ChkTopMost = new System.Windows.Forms.CheckBox();
            this.LblResourcesPath = new System.Windows.Forms.Label();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.DGVTextMap = new System.Windows.Forms.DataGridView();
            this.ColumnHash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTextMap)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtTextMapFilter
            // 
            resources.ApplyResources(this.TxtTextMapFilter, "TxtTextMapFilter");
            this.TxtTextMapFilter.Name = "TxtTextMapFilter";
            this.TxtTextMapFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtTextMapFilter_KeyDown);
            // 
            // BtnSelectRecoursePath
            // 
            resources.ApplyResources(this.BtnSelectRecoursePath, "BtnSelectRecoursePath");
            this.BtnSelectRecoursePath.Name = "BtnSelectRecoursePath";
            this.BtnSelectRecoursePath.UseVisualStyleBackColor = true;
            this.BtnSelectRecoursePath.Click += new System.EventHandler(this.BtnSelectRecoursePath_Click);
            // 
            // CmbLanguage
            // 
            resources.ApplyResources(this.CmbLanguage, "CmbLanguage");
            this.CmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbLanguage.FormattingEnabled = true;
            this.CmbLanguage.Name = "CmbLanguage";
            this.CmbLanguage.SelectedIndexChanged += new System.EventHandler(this.CmbLanguage_SelectedIndexChanged);
            // 
            // LblLanguage
            // 
            resources.ApplyResources(this.LblLanguage, "LblLanguage");
            this.LblLanguage.Name = "LblLanguage";
            // 
            // ChkTopMost
            // 
            resources.ApplyResources(this.ChkTopMost, "ChkTopMost");
            this.ChkTopMost.Name = "ChkTopMost";
            this.ChkTopMost.UseVisualStyleBackColor = true;
            this.ChkTopMost.CheckedChanged += new System.EventHandler(this.ChkTopMost_CheckedChanged);
            // 
            // LblResourcesPath
            // 
            resources.ApplyResources(this.LblResourcesPath, "LblResourcesPath");
            this.LblResourcesPath.Name = "LblResourcesPath";
            // 
            // BtnSearch
            // 
            resources.ApplyResources(this.BtnSearch, "BtnSearch");
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // DGVTextMap
            // 
            resources.ApplyResources(this.DGVTextMap, "DGVTextMap");
            this.DGVTextMap.AllowUserToAddRows = false;
            this.DGVTextMap.AllowUserToDeleteRows = false;
            this.DGVTextMap.AllowUserToResizeRows = false;
            this.DGVTextMap.BackgroundColor = System.Drawing.Color.White;
            this.DGVTextMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVTextMap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnHash,
            this.ColumnID,
            this.ColumnText});
            this.DGVTextMap.Name = "DGVTextMap";
            this.DGVTextMap.ReadOnly = true;
            this.DGVTextMap.RowTemplate.Height = 23;
            // 
            // ColumnHash
            // 
            resources.ApplyResources(this.ColumnHash, "ColumnHash");
            this.ColumnHash.Name = "ColumnHash";
            this.ColumnHash.ReadOnly = true;
            // 
            // ColumnID
            // 
            resources.ApplyResources(this.ColumnID, "ColumnID");
            this.ColumnID.Name = "ColumnID";
            this.ColumnID.ReadOnly = true;
            // 
            // ColumnText
            // 
            resources.ApplyResources(this.ColumnText, "ColumnText");
            this.ColumnText.Name = "ColumnText";
            this.ColumnText.ReadOnly = true;
            // 
            // FormTextMapBrowser
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DGVTextMap);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.ChkTopMost);
            this.Controls.Add(this.LblLanguage);
            this.Controls.Add(this.CmbLanguage);
            this.Controls.Add(this.LblResourcesPath);
            this.Controls.Add(this.BtnSelectRecoursePath);
            this.Controls.Add(this.TxtTextMapFilter);
            this.Name = "FormTextMapBrowser";
            this.Load += new System.EventHandler(this.FormTextMapBrowser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVTextMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TxtTextMapFilter;
        private System.Windows.Forms.Button BtnSelectRecoursePath;
        private System.Windows.Forms.ComboBox CmbLanguage;
        private System.Windows.Forms.Label LblLanguage;
        private System.Windows.Forms.CheckBox ChkTopMost;
        private System.Windows.Forms.Label LblResourcesPath;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.DataGridView DGVTextMap;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHash;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnText;
    }
}