using AuctionHouse.DAL;
using AuctionHouse.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuctionHouse.Controllers
{
    public class ItemController : Controller
    {
        AntiqueContext db = new AntiqueContext();

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
                return RedirectToAction("Details", item.ID);
            }
            return View();
        }

        [HttpGet]
        public ActionResult Details(int? ID)
        {
            Debug.WriteLine("We are in the Details Method");
            if (ID == null)
            {
                Debug.WriteLine("The ID was null");
                return RedirectToAction("List");
            }
            Item item = db.Items
                .Where(i => i.ID == ID)
                .FirstOrDefault();
            if (item == null)
            {
                Debug.WriteLine("The item was null");
                return RedirectToAction("List");
            }
            return View(item);
        }
    }
}