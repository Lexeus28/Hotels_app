using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Hotels_app;

namespace Hotels_app.Tests
{
    [TestClass]
    public class UserTests
    {

        [TestMethod]
        public void FirstName_ThrowsException_WhenEmpty()
        {
            var user = new User();
            Assert.ThrowsException<ArgumentException>(() => user.first_name = "");
        }

        [TestMethod]
        public void FirstName_ThrowsException_WhenTooLong()
        {
            var user = new User();
            var longName = new string('А', 51); 
            Assert.ThrowsException<ArgumentException>(() => user.first_name = longName);
        }

        [TestMethod]
        public void FirstName_ThrowsException_WhenInvalidFormat()
        {
            var user = new User();
            Assert.ThrowsException<ArgumentException>(() => user.first_name = "иван"); 
        }

        [TestMethod]
        public void FirstName_SetsCorrectly_WhenValid()
        {
            var user = new User();
            user.first_name = "Иван";
            Assert.AreEqual("Иван", user.first_name);
        }

        [TestMethod]
        public void LastName_ThrowsException_WhenEmpty()
        {
            var user = new User();
            Assert.ThrowsException<ArgumentException>(() => user.last_name = "");
        }

        [TestMethod]
        public void LastName_ThrowsException_WhenTooLong()
        {
            var user = new User();
            var longName = new string('А', 51); 
            Assert.ThrowsException<ArgumentException>(() => user.last_name = longName);
        }

        [TestMethod]
        public void LastName_ThrowsException_WhenInvalidFormat()
        {
            var user = new User();
            Assert.ThrowsException<ArgumentException>(() => user.last_name = "петров"); 
        }

        [TestMethod]
        public void LastName_SetsCorrectly_WhenValid()
        {
            var user = new User();
            user.last_name = "Петров";
            Assert.AreEqual("Петров", user.last_name);
        }


        [TestMethod]
        public void Patronymic_ThrowsException_WhenInvalidFormat()
        {
            var user = new User();
            Assert.ThrowsException<ArgumentException>(() => user.patronymic = "сидоров"); 
        }

        [TestMethod]
        public void Patronymic_ThrowsException_WhenTooLong()
        {
            var user = new User();
            var longPatronymic = new string('А', 51); // Превышение лимита в 50 символов
            Assert.ThrowsException<ArgumentException>(() => user.patronymic = longPatronymic);
        }

        [TestMethod]
        public void Patronymic_SetsCorrectly_WhenValid()
        {
            var user = new User();
            user.patronymic = "Евгеньевич";
            Assert.AreEqual("Евгеньевич", user.patronymic);
        }

        [TestMethod]
        public void Patronymic_AllowsNullValue()
        {
            var user = new User();
            user.patronymic = null;
            Assert.IsNull(user.patronymic);
        }

        [TestMethod]
        public void Username_ThrowsException_WhenEmpty()
        {
            var user = new User();
            Assert.ThrowsException<ArgumentException>(() => user.username = "");
        }

        [TestMethod]
        public void Username_ThrowsException_WhenTooLong()
        {
            var user = new User();
            var longUsername = new string('A', 51); 
            Assert.ThrowsException<ArgumentException>(() => user.username = longUsername);
        }

        [TestMethod]
        public void Username_SetsCorrectly_WhenValid()
        {
            var user = new User();
            user.username = "user123";
            Assert.AreEqual("user123", user.username);
        }



        [TestMethod]
        public void PasswordHash_ThrowsException_WhenEmpty()
        {
            var user = new User();
            Assert.ThrowsException<ArgumentException>(() => user.password_hash = "");
        }

        [TestMethod]
        public void PasswordHash_SetsCorrectly_WhenValid()
        {
            var user = new User();
            user.password_hash = "хэшпароль";
            Assert.AreEqual("хэшпароль", user.password_hash);
        }

        [TestMethod]
        public void PhoneNumber_ThrowsException_WhenEmpty()
        {
            var user = new User();
            Assert.ThrowsException<ArgumentException>(() => user.phone_number = "");
        }

        [TestMethod]
        public void PhoneNumber_ThrowsException_WhenInvalidFormat()
        {
            var user = new User();
            Assert.ThrowsException<ArgumentException>(() => user.phone_number = "abc"); 
        }

        [TestMethod]
        public void PhoneNumber_ThrowsException_WhenTooLong()
        {
            var user = new User();
            var longPhoneNumber = new string('1', 16); 
            Assert.ThrowsException<ArgumentException>(() => user.phone_number = longPhoneNumber);
        }

        [TestMethod]
        public void PhoneNumber_SetsCorrectly_WhenValid()
        {
            var user = new User();
            user.phone_number = "1234567890";
            Assert.AreEqual("1234567890", user.phone_number);
        }
    }
}