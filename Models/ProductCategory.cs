using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectMVC.Models
{
    public class ProductCategory : BaseModel
    {
        public string Name { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
