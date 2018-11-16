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
            //Return View.
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Name,Description,Seller")] Item item)
        {
            Seller Person = db.Sellers.Where(s => s.Name == item.Seller).FirstOrDefault();
            
            if (Person == null)
            {
                List<string> SellerNames = db.Sellers.Select(seller => seller.Name).ToList();
                string Names = SellerNames[0];
                for(int i = 1; i < SellerNames.Count; i++)
                {
                    Names += ", " + SellerNames[i];
                };

                Debug.WriteLine("Seller was not in the Seller Table.");
                ViewBag.Error = "The Seller is not in the seller table, please try again.";
                ViewBag.Options = "Your Options are: " + Names;
                    
                return View();
            }

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