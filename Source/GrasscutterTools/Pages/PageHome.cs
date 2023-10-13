/**
 *  Grasscutter Tools
 *  Copyright (C) 2022 jie65535
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
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using GrasscutterTools.Forms;
using GrasscutterTools.Properties;
using GrasscutterTools.Utils;

namespace GrasscutterTools.Pages
{
    internal partial class PageHome : BasePage
    {
        public override string Text => Resources.PageHomeTitle;

        /// <summary>
        /// 初始化首页设置
        /// </summary>
        public PageHome()
        {
            InitializeComponent();
            if (DesignMode) return;

            // 初始化多语言
            CmbLanguage.DataSource = MultiLanguage.LanguageNames;
            if (string.IsNullOrEmpty(Settings.Default.DefaultLanguage))
            {
                // 如果未选择语言，则默认载入本地语言
                var i = Array.IndexOf(MultiLanguage.Languages, Thread.CurrentThread.CurrentUICulture);
                // 仅支持时切换，避免重复加载
                if (i > 0) CmbLanguage.SelectedIndex = i;
            }
            else
            {
                CmbLanguage.SelectedIndex = Array.IndexOf(MultiLanguage.Languages, Settings.Default.DefaultLanguage);
            }
            CmbLanguage.SelectedIndexChanged += CmbLanguage_SelectedIndexChanged;
#if !DEBUG  // 仅正式版
            // 检查更新，但不要弹窗
            Task.Run(async () => { try { await LoadUpdate(); } catch { /* 启动时检查更新，忽略异常 */ }});
#endif
        }

        #region - 检查更新 Check update -

        private GithubHelper.ReleaseInfo LastestInfo = null;
        private Version lastestVersion = null;

        private async Task LoadUpdate()
        {
            var info = await GithubHelper.GetReleasesLatest("jie65535", "GrasscutterCommandGenerator");
            if (Version.TryParse(info.TagName.Substring(1), out lastestVersion) && Common.AppVersion < lastestVersion)
            {
                if (!string.IsNullOrEmpty(Settings.Default.CheckedLastVersion)
                    && Version.TryParse(Settings.Default.CheckedLastVersion, out Version checkedVersion)
                    && checkedVersion >= lastestVersion)
                    return;
                LastestInfo = info;
                BeginInvoke(new Action(() =>
                {
                    LnkNewVersion.Visible = true;
                    LnkNewVersion.Text = Resources.CheckToNewVersion;
                    this.Text += " - " + Resources.CheckToNewVersion;
                }));
            }
        }

        #endregion - 检查更新 Check update -

        private static void ToTop(Form form)
        {
            form.TopMost = true;
            form.TopMost = false;
        }

        private readonly Dictionary<string, Form> MyForms = new();

        private void ShowForm<T>(string tag) where T : Form, new()
        {
            if (!MyForms.TryGetValue(tag, out var form) || form.IsDisposed)
                form = new T();
            MyForms[tag] = form;
            if (form.IsHandleCreated)
                ToTop(form);
            else
                form.Show();
        }

        /// <summary>
        /// 点击打开卡池编辑器时触发
        /// </summary>
        private void BtnOpenGachaBannerEditor_Click(object sender, EventArgs e)
            => ShowForm<FormGachaBannersEditor3>("BannersEditor");

        /// <summary>
        /// 点击打开文本浏览器时触发
        /// </summary>
        private void BtnOpenTextMap_Click(object sender, EventArgs e)
            => ShowForm<FormTextMapBrowser>("TextMapBrowser");

        /// <summary>
        /// 点击打开掉落物编辑器时触发
        /// </summary>
        private void BtnOpenDropEditor_Click(object sender, EventArgs e)
            => ShowForm<FormDropEditor>("DropEditor");

        /// <summary>
        /// 点击打开商店编辑器时触发
        /// </summary>
        private void BtnOpenShopEditor_Click(object sender, EventArgs e)
            => ShowForm<FormShopEditor>("ShopEditor");

        /// <summary>
        /// 点击打开活动编辑器时触发
        /// </summary>
        private void BtnActivityEditor_Click(object sender, EventArgs e)
            => ShowForm<FormActivityEditor>("ActivityEditor");
        
        /// <summary>
        /// 语言选中项改变时触发
        /// </summary>
        private void CmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbLanguage.SelectedIndex < 0) return;
            // 切换默认语言
            MultiLanguage.SetDefaultLanguage(MultiLanguage.Languages[CmbLanguage.SelectedIndex]);
            // 动态更改语言
            MultiLanguage.LoadLanguage(ParentForm, ParentForm.GetType());
            // 重载界面
            FormMain.Instance.Reload();
        }

        /// <summary>
        /// 点击检查更新时触发
        /// </summary>
        private void LnkNewVersion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (LastestInfo != null)
            {
                var r = MessageBox.Show(
                    string.Format(Resources.NewVersionInfo, LastestInfo.Name, LastestInfo.CreateTime.ToLocalTime(), LastestInfo.Body),
                    Resources.CheckToNewVersion,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);
                if (r == DialogResult.Yes)
                    UIUtil.OpenURL(LastestInfo.Url);
                else if (r == DialogResult.No)
                    Settings.Default.CheckedLastVersion = lastestVersion.ToString();
            }
            else
            {
                // 没有更新，隐藏
                LnkNewVersion.Visible = false;
            }
        }
    }
}