using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOlympic.Models
{
    public class Event
    {
        public Athlete athlete { get; set; }
        public string modalidae { get; set; }
        public int gold { get; set; }
        public int silver { get; set; }
        public int bronze { get; set; }

        
    }
}