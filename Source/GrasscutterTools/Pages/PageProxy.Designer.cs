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
            this.TxtHost = new System.Windows.Forms.TextBox();
            this.LblServerAddress = new System.Windows.Forms.Label();
            this.BtnStartProxy = new System.Windows.Forms.Button();
            this.ChkAutoStart = new System.Windows.Forms.CheckBox();
            this.LblProxyIntroduction = new System.Windows.Forms.Label();
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
            this.TxtHost.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtHost.Location = new System.Drawing.Point(227, 40);
            this.TxtHost.Name = "TxtHost";
            this.TxtHost.Size = new System.Drawing.Size(160, 23);
            this.TxtHost.TabIndex = 4;
            this.TxtHost.Text = "http://127.0.0.1:443";
            // 
            // LblServerAddress
            // 
            this.LblServerAddress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblServerAddress.AutoSize = true;
            this.LblServerAddress.Location = new System.Drawing.Point(84, 43);
            this.LblServerAddress.Name = "LblServerAddress";
            this.LblServerAddress.Size = new System.Drawing.Size(137, 17);
            this.LblServerAddress.TabIndex = 3;
            this.LblServerAddress.Text = "目标 http(s) 服务器地址";
            // 
            // BtnStartProxy
            // 
            this.BtnStartProxy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnStartProxy.Location = new System.Drawing.Point(393, 40);
            this.BtnStartProxy.Name = "BtnStartProxy";
            this.BtnStartProxy.Size = new System.Drawing.Size(120, 25);
            this.BtnStartProxy.TabIndex = 5;
            this.BtnStartProxy.Text = "启动代理";
            this.BtnStartProxy.UseVisualStyleBackColor = true;
            this.BtnStartProxy.Click += new System.EventHandler(this.BtnStartProxy_Click);
            // 
            // ChkAutoStart
            // 
            this.ChkAutoStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ChkAutoStart.AutoSize = true;
            this.ChkAutoStart.Location = new System.Drawing.Point(519, 42);
            this.ChkAutoStart.Name = "ChkAutoStart";
            this.ChkAutoStart.Size = new System.Drawing.Size(75, 21);
            this.ChkAutoStart.TabIndex = 6;
            this.ChkAutoStart.Text = "自动开启";
            this.ChkAutoStart.UseVisualStyleBackColor = true;
            this.ChkAutoStart.CheckedChanged += new System.EventHandler(this.ChkAutoStart_CheckedChanged);
            // 
            // LblProxyIntroduction
            // 
            this.LblProxyIntroduction.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblProxyIntroduction.Location = new System.Drawing.Point(48, 72);
            this.LblProxyIntroduction.Name = "LblProxyIntroduction";
            this.LblProxyIntroduction.Size = new System.Drawing.Size(550, 120);
            this.LblProxyIntroduction.TabIndex = 7;
            this.LblProxyIntroduction.Text = "    启动代理需要信任本应用的临时根证书，该证书仅用于代理动漫游戏相关请求，有效期1月，你可以随时点击右下角卸载证书。\r\n    代理功能代码来自开源项目 Ea" +
    "vesdrop，遵循MIT开源协议，经过魔改以匹配应用需求。\r\n    本代理通过大量过滤规则来规避非动漫游戏的请求经过应用，减小影响，欢迎体验！\r\n    程" +
    "序退出时会自动关闭代理，放心使用 :)";
            // 
            // BtnDestroyCert
            // 
            this.BtnDestroyCert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnDestroyCert.Location = new System.Drawing.Point(529, 207);
            this.BtnDestroyCert.Name = "BtnDestroyCert";
            this.BtnDestroyCert.Size = new System.Drawing.Size(100, 25);
            this.BtnDestroyCert.TabIndex = 10;
            this.BtnDestroyCert.Text = "卸载证书";
            this.BtnDestroyCert.UseVisualStyleBackColor = true;
            this.BtnDestroyCert.Click += new System.EventHandler(this.BtnDestroyCert_Click);
            // 
            // LnkEavesdrop
            // 
            this.LnkEavesdrop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LnkEavesdrop.AutoSize = true;
            this.LnkEavesdrop.Location = new System.Drawing.Point(15, 211);
            this.LnkEavesdrop.Name = "LnkEavesdrop";
            this.LnkEavesdrop.Size = new System.Drawing.Size(70, 17);
            this.LnkEavesdrop.TabIndex = 8;
            this.LnkEavesdrop.TabStop = true;
            this.LnkEavesdrop.Text = "Eavesdrop";
            this.LnkEavesdrop.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkEavesdrop_LinkClicked);
            // 
            // LnkAbout
            // 
            this.LnkAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LnkAbout.AutoSize = true;
            this.LnkAbout.Location = new System.Drawing.Point(482, 211);
            this.LnkAbout.Name = "LnkAbout";
            this.LnkAbout.Size = new System.Drawing.Size(32, 17);
            this.LnkAbout.TabIndex = 9;
            this.LnkAbout.TabStop = true;
            this.LnkAbout.Text = "关于";
            this.LnkAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkAbout_LinkClicked);
            // 
            // LblGcJarPath
            // 
            this.LblGcJarPath.AutoSize = true;
            this.LblGcJarPath.Location = new System.Drawing.Point(102, 14);
            this.LblGcJarPath.Name = "LblGcJarPath";
            this.LblGcJarPath.Size = new System.Drawing.Size(119, 17);
            this.LblGcJarPath.TabIndex = 0;
            this.LblGcJarPath.Text = "GrasscutterJar 路径";
            this.LblGcJarPath.Visible = false;
            // 
            // TxtGcJarPath
            // 
            this.TxtGcJarPath.Location = new System.Drawing.Point(227, 11);
            this.TxtGcJarPath.Name = "TxtGcJarPath";
            this.TxtGcJarPath.Size = new System.Drawing.Size(160, 23);
            this.TxtGcJarPath.TabIndex = 1;
            this.TxtGcJarPath.Visible = false;
            // 
            // BtnStartGc
            // 
            this.BtnStartGc.Location = new System.Drawing.Point(393, 11);
            this.BtnStartGc.Name = "BtnStartGc";
            this.BtnStartGc.Size = new System.Drawing.Size(120, 25);
            this.BtnStartGc.TabIndex = 2;
            this.BtnStartGc.Text = "启动服务器";
            this.BtnStartGc.UseVisualStyleBackColor = true;
            this.BtnStartGc.Visible = false;
            this.BtnStartGc.Click += new System.EventHandler(this.BtnStartGc_Click);
            // 
            // PageProxy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
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
        private System.Windows.Forms.Label LblProxyIntroduction;
        private System.Windows.Forms.Button BtnDestroyCert;
        private System.Windows.Forms.LinkLabel LnkEavesdrop;
        private System.Windows.Forms.LinkLabel LnkAbout;
        private System.Windows.Forms.Label LblGcJarPath;
        private System.Windows.Forms.TextBox TxtGcJarPath;
        private System.Windows.Forms.Button BtnStartGc;
    }
}
