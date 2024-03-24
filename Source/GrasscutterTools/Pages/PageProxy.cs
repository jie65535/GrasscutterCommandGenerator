/**
 *  Grasscutter Tools
 *  Copyright (C) 2023 jie65535
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU Affero General Public License as published
 *  by the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU Affero General Public License for more details.
 *
 *  You should have received a copy of the GNU Affero General Public License
 *  along with this program.  If not, see <https://www.gnu.org/licenses/>.
 *
 **/

using System;
using System.Windows.Forms;
using GrasscutterTools.Forms;
using GrasscutterTools.Properties;
using GrasscutterTools.Utils;

namespace GrasscutterTools.Pages
{
    internal partial class PageProxy : BasePage
    {
        public override string Text => Resources.PageProxyTitle;

        public PageProxy()
        {
            InitializeComponent();
        }

        public override void OnLoad()
        {
            if (!string.IsNullOrEmpty(Settings.Default.Host))
                TxtHost.Text = Settings.Default.Host;
            ChkAutoStart.Checked = Settings.Default.AutoStartProxy;

            Application.ApplicationExit += OnApplicationExit;

            if (Settings.Default.AutoStartProxy && !ProxyHelper.IsRunning)
            {
                Logger.I(Name, "Auto start proxy!");
                BtnStartProxy_Click(BtnStartProxy, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 当应用程序退出时触发
        /// </summary>
        private void OnApplicationExit(object sender, EventArgs e)
        {
            if (!ProxyHelper.IsRunning) return;
            Logger.I(Name, "OnApplicationExit: StopProxy...");
            // 停止代理
            StopProxy();
        }

        /// <summary>
        /// 当页面被关闭时触发
        /// </summary>
        public override void OnClosed()
        {
            if (!ProxyHelper.IsRunning) return;
            Logger.I(Name, "OnPageClosed: StopProxy...");
            // 停止代理
            StopProxy();
        }

        /// <summary>
        /// 停止代理
        /// </summary>
        private static void StopProxy()
        {
            try
            {
                Logger.I("PageProxy", "Stop Proxy");
                ProxyHelper.StopProxy();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString(), Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
                Logger.E("PageProxy", "Stop Proxy Failed.", ex);
            }
        }

        /// <summary>
        /// 点击启动GC服务器时触发
        /// </summary>
        private void BtnStartGc_Click(object sender, EventArgs e)
        {
            // TODO Run java -jar grasscutter.jar
        }

        /// <summary>
        /// 点击代理按钮时触发
        /// </summary>
        private void BtnStartProxy_Click(object sender, EventArgs e)
        {
            try
            {
                // 正在运行则关闭
                if (ProxyHelper.IsRunning)
                {
                    ProxyHelper.StopProxy();
                    BtnStartProxy.Text = Resources.StartProxy;
                    TxtHost.Enabled = true;
                }
                else
                {
                    // 创建根证书并检查信任
                    if (!ProxyHelper.CheckAndCreateCertificate())
                    {
                        MessageBox.Show(Resources.TrustedBeforeContinuing, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 启动代理
                    ProxyHelper.StartProxy(TxtHost.Text);
                    BtnStartProxy.Text = Resources.StopProxy;
                    TxtHost.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Logger.E(Name, "Start Proxy failed.", ex);
                MessageBox.Show(ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 点击 Eavesdrop 标签时触发
        /// </summary>
        private void LnkEavesdrop_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UIUtil.OpenURL("https://github.com/ArachisH/Eavesdrop");
        }

        /// <summary>
        /// 点击关于标签时触发
        /// </summary>
        private void LnkAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormMain.Instance.NavigateTo<PageAbout>();
        }

        /// <summary>
        /// 点击卸载证书时触发
        /// </summary>
        private void BtnDestroyCert_Click(object sender, EventArgs e)
        {
            Logger.I(Name, "DestroyCertificate");
            ProxyHelper.DestroyCertificate();
            MessageBox.Show("OK", Resources.Tips);
        }

        /// <summary>
        /// 自动启动代理选项更改时触发
        /// </summary>
        private void ChkAutoStart_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.AutoStartProxy = ChkAutoStart.Checked;
        }
    }
}
