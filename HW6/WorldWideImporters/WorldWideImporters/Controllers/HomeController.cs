using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorldWideImporters.DAL;
using WorldWideImporters.Models;
using WorldWideImporters.Models.ViewModels;

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

        [HttpPost]
        public ActionResult Search(int ID)
        {
            Debug.WriteLine("ID = " + ID);

           var Result = db.People
                    .Where(p => p.PersonID == ID)
                    .Select(p => new Info { Name = p.FullName, PName = p.PreferredName, Phone = p.PhoneNumber, Fax = p.FaxNumber, Email = p.EmailAddress, Member = p.ValidFrom });
                                                      
            return View("~/Views/Information/Details.cshtml", Result);
        }
    }
}