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
    public class CustomerController : ControllerBase
    {
        private readonly ICartOperations _opn;

        public CustomerController(ICartOperations cartOperations)
        {
            _opn = cartOperations;
        }

        [Authorize(Roles = Role.Customer)]
        [HttpGet]
        public IActionResult GetAllItemsNotExpired()
        {
            var items = _opn.GetAllMenuItems();
            return Ok(items);
        }

        [Authorize(Roles = Role.Customer)]
        [HttpGet("{Id:int}")]
        public IActionResult GetItemsInUserCart(int userId)
        {
            var items = _opn.GetAllMenuItemsInUserCart(userId);
            if(items == null)
            {
                return BadRequest(new { message = "No items in user's cart" });
            }

            return Ok(items);
        }

        [Authorize(Roles =Role.Customer)]
        [HttpPost]
        public IActionResult AddCartItem([FromBody] Cart cart)
        {
            var cartItem = new Cart()
            {
                CartId = 1,
                MenuItemId = cart.MenuItemId,
                UserId = cart.UserId
            };

            var temp = _opn.CreateCartForUser(cartItem);

            if (!temp)
            {
                return StatusCode(500, "Error while adding item to cart");
            }

            return Ok();
        }

        [Authorize(Roles = Role.Customer)]
        [HttpDelete("{id:int}")]
        public IActionResult DeleteCartItem(int id)
        {
            var temp = _opn.GetCartItem(id);

            if(temp == null)
            {
                return BadRequest(new { message = "There is no item in User's cart" });
            }

            if (!_opn.DeleteCartOfUser(temp))
            {
                return StatusCode(500, "Error while removing cart item");
            }
            return NoContent();
        }
    }
}
