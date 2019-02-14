using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class Comment : BaseModel
    {
        public string content { get; set; }
        public bool Delected { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
