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
    public class UserController : ControllerBase
    {
        private readonly IUserManager _manager;

        public UserController(IUserManager manager)
        {
            _manager = manager;
        }

        [HttpGet("{id:int}",Name = "GetUserById")]
        public IActionResult GetUserById(int id)
        {
            var user = _manager.GetUserById(id);
            if(user == null)
            {
                return BadRequest(new { message = "User id doesn't exists" });
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            var temp = _manager.CreateUser(user);
            if (!temp)
            {
                return StatusCode(500, "Error while creating a new user");
            }
            return CreatedAtRoute("GetUserById", new {id = user.UserId },user);
        }

    }
}
