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
using System.IO;
using System.Windows.Forms;

using GrasscutterTools.Game;
using GrasscutterTools.Properties;
using GrasscutterTools.Utils;

namespace GrasscutterTools.Pages
{
    internal partial class PageWeather : BasePage
    {
        public override string Text => Resources.PageWeatherTitle;

        public PageWeather()
        {
            InitializeComponent();
        }

        public override void OnLoad()
        {
            CmbClimateType.Items.Clear();
            CmbClimateType.Items.AddRange(Resources.ClimateType.Split(','));

            LoadWeathers(GameData.Weathers);
        }

        /// <summary>
        /// 气候类型列表
        /// </summary>
        private static readonly string[] climateTypes = { "none", "sunny", "cloudy", "rain", "thunderstorm", "snow", "mist" };

        /// <summary>
        /// 气候类型下拉框选中项改变时触发
        /// </summary>
        private void CmbClimateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbClimateType.SelectedIndex < 0)
                return;
            if (CommandVersion.Check(CommandVersion.V1_2_2))
                SetCommand("/weather", CmbClimateType.SelectedIndex < climateTypes.Length ? climateTypes[CmbClimateType.SelectedIndex] : "none");
            else
                SetCommand("/weather", $"0 {CmbClimateType.SelectedIndex}");
        }

        /// <summary>
        /// 锁定天气
        /// </summary>
        private void BtnLockWeather_Click(object sender, EventArgs e)
        {
            SetCommand("/prop", $"is_weather_locked {((Button)sender).Tag}");
        }

        private ItemMapGroup weatherSources;
        /// <summary>
        /// 加载天气
        /// </summary>
        private void LoadWeathers(ItemMapGroup weathers)
        {
            weatherSources = weathers;

            TvSceneWeathers.BeginUpdate();
            TvSceneWeathers.Nodes.Clear();

            foreach (var weather in weathers)
            {
                // 将场景作为标签分类
                var sceneName = int.TryParse(weather.Key, out var sceneId)
                    ? GameData.Scenes[sceneId]
                    : weather.Key;
                var node = TvSceneWeathers.Nodes.Add(weather.Key, sceneName);

                // 添加所有标签
                var weatherName = weather.Value;
                for (var i = 0; i < weatherName.Count; i++)
                    node.Nodes.Add(weatherName.Ids[i].ToString(), weatherName.Lines[i]);
            }
            TvSceneWeathers.EndUpdate();
        }

        /// <summary>
        /// 选中项改变时触发
        /// </summary>
        private void TvSceneWeathers_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // 忽略未知操作
            if (e.Action == TreeViewAction.Unknown || !e.Node.IsSelected)
                return;

            // 忽略根节点
            if (e.Node.Level == 0)
                return;

            // 生成命令
            SetCommand("/weather", e.Node.Name);
        }

        /// <summary>
        /// 天气过滤栏文本更改时触发
        /// </summary>
        private void TxtWeatherFilter_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtWeatherFilter.Text))
            {
                LblClearFilter.Visible = false;
                ListFilteredWeathers.Visible = false;
                ListFilteredWeathers.Items.Clear();
            }
            else
            {
                UIUtil.ListBoxFilter(ListFilteredWeathers, weatherSources.Lines, TxtWeatherFilter.Text);
                ListFilteredWeathers.Visible = true;
                LblClearFilter.Visible = true;
            }
        }

        /// <summary>
        /// 点击清空过滤框标签时触发
        /// </summary>
        private void LblClearFilter_Click(object sender, EventArgs e)
        {
            TxtWeatherFilter.Clear();
        }

        /// <summary>
        /// 过滤的天气中选中项改变事件
        /// </summary>
        private void ListFilteredWeathers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (string)ListFilteredWeathers.SelectedItem;
            // 生成命令
            SetCommand("/weather", item.Substring(0, item.IndexOf(':')).Trim());
        }

        /// <summary>
        /// 点击获取当前天气命令时触发
        /// </summary>
        private void LnkCheckWeather_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetCommand("/weather");
        }
    }
}