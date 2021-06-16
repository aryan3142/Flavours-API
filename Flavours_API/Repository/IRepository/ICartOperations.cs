using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yum_PractiseCheck.Models;

namespace Yum_PractiseCheck.Repository.IRepository
{
    public interface ICartOperations
    {
        public ICollection<Cart> GetAllMenuItems();

        public ICollection<Cart> GetAllMenuItemsInUserCart(int userId);

        public Cart GetCartItem(int cartId);

        public bool CreateCartForUser(Cart cart);

        public bool DeleteCartOfUser(Cart cart);

        public bool Save(); 
    }
}
