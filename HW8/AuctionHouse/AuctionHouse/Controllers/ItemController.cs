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
            //Decide if the "Seller" inputted is in the Seller table, using Linq
            Seller Person = db.Sellers.Where(s => s.Name == item.Seller).FirstOrDefault();

            //Check if Person is null, if so return error message and list of options.
            if (Person == null)
            {
                //Find all the Sellers using Linq
                List<string> SellerNames = db.Sellers.Select(seller => seller.Name).ToList();

                //Create list of options so client can pick one from it.
                string Names = SellerNames[0];
                for(int i = 1; i < SellerNames.Count; i++)
                {
                    Names += ", " + SellerNames[i];
                };

                //Debug to let me know the seller was not in the table.
                Debug.WriteLine("Seller was not in the Seller Table.");

                //ViewBags error message and list of options
                ViewBag.Error = "The Seller is not in the seller table, please try again.";
                ViewBag.Options = "Your Options are: " + Names;

                //Return the View (with the ViewBags)
                return View();
            }

            //Check if model state is valid (if the object is actually formatted correctly)
            if (ModelState.IsValid)
            {
                //Add and save to database
                db.Items.Add(item);
                db.SaveChanges();

                //Redirect to the Details page so you can see what all has been added.
                return RedirectToAction("Details", item.ID);
            }

            //If model is not correctly formatted do nothing...
            return View();
        }

        [HttpGet]
        public ActionResult Details(int? ID)
        {
            //Debug to check where we are.
            Debug.WriteLine("We are in the Details Method");

            //Check if ID is null, if so go back to the list.
            if (ID == null)
            {
                Debug.WriteLine("The ID was null");
                return RedirectToAction("List");
            }

            //Get the item using Linq
            Item item = db.Items
                .Where(i => i.ID == ID)
                .FirstOrDefault();

            //Check if item is null, if so go back to the list.
            if (item == null)
            {
                Debug.WriteLine("The item was null");
                return RedirectToAction("List");
            }

            //return the view with the item.
            return View(item);
        }

        [HttpGet]
        public ActionResult Edit(int? ID)
        {
            //Debug to check where we are.
            Debug.WriteLine("We are in the Edit Method (Get)");

            //Check if ID is null, if so go back to the list.
            if (ID == null)
            {
                Debug.WriteLine("The ID was null");
                return RedirectToAction("List");
            }

            //Get the item using Linq
            Item item = db.Items
                .Where(i => i.ID == ID)
                .FirstOrDefault();

            //Check if the item is null, if so go back to the list.
            if (item == null)
            {
                Debug.WriteLine("The item was null.");
                return RedirectToAction("List");             
            }

            //return the view with the item.
            return View(item);
        }
    }
}