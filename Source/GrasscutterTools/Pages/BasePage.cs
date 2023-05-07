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
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using GrasscutterTools.Game;
using GrasscutterTools.Utils;

namespace GrasscutterTools.Pages
{
    internal class BasePage : UserControl
    {
        public BasePage()
        {
            Font = new Font("Microsoft YaHei UI", 9, GraphicsUnit.Point);
            //Size = new Size(652, 245);
            Size = new Size(646, 239);
            BackColor = Color.FromArgb(0xF9, 0xF9, 0xF9);
            Margin = new Padding(0);
        }

        #region - 命令相关 -

        protected static CommandVersion CommandVersion => Common.CommandVersion;

        public delegate void SetCommandHandler(string command, string args = "");

        /// <summary>
        /// 设置命令
        /// </summary>
        /// <param name="command">命令</param>
        /// <param name="args">参数</param>
        public SetCommandHandler SetCommand { get; set; }

        public delegate Task<bool> RunCommandsHandler(params string[] commands);

        /// <summary>
        /// 运行命令
        /// </summary>
        public RunCommandsHandler RunCommands { get; set; }

        /// <summary>
        /// 获取当前输入框命令
        /// </summary>
        public Func<string> GetCommand { get; set; }

        /// <summary>
        /// 运行原始命令（未处理的竖线分割命令文本）
        /// </summary>
        /// <param name="commands">未处理的竖线分割命令文本</param>
        /// <returns>是否运行成功</returns>
        protected async Task<bool> RunRawCommands(string commands)
        {
            if (commands.IndexOf('|') == -1)
                return await RunCommands(FormatCommand(commands));
            else
                return await RunCommands(commands.Split('|').Select(FormatCommand).ToArray());
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

        #endregion - 命令相关 -

        #region - 生命周期事件 -

        /// <summary>
        /// 加载时触发（修改语言时会再次触发）
        /// </summary>
        public virtual void OnLoad()
        { }

        /// <summary>
        /// 进入页面时触发（可触发多次）
        /// </summary>
        public virtual void OnEnter()
        { }

        /// <summary>
        /// 关闭时触发（用于保存页面数据）
        /// </summary>
        public virtual void OnClosed()
        { }

        #endregion - 生命周期事件 -
    }
}