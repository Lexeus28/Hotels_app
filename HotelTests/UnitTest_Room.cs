namespace Hotels_app.Tests
{
    [TestClass]
    public class RoomTests
    {
        [TestMethod]
        public void Name_ThrowsException_WhenEmpty()
        {
            var room = new Room();
            Assert.ThrowsException<ArgumentException>(() => room.name = "");
        }

        [TestMethod]
        public void Name_ThrowsException_WhenTooLong()
        {
            var room = new Room();
            var longName = new string('A', 36); 
            Assert.ThrowsException<ArgumentException>(() => room.name = longName);
        }

        [TestMethod]
        public void Name_SetsCorrectly_WhenValid()
        {
            var room = new Room();
            room.name = "комнатка";
            Assert.AreEqual("комнатка", room.name);
        }


        [TestMethod]
        public void PricePerNight_ThrowsException_WhenNegative()
        {
            var room = new Room();
            Assert.ThrowsException<ArgumentException>(() => room.price_per_night = -10);
        }

        [TestMethod]
        public void PricePerNight_ThrowsException_WhenZero()
        {
            var room = new Room();
            Assert.ThrowsException<ArgumentException>(() => room.price_per_night = 0);
        }

        [TestMethod]
        public void PricePerNight_SetsCorrectly_WhenValid()
        {
            var room = new Room();
            room.price_per_night = 23;
            Assert.AreEqual(23, room.price_per_night);
        }

        [TestMethod]
        public void Capacity_SetsCorrectly()
        {
            var room = new Room();
            room.capacity = 4;
            Assert.AreEqual(4, room.capacity);
        }

        [TestMethod]
        public void Amount_SetsCorrectly()
        {
            var room = new Room();
            room.amount = 10;
            Assert.AreEqual(10, room.amount);
        }


        [TestMethod]
        public void RoomDescription_ThrowsException_WhenTooLong()
        {
            var room = new Room();
            var longDescription = new string('A', 501); 
            Assert.ThrowsException<ArgumentException>(() => room.room_description = longDescription);
        }

        [TestMethod]
        public void RoomDescription_SetsCorrectly_WhenValid()
        {
            var room = new Room();
            room.room_description = "большое окошко на детский сад";
            Assert.AreEqual("большое окошко на детский сад", room.room_description);
        }
    }
}