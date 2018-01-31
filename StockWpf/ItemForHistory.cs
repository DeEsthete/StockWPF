using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockWpf
{
    public class ItemForHistory
    {
        public Item Item { get; set; }
        public DateTime Date { get; set; }
        public int ChangeInQuantity { get; set; }

        public ItemForHistory()
        {

        }

        public ItemForHistory(Item item, DateTime date, int changeInQuantity)
        {
            Item = item;
            Date = date;
            ChangeInQuantity = changeInQuantity;
        }

        public override string ToString()
        {
            return (Item.Name + " " + ChangeInQuantity + " " + " - " + Date);
        }
    }
}
