using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace MyProjectMVC.Models
{
    public class User : IdentityUser<int>
    {
        public virtual List<Cart> Carts { get; set; }
    }
}
