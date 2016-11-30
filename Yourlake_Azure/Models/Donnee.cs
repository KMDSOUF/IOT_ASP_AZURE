using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Yourlake_Azure.Models
{
    public class Donnee
    {
        [Key]
        public int DonneeId { get; set; }
        public string Temperature { get; set; }
        public string Debit { get; set; }
        public string Humidite_eau { get; set; }
        public string Humidite { get; set; }
        public int RegionId { get; set; }
        public string timeID { get; set; }
        public virtual Region Region { get; set; }

        public Donnee()
        {
            this.Temperature = "";
            this.Debit = "";
            this.Humidite_eau = "";
            this.Humidite = "";
            this.timeID = string.Format("{0:HH:mm:ss tt}", DateTime.Now);
        }

    }
}