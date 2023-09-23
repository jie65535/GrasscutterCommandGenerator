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
using System.IO;
using System.Windows.Forms;

namespace GrasscutterTools.Utils
{
    internal static class Logger
    {
        public static bool IsSaveLogs = false;

        private static readonly string LogPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), $"GcTools-{DateTime.Now:MMdd}.log");

        private static void Write(string message)
        {
#if DEBUG
            Console.WriteLine($"{DateTime.Now:mm:ss.fff} {message}");
#else
            if (IsSaveLogs)
            {
                Console.WriteLine($"{DateTime.Now:mm:ss.fff} {message}");
                File.AppendAllText(LogPath, $"{DateTime.Now:mm:ss.fff} {message}{Environment.NewLine}");
            }
#endif
        }

        private static void Write(string level, string tag, string message) => Write($"<{level}:{tag}> {message}");

        //public static void Debug(string message) => Write("DEBUG", "Proxy", message);

        //public static void Info(string info) => Write("INFO", "Proxy", info);

        //public static void Error(Exception ex) => Write("ERROR", "Proxy", ex.ToString());


        public static void I(string tag, string info) => Write("INFO", tag, info);

        public static void W(string tag, string message) => Write("WARR", tag, message);

        public static void W(string tag, string message, Exception ex) => Write("WARR", tag, $"{message} {ex}");

        public static void E(string tag, string message) => Write("ERROR", tag, message);

        public static void E(string tag, string message, Exception ex) => Write("ERROR", tag, $"{message} {ex}");
    }
}