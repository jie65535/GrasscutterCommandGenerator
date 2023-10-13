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
using System.Windows.Forms;

using GrasscutterTools.Game;
using GrasscutterTools.Properties;
using GrasscutterTools.Utils;

namespace GrasscutterTools.Pages
{
    internal partial class PageAvatar : BasePage
    {
        public override string Text => Resources.PageAvatarTitle;

        public PageAvatar()
        {
            InitializeComponent();
        }

        public override void OnLoad()
        {
            InitAvatars();
            InitStatList();
        }

        #region -- 获取角色 --

        /// <summary>
        /// 初始化角色列表
        /// </summary>
        private void InitAvatars()
        {
            CmbAvatar.Items.Clear();
            CmbAvatar.Items.AddRange(GameData.Avatars.Names);
        }

        /// <summary>
        /// 角色页面输入改变时触发
        /// </summary>
        private void GiveAvatarInputChanged(object sender, EventArgs e)
        {
            if (CmbAvatar.SelectedIndex >= 0)
                GenAvatar((int)NUDAvatarLevel.Value, (int)NUDAvatarConstellation.Value, (int)NUDAvatarSkillLevel.Value);
        }

        /// <summary>
        /// 获取角色命令
        /// </summary>
        /// <param name="level">等级</param>
        private void GenAvatar(int level, int constellation, int skillLevel)
        {
            if (CommandVersion.Check(CommandVersion.V1_4_1))
            {
                int avatarId = GameData.Avatars.Ids[CmbAvatar.SelectedIndex];
                SetCommand("/give", $"{avatarId} lv{level} c{constellation} sl{skillLevel}");
            }
            else if (CommandVersion.Check(CommandVersion.V1_2_2))
            {
                int avatarId = GameData.Avatars.Ids[CmbAvatar.SelectedIndex];
                SetCommand("/give", $"{avatarId} lv{level} c{constellation}");
            }
            else
            {
                int avatarId = GameData.Avatars.Ids[CmbAvatar.SelectedIndex] - 1000 + 10000000;
                SetCommand("/givechar", $"{avatarId} {level}");
            }
        }

        /// <summary>
        /// 点击获取所有角色按钮时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGiveAllChar_Click(object sender, EventArgs e)
        {
            var level = NUDAvatarLevel.Value;
            var constellation = NUDAvatarConstellation.Value;
            var skillLevel = NUDAvatarSkillLevel.Value;
            if (CommandVersion.Check(CommandVersion.V1_4_1))
                SetCommand("/give avatars", $"lv{level} c{constellation} sl{skillLevel}");
            else
                SetCommand("/give avatars", $"lv{level} c{constellation}");
        }

        #endregion -- 获取角色 --

        #region -- 切换主角元素 --

        /// <summary>
        /// 点击切换主角元素链接标签时触发
        /// </summary>
        private void LnkSwitchElement_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UIUtil.OpenURL("https://github.com/Penelopeep/SwitchElementTraveller");
        }

        /// <summary>
        /// 元素参数
        /// </summary>
        private readonly string[] Elements = { "white", "fire", "water", "wind", "ice", "rock", "electro", "grass" };

        /// <summary>
        /// 切换元素下拉框选中项改变时触发
        /// </summary>
        private void CmbSwitchElement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbSwitchElement.SelectedIndex == -1 || CmbSwitchElement.SelectedIndex >= Elements.Length) return;
            SetCommand("/se", Elements[CmbSwitchElement.SelectedIndex]);
        }

        #endregion -- 切换主角元素 --

        #region -- 设置角色属性 --

        /// <summary>
        /// 初始化数据列表
        /// </summary>
        private void InitStatList()
        {
            LblStatTip.Text = "";
            SetStatsCommand.InitStats();
            CmbStat.Items.Clear();
            CmbStat.Items.AddRange(SetStatsCommand.Stats.Select(s => s.Name).ToArray());
        }

        /// <summary>
        /// 数据页面输入改变时触发
        /// </summary>
        private void SetStatsInputChanged(object sender, EventArgs e)
        {
            if (CmbStat.SelectedIndex < 0)
                return;
            else
                BtnLockStat.Enabled = BtnUnlockStat.Enabled = true;

            var stat = SetStatsCommand.Stats[CmbStat.SelectedIndex];
            LblStatPercent.Visible = stat.Percent;
            LblStatTip.Text = stat.Tip;

            SetCommand("/setstats", $"{stat.ArgName} {NUDStat.Value}{(stat.Percent ? "%" : "")}");
        }

        /// <summary>
        /// 点击锁定按钮时触发
        /// </summary>
        private void BtnLockStat_Click(object sender, EventArgs e)
        {
            var stat = SetStatsCommand.Stats[CmbStat.SelectedIndex];
            SetCommand("/setstats", $"lock {stat.ArgName} {NUDStat.Value}{(stat.Percent ? "%" : "")}");
        }

        /// <summary>
        /// 点击解锁按钮时触发
        /// </summary>
        private void BtnUnlockStat_Click(object sender, EventArgs e)
        {
            var stat = SetStatsCommand.Stats[CmbStat.SelectedIndex];
            SetCommand("/setstats", $"unlock {stat.ArgName}");
        }

        #endregion -- 设置角色属性 --

        #region -- 设置技能等级 --

        /// <summary>
        /// 点击设置技能按钮时触发
        /// </summary>
        private void LnkSetTalentClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetCommand("/talent", $"{(sender as LinkLabel).Tag} {NUDTalentLevel.Value}");
        }

        #endregion -- 设置技能等级 --

        #region -- 设置命座 --

        /// <summary>
        /// 设置命座链接标签点击时触发
        /// </summary>
        private void LnkSetConst_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (NUDSetConstellation.Value >= 0)
                SetCommand("/setConst", $"{NUDSetConstellation.Value}" + (sender == LnkSetAllConst ? " all" : string.Empty));
            else
                SetCommand("/resetConst", (sender == LnkSetAllConst ? "all" : string.Empty));
        }

        #endregion -- 设置命座 --
    }
}