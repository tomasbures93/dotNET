﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON___Produkte.Models
{
    class Lager
    {
        public string CategoryName
        {
            get;
            set;
        }
        public List<Product> Products { get; set; }

        public Lager() { }
    }
}
