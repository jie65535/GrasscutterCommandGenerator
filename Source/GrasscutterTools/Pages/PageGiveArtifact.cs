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
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using GrasscutterTools.Game;
using GrasscutterTools.Properties;
using GrasscutterTools.Utils;

namespace GrasscutterTools.Pages
{
    internal partial class PageGiveArtifact : BasePage
    {
        public override string Text => Resources.PageGetArtifactTitle;

        public PageGiveArtifact()
        {
            InitializeComponent();
            if (DesignMode) return;

            CommandVersion.VersionChanged += (_, _1) => ChangeTPArtifact();
        }

        /// <summary>
        /// 副词条集
        /// </summary>
        private Dictionary<string, List<KeyValuePair<int, string>>> subAttrs;

        /// <summary>
        /// 部位标签集
        /// </summary>
        private string[] ArtifactPartLabels;

        /// <summary>
        /// 初始化圣遗物列表
        /// </summary>
        public override void OnLoad()
        {
            CmbArtifactSet.Items.Clear();
            CmbArtifactSet.Items.AddRange(GameData.ArtifactCats.Names);
            CmbMainAttribution.Items.Clear();
            CmbMainAttribution.Items.AddRange(GameData.ArtifactMainAttribution.Lines);

            subAttrs = new Dictionary<string, List<KeyValuePair<int, string>>>();
            for (int i = 0; i < GameData.ArtifactSubAttribution.Count; i++)
            {
                var name = GameData.ArtifactSubAttribution.Names[i];
                var pi = name.IndexOf('+');
                var prefix = name.Substring(0, pi);
                var value = name.Substring(pi);
                if (!subAttrs.TryGetValue(prefix, out List<KeyValuePair<int, string>> list))
                {
                    list = new List<KeyValuePair<int, string>>();
                    subAttrs[prefix] = list;
                }
                list.Add(new KeyValuePair<int, string>(GameData.ArtifactSubAttribution.Ids[i], value));
            }
            CmbSubAttribution.Items.Clear();
            CmbSubAttribution.Items.AddRange(subAttrs.Keys.ToArray());

            ArtifactPartLabels = Resources.ArtifactPartLabels.Split(',');

            ChangeTPArtifact();
        }

        /// <summary>
        /// 圣遗物套装下拉框选中项改变时触发
        /// </summary>
        private void CmbArtifactSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbArtifactSet.SelectedIndex < 0)
                return;
            var setId = GameData.ArtifactCats.Ids[CmbArtifactSet.SelectedIndex];
            var beginIndex = Array.FindIndex(GameData.Artifacts.Ids, id => id / 1000 == setId);
            var endIndex = Array.FindLastIndex(GameData.Artifacts.Ids, id => id / 1000 == setId);

            // 限制星级输入范围
            NUDArtifactStars.Minimum = GameData.Artifacts.Ids[beginIndex] / 100 % 10;
            NUDArtifactStars.Maximum = GameData.Artifacts.Ids[endIndex] / 100 % 10;

            var parts = GameData.Artifacts.Names.Skip(beginIndex).Take(endIndex - beginIndex + 1).Distinct().ToArray();
            var i = CmbArtifactPart.SelectedIndex;
            CmbArtifactPart.Items.Clear();
            CmbArtifactPart.Items.AddRange(parts);
            if (i < parts.Length) // 重新选中
                CmbArtifactPart.SelectedIndex = i;

