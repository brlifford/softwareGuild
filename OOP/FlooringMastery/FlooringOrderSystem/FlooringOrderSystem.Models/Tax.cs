﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderSystem.Models
{
    public class Tax
    {
        public string StateAbbreviation { get; set; }
        public string State { get; set; }
        public decimal TaxRate { get; set; }
    }
}
