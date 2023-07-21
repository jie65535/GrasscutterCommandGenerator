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

        private static string AppDataFolder { get; } = GetAppDataFolder();
        private static string GetAppDataFolder()
        {
            var dir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "GrasscutterTools");
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            return dir;
        }

        /// <summary>
        /// 应用数据目录
        /// </summary>
        public static string GetAppDataFile(string filename)
        {
            return Path.Combine(AppDataFolder, filename);
        }


        public static KeyGo KeyGo { get; set; }
    }
}