namespace GrasscutterTools.Pages
{
    partial class PageProxy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageProxy));
            this.TxtHost = new System.Windows.Forms.TextBox();
            this.LblServerAddress = new System.Windows.Forms.Label();
            this.BtnStartProxy = new System.Windows.Forms.Button();
            this.ChkAutoStart = new System.Windows.Forms.CheckBox();
            this.LblProxyIntroduction = new System.Windows.Forms.TextBox();
            this.BtnDestroyCert = new System.Windows.Forms.Button();
            this.LnkEavesdrop = new System.Windows.Forms.LinkLabel();
            this.LnkAbout = new System.Windows.Forms.LinkLabel();
            this.LblGcJarPath = new System.Windows.Forms.Label();
            this.TxtGcJarPath = new System.Windows.Forms.TextBox();
            this.BtnStartGc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtHost
            // 
            resources.ApplyResources(this.TxtHost, "TxtHost");
            this.TxtHost.Name = "TxtHost";
            // 
            // LblServerAddress
            // 
            resources.ApplyResources(this.LblServerAddress, "LblServerAddress");
            this.LblServerAddress.Name = "LblServerAddress";
            // 
            // BtnStartProxy
            // 
            resources.ApplyResources(this.BtnStartProxy, "BtnStartProxy");
            this.BtnStartProxy.Name = "BtnStartProxy";
            this.BtnStartProxy.UseVisualStyleBackColor = true;
            this.BtnStartProxy.Click += new System.EventHandler(this.BtnStartProxy_Click);
            // 
            // ChkAutoStart
            // 
            resources.ApplyResources(this.ChkAutoStart, "ChkAutoStart");
            this.ChkAutoStart.Name = "ChkAutoStart";
            this.ChkAutoStart.UseVisualStyleBackColor = true;
            this.ChkAutoStart.CheckedChanged += new System.EventHandler(this.ChkAutoStart_CheckedChanged);
            // 
            // LblProxyIntroduction
            // 
            resources.ApplyResources(this.LblProxyIntroduction, "LblProxyIntroduction");
            this.LblProxyIntroduction.Name = "LblProxyIntroduction";
            this.LblProxyIntroduction.ReadOnly = true;
            // 
            // BtnDestroyCert
            // 
            resources.ApplyResources(this.BtnDestroyCert, "BtnDestroyCert");
            this.BtnDestroyCert.Name = "BtnDestroyCert";
            this.BtnDestroyCert.UseVisualStyleBackColor = true;
            this.BtnDestroyCert.Click += new System.EventHandler(this.BtnDestroyCert_Click);
            // 
            // LnkEavesdrop
            // 
            resources.ApplyResources(this.LnkEavesdrop, "LnkEavesdrop");
            this.LnkEavesdrop.Name = "LnkEavesdrop";
            this.LnkEavesdrop.TabStop = true;
            this.LnkEavesdrop.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkEavesdrop_LinkClicked);
            // 
            // LnkAbout
            // 
            resources.ApplyResources(this.LnkAbout, "LnkAbout");
            this.LnkAbout.Name = "LnkAbout";
            this.LnkAbout.TabStop = true;
            this.LnkAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkAbout_LinkClicked);
            // 
            // LblGcJarPath
            // 
            resources.ApplyResources(this.LblGcJarPath, "LblGcJarPath");
            this.LblGcJarPath.Name = "LblGcJarPath";
            // 
            // TxtGcJarPath
            // 
            resources.ApplyResources(this.TxtGcJarPath, "TxtGcJarPath");
            this.TxtGcJarPath.Name = "TxtGcJarPath";
            // 
            // BtnStartGc
            // 
            resources.ApplyResources(this.BtnStartGc, "BtnStartGc");
            this.BtnStartGc.Name = "BtnStartGc";
            this.BtnStartGc.UseVisualStyleBackColor = true;
            this.BtnStartGc.Click += new System.EventHandler(this.BtnStartGc_Click);
            // 
            // PageProxy
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnStartGc);
            this.Controls.Add(this.TxtGcJarPath);
            this.Controls.Add(this.LblGcJarPath);
            this.Controls.Add(this.LnkAbout);
            this.Controls.Add(this.LnkEavesdrop);
            this.Controls.Add(this.BtnDestroyCert);
            this.Controls.Add(this.LblProxyIntroduction);
            this.Controls.Add(this.ChkAutoStart);
            this.Controls.Add(this.BtnStartProxy);
            this.Controls.Add(this.LblServerAddress);
            this.Controls.Add(this.TxtHost);
            this.Name = "PageProxy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtHost;
        private System.Windows.Forms.Label LblServerAddress;
        private System.Windows.Forms.Button BtnStartProxy;
        private System.Windows.Forms.CheckBox ChkAutoStart;
        private System.Windows.Forms.TextBox LblProxyIntroduction;
        private System.Windows.Forms.Button BtnDestroyCert;
        private System.Windows.Forms.LinkLabel LnkEavesdrop;
        private System.Windows.Forms.LinkLabel LnkAbout;
        private System.Windows.Forms.Label LblGcJarPath;
        private System.Windows.Forms.TextBox TxtGcJarPath;
        private System.Windows.Forms.Button BtnStartGc;
    }
}
