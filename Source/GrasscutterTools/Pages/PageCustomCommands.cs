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
using System.IO;
using System.Text;
using System.Windows.Forms;
using GrasscutterTools.Forms;
using GrasscutterTools.Properties;

using GrasscutterTools.Utils;

namespace GrasscutterTools.Pages
{
    internal partial class PageCustomCommands : BasePage
    {
        public override string Text => Resources.PageCustomCommandsTitle;

        public PageCustomCommands()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 自定义命令保存位置
        /// </summary>
        private readonly string CustomCommandsFilePath = Common.GetAppDataFile("CustomCommands.txt");

        /// <summary>
        /// 自定义命令是否存在更改
        /// </summary>
        private bool CustomCommandsChanged;

        /// <summary>
        /// 加载自定义命令
        /// </summary>
        public override void OnLoad()
        {
            if (File.Exists(CustomCommandsFilePath))
                LoadCustomCommandControls(File.ReadAllText(CustomCommandsFilePath));
            else
                LoadCustomCommandControls(Resources.CustomCommands);
            CustomCommandsChanged = false;
        }

        /// <summary>
        /// 加载自定义命令控件列表
        /// </summary>
        /// <param name="commands">命令集（示例："标签1\n命令1\n标签2\n命令2"）</param>
        private void LoadCustomCommandControls(string commands)
        {
            FLPCustomCommands.Controls.Clear();
            var lines = commands.Split('\n');
            for (int i = 0; i < lines.Length - 1; i += 2)
                AddCustomCommand(lines[i].Trim(), lines[i + 1].Trim());
        }

        /// <summary>
        /// 保存自定义命令
        /// </summary>
        public override void OnClosed()
        {
            if (CustomCommandsChanged)
                File.WriteAllText(CustomCommandsFilePath, SaveCustomCommandControls());
        }

        /// <summary>
        /// 保存自定义命令控件列表
        /// </summary>
        /// <returns>命令集（示例："标签1\n命令1\n标签2\n命令2"）</returns>
        private string SaveCustomCommandControls()
        {
            StringBuilder builder = new StringBuilder();
            foreach (LinkLabel lnk in FLPCustomCommands.Controls)
            {
                builder.AppendLine(lnk.Text);
                builder.AppendLine(lnk.Tag as string);
            }
            return builder.ToString();
        }

        /// <summary>
        /// 自定义命令点击时触发
        /// </summary>
        private void CustomCommand_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (sender is LinkLabel lnk && lnk.Tag is string command)
            {
                TxtCustomName.Text = lnk.Text;
                SetCommand(command);
            }
        }

        /// <summary>
        /// 自定义命令文本框回车时触发
        /// </summary>
        private void TxtCustomName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) BtnSaveCustomCommand_Click(BtnSaveCustomCommand, e);
        }

        /// <summary>
        /// 点击保存自定义命令列表时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnSaveCustomCommand_Click(object sender, EventArgs e)
        {
            var name = TxtCustomName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show(Resources.CommandTagCannotBeEmpty, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var command = GetCommand().Trim();
            if (string.IsNullOrEmpty(command))
            {
                MessageBox.Show(Resources.CommandContentCannotBeEmpty, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (LinkLabel lnk in FLPCustomCommands.Controls)
            {
                if (lnk.Text == name)
                {
                    lnk.Tag = command;
                    CustomCommandsChanged = true;
                    await UIUtil.ButtonComplete(BtnSaveCustomCommand);
                    return;
                }
            }

            CustomCommandsChanged = true;
            AddCustomCommand(name, command);
            await UIUtil.ButtonComplete(BtnSaveCustomCommand);
        }

        /// <summary>
        /// 添加自定义命令
        /// </summary>
        /// <param name="name">标签</param>
        /// <param name="command">命令</param>
        private void AddCustomCommand(string name, string command)
        {
            var lnk = new LinkLabel
            {
                Text = name,
                Tag = command,
                AutoSize = true,
            };
            lnk.LinkClicked += CustomCommand_Click;
            FLPCustomCommands.Controls.Add(lnk);
        }

        /// <summary>
        /// 点击移除自定义命令按钮时触发
        /// </summary>
        private async void BtnRemoveCustomCommand_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtCustomName.Text))
            {
                MessageBox.Show(Resources.CommandTagCannotBeEmpty, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var name = TxtCustomName.Text.Trim();

            foreach (LinkLabel lnk in FLPCustomCommands.Controls)
            {
                if (lnk.Text == name && MessageBox.Show(Resources.AskConfirmDeletion, Resources.Tips, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    FLPCustomCommands.Controls.Remove(lnk);
                    CustomCommandsChanged = true;
                    //TxtCustomName.Text = "";
                    //TxtCommand.Text = "";
                    await UIUtil.ButtonComplete(BtnRemoveCustomCommand);
                    return;
                }
            }

            MessageBox.Show(Resources.CommandNotFound, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 点击导入自定义命令时触发
        /// </summary>
        private void BtnImport_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (var stream = dialog.OpenFile())
                using (var reader = new StreamReader(stream))
                {
                    LoadCustomCommandControls(reader.ReadToEnd());
                    CustomCommandsChanged = true;
                }
            }
        }

        /// <summary>
        /// 点击导出自定义命令时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExport_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                FileName = "Commands.txt",
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (var stream = dialog.OpenFile())
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(SaveCustomCommandControls());
                }
            }
        }

        /// <summary>
        /// 点击重置链接按钮时触发
        /// </summary>
        private void LnkResetCustomCommands_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show(Resources.RestoreCustomCommands, Resources.Tips, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (File.Exists(CustomCommandsFilePath))
                    File.Delete(CustomCommandsFilePath);
                LoadCustomCommandControls(Resources.CustomCommands);
            }
        }

        /// <summary>
        /// 点击添加快捷键时触发
        /// </summary>
        private void BtnAddHotKey_Click(object sender, EventArgs e)
        {
            var name = TxtCustomName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show(Resources.CommandTagCannotBeEmpty, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 跳转到快捷键界面
            FormMain.Instance.NavigateTo<PageHotKey>()?
                .AddNewHotKey(name); // 设置标签
        }

        /// <summary>
        /// 标签栏文本改变时触发
        /// </summary>
        private void TxtCustomName_TextChanged(object sender, EventArgs e)
        {
            LblClearFilter.Visible = TxtCustomName.Text.Length > 0;
        }

        /// <summary>
        /// 点击清空标签栏标签时触发
        /// </summary>
        private void LblClearFilter_Click(object sender, EventArgs e)
        {
            TxtCustomName.Clear();
        }

    }
}