using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yourlake_Azure.Models
{
    public class Donnee
    {
        public string Temperature { get; set; }
        public string Debit { get; set; }
        public string Humidite_eau { get; set; }
        public string Humidite { get; set; }
        public string Time { get; set; }
        public Guid RegionID { get; set; }
    }
}