using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ColorChooser()
        {
            ViewBag.Message = "Your Color Chooser page.";

            return View();
        }

        public ActionResult Converter()
        {
            ViewBag.Message = "Your Metric Converter page.";

            return View();
        }
    }
}