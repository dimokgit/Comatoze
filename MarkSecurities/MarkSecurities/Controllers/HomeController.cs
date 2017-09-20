using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarkSecurities.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Olympic()
        {
            return PartialView("OlympicIsAAA");
        }
        public ActionResult Pershing()
        {
            return PartialView("PershingIsAAA");
        }
        public ActionResult KendoUI()
        {
            return File("~/Views/Home/KendoUI1.html", "text/html");
            //return PartialView("KendoUI");
        }
        //public ActionResult KendoUI()
        //{
        //    return View("KendoUI1");
        //}
    }
}