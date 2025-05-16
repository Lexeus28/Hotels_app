using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Hotels_app;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
namespace Hotels_app.Tests
{
    [TestClass]
    public class Functional
    {
        [TestMethod]
        public void IsRoomNameUnique_WhenNameIsUnique_ReturnsTrue()
        {
            // Arrange
            var temporaryRooms = new List<Room>
            {
                new Room
                {
                    name = "Room1",
                    price_per_night = 100,
                    capacity = 2,
                    amount = 1,
                    room_description = "Описание комнаты"
                },
                new Room
                {
                    name = "Room3",
                    price_per_night = 150,
                    capacity = 3,
                    amount = 2,
                    room_description = "Описание второй комнаты"
                }
            };

            var form = new AddRoomForm(null, null, temporaryRooms);
            Assert.IsTrue(form.IsRoomNameUnique("Room2"));
        }
        [TestMethod]
        public void HashPassword_ValidPassword_ReturnsDifferentHashes()
        {
            string password = "12345678";
            string hashedPassword1 = PasswordHasher.HashPassword(password);
            string hashedPassword2 = PasswordHasher.HashPassword(password);
            Assert.AreNotEqual(hashedPassword1, hashedPassword2);
        }
        [TestMethod]
        public void VerifyPassword_CorrectPassword_ReturnsTrue()
        {
            string password = "12345678";
            string hashedPassword = PasswordHasher.HashPassword(password);
            bool isVerified = PasswordHasher.VerifyPassword(password, hashedPassword);
            Assert.IsTrue(isVerified, "Правильный пароль должен быть подтвержден.");
        }
    }

}