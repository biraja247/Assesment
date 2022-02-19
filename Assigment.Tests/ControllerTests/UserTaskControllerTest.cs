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
    public class UserTaskControllerTest
    {
        private readonly UserTask _user;
        private readonly UserTaskController _userController;
        private readonly Mock<IUserTaskRepository> _userRepositoryMock;

        public UserTaskControllerTest()
        {
            _user = new UserTask()
            {
                Id = 1,
                TaskName = "Mock",
                Status = "MockStatus"
            };
            _userRepositoryMock = new Mock<IUserTaskRepository>();
            _userController = new UserTaskController(_userRepositoryMock.Object)
            {
                ControllerContext = new ControllerContext()
            };
            _userController.ControllerContext.HttpContext = new DefaultHttpContext();
            _userController.ControllerContext.HttpContext.Request.Headers["Id"] = "1";
        }

        [Fact]
        public void CreateTest()
        {
            _userRepositoryMock.Setup(x => x.AddTask(It.IsAny<UserTask>())).Returns(true);
            var data = _userController.Post(_user);
            var result = data as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void UpdateTest()
        {
            _userRepositoryMock.Setup(x => x.UpdateTask(It.IsAny<UserTask>()));
            var data = _userController.Update(_user);
            var result = data as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void GetAllTest()
        {
            var users = new List<UserTask>()
            {
                _user
            };
            _userRepositoryMock.Setup(x => x.GetAllTasks()).Returns(users);
            var data = _userController.Get();
            var result = data.ToList();

            Assert.Equal(users, result);
        }

        [Fact]
        public void GetByIdTest()
        {
            _userRepositoryMock.Setup(x => x.GetTasksById(1)).Returns(_user);
            var data = _userController.Get(1);
            var result = data as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
        }

    }
}
