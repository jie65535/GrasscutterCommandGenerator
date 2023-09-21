using System;
using System.Runtime.InteropServices;

namespace Eavesdrop
{
    internal static class NativeMethods
    {
        [DllImport("wininet.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int dwBufferLength);
    }
}