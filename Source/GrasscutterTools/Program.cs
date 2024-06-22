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
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using GrasscutterTools.OpenCommand;
using GrasscutterTools.Properties;
using GrasscutterTools.Utils;

namespace GrasscutterTools
{
    internal static class Program
    {
        private const string TAG = "Program";

        static Program()
        {
            AppDomain.CurrentDomain.AssemblyResolve += OnResolveAssembly;
        }

        private static Assembly OnResolveAssembly(object sender, ResolveEventArgs args)
        {
            //var executingAssembly = Assembly.GetExecutingAssembly();
            //var assemblyName = new AssemblyName(args.Name);

            //var path = assemblyName.Name + ".dll";
            //if (assemblyName.CultureInfo.Equals(CultureInfo.InvariantCulture) == false)
            //    path = $@"{assemblyName.CultureInfo}\{path}";
            //using (var stream = executingAssembly.GetManifestResourceStream(path))
            //{
            //    if (stream == null) return null;
            //    var assemblyRawBytes = new byte[stream.Length];
            //    stream.Read(assemblyRawBytes, 0, assemblyRawBytes.Length);
            //    return Assembly.Load(assemblyRawBytes);
            //}

            // 手工加载嵌入的dll文件
            if (new AssemblyName(args.Name).Name == "Newtonsoft.Json")
                return Assembly.Load(Resources.Newtonsoft_Json);
            return null;
        }

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static int Main(string[] args)
        {
            var result = HandleCommandLine(args);
            if (result != -1)
                return result;

            // 开启高DPI支持
            if (Environment.OSVersion.Version.Major >= 6) // 至少需要Vista系统
            {
               HighDPIUtil.SetDpiAwareness();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //设置应用程序处理异常方式：ThreadException处理
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //处理线程异常
            Application.ThreadException += Application_ThreadException;
            //处理非UI线程异常
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Logger.I(TAG, "Program startup");

            try
            {
                // 初始化语言环境
                if (!string.IsNullOrEmpty(Settings.Default.DefaultLanguage))
                    MultiLanguage.SetDefaultLanguage(Settings.Default.DefaultLanguage);
            }
            catch (Exception ex)
            {
                Logger.W(TAG, "Loading language error", ex);
                MessageBox.Show(Resources.SettingLoadError + ex.ToString(), Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Application.Run(new Forms.FormMain());
            Logger.I(TAG, "Program end.");
            return 0;
        }

        #region - 命令行参数 -

        /// <summary>
        /// 处理命令行参数并返回处理结果
        /// </summary>
        /// <param name="args">命令行参数</param>
        /// <returns>返回-1表示继续启动应用程序。返回其它值表示退出应用并将该值作为返回结果。</returns>
        private static int HandleCommandLine(string[] args)
        {
            var parser = new ToggleParser(args);
            if (parser.IsEmpty) return -1;
            try
            {
                GuiRedirect.Redirect();

                // 是否启动日志
                if (parser.HasToggle("debug") || parser.HasToggle("log"))
                    Logger.IsSaveLogs = true;

                if (parser.HasToggle("v") || parser.HasToggle("version"))
                {
                    Console.WriteLine("v" + Common.AppVersion.ToString(3));
                    return 0;
                }

                if (parser.HasToggle("h") || parser.HasToggle("help") || parser.HasToggle("?"))
                {
                    Console.WriteLine("Usages:");
                    Console.WriteLine("    GcTools.exe -help");
                    Console.WriteLine("    GcTools.exe -version");
                    Console.WriteLine("    GcTools.exe -c \"cmd arg\"");
                    Console.WriteLine("    GcTools.exe -c \"cmd1 arg\" && GcTools -c \"cmd2 arg1 arg2\"");
                    Console.WriteLine("    GcTools.exe -host http://127.0.0.1:443 -token 123456 -c \"cmd1 arg1 arg2 | cmd2 | cmd3 arg\"");
                    return 0;
                }

                // 服务器地址
                var host = parser.GetToggleValueOrDefault("host", Settings.Default.Host);
                // 服务器令牌
                var token = parser.GetToggleValueOrDefault("token", Settings.Default.TokenCache);

                if (Settings.Default.Host != host || Settings.Default.TokenCache != token)
                {
                    Settings.Default.Host = host;
                    Settings.Default.TokenCache = token;
                    Settings.Default.Save();
                }

#if DEBUG
                Logger.I(TAG, $"Host: {Settings.Default.Host}  Token: {Settings.Default.TokenCache}");
#endif
                // UID
                //Settings.Default.RemoteUid = decimal.Parse(parser.GetToggleValueOrDefault("uid", Settings.Default.RemoteUid.ToString()));

                if (!string.IsNullOrEmpty(Settings.Default.Host) && !string.IsNullOrEmpty(Settings.Default.TokenCache))
                {
                    Common.OC = new OpenCommandAPI(Settings.Default.Host, Settings.Default.TokenCache);
                }

                // 解析并执行命令
                var cmd = parser.GetToggleValueOrDefault("c", string.Empty);
                if (string.IsNullOrEmpty(cmd)) cmd = parser.GetToggleValueOrDefault("command", string.Empty);
                if (!string.IsNullOrEmpty(cmd))
                {
                    return RunCommand(cmd) ? 0 : 1;
                }
            }
            catch (Exception ex)
            {
                Logger.E(TAG, "Parse command failed!", ex);
            }
            return -1;
        }

        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="commands">GC命令，由|分割多条命令</param>
        /// <returns>返回是否执行成功</returns>
        private static bool RunCommand(string commands)
        {
            if (Common.OC == null || !Common.OC.CanInvoke)
            {
                Console.WriteLine(Resources.RequireOpenCommandTip);
                Logger.E(TAG, Resources.RequireOpenCommandTip);
                return false;
            }

            try
            {
                Common.OC.Ping().Wait(1000);

                if (Common.OC.CanInvokeMultipleCmd)
                {
                    var msg = Common.OC.Invoke(FormatCommand(commands)).Result;
                    Console.WriteLine(string.IsNullOrEmpty(msg) ? "OK" : msg);
                }
                else
                {
                    foreach (var cmd in commands.Split('|').Select(FormatCommand))
                    {
                        var msg = Common.OC.Invoke(cmd).Result;
                        Console.WriteLine(string.IsNullOrEmpty(msg) ? "OK" : msg);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Logger.E(TAG, "RunCommand Error:", ex);
                return false;
            }
        }

        /// <summary>
        /// 格式化命令
        /// （去除收尾空白，替换换行）
        /// </summary>
        /// <param name="raw">原始输入</param>
        /// <returns>格式化后可执行命令</returns>
        private static string FormatCommand(string raw)
        {
            return raw.Trim().Replace("\\r", "\r").Replace("\\n", "\n");
        }

        #endregion - 命令行参数 -

        #region - 全局异常处理 -

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            string str = GetExceptionMsg(e.Exception, e.ToString());
            Logger.E(TAG, "Application_ThreadException");
            Logger.E(TAG, str);
            MessageBox.Show(str, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string str = GetExceptionMsg(e.ExceptionObject as Exception, e.ToString());
            Logger.E(TAG, "CurrentDomain_UnhandledException");
            Logger.E(TAG, str);
            MessageBox.Show(str, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 生成自定义异常消息
        /// </summary>
        /// <param name="ex">异常对象</param>
        /// <param name="backStr">备用异常消息：当ex为null时有效</param>
        /// <returns>异常字符串文本</returns>
        private static string GetExceptionMsg(Exception ex, string backStr)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("****************************异常文本****************************");
            sb.AppendLine("【出现时间】：" + DateTime.Now.ToString());
            if (ex != null)
            {
                sb.AppendLine("【异常类型】：" + ex.GetType().Name);
                sb.AppendLine("【异常信息】：" + ex.Message);
#if DEBUG
                sb.AppendLine("【堆栈调用】：" + ex.StackTrace);
#endif
            }
            else
            {
                sb.AppendLine("【未处理异常】：" + backStr);
            }
            sb.AppendLine("***************************************************************");
            return sb.ToString();
        }

        #endregion - 全局异常处理 -
    }
}