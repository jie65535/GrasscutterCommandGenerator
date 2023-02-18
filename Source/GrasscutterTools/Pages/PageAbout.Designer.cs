namespace GrasscutterTools.Pages
{
    partial class PageAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageAbout));
            this.GrasscutterToolsSupport = new System.Windows.Forms.PictureBox();
            this.LnkGithub = new System.Windows.Forms.LinkLabel();
            this.LblSupportDescription = new System.Windows.Forms.Label();
            this.LnkOpenChat = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.GrasscutterToolsSupport)).BeginInit();
            this.SuspendLayout();
            // 
            // GrasscutterToolsSupport
            // 
            resources.ApplyResources(this.GrasscutterToolsSupport, "GrasscutterToolsSupport");
            this.GrasscutterToolsSupport.Image = global::GrasscutterTools.Properties.Resources.ImgSupport;
            this.GrasscutterToolsSupport.Name = "GrasscutterToolsSupport";
            this.GrasscutterToolsSupport.TabStop = false;
            // 
            // LnkGithub
            // 
            resources.ApplyResources(this.LnkGithub, "LnkGithub");
            this.LnkGithub.Name = "LnkGithub";
            this.LnkGithub.TabStop = true;
            this.LnkGithub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkGithub_LinkClicked);
            // 
            // LblSupportDescription
            // 
            resources.ApplyResources(this.LblSupportDescription, "LblSupportDescription");
            this.LblSupportDescription.Name = "LblSupportDescription";
            // 
            // LnkOpenChat
            // 
            resources.ApplyResources(this.LnkOpenChat, "LnkOpenChat");
            this.LnkOpenChat.Name = "LnkOpenChat";
            this.LnkOpenChat.TabStop = true;
            this.LnkOpenChat.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkOpenChat_LinkClicked);
            // 
            // PageAbout
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LnkOpenChat);
            this.Controls.Add(this.GrasscutterToolsSupport);
            this.Controls.Add(this.LnkGithub);
            this.Controls.Add(this.LblSupportDescription);
            this.Name = "PageAbout";
            ((System.ComponentModel.ISupportInitialize)(this.GrasscutterToolsSupport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox GrasscutterToolsSupport;
        private System.Windows.Forms.LinkLabel LnkGithub;
        private System.Windows.Forms.Label LblSupportDescription;
        private System.Windows.Forms.LinkLabel LnkOpenChat;
    }
}
