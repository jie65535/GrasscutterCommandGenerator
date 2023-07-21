using System;
using Newtonsoft.Json;

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
        [JsonIgnore]
        public int HotKeyId { get; set; }

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
        public bool IsEnabled { get; set; } = true;
    }
}