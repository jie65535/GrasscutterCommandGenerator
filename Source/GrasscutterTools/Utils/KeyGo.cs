/**
 *  Grasscutter Tools
 *  Copyright (C) 2023 jie65535
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
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace GrasscutterTools.Utils
{
    /// <summary>
    /// KeyGo 核心功能类
    /// </summary>
    internal class KeyGo
    {
        public KeyGo(IntPtr formHandle)
        {
            FormHandle = formHandle;
        }

        #region Member
        
        private static int _regMaxId;

        private readonly IntPtr FormHandle;

        private bool _isEnabled;

        public List<HotKeyItem> Items { get; set; } = new();

        /// <summary>
        /// 全局热键是否启用
        /// </summary>
        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                _isEnabled = value;
                if (value) RegAllKey();
                else UnRegAllKey();
            }
        }

        #endregion Member

        #region HotKey Register

        /// <summary>
        /// 注册所有启用的快捷键
        /// </summary>
        public void RegAllKey()
        {
            if (!_isEnabled) return;
            foreach (var item in Items.Where(item => item.IsEnabled))
            {
                try
                {
                    RegKey(item);
                }
                catch (Exception)
                {
                    // 忽视异常，外部通过ID是否被设置判断执行结果
                }
            }
        }

        /// <summary>
        /// 取消所有快捷键
        /// </summary>
        public void UnRegAllKey()
        {
            foreach (var item in Items)
            {
                try
                {
                    UnRegKey(item);
                }
                catch (Exception)
                {
                    // 忽视异常，外部通过ID是否被设置判断执行结果
                }
            }
        }

        /// <summary>
        /// 注册热键 - 成功后，会设置 HotKeyId
        /// </summary>
        /// <param name="item">The item.</param>
        /// <exception cref="ArgumentNullException">
        /// item
        /// or
        /// HotKey - 热键不能为空！
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// 功能键不能为空！
        /// or
        /// 快捷键不能为空！
        /// </exception>
        public void RegKey(HotKeyItem item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            if (string.IsNullOrWhiteSpace(item.HotKey))
                throw new ArgumentNullException(nameof(item.HotKey), "热键不能为空！");

            // 如果注册过该热键，ID不为0。卸载热键会将ID置零。
            if (item.HotKeyId != 0)
                return;
            if (!IsEnabled)
                return;

            var id = Interlocked.Increment(ref _regMaxId);

            var keys = item.HotKey.Split('+');
            var keyCode = Keys.None;
            var keyModifiers = AppHotKey.KeyModifiers.None;
            foreach (var key in keys)
            {
                switch (key.Trim().ToLower())
                {
                    case "ctrl":
                        keyModifiers |= AppHotKey.KeyModifiers.Ctrl;
                        break;

                    case "shift":
                        keyModifiers |= AppHotKey.KeyModifiers.Shift;
                        break;

                    case "alt":
                        keyModifiers |= AppHotKey.KeyModifiers.Alt;
                        break;

                    case "win":
                        keyModifiers |= AppHotKey.KeyModifiers.WindowsKey;
                        break;

                    default:
                        keyCode = (Keys)Enum.Parse(typeof(Keys), key);
                        break;
                }
            }

            // 允许功能键为空
            //if (keyModifiers == AppHotKey.KeyModifiers.None)
            //    throw new InvalidOperationException("功能键不能为空！");
            if (keyCode == Keys.None)
                throw new InvalidOperationException("快捷键不能为空！");

            AppHotKey.RegKey(FormHandle, id, keyModifiers, keyCode);
            item.HotKeyId = id;
        }

        /// <summary>
        /// 注销热键 - 完成后，会清零 HotKeyId
        /// </summary>
        /// <param name="item">The item.</param>
        /// <exception cref="ArgumentNullException">item</exception>
        public void UnRegKey(HotKeyItem item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            if (item.HotKeyId == 0)
                return;

            AppHotKey.UnRegKey(FormHandle, item.HotKeyId);
            item.HotKeyId = 0;
        }

        #endregion HotKey Register

        #region HotKey Trigger

        /// <summary>
        /// 热键触发时调用
        /// </summary>
        public event EventHandler<HotKeyTriggerEventArgs> HotKeyTriggerEvent;

        private bool OnHotKeyTrigger(HotKeyItem item)
        {
            var args = new HotKeyTriggerEventArgs { HotKeyItem = item };
            HotKeyTriggerEvent?.Invoke(this, args);
            return args.Handle;
        }

        /// <summary>
        /// Processes the hotkey.
        /// </summary>
        /// <param name="hotKey_id">The hot key identifier.</param>
        public void ProcessHotKey(int hotKeyId)
        {
            var hotKey = Items.Find(k => k.HotKeyId == hotKeyId);
            if (hotKey != null)
            {
                //Console.WriteLine($"ID:{hotKey.HotKeyId} Keys:{hotKey.HotKey} ProcessName:{hotKey.ProcessName}\nStartupPath:{hotKey.StartupPath}");
                //++hotKey.TriggerCounter;
                // 触发事件，若被外部处理，则内部不再执行
                OnHotKeyTrigger(hotKey);
            }
        }

        #endregion HotKey Trigger

        #region HotKey Manager

        /// <summary>
        /// 添加一个新热键
        /// </summary>
        /// <param name="item">The item.</param>
        /// <exception cref="ArgumentNullException">
        /// item
        /// or
        /// HotKey - 热键不能为空！
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// 功能键不能为空！
        /// or
        /// 快捷键不能为空！
        /// </exception>
        public void AddHotKey(HotKeyItem item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            if (_isEnabled && item.IsEnabled)
                RegKey(item);
            Items.Add(item);
        }

        /// <summary>
        /// 删除一个热键
        /// </summary>
        /// <param name="item">The item.</param>
        public void DelHotKey(HotKeyItem item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            if (item.HotKeyId != 0)
                UnRegKey(item);
            Items.Remove(item);
        }

        /// <summary>
        /// 修改热键
        /// </summary>
        /// <param name="item">The item.</param>
        public void ChangeHotKey(HotKeyItem item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            // 重新注册
            if (item.HotKeyId != 0)
                UnRegKey(item);
            if (_isEnabled && item.IsEnabled)
                RegKey(item);
        }

        #endregion HotKey Manager
    }

    /// <summary>
    /// 热键触发事件参数
    /// </summary>
    internal class HotKeyTriggerEventArgs
    {
        public HotKeyItem HotKeyItem { get; set; }

        /// <summary>
        /// 获取或设置该事件是否已经被处理
        /// </summary>
        /// <value>
        ///   <c>true</c> if handle; otherwise, <c>false</c>.
        /// </value>
        public bool Handle { get; set; }
    }
}