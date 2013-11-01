using MvcOlympic.App_Start;
using MvcOlympic.DTO;
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

        public ActionResult Index()
        {
            return View(DataBase.Athleres);
        }

        public ActionResult About()
        {

            var athleres = DataBase.Athleres;

            var sGroup = (from a in athleres
                          group a by new
                          {
                              a.country
                          } into g
                          select new EventDTO()
                          {
                              country = g.Key.country,
                              gold = g.Sum(a => a.gold),
                              silver = g.Sum(a => a.silver),
                              bronze = g.Sum(a => a.bronze),

                          }).OrderByDescending(x => x.gold)
                          .ToList();
            return View(sGroup);
        }

        public ActionResult GetSport()
        {
            return View(DataBase.Sports);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult Filter(int id)
        {

            var sportByAthlete = DataBase.Events
                                         .Where(e => e.athlete.id == id)
                                         .ToList();
            return Json(sportByAthlete, JsonRequestBehavior.AllowGet);


        }
    }
}
