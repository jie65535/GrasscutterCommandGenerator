using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using GrasscutterTools.Events;
using GrasscutterTools.Game;
using GrasscutterTools.Interfaces;
using GrasscutterTools.Models;
using GrasscutterTools.Pages;

namespace GrasscutterTools.Windows
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly double MinHeightDefault;

        #region - 属性 -

        /// <summary>
        /// 是否显示右侧列表栏
        /// </summary>
        private bool IsShowList
        {
            get => DockListBar.Visibility == Visibility.Visible;
            set => DockListBar.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <summary>
        /// 是否显示底部命令栏
        /// </summary>
        private bool IsShowCommand
        {
            get => GrpCommandBar.Visibility == Visibility.Visible;
            set => GrpCommandBar.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
        }

        #endregion

        #region - 构造与初始化 -

        /// <summary>
        /// 窗体构造函数
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            MinHeightDefault = MinHeight;

            //GameData.LoadResources();

            // 初始化菜单项选中事件
            foreach (RadioButton btn in SPMenu.Children)
            {
                btn.Checked += OnPageSelected;
            }
            // 默认选中首页
            RadHome.IsChecked = true;

        }

        #endregion

        #region - 导航 -

        /// <summary>
        /// 页面导航选中时触发
        /// </summary>
        private void OnPageSelected(object sender, RoutedEventArgs e)
        {
            var btn = sender as RadioButton;
            if (btn.Tag != null)
            {
                ShowPage(btn.Tag as Page);
                return;
            }

            // 创建页面
            Page page = null;

            // 首页
            if (btn == RadHome)
            {
                page = new PageHome();
            }
            else if (btn == RadCustom)
            {

            }
            else if (btn == RadArtifact)
            {

            }
            else if (btn == RadGive)
            {
                page = new PageGive();
            }
            else if (btn == RadSpawn)
            {

            }
            else if (btn == RadQuests)
            {

            }
            else if (btn == RadStats)
            {

            }
            else if (btn == RadTools)
            {
                page = new PageTools();
            }
            else if (btn == RadScenes)
            {

            }
            else if (btn == RadManage)
            {

            }
            else if (btn == RadOpenCommand)
            {

            }
            else if (btn == RadAbout)
            {

            }
            else if (btn == RadSettings)
            {

            }
            else
            {
                // TODO
            }


            if (page is IPageCommand t)
                t.CommandGenerated += OnCommandGenerated;
            if (page != null)
            {
                btn.Tag = page;
                ShowPage(page);
            }
        }

        /// <summary>
        /// 显示页面
        /// </summary>
        /// <param name="page">页面</param>
        private void ShowPage(Page page)
        {
            IsShowCommand = page is IPageCommand;

            if (page is IPageListProvider provider)
            {
                ListView = new ListCollectionView(provider.ListSource);
                
                // 清理分类
                if (SPCategories.Children.Count > 1)
                    SPCategories.Children.RemoveRange(1, SPCategories.Children.Count-1);
                // 默认选中全部
                ChkAllCategory.IsChecked = true;

                // 判断是否包含分类
                if (provider.CanGroup)
                {
                    // 显示分类按钮
                    BtnCategory.Visibility = Visibility.Visible;
                    foreach (var category in provider.Categories)
                    {
                        // 添加类别复选框
                        var chkCategory = new CheckBox
                        {
                            IsChecked = true,
                            Content = category,
                            Margin = new Thickness(0, 4, 0, 0),
                        };
                        chkCategory.Checked += OnCategoryChecked;
                        chkCategory.Unchecked += OnCategoryUnchecked;
                        SPCategories.Children.Add(chkCategory);
                    }
                }
                else
                {
                    BtnCategory.Visibility = Visibility.Collapsed;
                }

                ListView.Filter += OnListFilter;
                //cvsList.GroupDescriptions.Add(new PropertyGroupDescription("Category"));
                ListShared.ItemsSource = ListView;
                IsShowList = true;
            }
            else
            {
                IsShowList = false;
            }

            FrameContent.Content = page;
        }

        #endregion

        #region - 列表 -

        /// <summary>
        /// 列表视图，用于过滤
        /// </summary>
        ListCollectionView ListView;


        /// <summary>
        /// 列表选中项改变时触发
        /// </summary>
        private void OnListItemSelected(object sender, SelectionChangedEventArgs e)
        {
            if (ListShared.SelectedItem != null && FrameContent.Content is IPageListProvider page)
                page.OnListItemSelected(ListShared.SelectedItem as GameItem);
        }

        /// <summary>
        /// 列表过滤器
        /// </summary>
        private bool OnListFilter(object e)
        {
            if (ChkAllCategory.IsChecked != true && SPCategories.Children.Count > 1)
            {
                var item = e as GameItem;
                for (int i = 1; i < SPCategories.Children.Count; i++)
                {
                    var chk = SPCategories.Children[i] as CheckBox;
                    if ((string)chk.Content == item.Category)
                    {
                        if (chk.IsChecked == true)
                            break;
                        else
                            return false;
                    }
                }
            }

            if (string.IsNullOrEmpty(TxtSearch.Text))
                return true;
            else
                return e.ToString().IndexOf(TxtSearch.Text, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        #region -- 分类 --

        private void BtnCategory_Click(object sender, RoutedEventArgs e)
        {
            MenuCategories.IsOpen = true;
        }

        private bool IsInternalChanges = false;

        /// <summary>
        /// 全选类别勾选时触发
        /// </summary>
        private void ChkAllCategory_Checked(object sender, RoutedEventArgs e)
        {
            CheckAll(true);
        }

        /// <summary>
        /// 全选类别取消勾选时触发
        /// </summary>
        private void ChkAllCategory_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckAll(false);
        }

        private void CheckAll(bool isChecked)
        {
            IsInternalChanges = true;

            foreach (CheckBox chk in SPCategories.Children)
                chk.IsChecked = isChecked;

            IsInternalChanges = false;
            ListView.Refresh();
        }

        private void OnCategoryChecked(object sender, RoutedEventArgs e)
        {
            if (!IsInternalChanges) ListView.Refresh();
        }

        private void OnCategoryUnchecked(object sender, RoutedEventArgs e)
        {
            if (!IsInternalChanges) ListView.Refresh();
        }
        #endregion

        #region -- 搜索 --


        /// <summary>
        /// 搜索框文本改变时触发
        /// </summary>
        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListView.Refresh();
            if (string.IsNullOrEmpty(TxtSearch.Text))
                BtnClearFilter.Visibility = Visibility.Hidden;
            else
                BtnClearFilter.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// 清除搜索框文本按钮点击时触发
        /// </summary>
        private void BtnClearFilter_Click(object sender, RoutedEventArgs e)
        {
            TxtSearch.Clear();
        }

        #endregion

        #endregion

        #region - 命令 -

        /// <summary>
        /// 运行命令时触发
        /// </summary>
        private void BtnRun_Click(object sender, RoutedEventArgs e)
        {
            // 测试展开运行记录
            MinHeight = MinHeightDefault + TxtCommandLog.Height;
            TxtCommandLog.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// 命令生成时触发
        /// </summary>
        private void OnCommandGenerated(object sender, CommandGeneratedEventArgs e)
        {
            TxtCommand.Text = e.Command;
            // TODO
        }

        #endregion

    }
}
