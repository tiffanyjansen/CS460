using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;

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

            //Get Query Strings
            string miles = Request.QueryString["miles"];
            string unit = Request.QueryString["unit"];

            //Check to see if input in miles box is actually a number.
            Regex rx = new Regex(@"\d+");
            MatchCollection milesMatched = rx.Matches(miles);
            if (miles == null || milesMatched[0] == null)
            {
                //Miles either had nothing or no numbers.
                return View();
            }
            else
            {
                //Do converstion.
                int milesNum = Int32.Parse(miles);
                double kiloNum = milesNum * 1.60934;
                double meterNum = kiloNum * 1000;
                double centiNum = meterNum * 100;
                double milliNum = centiNum * 10;
                if (unit == "killometer")
                {
                    //We want kilometers, so let's use them.
                    //kiloNum;

                    //Make this work correctly with the stuff we are trying to do.
                    //I really want to pass parameters, but I don't know if that will work...
                    return View(miles, kiloNum);
                }
                else if(unit == "meter")
                {
                    //We want meters, so let's use them.
                    //meterNum;

                    //Make this work correctly with the stuff we are trying to do.
                    //I really want to pass parameters, but I don't know if that will work...
                    return View();
                }
                else if(unit == "centimeter")
                {
                    //We want centimeters, so let's use them.
                    //centiNum;

                    //Make this work correctly with the stuff we are trying to do.
                    //I really want to pass parameters, but I don't know if that will work...
                    return View();
                }
                else if(unit == "millimeter")
                {
                    //We want millimeters, so let's use them.
                    //milliNum;

                    //Make this work correctly with the stuff we are trying to do.
                    //I really want to pass parameters, but I don't know if that will work...
                    return View();
                }
                else
                {
                    //Someone made a mistake with the units.
                    return View();
                }
            }
        }
    }
}