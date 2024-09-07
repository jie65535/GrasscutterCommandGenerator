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
using System.IO;
using System.Linq;
using System.Windows.Forms;

using GrasscutterTools.Game;
using GrasscutterTools.Game.Mail;
using GrasscutterTools.Properties;
using GrasscutterTools.Utils;

using Newtonsoft.Json;

namespace GrasscutterTools.Pages
{
    internal partial class PageMail : BasePage
    {
        public override string Text => Resources.PageMailTitle;

        public PageMail()
        {
            InitializeComponent();
            if (DesignMode) return;
            InitMailList();
        }

        /// <summary>
        /// 初始化邮件页面
        /// </summary>
        public override void OnLoad()
        {
            TxtMailSender.Text = Settings.Default.DefaultMailSender;
            LoadMailSelectableItems();
        }

        /// <summary>
        /// 保存邮件设置
        /// </summary>
        public override void OnClosed()
        {
            Settings.Default.DefaultMailSender = TxtMailSender.Text;
        }

        /// <summary>
        /// 点击清空邮件内容时触发
        /// </summary>
        private void LblClearMailContent_Click(object sender, EventArgs e)
        {
            TxtMailContent.Clear();
        }

        /// <summary>
        /// 点击发送邮件时触发
        /// </summary>
        private void BtnSendMail_Click(object sender, EventArgs e)
        {
            var mail = new Mail
            {
                Title = TxtMailTitle.Text.Trim(),
                Sender = TxtMailSender.Text.Trim(),
                Content = TxtMailContent.Text.Trim(),
                Recipient = RbMailSendToAll.Checked ? 0 : (int)NUDMailRecipient.Value,
                ItemList = new List<MailItem>(MailItems),
                SendTime = DateTime.Now,
            };

            if (mail.Title == "" || mail.Sender == "" || mail.Content == "")
            {
                MessageBox.Show(Resources.EmptyInputTip, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (mail.SendToAll)
            {
                MessageBox.Show(Resources.MailSendToAllWarning, Resources.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            var cmd = $"/sendMail {(mail.SendToAll ? "all" : mail.Recipient.ToString())} |" +
                $"/sendMail {mail.Title} |" +
                $"/sendMail {mail.Content.Replace("\r", "\\r").Replace("\n", "\\n")} |" +
                $"/sendMail {mail.Sender} |";
            foreach (var item in mail.ItemList)
                cmd += $"/sendMail {item.ItemId} {item.ItemCount} {item.ItemLevel} |";
            cmd += "/sendMail finish";

            SetCommand(cmd);
            AddMailToList(mail);
        }

        /// <summary>
        /// 展示邮件
        /// </summary>
        /// <param name="mail"></param>
        private void ShowMail(Mail mail)
        {
            TxtMailTitle.Text = mail.Title;
            TxtMailSender.Text = mail.Sender;
            TxtMailContent.Text = mail.Content;
            NUDMailRecipient.Value = mail.Recipient;
            RbMailSendToAll.Checked = mail.SendToAll;
            RbMailSendToPlayer.Checked = !mail.SendToAll;
            ShowMailItems(mail.ItemList);
        }

        #region -- 邮件附件列表 Mail items --

        /// <summary>
        /// 当前邮件附件列表
        /// </summary>
        private readonly List<MailItem> MailItems = new List<MailItem>();

        /// <summary>
        /// 展示邮件附件列表
        /// </summary>
        /// <param name="items"></param>
        private void ShowMailItems(List<MailItem> items)
        {
            MailItems.Clear();
            MailItems.AddRange(items);
            ListMailItems.BeginUpdate();
            ListMailItems.Items.Clear();
            ListMailItems.Items.AddRange(items.Select(it => it.ToString()).ToArray());
            ListMailItems.EndUpdate();
        }

        /// <summary>
        /// 点击添加邮件附件项时触发
        /// </summary>
        private void BtnAddMailItem_Click(object sender, EventArgs e)
        {
            if (ListMailSelectableItems.SelectedIndex == -1)
                return;
            var item = ListMailSelectableItems.SelectedItem as string;
            var itemId = ItemMap.ToId(item);
            var mailItem = new MailItem
            {
                ItemId = itemId,
                ItemCount = (int)NUDMailItemCount.Value,
                ItemLevel = (int)NUDMailItemLevel.Value,
            };
            MailItems.Add(mailItem);
            ListMailItems.Items.Add(mailItem.ToString());
        }

        /// <summary>
        /// 点击删除邮件附件项时触发
        /// </summary>
        private void BtnDeleteMailItem_Click(object sender, EventArgs e)
        {
            if (ListMailItems.SelectedIndex == -1) return;

            MailItems.RemoveAt(ListMailItems.SelectedIndex);
            ListMailItems.Items.RemoveAt(ListMailItems.SelectedIndex);
        }

        #endregion -- 邮件附件列表 Mail items --

        #region -- 邮件附件可选列表 Mail item selectable list --

        private string[] MailSelectableItems;

        /// <summary>
        /// 加载附件可选项列表
        /// </summary>
        private void LoadMailSelectableItems()
        {
            MailSelectableItems = new string[GameData.Items.Lines.Length + GameData.Weapons.Count + GameData.Artifacts.Count];
            int i = 0;
            GameData.Items.Lines.CopyTo(MailSelectableItems, i); i += GameData.Items.Lines.Length;
            GameData.Weapons.Lines.CopyTo(MailSelectableItems, i); i += GameData.Weapons.Count;
            GameData.Artifacts.Lines.CopyTo(MailSelectableItems, i); i += GameData.Artifacts.Count;

            Array.Sort(MailSelectableItems, (a, b) => ItemMap.ToId(a) - ItemMap.ToId(b));

            ListMailSelectableItems.Items.Clear();
            ListMailSelectableItems.Items.AddRange(MailSelectableItems);
        }

        /// <summary>
        /// 邮件页面物品列表过滤器文本改变时触发
        /// </summary>
        private void TxtMailSelectableItemFilter_TextChanged(object sender, EventArgs e)
        {
            UIUtil.ListBoxFilter(ListMailSelectableItems, MailSelectableItems, TxtMailSelectableItemFilter.Text);
            LblClearFilter.Visible = TxtMailSelectableItemFilter.Text.Length > 0;
        }

        /// <summary>
        /// 点击清空过滤栏标签时触发
        /// </summary>
        private void LblClearFilter_Click(object sender, EventArgs e)
        {
            TxtMailSelectableItemFilter.Clear();
        }

        #endregion -- 邮件附件可选列表 Mail item selectable list --

        #region -- 邮件列表 Mail list --

        /// <summary>
        /// 获取物品记录文件路径
        /// </summary>
        private readonly string MailListPath = Common.GetAppDataFile("MailList.json");

        /// <summary>
        /// 邮件列表
        /// </summary>
        private List<Mail> MailList = new List<Mail>();

        /// <summary>
        /// 初始化邮件列表
        /// </summary>
        private void InitMailList()
        {
            if (File.Exists(MailListPath))
            {
                MailList = JsonConvert.DeserializeObject<List<Mail>>(File.ReadAllText(MailListPath));
                ListMailList.Items.AddRange(MailList.Select(it => it.ToString()).ToArray());
            }
            else
            {
                MailList = new List<Mail>();
            }
        }

        /// <summary>
        /// 保存邮件列表
        /// </summary>
        private void SaveMailList()
        {
            File.WriteAllText(MailListPath, JsonConvert.SerializeObject(MailList));
        }

        /// <summary>
        /// 添加邮件到列表
        /// </summary>
        /// <param name="mail">邮件</param>
        private void AddMailToList(Mail mail)
        {
            MailList.Add(mail);
            ListMailList.Items.Add(mail.ToString());
            SaveMailList();
        }

        /// <summary>
        /// 邮件列表选中项改变时发生
        /// </summary>
        private void ListMailList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListMailList.SelectedIndex == -1) return;
            // 显示选中邮件
            var mail = MailList[ListMailList.SelectedIndex];
            ShowMail(mail);
        }

        /// <summary>
        /// 点击删除邮件按钮时触发
        /// </summary>
        private void BtnRemoveMail_Click(object sender, EventArgs e)
        {
            if (ListMailList.SelectedIndex == -1) return;
            MailList.RemoveAt(ListMailList.SelectedIndex);
            ListMailList.Items.RemoveAt(ListMailList.SelectedIndex);
            SaveMailList();
        }

        /// <summary>
        /// 点击清空邮件列表按钮时触发
        /// </summary>
        private void BtnClearMail_Click(object sender, EventArgs e)
        {
            if (MailList.Count == 0) return;
            if (MessageBox.Show(Resources.AskConfirmDeletion, Resources.Tips, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ListMailList.Items.Clear();
                MailList.Clear();
                SaveMailList();
            }
        }

        #endregion -- 邮件列表 Mail list --

        private void ListMailItems_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = ListMailItems.Font.Height * 3 / 2;
        }
    }
}