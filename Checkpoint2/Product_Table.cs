using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkpoint2
{
    internal class Product_Table
    {
        public Product_Table()
        {
            products = new List<Product>();
        }

        public bool Add_Product(string fail_check)
        {
            Console.Write("Enter a Category: ");
            string category = Console.ReadLine() ?? "";

            if(category.Trim().ToLower() == fail_check.ToLower())
            {
                return false;
            }

            Console.Write("Enter a Product Name: ");
            string name = Console.ReadLine() ?? "";

            if (name.Trim().ToLower() == fail_check.ToLower())
            {
                return false;
            }

            Console.Write("Enter a Price: ");
            string price = Console.ReadLine() ?? "";

            if (price.Trim().ToLower() == fail_check.ToLower())
            {
                return false;
            }

            // fail checks passed, add product
            products.Add(new Product(category, name, price));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The product was successfully added!");
            Console.ResetColor();

            return true;
        }

        public void Display()
        {
            List<Product> ordered_list = products.OrderBy(p => p.Price).ToList();

            Console.WriteLine("--------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Category".PadRight(20) + "Product".PadRight(20) + "Price");
            Console.ResetColor();

            foreach (Product product in ordered_list)
            {
                Console.WriteLine(product.Category.PadRight(20) + product.Name.PadRight(20) + product.Price);
            }

            int price_sum = ordered_list.Sum(p => int.Parse(p.Price));
            Console.WriteLine("\n"+"Total amount:".PadRight(40) + price_sum.ToString());
            Console.WriteLine("--------------------------------------------------");
        }

        private List<Product> products;
    }
}
