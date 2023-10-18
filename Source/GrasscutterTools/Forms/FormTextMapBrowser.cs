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
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using GrasscutterTools.Game;
using GrasscutterTools.Properties;

namespace GrasscutterTools.Forms
{
    public partial class FormTextMapBrowser : Form
    {
        public FormTextMapBrowser()
        {
            InitializeComponent();
            Icon = Resources.IconGrasscutter;
        }

        private void FormTextMapBrowser_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Settings.Default.ResourcesDirPath))
            {
                LoadResources(Settings.Default.ResourcesDirPath);
            }
        }

        private TextMapData data;

        private void LoadResources(string resourcesDirPath)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Application.DoEvents();

                data = new TextMapData(resourcesDirPath);
                LblResourcesPath.Text = resourcesDirPath;
                if (Settings.Default.ResourcesDirPath != resourcesDirPath)
                {
                    Settings.Default.ResourcesDirPath = resourcesDirPath;
                }

                CmbLanguage.Items.Clear();
                CmbLanguage.Items.AddRange(data.TextMapFiles);
                if (!string.IsNullOrEmpty(Settings.Default.TextMapFileName))
                {
                    var i = CmbLanguage.Items.IndexOf(Settings.Default.TextMapFileName);
                    if (i != -1)
                        CmbLanguage.SelectedIndex = i;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void BtnSelectRecoursePath_Click(object sender, EventArgs e)
        {
            var dir = new FolderBrowserDialog()
            {
                ShowNewFolderButton = false,
                Description = "./Gasscutter/resources",
            };
            if (dir.ShowDialog() == DialogResult.OK)
            {
                LoadResources(dir.SelectedPath);
            }
        }

        private void CmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbLanguage.SelectedIndex == -1 || data == null)
                return;
            try
            {
                Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                data.LoadTextMap(data.TextMapFilePaths[CmbLanguage.SelectedIndex]);

                GenLines();
                Settings.Default.TextMapFileName = CmbLanguage.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private List<ListViewItem> Items;

        private void GenLines()
        {
            var items = new List<ListViewItem>(data.TextMap.Count);
            foreach (var kv in data.TextMap)
            {
                items.Add(data.ManualTextMap?.TryGetValue(kv.Key, out var id) == true
                    ? new ListViewItem(new[] { kv.Key, id, kv.Value })
                    : new ListViewItem(new[] { kv.Key, "", kv.Value }));
            }
            Items = items;
        }

        private void ChkTopMost_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = ChkTopMost.Checked;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (Items == null)
            {
                MessageBox.Show("请先选择资源目录，并选择对应语言文件。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var filter = TxtTextMapFilter.Text.Trim();
            if (string.IsNullOrEmpty(filter))
                return;
            Regex r;
            try
            {
                r = new Regex(filter, RegexOptions.IgnoreCase);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                Application.DoEvents();

                var manualResult = data.ManualTextMap?.Where(kv => r.Match(kv.Value).Success)
                    .Select(kv => new { Hash = kv.Key, Text = data.TextMap[kv.Key], Id = kv.Value, });
                var textMapResult = data.TextMap.Where(kv => r.Match(kv.Key).Success || r.Match(kv.Value).Success)
                    .Select(kv => new
                    {
                        Hash = kv.Key,
                        Text = kv.Value,
                        Id = data.ManualTextMap?.TryGetValue(kv.Key, out var id) == true ? id : "",
                    });
                var result = manualResult == null ? textMapResult.ToList() : textMapResult.Concat(manualResult).ToList();

                DGVTextMap.SuspendLayout();
                DGVTextMap.Rows.Clear();
                for (var i = 0; i < result.Count; i++)
                {
                    DGVTextMap.Rows.Add();
                    DGVTextMap.Rows[i].Cells[0].Value = result[i].Hash;
                    DGVTextMap.Rows[i].Cells[1].Value = result[i].Text;
                    DGVTextMap.Rows[i].Cells[2].Value = result[i].Id;
                }
                DGVTextMap.ResumeLayout();
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void TxtTextMapFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                BtnSearch_Click(sender, e);
        }

        private void TxtTextMapFilter_TextChanged(object sender, EventArgs e)
        {
            LblClearFilter.Visible = TxtTextMapFilter.Text.Length > 0;
        }

        private void LblClearFilter_Click(object sender, EventArgs e)
        {
            TxtTextMapFilter.Clear();
        }
    }
}