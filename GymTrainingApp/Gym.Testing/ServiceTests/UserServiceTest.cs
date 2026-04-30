using Gym.Business.Services;
using Gym.Models.Entities;
using Gym.Models.Interfaces;
using Gym.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Gym.Tests.ServiceTests
{
    [TestClass]
    public class UserServiceTest
    {
        private static UserService _service = null!;
        private static List<User> _users = null!;

        [ClassInitialize]
        public static void ClassInitialize(TestContext _)
        {
            _users =
            [
                new User { Id = 1, Username = "john", Password = BCrypt.Net.BCrypt.HashPassword("pass123"), Weight = 82.5 }
            ];

            var repoMock = new Mock<IUserRepository>();
            repoMock.Setup(r => r.GetById(It.IsAny<int>())).Returns((int id) => _users.FirstOrDefault(x => x.Id == id));
            repoMock.Setup(r => r.GetByUsername(It.IsAny<string>())).Returns((string username) => _users.FirstOrDefault(x => x.Username == username));
            repoMock.Setup(r => r.Delete(It.IsAny<User>())).Callback((User u) => _users.Remove(u));

            _service = new UserService(repoMock.Object);
        }

        [TestMethod]
        public void GetUserById_ShouldReturnDto_WhenValidId()
        {
            var result = _service.GetUserById(1);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(UserDTO));
        }

        [TestMethod]
        public void GetUserById_ShouldReturnNull_WhenInvalidId()
        {
            var result = _service.GetUserById(999);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetUserById_ShouldThrowException_WhenNegativeId()
        {
            Assert.Throws<ArgumentException>(() => _service.GetUserById(0));
        }



        [TestMethod]
        public void GetUserByUsername_ShouldReturnDto_WhenValidUsername()
        {
            var result = _service.GetUserByUsername("john");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(UserDTO));
        }

        [TestMethod]
        public void GetUserByUsername_ShouldReturnCorrectUser_WhenValidUsername()
        {
            var result = _service.GetUserByUsername("john");

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
        }

        [TestMethod]
        public void GetUserByUsername_ShouldThrowException_WhenEmptyUsername()
        {
            Assert.Throws<ArgumentException>(() => _service.GetUserByUsername(""));
        }

        [TestMethod]
        public void GetUserByUsername_ShouldThrowException_WhenInvalidUsername()
        {
            Assert.Throws<Exception>(() => _service.GetUserByUsername("nonexistent"));
        }



        [TestMethod]
        public void LoginUser_ShouldRetunUserDto_WhenValidCredentials()
        {
            var result = _service.LoginUser("john", "pass123");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(UserDTO));
        }

        [TestMethod]
        public void LoginUser_ShouldReturnNull_WhenInvalidPassword()
        {
            var result = _service.LoginUser("john", "wrongpass");
            Assert.IsNull(result);
        }

        [TestMethod]
        public void LoginUser_ShouldReturnNull_WhenInvalidUsername()
        {
            var result = _service.LoginUser("nonexistent", "pass123");
            Assert.IsNull(result);
        }

        [TestMethod]
        public void LoginUser_ShouldThrowException_WhenEmptyUsername()
        {
            Assert.Throws<ArgumentException>(() => _service.LoginUser("", "pass123"));
        }

        [TestMethod]
        public void LoginUser_ShouldThrowException_WhenEmptyPassword() 
        {
            Assert.Throws<ArgumentException>(() => _service.LoginUser("john", ""));
        }
    }
}