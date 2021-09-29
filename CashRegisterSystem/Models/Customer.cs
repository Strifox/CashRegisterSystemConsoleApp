using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegysterSystem.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public bool Membership { get; set; }
        public int DvdMoviesRented { get; set; }
        public int BluRayMoviesRented { get; set; }
        public double TotalPrice { get; set; }
    }
}
