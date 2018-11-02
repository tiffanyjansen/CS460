using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorldWideImporters.DAL;

namespace WorldWideImporters.Controllers
{
    public class HomeController : Controller
    {
        private WWIContext db = new WWIContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Search()
        {
            string SearchString = Request.QueryString["search"];

            var Results = db.People.Where(p => p.SearchName.Contains(SearchString));
                       
            return View(Results);
        }
    }
}