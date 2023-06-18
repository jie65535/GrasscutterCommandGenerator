using System;
using System.Xml.Serialization;

namespace GrasscutterTools.Utils
{
    /// <summary>
    /// 热键项
    /// </summary>
    public class HotKeyItem
    {
        /// <summary>
        /// Gets or sets the hot key identifier.
        /// </summary>
        /// <value>
        /// The hot key identifier.
        /// </value>
        [XmlIgnore]
        public int HotKeyID { get; set; }

        /// <summary>
        /// Gets or sets the name of the Tag.
        /// </summary>
        /// <value>
        /// The name of the Tag.
        /// </value>
        public string Tag { get; set; }

        /// <summary>
        /// Gets or sets the Commands.
        /// </summary>
        /// <value>
        /// The Commands.
        /// </value>
        public string Commands { get; set; }

        /// <summary>
        /// Gets or sets the hot key.
        /// 组合键之间使用+隔开，例如："Ctrl+Shift+W"
        /// </summary>
        /// <value>
        /// The hot key.
        /// </value>
        public string HotKey { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="HotKeyItem"/> is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// Gets or sets the trigger counter.
        /// </summary>
        /// <value>
        /// The trigger counter.
        /// </value>
        public int TriggerCounter { get; set; }

        /// <summary>
        /// Gets or sets the creation time.
        /// </summary>
        /// <value>
        /// The creation time.
        /// </value>
        public DateTime CreationTime { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the last modified time.
        /// </summary>
        /// <value>
        /// The last modified time.
        /// </value>
        public DateTime LastModifiedTime { get; set; } = DateTime.Now;
    }
}