using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yum_PractiseCheck.Repository.IRepository;

namespace Yum_PractiseCheck.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnonymousUserController : ControllerBase
    {
        private readonly IMenuItemOperations _MiOperations;

        public AnonymousUserController(IMenuItemOperations MiOperation)
        {
            _MiOperations = MiOperation;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllMenuItems()
        {
            var items = _MiOperations.GetItems();

            return Ok(items);
        }

    }
}
