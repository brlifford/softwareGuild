using DvdLibrary.Data.Factories;
using DvdLibrary.Models;
using DvdLibrary.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DvdLibrary.Controllers
{
    public class DvdController : Controller
    {
        // GET: Dvd
        public ActionResult Details(int id)
        {
            var repo = DvdRepositoryFactory.GetRepository();
            var model = repo.GetById(id);
            return View(model);
        }
        
        public ActionResult Index()
        {
            var repo = DvdRepositoryFactory.GetRepository();
            return View(repo.GetAll());
        }

        public ActionResult Add()
        {
            var model = new DvdShortItem();

            var directorRepo = DirectorRepositoryFactory.GetRepository();
            var ratingRepo = RatingRepositoryFactory.GetRepository();

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(DvdShortItem model)
        {
            var repo = DvdRepositoryFactory.GetRepository();

            try
            {
                repo.Insert(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(model);
        }
    }
}