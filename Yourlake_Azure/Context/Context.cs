using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Yourlake_Azure.Models;

namespace Yourlake_Azure.Context
{
    public class Context : DbContext
    {
        public DbSet<Region> Regions { get; set; }
        public DbSet<Donnee> Donnnes { get; set; }
    }
}