using CashRegysterSystem;
using CashRegysterSystem.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace xUnitTest_CashRegisterSystem
{
    public class UnitTest
    {
        Customer customer = new Customer()
        {
            Name = "Abahram Lincoln",
            DvdMoviesRented = 2,
            BluRayMoviesRented = 2,
            Membership = false
        };

        CustomerHandler customerHandler = new CustomerHandler();
        OrderHandler orderHandler = new OrderHandler();
        PriceHandler priceHandler = new PriceHandler();

        [Theory]
        //Discount for 2 dvd movies rented
        [InlineData(2, 29, 0.9, 52.2)]
        //Discount for 2 blu-ray movies rented
        [InlineData(2, 39, 0.85, 66.3)]
        public void MembershipDiscount(int moviesRented, double moviePrice, double discount, double expectedDiscount)
        {
            double totalPrice = moviesRented * moviePrice;
            double actualDiscount = Movie.MovieDiscount(totalPrice, discount);

            Assert.Equal(expectedDiscount, actualDiscount);
        }

        //Membership calculation tests
        [Theory]
        [InlineData(2, 2, 100)]
        [InlineData(4, 2, 166.3)]
        [InlineData(3, 3, 166.3)]
        [InlineData(1, 4, 133.15)]
        [InlineData(4, 4, 232.6)]
        [InlineData(5, 5, 291.85)]
        [InlineData(5, 0, 126.1)]
        public void MemberShipCalculation(int dvdMovies, int bluRayMovies, double expectedPrice)
        {
            customer.DvdMoviesRented = dvdMovies;
            customer.BluRayMoviesRented = bluRayMovies;

            double dvdPrice = customer.DvdMoviesRented * DvdMovie.Price;
            double bluRayPrice = customer.BluRayMoviesRented * BluRayMovie.Price;

            customer.Membership = true;

            var actualPrice = priceHandler.MembershipCalculation(customer, dvdPrice, bluRayPrice);

            Assert.Equal(expectedPrice, actualPrice);
        }

        //Standard price tests if not a member
        [Theory]
        [InlineData(2, 2, 136)]
        [InlineData(5, 3, 262)]
        [InlineData(0, 3, 117)]
        [InlineData(3, 0, 87)]
        public void StandardCalculation(int dvdMovies, int bluRayMovies, double expectedPrice)
        {
            customer.DvdMoviesRented = dvdMovies;
            customer.BluRayMoviesRented = bluRayMovies;

            double actualPrice = priceHandler.CalculateTotalPrice(customer);
            Assert.Equal(expectedPrice, actualPrice);
        }
    }
}