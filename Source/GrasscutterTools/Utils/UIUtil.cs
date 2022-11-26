using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using GrasscutterTools.Properties;

namespace GrasscutterTools.Utils
{
    public static class UIUtil
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
            filter = filter.Trim();
            listBox.BeginUpdate();
            listBox.Items.Clear();
            if (source != null && source.Length > 0)
            {
                if (string.IsNullOrEmpty(filter))
                    listBox.Items.AddRange(source);
                else
                    listBox.Items.AddRange(source.Where(n => n.Contains(filter)).ToArray());
            }
            listBox.EndUpdate();
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
        private readonly static ToolTip TTip = new ToolTip();

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
