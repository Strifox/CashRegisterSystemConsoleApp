using System;

namespace CashRegysterSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            PriceHandler priceHandler = new PriceHandler();
            CustomerHandler customerHandler = new CustomerHandler();
            OrderHandler orderHandler = new OrderHandler();

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Tryck på knapp:\n[1] Lägg beställning\n[2] Visa alla kunder\nEscape för att avsluta programmet.");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        orderHandler.CreateOrder(customerHandler, priceHandler);
                        Console.Clear();
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        if (!customerHandler.IsListEmpty())
                        {
                            customerHandler.ShowCustomers();
                            customerHandler.GetCustomerInfo();
                        }
                        else
                            Console.WriteLine("Inga kunder existerar");
                        break;
                    case ConsoleKey.Escape:
                        isRunning = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Välj något av alternativen.");
                        break;
                }
            }
        }
    }
}
