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
            this.GrpItemList = new System.Windows.Forms.GroupBox();
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
            this.LblDropPathLabel.AutoSize = true;
            this.LblDropPathLabel.Location = new System.Drawing.Point(17, 15);
            this.LblDropPathLabel.Name = "LblDropPathLabel";
            this.LblDropPathLabel.Size = new System.Drawing.Size(105, 17);
            this.LblDropPathLabel.TabIndex = 0;
            this.LblDropPathLabel.Text = "Drop.json 路径：";
            // 
            // TxtDropJsonPath
            // 
            this.TxtDropJsonPath.Location = new System.Drawing.Point(128, 12);
            this.TxtDropJsonPath.Name = "TxtDropJsonPath";
            this.TxtDropJsonPath.Size = new System.Drawing.Size(487, 23);
            this.TxtDropJsonPath.TabIndex = 1;
            // 
            // BtnLoad
            // 
            this.BtnLoad.Location = new System.Drawing.Point(621, 12);
            this.BtnLoad.Name = "BtnLoad";
            this.BtnLoad.Size = new System.Drawing.Size(75, 23);
            this.BtnLoad.TabIndex = 2;
            this.BtnLoad.Text = "加载";
            this.BtnLoad.UseVisualStyleBackColor = true;
            this.BtnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(702, 12);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 3;
            this.BtnSave.Text = "保存";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // ListMonsters
            // 
            this.ListMonsters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListMonsters.FormattingEnabled = true;
            this.ListMonsters.ItemHeight = 17;
            this.ListMonsters.Location = new System.Drawing.Point(6, 51);
            this.ListMonsters.Name = "ListMonsters";
            this.ListMonsters.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListMonsters.Size = new System.Drawing.Size(238, 344);
            this.ListMonsters.TabIndex = 4;
            this.ListMonsters.SelectedIndexChanged += new System.EventHandler(this.ListMonsters_SelectedIndexChanged);
            // 
            // TxtMonsterFilter
            // 
            this.TxtMonsterFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtMonsterFilter.Location = new System.Drawing.Point(6, 22);
            this.TxtMonsterFilter.Name = "TxtMonsterFilter";
            this.TxtMonsterFilter.Size = new System.Drawing.Size(238, 23);
            this.TxtMonsterFilter.TabIndex = 5;
            this.TxtMonsterFilter.TextChanged += new System.EventHandler(this.TxtMonsterFilter_TextChanged);
            // 
            // TxtItemFilter
            // 
            this.TxtItemFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtItemFilter.Location = new System.Drawing.Point(6, 22);
            this.TxtItemFilter.Name = "TxtItemFilter";
            this.TxtItemFilter.Size = new System.Drawing.Size(238, 23);
            this.TxtItemFilter.TabIndex = 6;
            this.TxtItemFilter.TextChanged += new System.EventHandler(this.TxtItemFilter_TextChanged);
            // 
            // ListDropData
            // 
            this.ListDropData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListDropData.FormattingEnabled = true;
            this.ListDropData.ItemHeight = 17;
            this.ListDropData.Location = new System.Drawing.Point(6, 22);
            this.ListDropData.Name = "ListDropData";
            this.ListDropData.Size = new System.Drawing.Size(288, 174);
            this.ListDropData.TabIndex = 7;
            this.ListDropData.SelectedIndexChanged += new System.EventHandler(this.ListDropData_SelectedIndexChanged);
            // 
            // GrpDropList
            // 
            this.GrpDropList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.GrpDropList.Location = new System.Drawing.Point(270, 41);
            this.GrpDropList.Name = "GrpDropList";
            this.GrpDropList.Size = new System.Drawing.Size(300, 400);
            this.GrpDropList.TabIndex = 8;
            this.GrpDropList.TabStop = false;
            this.GrpDropList.Text = "掉落列表";
            // 
            // BtnCopyAll
            // 
            this.BtnCopyAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnCopyAll.Location = new System.Drawing.Point(87, 202);
            this.BtnCopyAll.Name = "BtnCopyAll";
            this.BtnCopyAll.Size = new System.Drawing.Size(75, 23);
            this.BtnCopyAll.TabIndex = 22;
            this.BtnCopyAll.Text = "复制全部";
            this.BtnCopyAll.UseVisualStyleBackColor = true;
            this.BtnCopyAll.Click += new System.EventHandler(this.BtnCopyAll_Click);
            // 
            // BtnClear
            // 
            this.BtnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnClear.Location = new System.Drawing.Point(87, 230);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(75, 23);
            this.BtnClear.TabIndex = 21;
            this.BtnClear.Text = "× 清空";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // BtnPaste
            // 
            this.BtnPaste.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnPaste.Location = new System.Drawing.Point(168, 202);
            this.BtnPaste.Name = "BtnPaste";
            this.BtnPaste.Size = new System.Drawing.Size(75, 23);
            this.BtnPaste.TabIndex = 20;
            this.BtnPaste.Text = "粘贴";
            this.BtnPaste.UseVisualStyleBackColor = true;
            this.BtnPaste.Click += new System.EventHandler(this.BtnPaste_Click);
            // 
            // BtnCopy
            // 
            this.BtnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnCopy.Location = new System.Drawing.Point(6, 202);
            this.BtnCopy.Name = "BtnCopy";
            this.BtnCopy.Size = new System.Drawing.Size(75, 23);
            this.BtnCopy.TabIndex = 19;
            this.BtnCopy.Text = "复制";
            this.BtnCopy.UseVisualStyleBackColor = true;
            this.BtnCopy.Click += new System.EventHandler(this.BtnCopy_Click);
            // 
            // TxtItem
            // 
            this.TxtItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TxtItem.Location = new System.Drawing.Point(113, 280);
            this.TxtItem.Name = "TxtItem";
            this.TxtItem.Size = new System.Drawing.Size(137, 23);
            this.TxtItem.TabIndex = 12;
            // 
            // BtnDelete
            // 
            this.BtnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnDelete.Location = new System.Drawing.Point(6, 230);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(75, 23);
            this.BtnDelete.TabIndex = 18;
            this.BtnDelete.Text = "- 删除";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnAddOrUpdate
            // 
            this.BtnAddOrUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnAddOrUpdate.Location = new System.Drawing.Point(54, 371);
            this.BtnAddOrUpdate.Name = "BtnAddOrUpdate";
            this.BtnAddOrUpdate.Size = new System.Drawing.Size(196, 23);
            this.BtnAddOrUpdate.TabIndex = 17;
            this.BtnAddOrUpdate.Text = "+ 添加";
            this.BtnAddOrUpdate.UseVisualStyleBackColor = true;
            this.BtnAddOrUpdate.Click += new System.EventHandler(this.BtnAddOrUpdate_Click);
            // 
            // LblItemLabel
            // 
            this.LblItemLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblItemLabel.AutoSize = true;
            this.LblItemLabel.Location = new System.Drawing.Point(51, 283);
            this.LblItemLabel.Name = "LblItemLabel";
            this.LblItemLabel.Size = new System.Drawing.Size(56, 17);
            this.LblItemLabel.TabIndex = 15;
            this.LblItemLabel.Text = "掉落物：";
            // 
            // LblTilde2
            // 
            this.LblTilde2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblTilde2.AutoSize = true;
            this.LblTilde2.Location = new System.Drawing.Point(167, 342);
            this.LblTilde2.Name = "LblTilde2";
            this.LblTilde2.Size = new System.Drawing.Size(17, 17);
            this.LblTilde2.TabIndex = 14;
            this.LblTilde2.Text = "~";
            // 
            // LblTilde1
            // 
            this.LblTilde1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblTilde1.AutoSize = true;
            this.LblTilde1.Location = new System.Drawing.Point(167, 313);
            this.LblTilde1.Name = "LblTilde1";
            this.LblTilde1.Size = new System.Drawing.Size(17, 17);
            this.LblTilde1.TabIndex = 14;
            this.LblTilde1.Text = "~";
            // 
            // NUDMaxWeight
            // 
            this.NUDMaxWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NUDMaxWeight.Location = new System.Drawing.Point(190, 340);
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
            this.NUDMaxWeight.Size = new System.Drawing.Size(60, 23);
            this.NUDMaxWeight.TabIndex = 13;
            this.NUDMaxWeight.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // NUDMinWeight
            // 
            this.NUDMinWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NUDMinWeight.Location = new System.Drawing.Point(101, 342);
            this.NUDMinWeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NUDMinWeight.Name = "NUDMinWeight";
            this.NUDMinWeight.Size = new System.Drawing.Size(60, 23);
            this.NUDMinWeight.TabIndex = 12;
            // 
            // NUDMaxCount
            // 
            this.NUDMaxCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NUDMaxCount.Location = new System.Drawing.Point(190, 311);
            this.NUDMaxCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NUDMaxCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDMaxCount.Name = "NUDMaxCount";
            this.NUDMaxCount.Size = new System.Drawing.Size(60, 23);
            this.NUDMaxCount.TabIndex = 11;
            this.NUDMaxCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NUDMinCount
            // 
            this.NUDMinCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NUDMinCount.Location = new System.Drawing.Point(101, 311);
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
            this.NUDMinCount.Size = new System.Drawing.Size(60, 23);
            this.NUDMinCount.TabIndex = 10;
            this.NUDMinCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LblWeightLabel
            // 
            this.LblWeightLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblWeightLabel.AutoSize = true;
            this.LblWeightLabel.Location = new System.Drawing.Point(51, 344);
            this.LblWeightLabel.Name = "LblWeightLabel";
            this.LblWeightLabel.Size = new System.Drawing.Size(44, 17);
            this.LblWeightLabel.TabIndex = 9;
            this.LblWeightLabel.Text = "权重：";
            // 
            // LblCountLabel
            // 
            this.LblCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblCountLabel.AutoSize = true;
            this.LblCountLabel.Location = new System.Drawing.Point(51, 313);
            this.LblCountLabel.Name = "LblCountLabel";
            this.LblCountLabel.Size = new System.Drawing.Size(44, 17);
            this.LblCountLabel.TabIndex = 8;
            this.LblCountLabel.Text = "数量：";
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
            this.ListItems.Size = new System.Drawing.Size(238, 344);
            this.ListItems.TabIndex = 9;
            this.ListItems.SelectedIndexChanged += new System.EventHandler(this.ListItems_SelectedIndexChanged);
            // 
            // GrpMonsterList
            // 
            this.GrpMonsterList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.GrpMonsterList.Controls.Add(this.ListMonsters);
            this.GrpMonsterList.Controls.Add(this.TxtMonsterFilter);
            this.GrpMonsterList.Location = new System.Drawing.Point(12, 41);
            this.GrpMonsterList.Name = "GrpMonsterList";
            this.GrpMonsterList.Size = new System.Drawing.Size(250, 400);
            this.GrpMonsterList.TabIndex = 10;
            this.GrpMonsterList.TabStop = false;
            this.GrpMonsterList.Text = "怪物列表";
            // 
            // GrpItemList
            // 
            this.GrpItemList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpItemList.Controls.Add(this.TxtItemFilter);
            this.GrpItemList.Controls.Add(this.ListItems);
            this.GrpItemList.Location = new System.Drawing.Point(576, 41);
            this.GrpItemList.Name = "GrpItemList";
            this.GrpItemList.Size = new System.Drawing.Size(250, 400);
            this.GrpItemList.TabIndex = 11;
            this.GrpItemList.TabStop = false;
            this.GrpItemList.Text = "物品列表";
            // 
            // FormDropEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 450);
            this.Controls.Add(this.GrpItemList);
            this.Controls.Add(this.GrpMonsterList);
            this.Controls.Add(this.GrpDropList);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnLoad);
            this.Controls.Add(this.TxtDropJsonPath);
            this.Controls.Add(this.LblDropPathLabel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(855, 489);
            this.Name = "FormDropEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Drop.json Editor";
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
    }
}