using System;
using Course.Entities.Enums;
using Course.Entities;
using System.Globalization;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter cliente data:");

            Console.Write("Name: ");
            string clientName = Console.ReadLine();

            Console.Write("Email: ");
            string clientEmail = Console.ReadLine();

            Console.Write("Birth date (DD/MM/YYYY):");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Client client = new Client(clientName, clientEmail, birthDate);

            Console.WriteLine("\nEnter order data:");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Console.Write("\nHow many items to this order? ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Order order = new Order(DateTime.Now, status, client);
            OrderItem item = new OrderItem();

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter {i} item data: ");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();

                Console.Write("Product price: ");
                double productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture) ;

                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Product product = new Product(productName, productPrice);

                item = new OrderItem(quantity, productPrice, product);

                order.AddItem(item);
            }

            Console.WriteLine();
            Console.WriteLine("ORDER SUMMARY:");
            Console.WriteLine(order);
    }
    }
}
