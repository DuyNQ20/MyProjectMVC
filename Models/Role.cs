using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectMVC.Models
{
    public class Role : BaseModel
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public virtual List<User> Users { get; set; }
    }
}
