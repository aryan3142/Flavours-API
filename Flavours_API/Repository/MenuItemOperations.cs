using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yum_PractiseCheck.Context;
using Yum_PractiseCheck.Models;
using Yum_PractiseCheck.Repository.IRepository;

namespace Yum_PractiseCheck.Repository
{
    public class MenuItemOperations : IMenuItemOperations
    {
        private readonly ApplicationDbContext _context;

        public MenuItemOperations(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateMenuItem(MenuItem item)
        {
            _context.MenuItems.Add(item);

            return Save();
        }

        public bool DeleteMenuItem(MenuItem item)
        {
            _context.MenuItems.Remove(item);
            return Save();
        }

        public MenuItem GetItemById(int id)
        {
            var item = _context.MenuItems.SingleOrDefault(x => x.ItemId == id);
            if(item == null)
            {
                return null;
            }
            return item;
        }

        public ICollection<MenuItem> GetItems()
        {
            return _context.MenuItems.ToList();
        }

        public bool MenuItemExists(int id)
        {
            var temp = _context.MenuItems.Any(x => x.ItemId == id);
            return temp;

        }

        public bool Save()
        {
            return _context.SaveChanges() >=0 ? true : false ;
        }

        public bool UpdateMenuItem(MenuItem item)
        {
            _context.MenuItems.Update(item);
            return Save();
        }

    }
}
