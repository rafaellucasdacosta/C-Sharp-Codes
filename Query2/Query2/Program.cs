using System;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Query2.Entities;

namespace Query2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();
            try
            {
                using(StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] fields = sr.ReadLine().Split(",");
                        string name = fields[0];
                        string email = fields[1];
                        double salary = double.Parse(fields[2], CultureInfo.InvariantCulture);

                        employees.Add(new Employee(name, email, salary));
                    }
                }

                Console.Write("Enter salary: ");
                double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.WriteLine($"Email of people whose salary is more than {value.ToString("F2", CultureInfo.InvariantCulture)}");

                var emails = employees.Where(p => p.Salary > value).OrderBy(p => p.Email).Select(p => p.Email);

                foreach(string email in emails)
                {
                    Console.WriteLine(email);
                }

                var sum = employees.Where(p => p.Name[0] == 'M').Select(p => p.Salary).Sum();

                Console.WriteLine("Sum of salary of people whose name starts with 'M': " + sum.ToString("F2", CultureInfo.InvariantCulture));
                

            }catch(IOException e)
            {
                Console.WriteLine("File error: " + e.Message);
            }
        }
    }
}
