using System;
using System.Globalization;
using Exceptions.Entities;
using Exceptions.Entities.Exceptions;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account();
            try
            {
                Console.WriteLine("Enter account data");

                Console.Write("\nNumber: ");
                int number = int.Parse(Console.ReadLine());

                Console.Write("Holder: ");
                string holder = Console.ReadLine();

                Console.Write("Inicial balance: ");
                double initialBalance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Withdraw limit: ");
                double withdrawLimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                account = new Account(number, holder, initialBalance, withdrawLimit);

                Console.Write("\nEnter amount for withdraw: ");
                double amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                account.Withdraw(amount);
                Console.WriteLine(account);
            }
            catch (DomainException e)
            {
                Console.WriteLine("Withdraw error: " + e.Message);
            }
        }
    }
}
