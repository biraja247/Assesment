using Assignment.Models;
using Assignment.Models.Interface;
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
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthenticationController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("api/[controller]/login")]
        public IActionResult Login(User userAuth)
        {
            var token = _authService.GetToken(userAuth.UserName, userAuth.Password);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}
