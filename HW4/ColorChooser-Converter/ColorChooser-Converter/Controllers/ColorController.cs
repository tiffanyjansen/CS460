using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ColorChooser_Converter.Controllers
{
    public class ColorController : Controller
    {
        // GET: Color
        public ActionResult Create()
        {
            ViewBag.Message = "Create a New Color";

            return View();
        }

        [HttpPost]
        public ActionResult Create(string first, string second)
        {
            ViewBag.Message = "Create a New Color";



            return View();
        }
    }
}