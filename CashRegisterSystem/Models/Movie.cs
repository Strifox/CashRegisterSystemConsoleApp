namespace CashRegysterSystem.Models
{
    public class Movie
    {
        public double Price { get; set; }
        public double Discount { get; set; }

        /// <summary>
        /// Get discount for movies
        /// </summary>
        /// <param name="price"></param>
        /// <returns>Discounted price</returns>
        public static double MovieDiscount(double price, double discount)
        {
            return price * discount;
        }
    }
}