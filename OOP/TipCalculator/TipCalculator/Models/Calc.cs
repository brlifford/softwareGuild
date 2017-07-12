using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TipCalculator.Models
{
    public class Calc
    {
        public decimal? Dollars  { get; set; }
        public decimal? TipPercent { get; set; }
        public decimal? TipAmount => Dollars * (TipPercent / 100);
    }
}