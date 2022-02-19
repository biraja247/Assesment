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
    public class ProjectControllerTest
    {
        private readonly Project _project;
        private readonly ProjectController _projectController;
        private readonly Mock<IProjectRepository> _projectRepoMock;

        public ProjectControllerTest()
        {
            _project = new Project()
            {
                Id = 0,
                Cost = 8000,
                Title = "moq data",
                Duration = 20.5
            };

            _projectRepoMock = new Mock<IProjectRepository>();
            _projectController = new ProjectController(_projectRepoMock.Object)
            {
                ControllerContext = new ControllerContext()
            };
            _projectController.ControllerContext.HttpContext = new DefaultHttpContext();
            _projectController.ControllerContext.HttpContext.Request.Headers["Id"] = "1";
        }

        [Fact]
        public void AddTest()
        {
            _projectRepoMock.Setup(x => x.AddProject(It.IsAny<Project>())).Returns(true);
            var data = _projectController.Post(_project);
            var result = data as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void UpdateTest()
        {
            _projectRepoMock.Setup(x => x.UpdateProject(It.IsAny<Project>()));
            var data = _projectController.Update(_project);
            var result = data as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void GetAllTest()
        {
            var projects = new List<Project>()
            {
                _project
            };
            _projectRepoMock.Setup(x => x.GetAllProjects()).Returns(projects);
            var data = _projectController.Get();
            var result = data;

            Assert.Equal(projects, result.ToList());
        }

        [Fact]
        public void GetByIdTest()
        {
            _projectRepoMock.Setup(x => x.GetProjectById(1)).Returns(_project);
            var data = _projectController.Get(1);
            var result = data as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
        }
    }
}
