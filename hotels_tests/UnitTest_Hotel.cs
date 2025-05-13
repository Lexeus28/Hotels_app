using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Hotels_app;

namespace Hotels_app.Tests
{
    [TestClass]
    public class HotelTests
    {
        [TestMethod]
        public void HotelName_ThrowsException_WhenEmpty()
        {
            var hotel = new Hotel();
            Assert.ThrowsException<ArgumentException>(() => hotel.hotel_name = "");
        }

        [TestMethod]
        public void HotelName_ThrowsException_WhenTooLong()
        {
            var hotel = new Hotel();
            var longName = new string('A', 101);
            Assert.ThrowsException<ArgumentException>(() => hotel.hotel_name = longName);
        }

        [TestMethod]
        public void HotelName_SetsCorrectly_WhenValid()
        {
            var hotel = new Hotel();
            hotel.hotel_name = "Grand Hotel";
            Assert.AreEqual("Grand Hotel", hotel.hotel_name);
        }

        [TestMethod]
        public void HotelDescription_ThrowsException_WhenTooLong()
        {
            var hotel = new Hotel();
            var longDescription = new string('A', 201);
            Assert.ThrowsException<ArgumentException>(() => hotel.hotel_description = longDescription);
        }

        [TestMethod]
        public void HotelDescription_SetsCorrectly_WhenValid()
        {
            var hotel = new Hotel();
            hotel.hotel_description = "Luxury hotel with sea view.";
            Assert.AreEqual("Luxury hotel with sea view.", hotel.hotel_description);
        }

        [TestMethod]
        public void Address_ThrowsException_WhenTooLong()
        {
            var hotel = new Hotel();
            var longAddress = new string('A', 51);
            Assert.ThrowsException<ArgumentException>(() => hotel.address = longAddress);
        }

        [TestMethod]
        public void Address_SetsCorrectly_WhenValid()
        {
            var hotel = new Hotel();
            hotel.address = "123 Ocean Drive";
            Assert.AreEqual("123 Ocean Drive", hotel.address);
        }

        [TestMethod]
        public void MinPrice_SetsCorrectly_WhenValid()
        {
            var hotel = new Hotel();
            hotel.mn_price = 100;
            Assert.AreEqual(100, hotel.mn_price);
        }
    }
}