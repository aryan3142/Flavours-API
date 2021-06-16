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
    public class AdminController : ControllerBase
    {
        private readonly IMenuItemOperations _MiOperations;

        public AdminController(IMenuItemOperations menuItemOperations)
        {
            _MiOperations = menuItemOperations;
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet]
        public IActionResult GetAllMenuItems()
        {
            var items = _MiOperations.GetItems();
            if(items == null)
            {
                return StatusCode(500, "Error while getting the list of all items");
            }
            return Ok(items);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet("{id:int}", Name = "GetMenuItem")]
        public IActionResult GetMenuItemById(int id)
        {
            var item = _MiOperations.GetItemById(id);
            if(item == null)
            {
                return BadRequest(new { message = $"Item with id {id} not found" });
            }
            return Ok(item);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPut("{id:int}")]
        public IActionResult UpdateMenuItem(int id,[FromBody] MenuItem item)
        {
            if(item == null || id != item.ItemId)
            {
                return BadRequest(ModelState);
            }
            if (!_MiOperations.UpdateMenuItem(item))
            {
                return BadRequest(new { message = $"Something went wrong while updating item with id {id}" });
            }
            return NoContent();
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        public IActionResult CreateMenuItem([FromBody] MenuItem item)
        {
            if(item == null)
            {
                return BadRequest(ModelState);
            }
            if (!_MiOperations.MenuItemExists(item.ItemId))
            {
                return BadRequest(new { message = $"Menu item with item id {item.ItemId} already exists." });
            }
            if (!_MiOperations.CreateMenuItem(item))
            {
                return StatusCode(500, "Error while creating the menu item");
            }

            return CreatedAtRoute("GetMenuItem", new { id = item.ItemId }, item);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpDelete("{id:int}")]
        public IActionResult DeleteMenuItem(int id)
        {
            var item = _MiOperations.GetItemById(id);
            if(item == null)
            {
                return BadRequest(new { message = "Item doesn't exists" });
            }
            if (!_MiOperations.DeleteMenuItem(item))
            {
                return StatusCode(500, "Error while deleting the menu item");
            }
            return NoContent();
        }


    }
}
