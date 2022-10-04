using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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

namespace GrasscutterTools.Pages
{
    /// <summary>
    /// PageGive.xaml 的交互逻辑
    /// </summary>
    public partial class PageGive : Page, IPageListProvider, IPageCommand
    {
        public PageGive()
        {
            InitializeComponent();

            ListSource = new GameItems(Properties.Resources.Items);
            Categories = ListSource.Select(it => it.Category).Distinct().ToArray();
            OnCommandGenerated("");
        }

        public GameItems ListSource { get; private set; }

        public bool CanGroup => true;

        public string[] Categories { get; private set; }

        public event EventHandler<CommandGeneratedEventArgs> CommandGenerated;
        private void OnCommandGenerated(string command)
            => CommandGenerated?.Invoke(this, new CommandGeneratedEventArgs(command));

        public void OnListItemSelected(GameItem item)
        {
            //LblTest.Content = item;
        }
    }
}
