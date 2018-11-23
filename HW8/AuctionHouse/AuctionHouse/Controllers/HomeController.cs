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

        public JsonResult Table()
        {
            Debug.WriteLine("We are in the Ajax Controller");

            IEnumerable<Bid> recentBids = db.Items.SelectMany(item => item.Bids)
                .OrderBy(bid => bid.Timestamp)
                .Take(10);

            var viewModel = recentBids.Select(bid => new { ItemID = bid.Item, ItemName = bid.Item1.Name, BuyerName = bid.Buyer, BidAmount = bid.Price, TimeStamp = bid.Timestamp });
            
            string result = JsonConvert.SerializeObject(viewModel, Formatting.None);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}