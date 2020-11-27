using System;
using System.Globalization;
using AbstractClassesAndMethods.Entities;
using System.Collections.Generic;

namespace AbstractClassesAndMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TaxPayer> taxpayers = new List<TaxPayer>();

            Console.Write("Enter the number of tax payers: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"\nTax payer #{i}:");
                
                Console.Write("Individual or company (i/c)? ");
                char opt = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Anual income: ");
                double annualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                
                if(opt == 'i')
                {
                    Console.Write("Health expenditures: ");
                    double healthExpanses = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    taxpayers.Add(new Individual(name, annualIncome, healthExpanses));
                }
                else
                {
                    Console.Write("Number of employyes: ");
                    int employees = int.Parse(Console.ReadLine());
                    taxpayers.Add(new Company(name, annualIncome, employees));
                }
            }

            Console.WriteLine("\nTAXES PAID:");
            double totalTaxes = 0.0;
            foreach(TaxPayer taxpayer in taxpayers)
            {
                Console.WriteLine(taxpayer);
                totalTaxes += taxpayer.CalculateTax();
            }

            Console.Write($"\nTOTAL TAXES: $ {totalTaxes.ToString("F2", CultureInfo.InvariantCulture)}");
        }
    }
}
