using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOlympic.Models
{
    public class Athlete
    {
        public int id { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public int gold { get; set; }
        public int silver { get; set; }
        public int bronze { get; set; }
        public string img { get; set; }
    }
}