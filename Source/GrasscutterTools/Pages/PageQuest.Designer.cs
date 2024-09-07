namespace GrasscutterTools.Pages
{
    partial class PageQuest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageQuest));
            this.GrpQuestFilters = new System.Windows.Forms.GroupBox();
            this.ChkQuestFilterTEST = new System.Windows.Forms.CheckBox();
            this.ChkQuestFilterUNRELEASED = new System.Windows.Forms.CheckBox();
            this.ChkQuestFilterHIDDEN = new System.Windows.Forms.CheckBox();
            this.BtnFinishQuest = new System.Windows.Forms.Button();
            this.BtnAddQuest = new System.Windows.Forms.Button();
            this.LblQuestDescription = new System.Windows.Forms.Label();
            this.TxtQuestFilter = new System.Windows.Forms.TextBox();
            this.ListQuest = new System.Windows.Forms.ListBox();
            this.LblClearFilter = new System.Windows.Forms.Label();
            this.ChkAddAndFinishQuest = new System.Windows.Forms.CheckBox();
            this.GrpQuestFilters.SuspendLayout();
            this.SuspendLayout();
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
            this.ListQuest.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.ListQuest_MeasureItem);
            this.ListQuest.SelectedIndexChanged += new System.EventHandler(this.ListQuest_SelectedIndexChanged);
            // 
            // LblClearFilter
            // 
            resources.ApplyResources(this.LblClearFilter, "LblClearFilter");
            this.LblClearFilter.BackColor = System.Drawing.Color.White;
            this.LblClearFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblClearFilter.Name = "LblClearFilter";
            this.LblClearFilter.Click += new System.EventHandler(this.LblClearFilter_Click);
            // 
            // ChkAddAndFinishQuest
            // 
            resources.ApplyResources(this.ChkAddAndFinishQuest, "ChkAddAndFinishQuest");
            this.ChkAddAndFinishQuest.Name = "ChkAddAndFinishQuest";
            this.ChkAddAndFinishQuest.UseVisualStyleBackColor = true;
            // 
            // PageQuest
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ChkAddAndFinishQuest);
            this.Controls.Add(this.LblClearFilter);
            this.Controls.Add(this.GrpQuestFilters);
            this.Controls.Add(this.BtnFinishQuest);
            this.Controls.Add(this.BtnAddQuest);
            this.Controls.Add(this.LblQuestDescription);
            this.Controls.Add(this.TxtQuestFilter);
            this.Controls.Add(this.ListQuest);
            this.Name = "PageQuest";
            this.GrpQuestFilters.ResumeLayout(false);
            this.GrpQuestFilters.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpQuestFilters;
        private System.Windows.Forms.CheckBox ChkQuestFilterTEST;
        private System.Windows.Forms.CheckBox ChkQuestFilterUNRELEASED;
        private System.Windows.Forms.CheckBox ChkQuestFilterHIDDEN;
        private System.Windows.Forms.Button BtnFinishQuest;
        private System.Windows.Forms.Button BtnAddQuest;
        private System.Windows.Forms.Label LblQuestDescription;
        private System.Windows.Forms.TextBox TxtQuestFilter;
        private System.Windows.Forms.ListBox ListQuest;
        private System.Windows.Forms.Label LblClearFilter;
        private System.Windows.Forms.CheckBox ChkAddAndFinishQuest;
    }
}
