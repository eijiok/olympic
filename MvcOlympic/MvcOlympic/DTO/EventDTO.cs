using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOlympic.DTO
{
    public class EventDTO
    {
        
        public string country { get; set; }
        public int gold { get; set; }
        public int silver { get; set; }
        public int bronze { get; set; }

        public int total
        {
            get { return gold + silver + bronze; }
        }
    }
}