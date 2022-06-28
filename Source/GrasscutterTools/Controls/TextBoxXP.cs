using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace GrasscutterTools.Controls
{
    [ToolboxItem(true)]
    public class TextBoxXP : TextBox
    {

        /// <summary>
        /// 获得当前进程，以便重绘控件
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        private const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage
          (IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        /// <summary>
        /// 水印文本
        /// </summary>
        private string _Watermark = "";

        private float maximum;
        private float minimum;

        #region 属性

        /// <summary>
        /// 是否启用热点效果
        /// </summary>
        [Category("外观")]
        [Browsable(true)]
        [Localizable(true)]
        [Description("获取或设置输入框水印文本")]
        [DefaultValue("")]
        public string Watermark
        {
            get
            {
                return this._Watermark;
            }
            set
            {
                this._Watermark = value;
                SendMessage(Handle, EM_SETCUEBANNER, 0, _Watermark);
                this.Invalidate();
            }
        }

        /// <summary>
        /// 是否只能输入数字
        /// </summary>
        [Category("行为")]
        [Browsable(true)]
        [Description("获取或设置TextBox是否只允许输入数字")]
        [DefaultValue(false)]
        public bool DigitOnly { get; set; }

        /// <summary>
        /// 转为数值
        /// </summary>
        public float Number
        {
            get
            {
                if (float.TryParse(Text, out float value))
                    return value;
                else
                    return 0f;
            }
        }

        [Category("数据")]
        [Browsable(true)]
        [DefaultValue(0)]
        [Description("指示小数点后位数")]
        public int DecimalPlaces { get; set; }

        [Category("数据")]
        [Description("获取或设置限制的最大值")]
        public float Maximum
        {
            get
            {
                return maximum;
            }
            set
            {
                maximum = value;
                if (minimum > maximum)
                {
                    minimum = maximum;
                }
            }
        }

        [Category("数据")]
        [Browsable(true)]
        [Description("获取或设置限制的最小值")]
        public float Minimum
        {
            get
            {
                return minimum;
            }
            set
            {
                minimum = value;
                if (minimum > maximum)
                {
                    maximum = value;
                }
            }
        }

        #endregion 属性

        /// <summary>
        ///
        /// </summary>
        public TextBoxXP()
            : base()
        {
            //BorderStyle = BorderStyle.FixedSingle;
            //Font = Styles.StaticResources.DefaultFont;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            // 如果只允许输入数字，则判断输入是否为退格或者数字
            if (DigitOnly)
            {
                //IsNumber：指定字符串中位于指定位置的字符是否属于数字类别
                //IsPunctuation：指定字符串中位于指定位置的字符是否属于标点符号类别
                //IsControl：指定字符串中位于指定位置的字符是否属于控制字符类别
                if (!Char.IsNumber(e.KeyChar) && !Char.IsPunctuation(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true; //获取或设置一个值，指示是否处理过System.Windows.Forms.Control.KeyPress事件
                }
                else if (Char.IsPunctuation(e.KeyChar) && DecimalPlaces > 0)
                {
                    if (e.KeyChar == '.')
                    {
                        if (Text.LastIndexOf('.') != -1)
                        {
                            e.Handled = true;
                        }
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);

            if (DigitOnly)
            {
                if (!string.IsNullOrWhiteSpace(Text))
                {
                    if (Number > Maximum)
                        Text = Maximum.ToString("F" + DecimalPlaces);
                    if (Number < Minimum)
                        Text = Minimum.ToString("F" + DecimalPlaces);
                }
            }
        }
    }
}
