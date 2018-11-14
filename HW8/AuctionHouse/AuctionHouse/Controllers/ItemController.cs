using AuctionHouse.DAL;
using AuctionHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuctionHouse.Controllers
{
    public class ItemController : Controller
    {
        AntiquitiesContext db = new AntiquitiesContext();

        [HttpGet]
        public ActionResult List()
        {
            //return view with item list
            return View(db.Items);
        }

        [HttpGet]
        public ActionResult Create()
        {
            //return view
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Name,Description,Seller")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return View();
            }
            return View();
        }
    }
}