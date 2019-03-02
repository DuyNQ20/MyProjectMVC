using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectMVC.ViewModels
{
    public class CartView
    {
        public bool Active { get; set; }

        public virtual int ProductId { get; set; }

        public int UserId { get; set; }


    }
}
