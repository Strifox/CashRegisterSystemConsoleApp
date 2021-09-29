using CashRegysterSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegysterSystem
{
    public class OrderHandler
    {
        internal void CreateOrder(CustomerHandler customerHandler, PriceHandler priceHandler)
        {
            Customer customer = customerHandler.CreateCustomer();
            customer.TotalPrice = priceHandler.CalculateTotalPrice(customer);
            customerHandler.customers.Add(customer);
        }

    }
}
