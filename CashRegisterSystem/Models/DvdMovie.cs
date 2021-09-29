using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegysterSystem.Models
{
    public class DvdMovie : Movie
    {
        public static new double Price { get; set; } = 29;
        public static new double Discount { get; set; } = 0.90;
    }
}
