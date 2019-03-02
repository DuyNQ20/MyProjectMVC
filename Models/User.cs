using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectMVC.Models
{
    public class User : People
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        public virtual List<Cart> Carts { get; set; }
    }
}
