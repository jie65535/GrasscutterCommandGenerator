using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace GrasscutterTools.Game.Mail
{
    /// <summary>
    /// 邮件
    /// </summary>
    public class Mail
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
    }
}
