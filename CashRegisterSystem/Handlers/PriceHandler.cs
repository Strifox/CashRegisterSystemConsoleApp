using CashRegysterSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashRegysterSystem
{
    public class PriceHandler
    {
        /// <summary>
        /// Calculates the price for the customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public double CalculateTotalPrice(Customer customer)
        {
            // Standard dvd prices
            double dvdPrice = customer.DvdMoviesRented * DvdMovie.Price;
            // Standard blu-ray prices
            double bluRayPrice = customer.BluRayMoviesRented * BluRayMovie.Price;

            if (customer.Membership)
            {
                return MembershipCalculation(customer, dvdPrice, bluRayPrice);
            }

            return customer.TotalPrice = dvdPrice + bluRayPrice;
        }

        /// <summary>
        /// Calculates total price for customers with membership
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="dvdPrice">Standard price for all dvd movies</param>
        /// <param name="bluRayPrice">Standard price for all blu-ray movies</param>
        /// <returns>Total price after discounts</returns>
        public double MembershipCalculation(Customer customer, double dvdPrice, double bluRayPrice)
        {
            int amountOfMovies = customer.DvdMoviesRented + customer.BluRayMoviesRented;

            // New price for dvd movies after discount
            double dvdDiscountedPrice = Movie.MovieDiscount(dvdPrice, DvdMovie.Discount);
            // New price for blu-ray movies after discount
            double bluRayDiscountedPrice = Movie.MovieDiscount(bluRayPrice, BluRayMovie.Discount);

            // Count for each movie list.
            int dvdMovies = customer.DvdMoviesRented;
            int bluRayMovies = customer.BluRayMoviesRented;

            if (amountOfMovies >= 4)
            {
                // Sets the total price to 100 
                customer.TotalPrice = 100;

                if (amountOfMovies >= 5)
                {
                    // if-else to check if the 4 cheapest movies are DVD
                    // if dvd movies are less then 4 then it will include a blu-ray movie instead
                    // else if no dvd movies, returns total price 100 + discount for blu-ray movies only
                    if (dvdMovies >= 4)
                    {
                        // Sets new price for all dvd movies minus 4 movies
                        dvdDiscountedPrice = Movie.MovieDiscount(
                            (dvdMovies - 4) * DvdMovie.Price,
                            DvdMovie.Discount
                            );
                        return customer.TotalPrice += bluRayDiscountedPrice + dvdDiscountedPrice;
                    }
                    else if (dvdMovies == 3)
                    {
                        //Sets new price for all blu-ray movies minus 1 blu-ray movie
                        bluRayDiscountedPrice = Movie.MovieDiscount(
                            (bluRayMovies - 1) * BluRayMovie.Price,
                            BluRayMovie.Discount
                            );

                        //Sets new price for all dvd movies minus 3 dvd movies
                        dvdDiscountedPrice = Movie.MovieDiscount(
                            (dvdMovies - 3) * DvdMovie.Price,
                            DvdMovie.Discount
                            );

                        return customer.TotalPrice += bluRayDiscountedPrice + dvdDiscountedPrice;
                    }
                    else if (dvdMovies == 2)
                    {
                        //Sets new price for all blu-ray movies minus 2 blu-ray movies
                        bluRayDiscountedPrice = Movie.MovieDiscount(
                            (bluRayMovies - 2) * BluRayMovie.Price,
                            BluRayMovie.Discount
                            );

                        //Sets new price for all dvd movies minus 2 dvd movies
                        dvdDiscountedPrice = Movie.MovieDiscount(
                            (dvdMovies - 2) * DvdMovie.Price,
                            DvdMovie.Discount
                            );

                        return customer.TotalPrice += bluRayDiscountedPrice + dvdDiscountedPrice;
                    }
                    else if (dvdMovies == 1)
                    {
                        //Sets new price for all blu-ray movies minus 3 blu-ray movies
                        bluRayDiscountedPrice = Movie.MovieDiscount(
                            (bluRayMovies - 3) * BluRayMovie.Price,
                            BluRayMovie.Discount
                            );

                        //Sets new price for all dvd movies minus 1 dvd movie
                        dvdDiscountedPrice = Movie.MovieDiscount(
                            (dvdMovies - 1) * DvdMovie.Price,
                            DvdMovie.Discount
                            );

                        return customer.TotalPrice += bluRayDiscountedPrice + dvdDiscountedPrice;
                    }

                    //Sets new price for all blu-ray movies minus 4 blu-ray movies
                    //Only happens if there are no dvd movies
                    bluRayDiscountedPrice = Movie.MovieDiscount(
                        (bluRayMovies - 4) * BluRayMovie.Price,
                        BluRayMovie.Discount
                        );

                    return customer.TotalPrice += bluRayDiscountedPrice;
                }

                //Returns 100 (if amountOfMovies == 4)
                return customer.TotalPrice;
            }

            //Returns standard discounts if less than 4 movies is rented
            return customer.TotalPrice = dvdDiscountedPrice + bluRayDiscountedPrice;
        }
    }
}
