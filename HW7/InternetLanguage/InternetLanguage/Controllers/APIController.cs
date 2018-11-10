using InternetLanguage.DAL;
using InternetLanguage.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace InternetLanguage.Controllers
{
    public class APIController : Controller
    {
        private RequestsContext db = new RequestsContext();
        
        // GET: API
        public JsonResult Sentence(string word)
        {
            string key = System.Configuration.ConfigurationManager.AppSettings["GiphyKey"];

            Debug.WriteLine("word = " + word);
            Debug.WriteLine("Key = " + key);

            string website = "https://api.giphy.com/v1/stickers/translate?api_key=" + key + "&s=" + word;

            WebRequest request = WebRequest.Create(website);
            request.ContentType = "application/json; charset=utf-8";
            var response = (HttpWebResponse)request.GetResponse();
            string words;
            using (var stream = new StreamReader(response.GetResponseStream()))
            {
                words = stream.ReadToEnd();
            };

            var obj = JObject.Parse(words);
            string data = (string)obj["data"]["embed_url"];

           // For now this is broken. Hopefully I will get this fixed tomorrow morning.
           // AddToDatabase(data);

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        private void AddToDatabase(string data)
        {
            Debug.WriteLine("Made it to the add to database part.");
            Debug.WriteLine("data = " + data);
            Request request = new Request
            {
                IPAddress = HttpContext.Request.UserHostAddress,
                DateOfRequest = DateTime.Now,
                Browser = HttpContext.Request.UserAgent,
                SpecialSite = data
            };
            Debug.WriteLine(request);
            Debug.WriteLine("IPAddress = " + request.IPAddress);
            Debug.WriteLine("Browser = " + request.Browser);
            Debug.WriteLine("DateOfRequest = " + request.DateOfRequest);
            Debug.WriteLine("SpecialSite = " + request.SpecialSite);
            db.Requests.Add(request);
            Debug.WriteLine(db.Requests);
            db.SaveChanges();
        }
    }
}