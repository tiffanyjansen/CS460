using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;


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

            Color firstColor = ColorTranslator.FromHtml(first);
            Color secondColor = ColorTranslator.FromHtml(second);

            Color mixedColor = BlendColors(firstColor, secondColor);

            ViewBag.Color = firstColor + " + " + secondColor + " = " + mixedColor;
           
            return View();
        }
        public Color BlendColors(Color firstColor, Color secondColor)
        {
            byte r = (byte)((firstColor.R * 0.5) + secondColor.R * 0.5);
            byte g = (byte)((firstColor.G * 0.5) + secondColor.G * 0.5);
            byte b = (byte)((firstColor.B * 0.5) + secondColor.B * 0.5);
            return Color.FromArgb(r, g, b);
        }
    }
}