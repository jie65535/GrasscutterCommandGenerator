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
    }
}
