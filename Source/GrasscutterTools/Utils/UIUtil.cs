using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GrasscutterTools.Properties;

namespace GrasscutterTools.Utils
{
    internal static class UIUtil
    {
        /// <summary>
        /// 播放按钮完成动画
        /// </summary>
        /// <param name="btn"></param>
        /// <returns></returns>
        public static async Task ButtonComplete(Button btn)
        {
            var t = btn.Text;
            btn.Text = "√";
            btn.Enabled = false;
            await Task.Delay(300);
            btn.Text = t;
            btn.Enabled = true;
        }

        /// <summary>
        /// 列表过滤
        /// </summary>
        /// <param name="listBox">列表控件</param>
        /// <param name="source">数据源</param>
        /// <param name="filter">过滤内容</param>
        public static void ListBoxFilter(ListBox listBox, string[] source, string filter)
        {
            filter = filter.Trim().ToLower();
            listBox.BeginUpdate();
            listBox.Items.Clear();
            if (source != null && source.Length > 0)
            {
                if (string.IsNullOrEmpty(filter))
                    listBox.Items.AddRange(source);
                else
                    listBox.Items.AddRange(source.Where(n => Contains(n, filter)).ToArray());
            }
            listBox.EndUpdate();
        }

        private static bool Contains(string source, string filter)
        {
            source = source.ToLower();
            return source.Contains(filter) || (Encoding.Default.CodePage == 936 && ContainsPY(source, filter));
        }

        private static bool ContainsPY(string source, string filter)
        {
            int i = 0;
            foreach (var ch in source)
            {
                var py = ch;
                var bytes = Encoding.Default.GetBytes(new char[] { ch });
                if (bytes.Length == 2)
                {
                    py = GetPinYing((bytes[0] << 8) + bytes[1]);
                    py = py == '\0' ? ch : py;
                }
                if (filter[i] == py)
                    i++;
                else i = 0;
                if (i == filter.Length) return true;
            }
            return false;
        }

        /// <summary>
        /// 获取拼音首字母，范围外返回原值
        /// </summary>
        /// <param name="ch">字符</param>
        /// <returns>拼音首字母</returns>
        private static char GetPinYing(int i)
        {
            if (i < 45217) return '\0';
            if (i < 45253) return 'a';
            if (i < 45761) return 'b';
            if (i < 46318) return 'c';
            if (i < 46826) return 'd';
            if (i < 47010) return 'e';
            if (i < 47297) return 'f';
            if (i < 47614) return 'g';
            if (i < 48119) return 'h';
            if (i < 48119) return 'i';
            if (i < 49062) return 'j';
            if (i < 49324) return 'k';
            if (i < 49896) return 'l';
            if (i < 50371) return 'm';
            if (i < 50614) return 'n';
            if (i < 50622) return 'o';
            if (i < 50906) return 'p';
            if (i < 51387) return 'q';
            if (i < 51446) return 'r';
            if (i < 52218) return 's';
            if (i < 52698) return 't';
            if (i < 52698) return 'u';
            if (i < 52698) return 'v';
            if (i < 52980) return 'w';
            if (i < 53689) return 'x';
            if (i < 54481) return 'y';
            if (i < 55290) return 'z';
            return '\0';
        }

        /// <summary>
        /// 使用浏览器打开网址
        /// </summary>
        /// <param name="url">网址</param>
        public static void OpenURL(string url)
        {
            try
            {
                System.Diagnostics.Process.Start(url);
            }
            catch (Exception)
            {
                MessageBox.Show(Resources.BrowserOpenFailedTip + "\n " + url,
                    Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 提示气泡对象
        /// </summary>
        private static readonly ToolTip TTip = new ToolTip();

        /// <summary>
        /// 在指定控件上显示提示气泡
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="control">控件</param>
        public static void ShowTip(string message, Control control)
        {
            TTip.Show(message, control, 0, control.Size.Height, 3000);
        }
    }
}