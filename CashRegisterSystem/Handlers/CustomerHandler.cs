﻿using CashRegysterSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegysterSystem
{
    public class CustomerHandler
    {
        internal readonly List<Customer> customers = new List<Customer>();

        internal Customer CreateCustomer()
        {
            Console.WriteLine("Kundnamn:");
            string name = Console.ReadLine();

            bool membership = IsMember();

            Console.WriteLine("\n\nAntal dvd filmer att hyra:");
            int dvdMoviesRented = GetInputNumber();

            Console.WriteLine("\n\nAntal blu-ray filmer att hyra");
            int bluRayMoviesRented = GetInputNumber();

            return new Customer
            {
                Name = name,
                Membership = membership,
                DvdMoviesRented = dvdMoviesRented,
                BluRayMoviesRented = bluRayMoviesRented
            };
        }

        internal void GetCustomerInfo()
        {
            while (true)
            {
                Console.WriteLine("\nSkriv in kundnamn:");
                if (IsCustomerMatched(Console.ReadLine()))
                    break;

                Console.WriteLine("Fel kundnamn!");
            }
        }

        private bool IsCustomerMatched(string customerName)
        {
            foreach (var customer in customers)
            {
                if (customerName == customer.Name)
                {
                    string membership;

                    if (customer.Membership)
                        membership = "Ja";
                    else
                        membership = "Nej";

                    Console.Clear();
                    Console.WriteLine($"Kund: {customer.Name}" +
                        $"\nMedlem: {membership}" +
                        $"\nAntal hyrda dvd filmer: {customer.DvdMoviesRented}" +
                        $"\nAntal hyrda blu-ray filmer: {customer.BluRayMoviesRented}" +
                        $"\nTotal kostnad: {customer.TotalPrice} kr\n\n");
                    return true;
                }
            }
            return false;
        }

        internal bool IsListEmpty()
        {
            if (customers.Count == 0)
                return true;

            return false;
        }

        internal void ShowCustomers()
        {
            Console.WriteLine("Kunder:");
            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.Name}");
            }
        }

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
