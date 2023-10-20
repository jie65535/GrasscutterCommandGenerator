namespace GrasscutterTools.Forms
{
    partial class FormDropEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDropEditor));
            this.LblDropPathLabel = new System.Windows.Forms.Label();
            this.TxtDropJsonPath = new System.Windows.Forms.TextBox();
            this.BtnLoad = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.ListMonsters = new System.Windows.Forms.ListBox();
            this.TxtMonsterFilter = new System.Windows.Forms.TextBox();
            this.TxtItemFilter = new System.Windows.Forms.TextBox();
            this.ListDropData = new System.Windows.Forms.ListBox();
            this.GrpDropList = new System.Windows.Forms.GroupBox();
            this.BtnCopyAll = new System.Windows.Forms.Button();
            this.BtnClear = new System.Windows.Forms.Button();
            this.BtnPaste = new System.Windows.Forms.Button();
            this.BtnCopy = new System.Windows.Forms.Button();
            this.TxtItem = new System.Windows.Forms.TextBox();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnAddOrUpdate = new System.Windows.Forms.Button();
            this.LblItemLabel = new System.Windows.Forms.Label();
            this.LblTilde2 = new System.Windows.Forms.Label();
            this.LblTilde1 = new System.Windows.Forms.Label();
            this.NUDMaxWeight = new System.Windows.Forms.NumericUpDown();
            this.NUDMinWeight = new System.Windows.Forms.NumericUpDown();
            this.NUDMaxCount = new System.Windows.Forms.NumericUpDown();
            this.NUDMinCount = new System.Windows.Forms.NumericUpDown();
            this.LblWeightLabel = new System.Windows.Forms.Label();
            this.LblCountLabel = new System.Windows.Forms.Label();
            this.ListItems = new System.Windows.Forms.ListBox();
            this.GrpMonsterList = new System.Windows.Forms.GroupBox();
            this.LblClearMonsterFilter = new System.Windows.Forms.Label();
            this.GrpItemList = new System.Windows.Forms.GroupBox();
            this.LblClearItemFilter = new System.Windows.Forms.Label();
            this.GrpDropList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDMaxWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDMinWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDMaxCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDMinCount)).BeginInit();
            this.GrpMonsterList.SuspendLayout();
            this.GrpItemList.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblDropPathLabel
            // 
            resources.ApplyResources(this.LblDropPathLabel, "LblDropPathLabel");
            this.LblDropPathLabel.Name = "LblDropPathLabel";
            // 
            // TxtDropJsonPath
            // 
            resources.ApplyResources(this.TxtDropJsonPath, "TxtDropJsonPath");
            this.TxtDropJsonPath.Name = "TxtDropJsonPath";
            // 
            // BtnLoad
            // 
            resources.ApplyResources(this.BtnLoad, "BtnLoad");
            this.BtnLoad.Name = "BtnLoad";
            this.BtnLoad.UseVisualStyleBackColor = true;
            this.BtnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // BtnSave
            // 
            resources.ApplyResources(this.BtnSave, "BtnSave");
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // ListMonsters
            // 
            resources.ApplyResources(this.ListMonsters, "ListMonsters");
            this.ListMonsters.FormattingEnabled = true;
            this.ListMonsters.Name = "ListMonsters";
            this.ListMonsters.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListMonsters.SelectedIndexChanged += new System.EventHandler(this.ListMonsters_SelectedIndexChanged);
            // 
            // TxtMonsterFilter
            // 
            resources.ApplyResources(this.TxtMonsterFilter, "TxtMonsterFilter");
            this.TxtMonsterFilter.Name = "TxtMonsterFilter";
            this.TxtMonsterFilter.TextChanged += new System.EventHandler(this.TxtMonsterFilter_TextChanged);
            // 
            // TxtItemFilter
            // 
            resources.ApplyResources(this.TxtItemFilter, "TxtItemFilter");
            this.TxtItemFilter.Name = "TxtItemFilter";
            this.TxtItemFilter.TextChanged += new System.EventHandler(this.TxtItemFilter_TextChanged);
            // 
            // ListDropData
            // 
            resources.ApplyResources(this.ListDropData, "ListDropData");
            this.ListDropData.FormattingEnabled = true;
            this.ListDropData.Name = "ListDropData";
            this.ListDropData.SelectedIndexChanged += new System.EventHandler(this.ListDropData_SelectedIndexChanged);
            // 
            // GrpDropList
            // 
            resources.ApplyResources(this.GrpDropList, "GrpDropList");
            this.GrpDropList.Controls.Add(this.BtnCopyAll);
            this.GrpDropList.Controls.Add(this.BtnClear);
            this.GrpDropList.Controls.Add(this.BtnPaste);
            this.GrpDropList.Controls.Add(this.BtnCopy);
            this.GrpDropList.Controls.Add(this.TxtItem);
            this.GrpDropList.Controls.Add(this.BtnDelete);
            this.GrpDropList.Controls.Add(this.BtnAddOrUpdate);
            this.GrpDropList.Controls.Add(this.LblItemLabel);
            this.GrpDropList.Controls.Add(this.LblTilde2);
            this.GrpDropList.Controls.Add(this.LblTilde1);
            this.GrpDropList.Controls.Add(this.NUDMaxWeight);
            this.GrpDropList.Controls.Add(this.NUDMinWeight);
            this.GrpDropList.Controls.Add(this.NUDMaxCount);
            this.GrpDropList.Controls.Add(this.NUDMinCount);
            this.GrpDropList.Controls.Add(this.LblWeightLabel);
            this.GrpDropList.Controls.Add(this.LblCountLabel);
            this.GrpDropList.Controls.Add(this.ListDropData);
            this.GrpDropList.Name = "GrpDropList";
            this.GrpDropList.TabStop = false;
            // 
            // BtnCopyAll
            // 
            resources.ApplyResources(this.BtnCopyAll, "BtnCopyAll");
            this.BtnCopyAll.Name = "BtnCopyAll";
            this.BtnCopyAll.UseVisualStyleBackColor = true;
            this.BtnCopyAll.Click += new System.EventHandler(this.BtnCopyAll_Click);
            // 
            // BtnClear
            // 
            resources.ApplyResources(this.BtnClear, "BtnClear");
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // BtnPaste
            // 
            resources.ApplyResources(this.BtnPaste, "BtnPaste");
            this.BtnPaste.Name = "BtnPaste";
            this.BtnPaste.UseVisualStyleBackColor = true;
            this.BtnPaste.Click += new System.EventHandler(this.BtnPaste_Click);
            // 
            // BtnCopy
            // 
            resources.ApplyResources(this.BtnCopy, "BtnCopy");
            this.BtnCopy.Name = "BtnCopy";
            this.BtnCopy.UseVisualStyleBackColor = true;
            this.BtnCopy.Click += new System.EventHandler(this.BtnCopy_Click);
            // 
            // TxtItem
            // 
            resources.ApplyResources(this.TxtItem, "TxtItem");
            this.TxtItem.Name = "TxtItem";
            // 
            // BtnDelete
            // 
            resources.ApplyResources(this.BtnDelete, "BtnDelete");
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnAddOrUpdate
            // 
            resources.ApplyResources(this.BtnAddOrUpdate, "BtnAddOrUpdate");
            this.BtnAddOrUpdate.Name = "BtnAddOrUpdate";
            this.BtnAddOrUpdate.UseVisualStyleBackColor = true;
            this.BtnAddOrUpdate.Click += new System.EventHandler(this.BtnAddOrUpdate_Click);
            // 
            // LblItemLabel
            // 
            resources.ApplyResources(this.LblItemLabel, "LblItemLabel");
            this.LblItemLabel.Name = "LblItemLabel";
            // 
            // LblTilde2
            // 
            resources.ApplyResources(this.LblTilde2, "LblTilde2");
            this.LblTilde2.Name = "LblTilde2";
            // 
            // LblTilde1
            // 
            resources.ApplyResources(this.LblTilde1, "LblTilde1");
            this.LblTilde1.Name = "LblTilde1";
            // 
            // NUDMaxWeight
            // 
            resources.ApplyResources(this.NUDMaxWeight, "NUDMaxWeight");
            this.NUDMaxWeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NUDMaxWeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDMaxWeight.Name = "NUDMaxWeight";
            this.NUDMaxWeight.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // NUDMinWeight
            // 
            resources.ApplyResources(this.NUDMinWeight, "NUDMinWeight");
            this.NUDMinWeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NUDMinWeight.Name = "NUDMinWeight";
            // 
            // NUDMaxCount
            // 
            resources.ApplyResources(this.NUDMaxCount, "NUDMaxCount");
            this.NUDMaxCount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NUDMaxCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDMaxCount.Name = "NUDMaxCount";
            this.NUDMaxCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NUDMinCount
            // 
            resources.ApplyResources(this.NUDMinCount, "NUDMinCount");
            this.NUDMinCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NUDMinCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDMinCount.Name = "NUDMinCount";
            this.NUDMinCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LblWeightLabel
            // 
            resources.ApplyResources(this.LblWeightLabel, "LblWeightLabel");
            this.LblWeightLabel.Name = "LblWeightLabel";
            // 
            // LblCountLabel
            // 
            resources.ApplyResources(this.LblCountLabel, "LblCountLabel");
            this.LblCountLabel.Name = "LblCountLabel";
            // 
            // ListItems
            // 
            resources.ApplyResources(this.ListItems, "ListItems");
            this.ListItems.FormattingEnabled = true;
            this.ListItems.Name = "ListItems";
            this.ListItems.SelectedIndexChanged += new System.EventHandler(this.ListItems_SelectedIndexChanged);
            // 
            // GrpMonsterList
            // 
            resources.ApplyResources(this.GrpMonsterList, "GrpMonsterList");
            this.GrpMonsterList.Controls.Add(this.LblClearMonsterFilter);
            this.GrpMonsterList.Controls.Add(this.ListMonsters);
            this.GrpMonsterList.Controls.Add(this.TxtMonsterFilter);
            this.GrpMonsterList.Name = "GrpMonsterList";
            this.GrpMonsterList.TabStop = false;
            // 
            // LblClearMonsterFilter
            // 
            resources.ApplyResources(this.LblClearMonsterFilter, "LblClearMonsterFilter");
            this.LblClearMonsterFilter.BackColor = System.Drawing.Color.White;
            this.LblClearMonsterFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblClearMonsterFilter.Name = "LblClearMonsterFilter";
            this.LblClearMonsterFilter.Click += new System.EventHandler(this.LblClearMonsterFilter_Click);
            // 
            // GrpItemList
            // 
            resources.ApplyResources(this.GrpItemList, "GrpItemList");
            this.GrpItemList.Controls.Add(this.LblClearItemFilter);
            this.GrpItemList.Controls.Add(this.TxtItemFilter);
            this.GrpItemList.Controls.Add(this.ListItems);
            this.GrpItemList.Name = "GrpItemList";
            this.GrpItemList.TabStop = false;
            // 
            // LblClearItemFilter
            // 
            resources.ApplyResources(this.LblClearItemFilter, "LblClearItemFilter");
            this.LblClearItemFilter.BackColor = System.Drawing.Color.White;
            this.LblClearItemFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblClearItemFilter.Name = "LblClearItemFilter";
            this.LblClearItemFilter.Click += new System.EventHandler(this.LblClearItemFilter_Click);
            // 
            // FormDropEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GrpItemList);
            this.Controls.Add(this.GrpMonsterList);
            this.Controls.Add(this.GrpDropList);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnLoad);
            this.Controls.Add(this.TxtDropJsonPath);
            this.Controls.Add(this.LblDropPathLabel);
            this.Name = "FormDropEditor";
            this.GrpDropList.ResumeLayout(false);
            this.GrpDropList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDMaxWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDMinWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDMaxCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDMinCount)).EndInit();
            this.GrpMonsterList.ResumeLayout(false);
            this.GrpMonsterList.PerformLayout();
            this.GrpItemList.ResumeLayout(false);
            this.GrpItemList.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblDropPathLabel;
        private System.Windows.Forms.TextBox TxtDropJsonPath;
        private System.Windows.Forms.Button BtnLoad;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.ListBox ListMonsters;
        private System.Windows.Forms.TextBox TxtMonsterFilter;
        private System.Windows.Forms.TextBox TxtItemFilter;
        private System.Windows.Forms.ListBox ListDropData;
        private System.Windows.Forms.GroupBox GrpDropList;
        private System.Windows.Forms.Label LblTilde2;
        private System.Windows.Forms.Label LblTilde1;
        private System.Windows.Forms.NumericUpDown NUDMaxWeight;
        private System.Windows.Forms.NumericUpDown NUDMinWeight;
        private System.Windows.Forms.NumericUpDown NUDMaxCount;
        private System.Windows.Forms.NumericUpDown NUDMinCount;
        private System.Windows.Forms.Label LblWeightLabel;
        private System.Windows.Forms.Label LblCountLabel;
        private System.Windows.Forms.Label LblItemLabel;
        private System.Windows.Forms.ListBox ListItems;
        private System.Windows.Forms.GroupBox GrpMonsterList;
        private System.Windows.Forms.GroupBox GrpItemList;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnAddOrUpdate;
        private System.Windows.Forms.TextBox TxtItem;
        private System.Windows.Forms.Button BtnCopy;
        private System.Windows.Forms.Button BtnPaste;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.Button BtnCopyAll;
        private System.Windows.Forms.Label LblClearMonsterFilter;
        private System.Windows.Forms.Label LblClearItemFilter;
    }
}