using Assignment.Models;
using Assignment.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _repository;

        public ProjectController(IProjectRepository projectRepository)
        {
            _repository = projectRepository;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult Get()
        {
            var projects = _repository.GetAllProjects();
            return Ok(projects);
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult Get(int id)
        {
            var project = _repository.GetProjectById(id);

            if (project == null)
                return NotFound("Project does not exist.");

            return Ok(project);
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult Post(Project project)
        {
            var proj = _repository.AddProject(project);

            if (proj == null)
                return BadRequest("Unable to add user.");

            return Ok("User created");
        }

        [HttpDelete]
        [Route("api/[controller]")]
        public IActionResult Delete(int id)
        {
            _repository.DeleteProject(id);
            return Ok("Project Deleted");
        }

        [HttpPatch]
        [Route("api/[controller]")]
        public IActionResult Update(Project project)
        {
            _repository.UpdateProject(project);
            return Ok("Project Data Updated");
        }
    }
}
