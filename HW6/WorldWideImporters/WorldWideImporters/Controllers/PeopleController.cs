using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorldWideImporters.DAL;
using WorldWideImporters.Models;

namespace WorldWideImporters.Controllers
{
    public class PeopleController : Controller
    {
        private WWIContext db = new WWIContext();

        // GET: People
        public ActionResult Index()
        {
            var people = db.People.Include(p => p.Person1);
            return View(people.ToList());
        }

        // GET: People/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

    }
}
