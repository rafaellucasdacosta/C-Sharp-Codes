using System;
using System.Globalization;
using ContractProcessing.Entities;
using ContractProcessing.Services;

namespace ContractProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter contract data");
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Date (dd/MM/yyyy): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Contract value: ");
            double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter number of installments: ");
            int installments = int.Parse(Console.ReadLine());

            Contract contract = new Contract(number, date, value);

            ContractService payPal = new ContractService(new PaypalService());

            payPal.ProcessContract(contract, installments);

            Console.WriteLine("Installments: ");
            foreach(Installment i in contract.installments)
            {
                Console.WriteLine(i);
            }
        }
    }
}
