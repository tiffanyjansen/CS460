using AuctionHouse.DAL;
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

        // GET: Item
        public ActionResult List()
        {
            return View(db.Items);
        }
    }
}