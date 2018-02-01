using System;
using System.Collections.Generic;
using System.IO;
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
        private string pathStock;
        private string pathHistory;

        #region ctor
        public MainWindow()
        {
            InitializeComponent();
            items = new List<Item>();
            itemForHistory = new List<ItemForHistory>();

            mainWindow.Closed += MainWindowClosed;
            FileReader();
            foreach (Item i in this.items)
            {
                stockListBox.Items.Add(i);
            }
        }

        public MainWindow(List<Item> items, List<ItemForHistory> itemForHistory)
        {
            InitializeComponent();
            mainWindow.Closed += MainWindowClosed;
            this.itemForHistory = itemForHistory;
            this.items = items;
            foreach (Item i in this.items)
            {
                stockListBox.Items.Add(i);
            }
        }

        private void MainWindowClosed(object sender, EventArgs e)
        {
            FileWriter();
        }
        #endregion

        #region Button
        private void NewOperationButtonClick(object sender, RoutedEventArgs e)
        {
            new OperationWindow(mainWindow ,items, itemForHistory).Show();
            mainWindow.Close();
        }

        private void HistoryButtonClick(object sender, RoutedEventArgs e)
        {
            new HistoryWindow(mainWindow, items , itemForHistory).Show();
            mainWindow.Close();
        }
        #endregion

        #region File
        private void FileWriter()
        {
            pathStock = Directory.GetCurrentDirectory() + "/stock.txt";
            pathHistory = Directory.GetCurrentDirectory() + "/history.txt";

            using (BinaryWriter writer = new BinaryWriter(File.Open(pathStock, FileMode.Open)))
            {
                for (int i = 0; i < items.Count; i++)
                {
                    writer.Write(items[i].Name);
                    writer.Write(items[i].Count);
                }
                //foreach (Item s in items)
                //{
                //    writer.Write(s.Name);
                //    writer.Write(s.Count);
                //}
            }
            using (BinaryWriter writer = new BinaryWriter(File.Open(pathHistory, FileMode.Open)))
            {
                //foreach (ItemForHistory s in itemForHistory)
                //{
                //    writer.Write(s.Item.Name);
                //    writer.Write(s.Item.Count);

                //    writer.Write(s.Date.Year);
                //    writer.Write(s.Date.Month);
                //    writer.Write(s.Date.Day);
                //    writer.Write(s.Date.Hour);
                //    writer.Write(s.Date.Minute);
                //    writer.Write(s.Date.Second);

                //    writer.Write(s.ChangeInQuantity);
                //}

                for (int i = 0; i < itemForHistory.Count; i++)
                {
                    writer.Write(itemForHistory[i].Item.Name);
                    writer.Write(itemForHistory[i].Item.Count);

                    writer.Write(itemForHistory[i].Date.Year);
                    writer.Write(itemForHistory[i].Date.Month);
                    writer.Write(itemForHistory[i].Date.Day);
                    writer.Write(itemForHistory[i].Date.Hour);
                    writer.Write(itemForHistory[i].Date.Minute);
                    writer.Write(itemForHistory[i].Date.Second);

                    writer.Write(itemForHistory[i].ChangeInQuantity);
                }
            }
        }

        private void FileReader()
        {
            pathStock = Directory.GetCurrentDirectory() + "/stock.txt";
            pathHistory = Directory.GetCurrentDirectory() + "/history.txt";

            using (BinaryReader reader = new BinaryReader(File.Open(pathStock, FileMode.OpenOrCreate)))
            {
                while (reader.PeekChar() > -1)
                {
                    Item tempItem = new Item();
                    tempItem.Name = reader.ReadString();
                    tempItem.Count = reader.ReadInt32();

                    items.Add(tempItem);
                }
            }
            using (BinaryReader reader = new BinaryReader(File.Open(pathHistory, FileMode.OpenOrCreate)))
            {
                while (reader.PeekChar() > -1)
                {
                    Item tempItem = new Item();
                    tempItem.Name = reader.ReadString();
                    tempItem.Count = reader.ReadInt32();

                    ItemForHistory tempHistory = new ItemForHistory();
                    tempHistory.Item = tempItem;

                    int tempYear = reader.ReadInt32();
                    int tempMonth = reader.ReadInt32();
                    int tempDay = reader.ReadInt32();
                    int tempHour = reader.ReadInt32();
                    int tempMinute = reader.ReadInt32();
                    int tempSecond = reader.ReadInt32();
                    DateTime tempDate = new DateTime(tempYear, tempMonth, tempDay, tempHour, tempMinute, tempSecond);
                    tempHistory.Date = tempDate;

                    tempHistory.ChangeInQuantity = reader.ReadInt32();

                    itemForHistory.Add(tempHistory);
                }
            }
        }
        #endregion

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            FileWriter();
        }
    }
}
