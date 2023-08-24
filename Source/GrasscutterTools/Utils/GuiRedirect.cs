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
using System.Runtime.InteropServices;

namespace GrasscutterTools.Utils
{
    /// <summary>
    /// <see cref="https://stackoverflow.com/a/17534263"/>
    /// </summary>
    internal class GuiRedirect
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool AttachConsole(int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetStdHandle(StandardHandle nStdHandle);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetStdHandle(StandardHandle nStdHandle, IntPtr handle);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern FileType GetFileType(IntPtr handle);

        //[DllImport("kernel32.dll", SetLastError = true)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //static extern bool AllocConsole();

        private enum StandardHandle : uint
        {
            Input = unchecked((uint)-10),
            Output = unchecked((uint)-11),
            Error = unchecked((uint)-12)
        }

        private enum FileType : uint
        {
            Unknown = 0x0000,
            Disk = 0x0001,
            Char = 0x0002,
            Pipe = 0x0003
        }

        private static bool IsRedirected(IntPtr handle)
        {
            FileType fileType = GetFileType(handle);

            return (fileType == FileType.Disk) || (fileType == FileType.Pipe);
        }

        public static void Redirect()
        {
            if (IsRedirected(GetStdHandle(StandardHandle.Output)))
            {
                var initialiseOut = Console.Out;
            }

            bool errorRedirected = IsRedirected(GetStdHandle(StandardHandle.Error));
            if (errorRedirected)
            {
                var initialiseError = Console.Error;
            }

            AttachConsole(-1);

            if (!errorRedirected)
                SetStdHandle(StandardHandle.Error, GetStdHandle(StandardHandle.Output));
        }
    }
}