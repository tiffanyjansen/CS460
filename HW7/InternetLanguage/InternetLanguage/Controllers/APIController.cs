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
            }
            return Json(words, JsonRequestBehavior.AllowGet);
        }
    }
}