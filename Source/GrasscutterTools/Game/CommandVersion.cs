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

namespace GrasscutterTools.Game
{
    /// <summary>
    /// 命令版本
    ///
    /// 用法：
    /// ver = Version.TryParse(input, out Version current) ? new CommandVersion(current) : CommandVersion.Latest();
    ///
    /// </summary>
    internal class CommandVersion
    {
        /// <summary>
        /// 初始化当前版本
        /// </summary>
        /// <param name="current"></param>
        public CommandVersion(Version current)
        {
            this.current = current ?? throw new ArgumentNullException(nameof(current));
        }

        private Version current;

        /// <summary>
        /// 当前命令版本
        /// </summary>
        public Version Current
        {
            get => current;
            set
            {
                if (current != value)
                {
                    current = value;
                    OnVersionChanged();
                }
            }
        }

        /// <summary>
        /// 选中版本改变事件
        /// </summary>
        public event EventHandler VersionChanged;

        /// <summary>
        /// 触发版本更改事件
        /// </summary>
        private void OnVersionChanged() => VersionChanged?.Invoke(this, EventArgs.Empty);

        /// <summary>
        /// 当前支持的最新版本 - 当未选择版本时，默认为最新版本
        /// </summary>
        public static CommandVersion Latest() => new CommandVersion(List[List.Length - 1]);

        /// <summary>
        /// 检查命令版本
        /// </summary>
        /// <param name="version">最低要求版本</param>
        /// <returns>当前版本是否满足</returns>
        public bool Check(Version version) => Current >= version;

        #region - 版本列表 Version List -

        // 忽略更早以前的版本
        /// <summary>
        /// v1.2.1  2022/6/18
        /// git 30c7bb94439a123417a6a1e0116acd3c40f2d115
        /// </summary>
        public static readonly Version V1_2_1 = new Version(1, 2, 1);

        /// <summary>
        /// v1.2.1 -> v1.2.2  2022/6/22
        /// git aa43943025fefcda9739c9fcf242e67f1a7b83b4
        /// </summary>
        public static readonly Version V1_2_2 = new Version(1, 2, 2);

        /// <summary>
        /// v1.2.2 -> v1.2.3  2022/7/21
        /// git a07b3f21e6fbeb9abfad8862d6fa0dc4a1c3c1a3
        /// </summary>
        public static readonly Version V1_2_3 = new Version(1, 2, 3);

        /// <summary>
        /// v1.2.3 -> v1.3.0  2022/9/3 - stable
        /// git 155501058fcce109489a19db37d0513d2235e08e
        /// </summary>
        public static readonly Version V1_3_0 = new Version(1, 3, 0);

        /// <summary>
        /// v1.3.0 -> v1.3.1  2022/9/3
        /// git 6cf83b30eeaa98a68de2d786d7ca85ae21a95e32
        /// </summary>
        public static readonly Version V1_3_1 = new Version(1, 3, 1);

        /// <summary>
        /// 2022/10/13
        /// </summary>
        public static readonly Version V1_4_0 = new Version(1, 4, 0);

        /// <summary>
        /// 2022/10/18
        /// </summary>
        public static readonly Version V1_4_1 = new Version(1, 4, 1);

        /// <summary>
        /// 2022/10/27
        /// </summary>
        public static readonly Version V1_4_2 = new Version(1, 4, 2);

        /// <summary>
        /// 2022/11/15
        /// </summary>
        public static readonly Version V1_4_3 = new Version(1, 4, 3);

        /// <summary>
        /// 2023/4/1
        /// </summary>
        public static readonly Version V1_4_7 = new Version(1, 4, 7);

        /// <summary>
        /// 2023/4/1
        /// </summary>
        public static readonly Version V1_5_0 = new Version(1, 5, 0);

        /// <summary>
        /// 2023/6/1
        /// </summary>
        public static readonly Version V1_6_0 = new Version(1, 6, 0);

        /// <summary>
        /// 2023/6/2
        /// </summary>
        public static readonly Version V1_6_1 = new Version(1, 6, 1);

        /// <summary>
        /// 2023/7/1
        /// </summary>
        public static readonly Version V1_6_2 = new Version(1, 6, 2);

        /// <summary>
        /// 2023/8/1
        /// </summary>
        public static readonly Version V1_6_3 = new Version(1, 6, 3);

        /// <summary>
        /// 2023/9/1
        /// </summary>
        public static readonly Version V1_7_0 = new Version(1, 7, 0);

        /// <summary>
        /// 2023/9/3
        /// </summary>
        public static readonly Version V1_7_1 = new Version(1, 7, 1);

        /// <summary>
        /// 2023/10/1
        /// </summary>
        public static readonly Version V1_7_2 = new Version(1, 7, 2);

        // More...
        /// <summary>
        /// Date
        /// </summary>
        //public static readonly Version V1_6_3 = new Version(1, 6, 3);

        public static Version[] List { get; } = new Version[] {
            V1_2_1,
            V1_2_2,
            V1_2_3,
            V1_3_0,
            V1_3_1,
            V1_4_0,
            V1_4_1,
            V1_4_2,
            V1_4_3,
            V1_4_7,
            V1_5_0,
            V1_6_0,
            V1_6_1,
            V1_6_2,
            V1_6_3,
            V1_7_0,
            V1_7_1,
            V1_7_2,
        };

        #endregion - 版本列表 Version List -
    }
}