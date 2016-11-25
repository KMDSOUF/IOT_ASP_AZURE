using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Yourlake_Azure.Models
{
    public class Region
    {
        [Key]
        public int RegionId { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }

        public List<Donnee> ListeDonnees { get; set; }

    }
}