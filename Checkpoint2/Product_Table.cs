using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
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

        /**
         * Helps with error handling for input
         * Set is_number to true to add check if input can be parsed to int
         * Returns false if any check fails 
         */
        private bool Input_Check(string input, bool is_number = false)
        {
            if (input.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Input can't be empty!");
                Console.ResetColor();
                return false;
            }

            if (is_number && !int.TryParse(input, out _))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Input must be a number!");
                Console.ResetColor();
                return false;
            }

            return true;
        }

        public bool Add_Product(string fail_check)
        {
            string category = "";
            string name = "";
            string price = "";

            while (true)
            {
                Console.Write("Enter a Category: ");
                category = (Console.ReadLine() ?? "").Trim();

                if (category.ToLower() == fail_check.ToLower())
                {
                    return false;
                }
                
                if (Input_Check(category)) {
                    break;
                }
            }

            while (true)
            {
                Console.Write("Enter a Product Name: ");
                name = (Console.ReadLine() ?? "").Trim();

                if (name.ToLower() == fail_check.ToLower())
                {
                    return false;
                }

                if (Input_Check(name))
                {
                    // for search to work, product names must be unique
                    if (products.FindIndex(p => p.Name == name) != -1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("A product with that name already exists!");
                        Console.ResetColor();
                    }
                    else
                    {
                        break;
                    }
                }
            }

            while (true)
            {
                Console.Write("Enter a Price: ");
                price = (Console.ReadLine() ?? "").Trim();

                if (price.ToLower() == fail_check.ToLower())
                {
                    return false;
                }

                if (Input_Check(price, true))
                {
                    break;
                }
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

        public bool Search(string fail_check)
        {
            string name = "";

            while (true)
            {
                Console.Write("Enter a Product Name: ");
                name = Console.ReadLine() ?? "";

                if (name.Trim().ToLower() == fail_check.ToLower())
                {
                    return false;
                }

                if (Input_Check(name))
                {
                    break;
                }
            }

            List<Product> ordered_list = products.OrderBy(p => p.Price).ToList();
            int search_ind = ordered_list.FindIndex(p => p.Name == name);

            if (search_ind == -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No product with that name found!");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("--------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Category".PadRight(20) + "Product".PadRight(20) + "Price");
                Console.ResetColor();

                for(int i = 0; i < ordered_list.Count; i++)
                {
                    if(i == search_ind)
                    {
                        Console.ForegroundColor= ConsoleColor.Magenta;
                    }
                    Console.WriteLine(ordered_list[i].Category.PadRight(20) + ordered_list[i].Name.PadRight(20) + ordered_list[i].Price);
                    Console.ResetColor();
                }

                Console.WriteLine("--------------------------------------------------");
            }

            return true;
        }

        private List<Product> products;
    }
}
