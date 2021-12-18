using Assignment.Models;
using Assignment.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTaskController : ControllerBase
    {
        private readonly IUserTaskRepository _repository;

        public UserTaskController(IUserTaskRepository taskRepository)
        {
            _repository = taskRepository;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult Get()
        {
            var utask = _repository.GetAllTasks();
            return Ok(utask);
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult Get(int id)
        {
            var utask = _repository.GetTasksById(id);

            if (utask == null)
                return NotFound("Task does not exist.");

            return Ok(utask);
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult Post(UserTask utask)
        {
            var utask1 = _repository.AddTask(utask);

            if (utask1 == null)
                return BadRequest("Unable to add task.");

            return Ok("Task created");
        }

        [HttpDelete]
        [Route("api/[controller]")]
        public IActionResult Delete(int id)
        {
            _repository.DeleteTask(id);
            return Ok("Task Deleted");
        }

        [HttpPatch]
        [Route("api/[controller]")]
        public IActionResult Update(UserTask uTask)
        {
            _repository.UpdateTask(uTask);
            return Ok("UserTask Data Updated");
        }
    }
}
