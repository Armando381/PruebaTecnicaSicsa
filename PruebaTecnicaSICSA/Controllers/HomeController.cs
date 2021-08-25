using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PruebaTecnicaSICSA.Models;
using MySql.Data;

namespace PruebaTecnicaSICSA.Controllers
{
    
    public class HomeController : Controller
    {
        private PruebaSicsaEntities1 dbContext = new PruebaSicsaEntities1();

        public ActionResult Index()
        {
           //ViewBag.Categories = dbContext.categories.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}