using System.Collections.Generic;

using Newtonsoft.Json;

namespace GrasscutterTools.Game.Drop
{
    internal class DropInfo
    {
        /// <summary>
        /// 怪物ID
        /// </summary>
        [JsonProperty("monsterId")]
        public int MonsterId { get; set; }

        /// <summary>
        /// 掉落列表
        /// </summary>
        [JsonProperty("dropDataList")]
        public List<DropData> DropDataList { get; set; } = new List<DropData>();
    }
}
