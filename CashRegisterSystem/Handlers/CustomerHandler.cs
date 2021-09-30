using CashRegysterSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashRegysterSystem
{
    public class CustomerHandler
    {
        internal readonly List<Customer> customers = new List<Customer>();
        private int id = 0;
        /// <summary>
        /// Creates customer
        /// </summary>
        /// <returns></returns>
        internal Customer CreateCustomer()
        {
            id++;

            Console.WriteLine("Kundnamn:");
            string name = Console.ReadLine();

            bool membership = IsMember();

            Console.WriteLine("\n\nAntal dvd filmer att hyra:");
            int dvdMoviesRented = GetInputNumber();

            Console.WriteLine("\n\nAntal blu-ray filmer att hyra");
            int bluRayMoviesRented = GetInputNumber();

            return new Customer
            {
                Id = id, 
                Name = name,
                Membership = membership,
                DvdMoviesRented = dvdMoviesRented,
                BluRayMoviesRented = bluRayMoviesRented
            };
        }

        /// <summary>
        /// Checks and writes customer info to console if customer exists
        /// </summary>
        internal void GetCustomerInfo()
        {
            while (true)
            {
                Console.WriteLine("\nSkriv in kund id:");
                if (IsCustomerExisting(GetInputNumber()))
                    break;

                Console.WriteLine("Fel id!");
            }
        }

        /// <summary>
        /// Checks if customer exists
        /// </summary>
        /// <param name="name"></param>
        /// <returns>True if exists</returns>
        private bool IsCustomerExisting(int id)
        {
            foreach (var customer in customers)
            {
                if (id == customer.Id)
                {
                    string membership;

                    if (customer.Membership)
                        membership = "Ja";
                    else
                        membership = "Nej";

                    Console.Clear();
                    Console.WriteLine($"Id: {customer.Id}" +
                        $"Kund: {customer.Name}" +
                        $"\nMedlem: {membership}" +
                        $"\nAntal hyrda dvd filmer: {customer.DvdMoviesRented}" +
                        $"\nAntal hyrda blu-ray filmer: {customer.BluRayMoviesRented}" +
                        $"\nTotal kostnad: {customer.TotalPrice} kr\n\n");
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if customer list is empty
        /// </summary>
        /// <returns>Returns true if not empty</returns>
        internal bool IsListEmpty()
        {
            if (customers.Count == 0)
                return true;

            return false;
        }

        /// <summary>
        /// Writes all existing customers and amount of movies rented
        /// </summary>
        internal void ShowCustomers()
        {
            Console.WriteLine("Kunder:");
            foreach (var customer in customers)
            {
                Console.WriteLine($"Id:{customer.Id}\t{customer.Name}\n - Hyrda filmer: {customer.BluRayMoviesRented + customer.DvdMoviesRented}\n");
            }
        }

        /// <summary>
        /// Gets user input and tries parsing to integer
        /// </summary>
        /// <returns>Integer</returns>
        private static int GetInputNumber()
        {
            int userInput = 0;
            bool isNumber = false;

            while (!isNumber)
            {
                isNumber = int.TryParse(Console.ReadLine(), out userInput);
            }

            return userInput;
        }

        /// <summary>
        /// Checks if customer is member or not
        /// </summary>
        /// <returns>True if member</returns>
        private static bool IsMember()
        {
            Console.WriteLine("\nMedlem\nTryck på:\n[1] Ja\n[2] Nej");
            while (true)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        return true;
                    case ConsoleKey.D2:
                        return false;
                    default:
                        Console.WriteLine("\nTryck på:\n[1] Ja\n[2] Nej");
                        break;
                }
            }
        }
    }
}
