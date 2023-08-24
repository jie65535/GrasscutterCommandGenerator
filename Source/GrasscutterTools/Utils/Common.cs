/**
 *  Grasscutter Tools
 *  Copyright (C) 2023 jie65535
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