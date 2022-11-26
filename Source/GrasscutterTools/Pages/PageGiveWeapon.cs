using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GrasscutterTools.Game;
using GrasscutterTools.Utils;

namespace GrasscutterTools.Pages
{
    internal partial class PageGiveWeapon : BasePage
    {
        public PageGiveWeapon()
        {
            InitializeComponent();
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode) return;
            ListWeapons.Items.Clear();
            ListWeapons.Items.AddRange(GameData.Weapons.Lines);
        }

        /// <summary>
        /// 武器列表过滤器文本改变时触发
        /// </summary>
        private void TxtWeaponFilter_TextChanged(object sender, EventArgs e)
        {
            UIUtil.ListBoxFilter(ListWeapons, GameData.Weapons.Lines, TxtWeaponFilter.Text);
        }

        /// <summary>
        /// 武器页面输入改变时触发
        /// </summary>
        private void WeaponValueChanged(object sender, EventArgs e)
        {
            var name = ListWeapons.SelectedItem as string;
            if (!string.IsNullOrEmpty(name))
            {
                var id = ItemMap.ToId(name);
                if (CommandVersion.Check(CommandVersion.V1_2_2))
                    SetCommand("/give", $"{id} x{NUDWeaponAmout.Value} lv{NUDWeaponLevel.Value} r{NUDWeaponRefinement.Value}");
                else
                    SetCommand("/give", $"{id} {NUDWeaponAmout.Value} {NUDWeaponLevel.Value} {NUDWeaponRefinement.Value}");
            }
        }

        /// <summary>
        /// 点击获取所有武器按钮时触发
        /// </summary>
        private void BtnGiveAllWeapons_Click(object sender, EventArgs e)
        {
            SetCommand("/give", $"weapons x{NUDWeaponAmout.Value} lv{NUDWeaponLevel.Value} r{NUDWeaponRefinement.Value}");
        }
    }
}
