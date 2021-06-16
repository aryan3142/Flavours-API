using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yum_PractiseCheck.Models;

namespace Yum_PractiseCheck.Repository.IRepository
{
    public interface IMenuItemOperations
    {
        public ICollection<MenuItem> GetItems();

        public MenuItem GetItemById(int id);

        public bool MenuItemExists(int id);

        public bool UpdateMenuItem(MenuItem item);

        public bool CreateMenuItem(MenuItem item);

        public bool DeleteMenuItem(MenuItem item);

        public bool Save();
    }
}
