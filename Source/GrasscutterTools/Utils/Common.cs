using System;

using GrasscutterTools.Game;
using GrasscutterTools.OpenCommand;

namespace GrasscutterTools.Utils
{
    internal static class Common
    {
        /// <summary>
        /// 应用版本
        /// </summary>
        public static Version AppVersion { get; } = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

        /// <summary>
        /// 命令版本
        /// </summary>
        public static CommandVersion CommandVersion { get; } = CommandVersion.Latest();

        /// <summary>
        /// 开放命令接口
        /// </summary>
        public static OpenCommandAPI OC { get; set; }
    }
}
