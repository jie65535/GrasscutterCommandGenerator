using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using Microsoft.Win32;

namespace Eavesdrop
{
    public static class INETOptions
    {
        private static readonly object _stateLock;
        private static readonly int _iNetOptionSize;
        private static readonly int _iNetPackageSize;
        private static readonly RegistryKey _proxyKey;

        public static List<string> Overrides { get; }

        public static string HTTPAddress { get; set; }
        public static string HTTPSAddress { get; set; }

        public static bool IsProxyEnabled { get; set; }
        public static bool IsIgnoringLocalTraffic { get; set; }

        static INETOptions()
        {
            _stateLock = new object();
            _iNetOptionSize = Marshal.SizeOf(typeof(INETOption));
            _iNetPackageSize = Marshal.SizeOf(typeof(INETPackage));
            _proxyKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings", true);

            Overrides = new List<string>();
            Load();
        }

        public static void Save()
        {
            lock (_stateLock)
            {
                var options = new List<INETOption>(3);
                string joinedAddresses = (IsProxyEnabled ? GetJoinedAddresses() : null);
                string joinedOverrides = (IsProxyEnabled ? GetJoinedOverrides() : null);

                var kind = ProxyKind.PROXY_TYPE_DIRECT;
                if (!string.IsNullOrWhiteSpace(joinedAddresses))
                {
                    options.Add(new INETOption(OptionKind.INTERNET_PER_CONN_PROXY_SERVER, joinedAddresses));
                    if (!string.IsNullOrWhiteSpace(joinedOverrides))
                    {
                        options.Add(new INETOption(OptionKind.INTERNET_PER_CONN_PROXY_BYPASS, joinedOverrides));
                    }
                    kind |= ProxyKind.PROXY_TYPE_PROXY;
                }
                options.Insert(0, new INETOption(OptionKind.INTERNET_PER_CONN_FLAGS, (int)kind));

                var inetPackage = new INETPackage
                {
                    _optionError = 0,
                    _size = _iNetPackageSize,
                    _connection = IntPtr.Zero,
                    _optionCount = options.Count
                };

                IntPtr optionsPtr = Marshal.AllocCoTaskMem(_iNetOptionSize * options.Count);
                for (int i = 0; i < options.Count; ++i)
                {
                    var optionPtr = new IntPtr((IntPtr.Size == 4 ? optionsPtr.ToInt32() : optionsPtr.ToInt64()) + (i * _iNetOptionSize));
                    Marshal.StructureToPtr(options[i], optionPtr, false);
                }
                inetPackage._optionsPtr = optionsPtr;

                IntPtr iNetPackagePtr = Marshal.AllocCoTaskMem(_iNetPackageSize);
                Marshal.StructureToPtr(inetPackage, iNetPackagePtr, false);

                int returnvalue = (NativeMethods.InternetSetOption(IntPtr.Zero, 75, iNetPackagePtr, _iNetPackageSize) ? -1 : 0);
                if (returnvalue == 0)
                {
                    returnvalue = Marshal.GetLastWin32Error();
                }

                Marshal.FreeCoTaskMem(optionsPtr);
                Marshal.FreeCoTaskMem(iNetPackagePtr);
                if (returnvalue > 0)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }

                NativeMethods.InternetSetOption(IntPtr.Zero, 39, iNetPackagePtr, _iNetPackageSize);
                NativeMethods.InternetSetOption(IntPtr.Zero, 37, iNetPackagePtr, _iNetPackageSize);
            }
        }
        public static void Load()
        {
            lock (_stateLock)
            {
                LoadAddresses();
                LoadOverrides();
                IsProxyEnabled = (_proxyKey.GetValue("ProxyEnable")?.ToString() == "1");
            }
        }

        private static void LoadOverrides()
        {
            string proxyOverride = _proxyKey.GetValue("ProxyOverride")?.ToString();
            if (string.IsNullOrWhiteSpace(proxyOverride)) return;

            string[] overrides = proxyOverride.Split(';');
            foreach (string @override in overrides)
            {
                if (@override == "<local>")
                {
                    IsIgnoringLocalTraffic = true;
                }
                else if (!Overrides.Contains(@override))
                {
                    Overrides.Add(@override);
                }
            }
        }
        private static void LoadAddresses()
        {
            string proxyServer = _proxyKey.GetValue("ProxyServer")?.ToString();
            if (string.IsNullOrWhiteSpace(proxyServer)) return;

            string[] values = proxyServer.Split(';');
            foreach (string value in values)
            {
                string[] pair = value.Split('=');
                if (pair.Length != 2)
                {
                    HTTPAddress = value;
                    HTTPSAddress = value;
                    return;
                }

                string address = pair[1];
                string protocol = pair[0];
                switch (protocol)
                {
                    case "http": HTTPAddress = address; break;
                    case "https": HTTPSAddress = address; break;
                }
            }
        }

        private static string GetJoinedAddresses()
        {
            var addresses = new List<string>(2);
            if (!string.IsNullOrWhiteSpace(HTTPAddress))
            {
                addresses.Add("http=" + HTTPAddress);
            }
            if (!string.IsNullOrWhiteSpace(HTTPSAddress))
            {
                addresses.Add("https=" + HTTPSAddress);
            }
            return string.Join(";", addresses);
        }
        private static string GetJoinedOverrides()
        {
            var overrides = new List<string>(Overrides);
            if (IsIgnoringLocalTraffic)
            {
                overrides.Add("<local>");
            }
            return string.Join(";", overrides);
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct INETOption
        {
            private readonly OptionKind _kind;
            private readonly INETOptionValue _value;

            public INETOption(OptionKind kind, int value)
            {
                _kind = kind;
                _value = CreateValue(value);
            }
            public INETOption(OptionKind kind, string value)
            {
                _kind = kind;
                _value = CreateValue(value);
            }

            private static INETOptionValue CreateValue(int value)
            {
                return new INETOptionValue
                {
                    _intValue = value
                };
            }
            private static INETOptionValue CreateValue(string value)
            {
                return new INETOptionValue
                {
                    _stringPointer = Marshal.StringToHGlobalAuto(value)
                };
            }

            [StructLayout(LayoutKind.Explicit)]
            private struct INETOptionValue
            {
                [FieldOffset(0)]
                public int _intValue;

                [FieldOffset(0)]
                public IntPtr _stringPointer;

                [FieldOffset(0)]
                public System.Runtime.InteropServices.ComTypes.FILETIME _fileTime;
            }
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct INETPackage
        {
            public int _size;
            public IntPtr _connection;
            public int _optionCount;
            public int _optionError;
            public IntPtr _optionsPtr;
        }

        [Flags]
        private enum ProxyKind
        {
            PROXY_TYPE_DIRECT = 1,
            PROXY_TYPE_PROXY = 2,
            PROXY_TYPE_AUTO_PROXY_URL = 4,
            PROXY_TYPE_AUTO_DETECT = 8
        }
        private enum OptionKind
        {
            INTERNET_PER_CONN_FLAGS = 1,
            INTERNET_PER_CONN_PROXY_SERVER = 2,
            INTERNET_PER_CONN_PROXY_BYPASS = 3,
            INTERNET_PER_CONN_AUTOCONFIG_URL = 4
        }
    }
}