using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yum_PractiseCheck.Models;
using Yum_PractiseCheck.Repository.IRepository;

namespace Yum_PractiseCheck.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationManager _manager;

        public AuthController(IAuthenticationManager manager)
        {
            _manager = manager;
        }

        
        [AllowAnonymous]
        [HttpPost("AuthenticateUser")]
        public IActionResult GetEmployees([FromBody] User user)
        {
            var token = _manager.Authenticate(user.UserName, user.Password);
            if(token == null)
            {
                return BadRequest(new { message = "Username or Password is incorrect" });
            }
            return Ok(token);
        }

    }
}
