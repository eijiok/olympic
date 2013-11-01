using MvcOlympic.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOlympic.Controllers
{
    public class HomeController : Controller
    {
        private readonly string PathBase = @"C:\Users\th\Documents\Visual Studio 2012\Projects\MvcOlympic\MvcOlympic\App_Data\";
        private readonly string Athletes = "athletes.json";
        private readonly string Sports = "sports.json";
        private readonly string Events = "events.json";
        public ActionResult Index()
        {
            StreamReader myFile = new StreamReader(string.Format("{0}{1}", PathBase, Athletes));
            string myString = myFile.ReadToEnd();

            var athleres = JsonConvert.DeserializeObject<List<Athlete>>(myString);

            return View(athleres);
        }

        public ActionResult About()
        {
            StreamReader myFile = new StreamReader(string.Format("{0}{1}", PathBase, Athletes));
            string myString = myFile.ReadToEnd();

            var athleres = JsonConvert.DeserializeObject<List<Athlete>>(myString);

            var sGroup = (from a in athleres
                          group a by new
                          {
                              a
                          } into g
                          select new Event()
                          {
                              athlete = g.Key.a,
                              gold = g.Sum(a => a.gold),
                              silver = g.Sum(a => a.silver),
                              bronze = g.Sum(a => a.bronze),

                          }).OrderByDescending(x => x.gold)
                          .ToList();
            return View(sGroup);
        }

        public ActionResult GetSport()
        {
            StreamReader myFile = new StreamReader(string.Format("{0}{1}", PathBase, Sports));
            string myString = myFile.ReadToEnd();

            var sports = JsonConvert.DeserializeObject<List<Sport>>(myString);

            return View(sports);

        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult Filter(int id)
        {
            StreamReader myFile = new StreamReader(string.Format("{0}{1}", PathBase, Events));
            string myString = myFile.ReadToEnd();

            var sports = JsonConvert.DeserializeObject<List<Event>>(myString);
            var sportByAthlete = sports.Where(e => e.athlete.id == id).ToList();
            return Json(sportByAthlete, JsonRequestBehavior.AllowGet);


        }
    }
}
