using MvcOlympic.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MvcOlympic.App_Start
{
    public static class DataBase
    {
        private static readonly string PathBase = @"C:\Users\th\Documents\GitHub\olympic\MvcOlympic\MvcOlympic\App_Data\";
        private static readonly string Athletes_json = "athletes.json";
        private static readonly string Sports_json = "sports.json";
        private static readonly string Events_json = "events.json";
        private static StreamReader sr;

        public static List<Athlete> Athleres;
        public static List<Sport> Sports;
        public static List<Event> Events;

        public static void InitDataBase()
        {
            sr = new StreamReader(string.Format("{0}{1}", PathBase, Athletes_json));
            string myAthletes = sr.ReadToEnd();

            Athleres = JsonConvert.DeserializeObject<List<Athlete>>(myAthletes);

            sr = new StreamReader(string.Format("{0}{1}", PathBase, Sports_json));
            string mySports = sr.ReadToEnd();

            Sports = JsonConvert.DeserializeObject<List<Sport>>(mySports);

            sr = new StreamReader(string.Format("{0}{1}", PathBase, Events_json));
            string myEvents = sr.ReadToEnd();

            Events = JsonConvert.DeserializeObject<List<Event>>(myEvents);
        }

    }
}