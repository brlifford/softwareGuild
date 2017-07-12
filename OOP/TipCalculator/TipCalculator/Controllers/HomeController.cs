using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TipCalculator.Models;

namespace TipCalculator.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(decimal? dollars, decimal? tipPercent)
        {
            Calc calc = new Calc();
            calc.Dollars = dollars;
            calc.TipPercent = tipPercent;
            
            
            return View(calc);
        }
    }
}