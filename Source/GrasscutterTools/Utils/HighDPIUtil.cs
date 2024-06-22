using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GrasscutterTools.Utils
{
    internal class HighDPIUtil
    {
        public static void SetDpiAwareness()
        {
            var dpiAwareness = ProcessDpiAwareness.PerMonitorDpiAware;
            var hresult = SetProcessDpiAwareness(dpiAwareness);
            if (hresult != 0)
            {
                throw new System.ComponentModel.Win32Exception(hresult);
            }
        }

        [DllImport("shcore.dll")]
        private static extern int SetProcessDpiAwareness(ProcessDpiAwareness value);

        private enum ProcessDpiAwareness
        {
            DpiUnaware = 0,
            SystemDpiAware = 1,
            PerMonitorDpiAware = 2
        }
    }
}
