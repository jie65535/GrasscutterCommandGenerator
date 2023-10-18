namespace GrasscutterTools.Pages
{
    partial class PageSceneTag
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageSceneTag));
            this.TvSceneTags = new System.Windows.Forms.TreeView();
            this.GrpOnSelectedCheck = new System.Windows.Forms.GroupBox();
            this.RbOnSelectedUncheck = new System.Windows.Forms.RadioButton();
            this.RbOnSelectedCheck = new System.Windows.Forms.RadioButton();
            this.GrpOnDefaultSelectedCheck = new System.Windows.Forms.GroupBox();
            this.RbOnDefaultSelectedCheck = new System.Windows.Forms.RadioButton();
            this.RbOnDefaultSelectedUncheck = new System.Windows.Forms.RadioButton();
            this.LblTitle = new System.Windows.Forms.Label();
            this.LblDefaultTagTip = new System.Windows.Forms.Label();
            this.BtnUnlockAll = new System.Windows.Forms.Button();
            this.ChkOnSceneSelectedEnter = new System.Windows.Forms.CheckBox();
            this.LblRightButtonClickTip = new System.Windows.Forms.Label();
            this.BtnResetAll = new System.Windows.Forms.Button();
            this.GrpOnSelectedCheck.SuspendLayout();
            this.GrpOnDefaultSelectedCheck.SuspendLayout();
            this.SuspendLayout();
            // 
            // TvSceneTags
            // 
            resources.ApplyResources(this.TvSceneTags, "TvSceneTags");
            this.TvSceneTags.FullRowSelect = true;
            this.TvSceneTags.Name = "TvSceneTags";
            this.TvSceneTags.ShowLines = false;
            this.TvSceneTags.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TvSceneTags_NodeMouseClick);
            // 
            // GrpOnSelectedCheck
            // 
            resources.ApplyResources(this.GrpOnSelectedCheck, "GrpOnSelectedCheck");
            this.GrpOnSelectedCheck.Controls.Add(this.RbOnSelectedUncheck);
            this.GrpOnSelectedCheck.Controls.Add(this.RbOnSelectedCheck);
            this.GrpOnSelectedCheck.Name = "GrpOnSelectedCheck";
            this.GrpOnSelectedCheck.TabStop = false;
            // 
            // RbOnSelectedUncheck
            // 
            resources.ApplyResources(this.RbOnSelectedUncheck, "RbOnSelectedUncheck");
            this.RbOnSelectedUncheck.Name = "RbOnSelectedUncheck";
            this.RbOnSelectedUncheck.TabStop = true;
            this.RbOnSelectedUncheck.UseVisualStyleBackColor = true;
            // 
            // RbOnSelectedCheck
            // 
            resources.ApplyResources(this.RbOnSelectedCheck, "RbOnSelectedCheck");
            this.RbOnSelectedCheck.Checked = true;
            this.RbOnSelectedCheck.Name = "RbOnSelectedCheck";
            this.RbOnSelectedCheck.TabStop = true;
            this.RbOnSelectedCheck.UseVisualStyleBackColor = true;
            // 
            // GrpOnDefaultSelectedCheck
            // 
            resources.ApplyResources(this.GrpOnDefaultSelectedCheck, "GrpOnDefaultSelectedCheck");
            this.GrpOnDefaultSelectedCheck.Controls.Add(this.RbOnDefaultSelectedCheck);
            this.GrpOnDefaultSelectedCheck.Controls.Add(this.RbOnDefaultSelectedUncheck);
            this.GrpOnDefaultSelectedCheck.Name = "GrpOnDefaultSelectedCheck";
            this.GrpOnDefaultSelectedCheck.TabStop = false;
            // 
            // RbOnDefaultSelectedCheck
            // 
            resources.ApplyResources(this.RbOnDefaultSelectedCheck, "RbOnDefaultSelectedCheck");
            this.RbOnDefaultSelectedCheck.Name = "RbOnDefaultSelectedCheck";
            this.RbOnDefaultSelectedCheck.TabStop = true;
            this.RbOnDefaultSelectedCheck.UseVisualStyleBackColor = true;
            // 
            // RbOnDefaultSelectedUncheck
            // 
            resources.ApplyResources(this.RbOnDefaultSelectedUncheck, "RbOnDefaultSelectedUncheck");
            this.RbOnDefaultSelectedUncheck.Checked = true;
            this.RbOnDefaultSelectedUncheck.Name = "RbOnDefaultSelectedUncheck";
            this.RbOnDefaultSelectedUncheck.TabStop = true;
            this.RbOnDefaultSelectedUncheck.UseVisualStyleBackColor = true;
            // 
            // LblTitle
            // 
            resources.ApplyResources(this.LblTitle, "LblTitle");
            this.LblTitle.Name = "LblTitle";
            // 
            // LblDefaultTagTip
            // 
            resources.ApplyResources(this.LblDefaultTagTip, "LblDefaultTagTip");
            this.LblDefaultTagTip.ForeColor = System.Drawing.SystemColors.GrayText;
            this.LblDefaultTagTip.Name = "LblDefaultTagTip";
            // 
            // BtnUnlockAll
            // 
            resources.ApplyResources(this.BtnUnlockAll, "BtnUnlockAll");
            this.BtnUnlockAll.Name = "BtnUnlockAll";
            this.BtnUnlockAll.UseVisualStyleBackColor = true;
            this.BtnUnlockAll.Click += new System.EventHandler(this.BtnUnlockAll_Click);
            // 
            // ChkOnSceneSelectedEnter
            // 
            resources.ApplyResources(this.ChkOnSceneSelectedEnter, "ChkOnSceneSelectedEnter");
            this.ChkOnSceneSelectedEnter.Name = "ChkOnSceneSelectedEnter";
            this.ChkOnSceneSelectedEnter.UseVisualStyleBackColor = true;
            // 
            // LblRightButtonClickTip
            // 
            resources.ApplyResources(this.LblRightButtonClickTip, "LblRightButtonClickTip");
            this.LblRightButtonClickTip.ForeColor = System.Drawing.SystemColors.GrayText;
            this.LblRightButtonClickTip.Name = "LblRightButtonClickTip";
            // 
            // BtnResetAll
            // 
            resources.ApplyResources(this.BtnResetAll, "BtnResetAll");
            this.BtnResetAll.Name = "BtnResetAll";
            this.BtnResetAll.UseVisualStyleBackColor = true;
            this.BtnResetAll.Click += new System.EventHandler(this.BtnResetAll_Click);
            // 
            // PageSceneTag
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LblRightButtonClickTip);
            this.Controls.Add(this.ChkOnSceneSelectedEnter);
            this.Controls.Add(this.BtnResetAll);
            this.Controls.Add(this.BtnUnlockAll);
            this.Controls.Add(this.LblDefaultTagTip);
            this.Controls.Add(this.LblTitle);
            this.Controls.Add(this.GrpOnDefaultSelectedCheck);
            this.Controls.Add(this.GrpOnSelectedCheck);
            this.Controls.Add(this.TvSceneTags);
            this.Name = "PageSceneTag";
            this.GrpOnSelectedCheck.ResumeLayout(false);
            this.GrpOnSelectedCheck.PerformLayout();
            this.GrpOnDefaultSelectedCheck.ResumeLayout(false);
            this.GrpOnDefaultSelectedCheck.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView TvSceneTags;
        private System.Windows.Forms.GroupBox GrpOnSelectedCheck;
        private System.Windows.Forms.RadioButton RbOnSelectedUncheck;
        private System.Windows.Forms.RadioButton RbOnSelectedCheck;
        private System.Windows.Forms.GroupBox GrpOnDefaultSelectedCheck;
        private System.Windows.Forms.RadioButton RbOnDefaultSelectedCheck;
        private System.Windows.Forms.RadioButton RbOnDefaultSelectedUncheck;
        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.Label LblDefaultTagTip;
        private System.Windows.Forms.Button BtnUnlockAll;
        private System.Windows.Forms.CheckBox ChkOnSceneSelectedEnter;
        private System.Windows.Forms.Label LblRightButtonClickTip;
        private System.Windows.Forms.Button BtnResetAll;
    }
}
