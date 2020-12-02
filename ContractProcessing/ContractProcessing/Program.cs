using System;
using System.Globalization;
using ContractProcessing.Entities;
using ContractProcessing.Services;
using ContractProcessing.Exceptions;

namespace ContractProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            try
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

                ContractService paypal = new ContractService(new PaypalService());

                paypal.ProcessContract(contract, installments);

                Console.WriteLine("Installments: ");
                foreach (Installment i in contract.Installments)
                {
                    Console.WriteLine(i);
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("Error in formact: " + e.Message);
            }
            catch(DomainException e)
            {
                Console.WriteLine("Error in contract: " + e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine("Unexpected error: " + e.Message);
            }

        }
    }
}
