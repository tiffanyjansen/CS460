using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using WorldWideImporters.DAL;
using WorldWideImporters.Models.ViewModels;
using WorldWideImporters.Models;

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

            var Person = db.People
                    .Where(p => p.PersonID == ID)
                    .Select(p => new { Name = p.FullName, PName = p.PreferredName, Phone = p.PhoneNumber, Fax = p.FaxNumber, Email = p.EmailAddress, Member = p.ValidFrom })
                    .First();

            Info Result = new Info();
            Result.Name = Person.Name;
            Result.PName = Person.PName;
            Result.Phone = Person.Phone;
            Result.Fax = Person.Fax;
            Result.Email = Person.Email;
            Result.Member = Person.Member;
            
            if (db.People.Find(ID).Customers2.First() != null) {
                //Company Information
                var Company = db.People
                    .Find(ID).Customers2
                    .Select(p => new { CompanyName = p.CustomerName, CompanyPhone = p.PhoneNumber, CompanyFax = p.FaxNumber, Website = p.WebsiteURL, CompanyYear = p.ValidFrom })
                    .FirstOrDefault();

                //Put information from Query into Result.
                Result.CompanyName = Company.CompanyName;
                Result.CompanyPhone = Company.CompanyPhone;
                Result.CompanyFax = Company.CompanyFax;
                Result.Website = Company.Website;
                Result.CompanyYear = Company.CompanyYear;

                //Purchases Information
                //Count Number of Orders
                Result.Orders = db.People
                    .Find(ID).Customers2.First().Orders
                    .Count();

                //Gross Sales
                Result.GrossSales = db.People
                    .Find(ID).Customers2.First().Orders
                    .SelectMany(o => o.Invoices
                        .SelectMany(i => i.InvoiceLines
                            .Select(il => il.ExtendedPrice)))
                    .Sum();

                //Gross Profit
                Result.GrossProfit = db.People
                    .Find(ID).Customers2.First().Orders
                    .SelectMany(o => o.Invoices
                        .SelectMany(i => i.InvoiceLines
                            .Select(il => il.LineProfit)))
                    .Sum();
            }
                                                                           
            return View("~/Views/Information/Details.cshtml", Result);
        }
    }
}