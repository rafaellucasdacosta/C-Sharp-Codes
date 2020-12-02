using System;
using System.Globalization;
using Interface_CarRental.Entities;
using Interface_CarRental.Services;
using Interface_CarRental.Exceptions;

namespace Interface_CarRental
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter rental data");
                Console.Write("Car model: ");
                string model = Console.ReadLine();

                Console.Write("Pickup (dd/MM/yyyy hh:mm): ");
                DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                Console.Write("Return (dd/MM/yyyy hh:mm): ");
                DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                Console.Write("Enter price per hour: ");
                double hour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Enter price per day: ");
                double day = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                CarRental carRental = new CarRental(start, finish, new Vehicle(model));

                RentalService rentalService = new RentalService(hour, day, new BrazilTaxService());

                rentalService.ProcessInvoice(carRental);

                Console.WriteLine("INVOICE: ");
                Console.WriteLine(carRental.Invoice);
            }
            catch(System.FormatException e)
            {
                Console.WriteLine("Error in format: " + e.Message);
            }
            catch(DomainException e)
            {
                Console.WriteLine("Error in car rental: " + e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine("Unexpected error: " + e.Message);
            }
        }
    }
}
