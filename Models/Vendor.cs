using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectMVC.Models
{
    public class Vendor:People
    {
        public virtual List<Product> Products { get; set; }
    }
}
