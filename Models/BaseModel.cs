using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectMVC.Models
{
    public class BaseModel
    {
        public int Id { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public bool Active { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset ModifiedAt { get; set; }
    }
}
