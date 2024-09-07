namespace GrasscutterTools.Pages
{
    partial class PageMail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageMail));
            this.LblClearMailContent = new System.Windows.Forms.Label();
            this.BtnAddMailItem = new System.Windows.Forms.Button();
            this.BtnDeleteMailItem = new System.Windows.Forms.Button();
            this.TCMailRight = new System.Windows.Forms.TabControl();
            this.TPMailSelectableItemList = new System.Windows.Forms.TabPage();
            this.LblClearFilter = new System.Windows.Forms.Label();
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
            this.TPMailSelectableItemList.Controls.Add(this.LblClearFilter);
            this.TPMailSelectableItemList.Controls.Add(this.ListMailSelectableItems);
            this.TPMailSelectableItemList.Controls.Add(this.TxtMailSelectableItemFilter);
            this.TPMailSelectableItemList.Controls.Add(this.PanelMailItemArgs);
            resources.ApplyResources(this.TPMailSelectableItemList, "TPMailSelectableItemList");
            this.TPMailSelectableItemList.Name = "TPMailSelectableItemList";
            this.TPMailSelectableItemList.UseVisualStyleBackColor = true;
            // 
            // LblClearFilter
            // 
            resources.ApplyResources(this.LblClearFilter, "LblClearFilter");
            this.LblClearFilter.BackColor = System.Drawing.Color.White;
            this.LblClearFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblClearFilter.Name = "LblClearFilter";
            this.LblClearFilter.Click += new System.EventHandler(this.LblClearFilter_Click);
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
            this.ListMailItems.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.ListMailItems_MeasureItem);
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
            // PageMail
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LblClearMailContent);
            this.Controls.Add(this.BtnAddMailItem);
            this.Controls.Add(this.BtnDeleteMailItem);
            this.Controls.Add(this.TCMailRight);
            this.Controls.Add(this.BtnSendMail);
            this.Controls.Add(this.ListMailItems);
            this.Controls.Add(this.LblMailItemsLabel);
            this.Controls.Add(this.NUDMailRecipient);
            this.Controls.Add(this.RbMailSendToPlayer);
            this.Controls.Add(this.RbMailSendToAll);
            this.Controls.Add(this.LblMailRecipientLabel);
            this.Controls.Add(this.TxtMailContent);
            this.Controls.Add(this.LblMailContentLabel);
            this.Controls.Add(this.TxtMailTitle);
            this.Controls.Add(this.LblMailTitleLabel);
            this.Controls.Add(this.TxtMailSender);
            this.Controls.Add(this.LblMailSenderLabel);
            this.Name = "PageMail";
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
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblClearMailContent;
        private System.Windows.Forms.Button BtnAddMailItem;
        private System.Windows.Forms.Button BtnDeleteMailItem;
        private System.Windows.Forms.TabControl TCMailRight;
        private System.Windows.Forms.TabPage TPMailSelectableItemList;
        private System.Windows.Forms.ListBox ListMailSelectableItems;
        private System.Windows.Forms.TextBox TxtMailSelectableItemFilter;
        private System.Windows.Forms.Panel PanelMailItemArgs;
        private System.Windows.Forms.NumericUpDown NUDMailItemLevel;
        private System.Windows.Forms.NumericUpDown NUDMailItemCount;
        private System.Windows.Forms.Label LblMailItemCount;
        private System.Windows.Forms.Label LblMailItemLevel;
        private System.Windows.Forms.TabPage TPMailList;
        private System.Windows.Forms.ListBox ListMailList;
        private System.Windows.Forms.Panel PanelMailListControls;
        private System.Windows.Forms.Button BtnClearMail;
        private System.Windows.Forms.Button BtnRemoveMail;
        private System.Windows.Forms.Button BtnSendMail;
        private System.Windows.Forms.ListBox ListMailItems;
        private System.Windows.Forms.Label LblMailItemsLabel;
        private System.Windows.Forms.NumericUpDown NUDMailRecipient;
        private System.Windows.Forms.RadioButton RbMailSendToPlayer;
        private System.Windows.Forms.RadioButton RbMailSendToAll;
        private System.Windows.Forms.Label LblMailRecipientLabel;
        private System.Windows.Forms.TextBox TxtMailContent;
        private System.Windows.Forms.Label LblMailContentLabel;
        private System.Windows.Forms.TextBox TxtMailTitle;
        private System.Windows.Forms.Label LblMailTitleLabel;
        private System.Windows.Forms.TextBox TxtMailSender;
        private System.Windows.Forms.Label LblMailSenderLabel;
        private System.Windows.Forms.Label LblClearFilter;
    }
}
