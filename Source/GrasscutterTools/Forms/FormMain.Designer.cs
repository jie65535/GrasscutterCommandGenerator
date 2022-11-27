namespace GrasscutterTools.Forms
{
    partial class FormMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.CmbCommand = new System.Windows.Forms.ComboBox();
            this.BtnCopy = new System.Windows.Forms.Button();
            this.ChkAutoCopy = new System.Windows.Forms.CheckBox();
            this.GrpCommand = new System.Windows.Forms.GroupBox();
            this.BtnInvokeOpenCommand = new System.Windows.Forms.Button();
            this.TPRemoteCall = new System.Windows.Forms.TabPage();
            this.TPAbout = new System.Windows.Forms.TabPage();
            this.TPManage = new System.Windows.Forms.TabPage();
            this.TPScene = new System.Windows.Forms.TabPage();
            this.TPItem = new System.Windows.Forms.TabPage();
            this.TPWeapon = new System.Windows.Forms.TabPage();
            this.TPAvatar = new System.Windows.Forms.TabPage();
            this.TPSpawn = new System.Windows.Forms.TabPage();
            this.TPQuest = new System.Windows.Forms.TabPage();
            this.TPArtifact = new System.Windows.Forms.TabPage();
            this.TPCustom = new System.Windows.Forms.TabPage();
            this.TPHome = new System.Windows.Forms.TabPage();
            this.TCMain = new System.Windows.Forms.TabControl();
            this.TPMail = new System.Windows.Forms.TabPage();
            this.MenuSpawnEntityFilter = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.GrpCommand.SuspendLayout();
            this.TCMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // CmbCommand
            // 
            resources.ApplyResources(this.CmbCommand, "CmbCommand");
            this.CmbCommand.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CmbCommand.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbCommand.Name = "CmbCommand";
            this.CmbCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCommand_KeyDown);
            // 
            // BtnCopy
            // 
            resources.ApplyResources(this.BtnCopy, "BtnCopy");
            this.BtnCopy.Name = "BtnCopy";
            this.BtnCopy.UseVisualStyleBackColor = true;
            this.BtnCopy.Click += new System.EventHandler(this.BtnCopy_Click);
            // 
            // ChkAutoCopy
            // 
            resources.ApplyResources(this.ChkAutoCopy, "ChkAutoCopy");
            this.ChkAutoCopy.Name = "ChkAutoCopy";
            this.ChkAutoCopy.UseVisualStyleBackColor = true;
            // 
            // GrpCommand
            // 
            resources.ApplyResources(this.GrpCommand, "GrpCommand");
            this.GrpCommand.Controls.Add(this.BtnInvokeOpenCommand);
            this.GrpCommand.Controls.Add(this.BtnCopy);
            this.GrpCommand.Controls.Add(this.ChkAutoCopy);
            this.GrpCommand.Controls.Add(this.CmbCommand);
            this.GrpCommand.Name = "GrpCommand";
            this.GrpCommand.TabStop = false;
            // 
            // BtnInvokeOpenCommand
            // 
            resources.ApplyResources(this.BtnInvokeOpenCommand, "BtnInvokeOpenCommand");
            this.BtnInvokeOpenCommand.Name = "BtnInvokeOpenCommand";
            this.BtnInvokeOpenCommand.UseVisualStyleBackColor = true;
            this.BtnInvokeOpenCommand.Click += new System.EventHandler(this.BtnInvokeOpenCommand_Click);
            // 
            // TPRemoteCall
            // 
            resources.ApplyResources(this.TPRemoteCall, "TPRemoteCall");
            this.TPRemoteCall.Name = "TPRemoteCall";
            this.TPRemoteCall.UseVisualStyleBackColor = true;
            // 
            // TPAbout
            // 
            resources.ApplyResources(this.TPAbout, "TPAbout");
            this.TPAbout.Name = "TPAbout";
            this.TPAbout.UseVisualStyleBackColor = true;
            // 
            // TPManage
            // 
            resources.ApplyResources(this.TPManage, "TPManage");
            this.TPManage.Name = "TPManage";
            this.TPManage.UseVisualStyleBackColor = true;
            // 
            // TPScene
            // 
            resources.ApplyResources(this.TPScene, "TPScene");
            this.TPScene.Name = "TPScene";
            this.TPScene.UseVisualStyleBackColor = true;
            // 
            // TPItem
            // 
            resources.ApplyResources(this.TPItem, "TPItem");
            this.TPItem.Name = "TPItem";
            this.TPItem.UseVisualStyleBackColor = true;
            // 
            // TPWeapon
            // 
            resources.ApplyResources(this.TPWeapon, "TPWeapon");
            this.TPWeapon.Name = "TPWeapon";
            this.TPWeapon.UseVisualStyleBackColor = true;
            // 
            // TPAvatar
            // 
            resources.ApplyResources(this.TPAvatar, "TPAvatar");
            this.TPAvatar.Name = "TPAvatar";
            this.TPAvatar.UseVisualStyleBackColor = true;
            // 
            // TPSpawn
            // 
            resources.ApplyResources(this.TPSpawn, "TPSpawn");
            this.TPSpawn.Name = "TPSpawn";
            this.TPSpawn.UseVisualStyleBackColor = true;
            // 
            // TPQuest
            // 
            resources.ApplyResources(this.TPQuest, "TPQuest");
            this.TPQuest.Name = "TPQuest";
            this.TPQuest.UseVisualStyleBackColor = true;
            // 
            // TPArtifact
            // 
            resources.ApplyResources(this.TPArtifact, "TPArtifact");
            this.TPArtifact.Name = "TPArtifact";
            this.TPArtifact.UseVisualStyleBackColor = true;
            // 
            // TPCustom
            // 
            resources.ApplyResources(this.TPCustom, "TPCustom");
            this.TPCustom.Name = "TPCustom";
            this.TPCustom.UseVisualStyleBackColor = true;
            // 
            // TPHome
            // 
            resources.ApplyResources(this.TPHome, "TPHome");
            this.TPHome.Name = "TPHome";
            this.TPHome.UseVisualStyleBackColor = true;
            // 
            // TCMain
            // 
            resources.ApplyResources(this.TCMain, "TCMain");
            this.TCMain.Controls.Add(this.TPHome);
            this.TCMain.Controls.Add(this.TPRemoteCall);
            this.TCMain.Controls.Add(this.TPCustom);
            this.TCMain.Controls.Add(this.TPArtifact);
            this.TCMain.Controls.Add(this.TPSpawn);
            this.TCMain.Controls.Add(this.TPItem);
            this.TCMain.Controls.Add(this.TPAvatar);
            this.TCMain.Controls.Add(this.TPWeapon);
            this.TCMain.Controls.Add(this.TPManage);
            this.TCMain.Controls.Add(this.TPMail);
            this.TCMain.Controls.Add(this.TPQuest);
            this.TCMain.Controls.Add(this.TPScene);
            this.TCMain.Controls.Add(this.TPAbout);
            this.TCMain.Name = "TCMain";
            this.TCMain.SelectedIndex = 0;
            // 
            // TPMail
            // 
            resources.ApplyResources(this.TPMail, "TPMail");
            this.TPMail.Name = "TPMail";
            this.TPMail.UseVisualStyleBackColor = true;
            // 
            // MenuSpawnEntityFilter
            // 
            this.MenuSpawnEntityFilter.Name = "MenuSpawnEntityFilter";
            resources.ApplyResources(this.MenuSpawnEntityFilter, "MenuSpawnEntityFilter");
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TCMain);
            this.Controls.Add(this.GrpCommand);
            this.KeyPreview = true;
            this.Name = "FormMain";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.GrpCommand.ResumeLayout(false);
            this.GrpCommand.PerformLayout();
            this.TCMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbCommand;
        private System.Windows.Forms.Button BtnCopy;
        private System.Windows.Forms.CheckBox ChkAutoCopy;
        private System.Windows.Forms.GroupBox GrpCommand;
        private System.Windows.Forms.Button BtnInvokeOpenCommand;
        private System.Windows.Forms.TabPage TPRemoteCall;
        private System.Windows.Forms.TabPage TPAbout;
        private System.Windows.Forms.TabPage TPManage;
        private System.Windows.Forms.TabPage TPScene;
        private System.Windows.Forms.TabPage TPItem;
        private System.Windows.Forms.TabPage TPWeapon;
        private System.Windows.Forms.TabPage TPAvatar;
        private System.Windows.Forms.TabPage TPSpawn;
        private System.Windows.Forms.TabPage TPQuest;
        private System.Windows.Forms.TabPage TPArtifact;
        private System.Windows.Forms.TabPage TPCustom;
        private System.Windows.Forms.TabPage TPHome;
        private System.Windows.Forms.TabControl TCMain;
        private System.Windows.Forms.TabPage TPMail;
        private System.Windows.Forms.ContextMenuStrip MenuSpawnEntityFilter;
    }
}
