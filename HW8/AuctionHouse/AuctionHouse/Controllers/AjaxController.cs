using AuctionHouse.DAL;
using AuctionHouse.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace AuctionHouse.Controllers
{
    public class AjaxController : Controller
    {
        AntiqueContext db = new AntiqueContext();

        // GET: Ajax
        public JsonResult Item(int id)
        {
            Debug.WriteLine("We are in the Ajax Controller");

            IEnumerable<Bid> bids = db.Items
                                        .Find(id)
                                        .Bids
                                        .Select(b => new Bid { Buyer = b.Buyer, Price = b.Price })
                                        .OrderByDescending(bid => bid.Price)
                                        .Take(10);

            Debug.WriteLine("Bids = " + bids);

            string result = JsonConvert.SerializeObject(bids, Formatting.None);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Table()
        {
            Debug.WriteLine("We are in the Ajax Controller");

            IEnumerable<Bid> recentBids = db.Items.SelectMany(item => item.Bids)
                .OrderByDescending(bid => bid.Timestamp)
                .Take(10);

            var viewModel = recentBids.Select(bid => new { ItemID = bid.Item, ItemName = bid.Item1.Name, BuyerName = bid.Buyer, BidAmount = bid.Price, TimeStamp = bid.Timestamp });
                        
            string result = JsonConvert.SerializeObject(viewModel, Formatting.None);

            Debug.WriteLine(result);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}