using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Yum_PractiseCheck.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int CartId { get; set; }
        public MenuItem Item { get; set; }
        public int MenuItemId { get; set; }

        public int UserId { get; set; }

    }
}
