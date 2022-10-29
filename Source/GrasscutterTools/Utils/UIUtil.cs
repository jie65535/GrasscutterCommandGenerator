using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if (string.IsNullOrEmpty(filter))
                listBox.Items.AddRange(source);
            else
                listBox.Items.AddRange(source.Where(n => n.Contains(filter)).ToArray());
            listBox.EndUpdate();
        }
    }
}
