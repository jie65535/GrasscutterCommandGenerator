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

using Newtonsoft.Json;

namespace GrasscutterTools.Game.Mail
{
    /// <summary>
    /// 邮件
    /// </summary>
    internal class Mail
    {
        /// <summary>
        /// 发件人
        /// </summary>
        public string Sender { get; set; }

        /// <summary>
        /// 收件人 (0 表示发送给所有人)
        /// </summary>
        public int Recipient { get; set; }

        /// <summary>
        /// 是否发送给所有人
        /// </summary>
        [JsonIgnore]
        public bool SendToAll => Recipient == 0;

        /// <summary>
        /// 邮件标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 邮件内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 附件列表
        /// </summary>
        public List<MailItem> ItemList { get; set; }

        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime SendTime { get; set; }

        public override string ToString()
        {
            if (SendToAll)
                return $"ToAll: [{Title}] {Content} | {SendTime}";
            else
                return $"To[{Recipient}]: [{Title}] {Content} | {SendTime}";
        }
    }
}