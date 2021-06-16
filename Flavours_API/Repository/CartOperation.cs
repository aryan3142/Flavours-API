using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yum_PractiseCheck.Context;
using Yum_PractiseCheck.Models;
using Yum_PractiseCheck.Repository.IRepository;

namespace Yum_PractiseCheck.Repository
{
    public class CartOperation : ICartOperations
    {
        private readonly ApplicationDbContext _context;

        public CartOperation(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateCartForUser(Cart cart)
        {
            _context.Carts.Add(cart);
            return Save();
        }

        public bool DeleteCartOfUser(Cart cart)
        {
            _context.Carts.Remove(cart);
            return Save();
        }

        public ICollection<Cart> GetAllMenuItems()
        {
            return _context.Carts.Where(x => x.Item.DateOfExpiry < DateTime.UtcNow).ToList();
        }

        public ICollection<Cart> GetAllMenuItemsInUserCart(int userId)
        {
            return _context.Carts.Where(x => x.UserId == userId).ToList();
        }

        public Cart GetCartItem(int cartId)
        {
            return _context.Carts.FirstOrDefault(x => x.CartId == cartId); 
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }
    }
}
