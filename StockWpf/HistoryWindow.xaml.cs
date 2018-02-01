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
using System.Windows.Shapes;

namespace StockWpf
{
    /// <summary>
    /// Логика взаимодействия для HistoryWindow.xaml
    /// </summary>
    public partial class HistoryWindow : Window
    {
        private List<Item> items;
        private List<ItemForHistory> itemForHistory;
        private Window window;
        public HistoryWindow(Window window , List<Item> items ,List<ItemForHistory> itemForHistory)
        {
            InitializeComponent();

            this.items = items;
            this.itemForHistory = itemForHistory;
            this.window = window;

            historyWindow.Closed += HistoryWindowClosed;

            foreach (ItemForHistory i in itemForHistory)
            {
                historyListBox.Items.Add(i.ToString());
            }
        }

        private void HistoryWindowClosed(object sender, EventArgs e)
        {
            new MainWindow(items, itemForHistory).Show();
        }

        private void backButtonClick(object sender, RoutedEventArgs e)
        {
            historyWindow.Close();
        }
    }
}
