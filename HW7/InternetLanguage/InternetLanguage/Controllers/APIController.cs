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

            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(website);
            request.Method = WebRequestMethods.Http.Get;
            request.Accept = "application/json";

            return Json(request, JsonRequestBehavior.AllowGet);
        }
    }
}