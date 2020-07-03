using GoogleTranslate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoogleTranslation.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetTranslete(string chinese)
        {
            Translate translate = new Translate();
            var translateResult = translate.GoogleTranslate(chinese, "zh-CN", "en");
            var wordList = System.Text.RegularExpressions.Regex.Split(translateResult, @"\s+");
            var str = "";
            foreach (var item in wordList)
            {
                str += item.Substring(0, 1).ToUpper() + item.Substring(1);
            }
            var result = new Result()
            {
                Original = translateResult,
                Formate = str
            };
            return Json(result);
        }

        public class Result
        {
            public string Original { get; set; }

            public string Formate { get; set; }
        }
    }
}