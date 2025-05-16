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
                var longName = new string('A', 1000);
                Assert.ThrowsException<ArgumentException>(() => hotel.hotel_name = longName);
            }

            [TestMethod]
            public void HotelName_SetsCorrectly_WhenValid()
            {
                var hotel = new Hotel();
                hotel.hotel_name = "отель";
                Assert.AreEqual("отель", hotel.hotel_name);
            }

            [TestMethod]
            public void HotelDescription_ThrowsException_WhenTooLong()
            {
                var hotel = new Hotel();
                Assert.ThrowsException<ArgumentException>(() => hotel.hotel_description = new string('A', 300));
            }

            [TestMethod]
            public void HotelDescription_SetsCorrectly_WhenValid()
            {
                var hotel = new Hotel();
                hotel.hotel_description = "шикарный отель";
                Assert.AreEqual("шикарный отель", hotel.hotel_description);
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
                hotel.address = "30 лет победы";
                Assert.AreEqual("30 лет победы", hotel.address);
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