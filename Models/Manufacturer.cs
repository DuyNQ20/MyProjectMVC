using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class Manufacturer:BaseModel
    {
        public string Name { get; set; }

        public string Info { get; set; }

        public string Logo { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
