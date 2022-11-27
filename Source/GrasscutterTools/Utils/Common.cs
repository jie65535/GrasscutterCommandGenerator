using System;
using System.IO;

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

        /// <summary>
        /// 应用数据目录
        /// </summary>
        public static string GetAppDataFile(string filename) =>
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "GrasscutterTools",
                filename);

        /// <summary>
        /// UID
        /// </summary>
        public static int UID { get; set; }

        /// <summary>
        /// 生成命令是否包含UID
        /// </summary>
        public static bool IsIncludeUID { get; set; }
    }
}
