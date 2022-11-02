using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkpoint2
{
    internal class Product
    {
        public Product(string category, string name, string price)
        {
            Category = category;
            Name = name;
            Price = price;
        }

        public string Category { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }

    }
}
