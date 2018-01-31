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
    /// Логика взаимодействия для OperationWindow.xaml
    /// </summary>
    public partial class OperationWindow : Window
    {
        private List<Item> items;
        private List<ItemForHistory> itemForHistory;
        private Window window;
        public OperationWindow(Window window ,List<Item> items, List<ItemForHistory> itemForHistory)
        {
            InitializeComponent();

            this.window = window;
            this.items = items;
            this.itemForHistory = itemForHistory;

            operationComboBox.Items.Add("Поступление");
            operationComboBox.Items.Add("Убывание");

            
            operationWindow.Closed += OperationWindowClosed;

        }

        private void OperationWindowClosed(object sender, EventArgs e)
        {
            new MainWindow(items, itemForHistory).Show();
        }

        private void FinishButtonClick(object sender, RoutedEventArgs e)
        {
            if (operationComboBox.SelectedIndex == 0)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    int countTemp = 0;
                    if (items[i].Name == nameItemTextBox.Text)
                    {
                        try
                        {
                            int.TryParse(countTextBox.Text, out countTemp);
                        }
                        catch
                        {
                            MessageBox.Show("Поле 'Кол-во' должно содержать только цифры");
                        }
                        items[i].Count += countTemp;
                        ItemForHistory temp = new ItemForHistory(items[i], DateTime.Now, countTemp);
                        itemForHistory.Add(temp);
                    }
                    else
                    {
                        Item temp = new Item(Guid.NewGuid(), nameItemTextBox.Text, countTemp);
                        items.Add(temp);
                    }
                }
            }
            else if (operationComboBox.SelectedIndex == 1)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    int countTemp = 0;
                    if (items[i].Name == nameItemTextBox.Text)
                    {
                        try
                        {
                            int.TryParse(countTextBox.Text, out countTemp);
                        }
                        catch
                        {
                            MessageBox.Show("Поле 'Кол-во' должно содержать только цифры");
                        }
                        items[i].Count -= countTemp;
                        ItemForHistory temp = new ItemForHistory(items[i], DateTime.Now, (countTemp - (countTemp *2)));
                        itemForHistory.Add(temp);
                    }
                    else
                    {
                        Item temp = new Item(Guid.NewGuid(), nameItemTextBox.Text, (countTemp - (countTemp * 2)));
                        items.Add(temp);
                    }
                }
            }
            operationWindow.Close();
        }
    }
}
