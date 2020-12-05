using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Querys.Entities;
using System.Globalization;

namespace Querys
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();
            List<Product> products = new List<Product>();            
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] fields = sr.ReadLine().Split(",");
                        string name = fields[0];
                        double price = double.Parse(fields[1], CultureInfo.InvariantCulture);

                        products.Add(new Product(name, price));
                    }
                }

                var avg = products.Select(p => p.Price).DefaultIfEmpty(0.0).Average();
                Console.WriteLine("Average price = " + avg.ToString("F2", CultureInfo.InvariantCulture));

                var names = products.Where(p => p.Price < avg).OrderByDescending(p => p.Name).Select(p => p.Name);

                foreach(string name in names)
                {
                    Console.WriteLine(name);
                }
                
            }catch(IOException e)
            {
                Console.WriteLine("File error: " + e.Message);
            }
        }
    }
}
