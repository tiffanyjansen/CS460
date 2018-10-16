using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ColorChooser_Converter.Controllers
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
            ViewBag.Message = "Convert Miles to Metric";

            return View();
        }
    }
}