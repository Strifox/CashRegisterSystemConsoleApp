using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegysterSystem.Models
{
    public class BluRayMovie : Movie
    {
        public static new double Discount { get; set; } = 0.85;
        public static new double Price { get; set; } = 39;
    }
}