            ArtifactInputChanged(sender, e);
        }

        /// <summary>
        /// 圣遗物部件选中项改变时触发
        /// </summary>
        private void CmbArtifactPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbArtifactPart.SelectedIndex < 0)
            {
                LblArtifactName.Text = "";
                return;
            }
            var name = CmbArtifactPart.SelectedItem as string;
            var id = GameData.Artifacts.Ids[Array.IndexOf(GameData.Artifacts.Names, name)];
            var pardIndex = id / 10 % 10 - 1;
            if (pardIndex < ArtifactPartLabels?.Length)
                LblArtifactName.Text = ArtifactPartLabels[pardIndex];
            else
                LblArtifactName.Text = "";
            ArtifactInputChanged(sender, e);
        }

        /// <summary>
        /// 圣遗物页面输入改变时调用
        /// </summary>
        private void ArtifactInputChanged(object sender, EventArgs e)
        {
            // 圣遗物ID五位数，ABCDE，其中AB是圣遗物类型（魔女/水/风套......）
            // C是星级（5就是五星），D是圣遗物部位，E是初始词条数量
            if (CmbArtifactSet.SelectedIndex < 0 || CmbArtifactPart.SelectedIndex < 0)
                return;
            //var setId = GameData.ArtifactCats.Ids[CmbArtifactSet.SelectedIndex];
            //var part = CmbArtifactPart.SelectedIndex+1;
            //var index = Array.FindLastIndex(
            //    GameData.Artifacts.Ids,
            //    it =>  it / 1000     == setId // 套装ID
            //        //&& it / 100 % 10 == NUDArtifactStars.Value // 星级
            //        && it / 10 % 10  == part // 部位
            //    );
            var name = CmbArtifactPart.SelectedItem as string;
            var id = GameData.Artifacts.Ids[Array.LastIndexOf(GameData.Artifacts.Names, name)];
            id = id / 1000 * 1000 + (int)NUDArtifactStars.Value * 100 + id % 100;
            if (CmbMainAttribution.SelectedIndex < 0)
            {
                if (CommandVersion.Check(CommandVersion.V1_2_2))
                    SetCommand("/give", $"{id} lv{NUDArtifactLevel.Value}");
                else
                    SetCommand("/giveart", $"{id} {NUDArtifactLevel.Value}");
            }
            else
            {
                var t = CmbMainAttribution.SelectedItem as string;
                var mainAttr = ItemMap.ToId(t);

                var subAttrs = "";
                if (ListSubAttributionChecked.Items.Count > 0)
                {
                    var subAttrDir = new Dictionary<int, int>(ListSubAttributionChecked.Items.Count);
                    foreach (string item in ListSubAttributionChecked.Items)
                    {
                        var subId = ItemMap.ToId(item);
                        var times = int.Parse(item.Substring(item.LastIndexOf('x') + 1));
                        if (subAttrDir.ContainsKey(subId))
                            subAttrDir[subId] += times;
                        else
                            subAttrDir[subId] = times;
                    }

                    foreach (var kv in subAttrDir)
                    {
                        if (kv.Value > 1)
                            subAttrs += $"{kv.Key},{kv.Value} ";
                        else
                            subAttrs += $"{kv.Key} ";
                    }
                }
                if (CommandVersion.Check(CommandVersion.V1_2_2))
                    SetCommand("/give", $"{id} lv{NUDArtifactLevel.Value} {mainAttr} {subAttrs}");
                else
                    SetCommand("/giveart", $"{id} {mainAttr} {subAttrs}{NUDArtifactLevel.Value}");
            }
        }

        /// <summary>
        /// 副词条下拉框选中项改变时触发
        /// </summary>
        private void CmbSubAttribution_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbSubAttributionValue.Items.Clear();
            if (CmbSubAttribution.SelectedIndex >= 0)
            {
                CmbSubAttributionValue.Items.AddRange(subAttrs[CmbSubAttribution.SelectedItem as string].Select(kv => kv.Value).ToArray());
                CmbSubAttributionValue.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 点击添加副词条按钮时触发
        /// </summary>
        private void BtnAddSubAttr_Click(object sender, EventArgs e)
        {
            if (CmbSubAttribution.SelectedIndex >= 0 && CmbSubAttributionValue.SelectedIndex >= 0)
            {
                var name = CmbSubAttribution.SelectedItem as string;
                var kv = subAttrs[name][CmbSubAttributionValue.SelectedIndex];
                ListSubAttributionChecked.Items.Add($"{kv.Key}:{name}{kv.Value} x{NUDSubAttributionTimes.Value}");
                ArtifactInputChanged(null, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 已添加的副词条列表选中项改变时触发
        /// </summary>
        private void ListSubAttributionChecked_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListSubAttributionChecked.SelectedIndex >= 0)
            {
                ListSubAttributionChecked.Items.RemoveAt(ListSubAttributionChecked.SelectedIndex);
                ListSubAttributionChecked.ClearSelected();
                ArtifactInputChanged(null, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 清除词条链接标签点击时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblClearSubAttrCheckedList_Click(object sender, EventArgs e)
        {
            CmbMainAttribution.SelectedIndex = -1;
            ListSubAttributionChecked.Items.Clear();
            ArtifactInputChanged(null, EventArgs.Empty);
        }

        /// <summary>
        /// 改变圣遗物等级输入范围（旧版本范围是1-21）
        /// </summary>
        private void ChangeTPArtifact()
        {
            if (CommandVersion.Check(CommandVersion.V1_2_2))
            {
                NUDArtifactLevel.Minimum = 0;
                NUDArtifactLevel.Maximum = 20;
            }
            else
            {
                NUDArtifactLevel.Minimum = 1;
                NUDArtifactLevel.Maximum = 21;
            }
            LblArtifactLevelTip.Text = $"[{NUDArtifactLevel.Minimum}-{NUDArtifactLevel.Maximum}]";
        }

        /// <summary>
        /// 点击CharacterBuilder链接标签时触发
        /// </summary>
        private void LnkCharacterBuilder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UIUtil.OpenURL("https://github.com/Penelopeep/CharacterBuilder");
        }

        private void ListSubAttributionChecked_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = ListSubAttributionChecked.Font.Height * 3 / 2;
        }
    }
}