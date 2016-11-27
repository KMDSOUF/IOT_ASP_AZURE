using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Yourlake_Azure.Context;
using Yourlake_Azure.Models;

namespace Yourlake_Azure.Controllers
{
    public class DonneesController : Controller
    {
        private Context.Context db = new Context.Context();

        // GET: Donnees
        public ActionResult Index()
        {
            var donnnees = db.Donnnees.Include(d => d.Region);
            return View(donnnees.ToList());
        }

        // GET: Donnees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donnee donnee = db.Donnnees.Find(id);
            if (donnee == null)
            {
                return HttpNotFound();
            }
            return View(donnee);
        }

        // GET: Donnees/Create
        public ActionResult Create()
        {
            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "Nom");
            return View();
        }

        // POST: Donnees/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DonneeId,Temperature,Debit,Humidite_eau,Humidite,Time,RegionId")] Donnee donnee)
        {
            if (ModelState.IsValid)
            {
                db.Donnnees.Add(donnee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "Nom", donnee.RegionId);
            return View(donnee);
        }
        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
