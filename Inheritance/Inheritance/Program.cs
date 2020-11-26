using System;
using System.Globalization;
using Inheritance.Entities;
using System.Collections.Generic;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();

            Console.Write("Enter the number of products:");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"\nProduct #{i} data: ");
                Console.Write("\nCommon, used or imported (c/u/i)? ");
                char opt = char.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string prodName = Console.ReadLine();
                Console.Write("Price: ");
                double prodPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (opt == 'c')
                {
                    products.Add(new Product(prodName, prodPrice));
                }
                else if (opt == 'u')
                {
                    Console.Write("Manufacture date: ");
                    DateTime manufacture = DateTime.Parse(Console.ReadLine());
                    products.Add(new UsedProduct(prodName, prodPrice, manufacture));
                }
                else if (opt == 'i')
                {
                    Console.Write("Customs fee: ");
                    double customsFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    products.Add(new ImportedProduct(prodName, prodPrice, customsFee));
                }
            }

            Console.WriteLine("\nPRICE TAGS:");
            foreach (Product prod in products)
            {
                Console.WriteLine(prod.PriceTag());
            }
        }
    }
}
