﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class Status : BaseModel
    {
        public string Name { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}