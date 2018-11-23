using AuctionHouse.DAL;
using AuctionHouse.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuctionHouse.Controllers
{
    public class HomeController : Controller
    {
        AntiqueContext db = new AntiqueContext();

        public ActionResult Index()
        {
            return View();
        }
    }
}