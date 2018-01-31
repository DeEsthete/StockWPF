using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockWpf
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }

        public Item()
        {

        }

        public Item(Guid id, string name, int count)
        {
            Id = id;
            Name = name;
            Count = count;
        }

        public override string ToString()
        {
            return (Name + " - " + Count);
        }
    }
}
