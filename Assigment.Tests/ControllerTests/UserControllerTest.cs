using Assignment.Controllers;
using Assignment.Models;
using Assignment.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Assigment.Tests.ControllerTests
{
    public class UserControllerTest
    {
        private readonly User _user;
        private readonly UserController _userController;
        private readonly Mock<IUserRepository> _userRepositoryMock;

        public UserControllerTest()
        {
            _user = new User()
            {
                Id = 1,
                Name = "Test",
                Email = "mockmail@gmail.com",
                UserName = "Mockuser",
                Password = "pwd"
            };
            _userRepositoryMock = new Mock<IUserRepository>();
            _userController = new UserController(_userRepositoryMock.Object)
            {
                ControllerContext = new ControllerContext()
            };
            _userController.ControllerContext.HttpContext = new DefaultHttpContext();
            _userController.ControllerContext.HttpContext.Request.Headers["Id"] = "1";
        }

        [Fact]
        public void CreateTest()
        {
            _userRepositoryMock.Setup(x => x.AddUser(It.IsAny<User>())).Returns(true);
            var data = _userController.Post(_user);
            var result = data as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void UpdateTest()
        {
            _userRepositoryMock.Setup(x => x.UpdateUser(It.IsAny<User>()));
            var data = _userController.Update(_user);
            var result = data as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void GetAllTest()
        {
            var users = new List<User>()
            {
                _user
            };
            _userRepositoryMock.Setup(x => x.GetAllUsers()).Returns(users);
            var data = _userController.Get();
            var result = data.ToList();

            Assert.Equal(users, result);
        }

        [Fact]
        public void GetByIdTest()
        {
            _userRepositoryMock.Setup(x => x.GetUserById(1)).Returns(_user);
            var data = _userController.Get(1);
            var result = data as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
        }

    }
}
