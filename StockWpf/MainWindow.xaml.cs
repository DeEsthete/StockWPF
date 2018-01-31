using System;
using System.Collections.Generic;
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

namespace StockWpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Item> items;
        private List<ItemForHistory> itemForHistory;
        public MainWindow()
        {
            InitializeComponent();
            items = new List<Item>();
        }

        public MainWindow(List<Item> items, List<ItemForHistory> itemForHistory)
        {
            InitializeComponent();
            this.itemForHistory = itemForHistory;
            this.items = items;
            foreach (Item i in this.items)
            {
                stockListBox.Items.Add(i.ToString());
            }
        }

        private void NewOperationButtonClick(object sender, RoutedEventArgs e)
        {
            new OperationWindow(mainWindow ,items, itemForHistory).Show();
            mainWindow.Close();
        }

        private void HistoryButtonClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
