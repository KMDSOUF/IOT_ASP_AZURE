using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Yourlake_Azure.Context;
using Yourlake_Azure.Models;
using HtmlAgilityPack;
using System.Text;

namespace Yourlake_Azure.Controllers
{
    public class DonneesController : Controller
    {
        private Context.Context db = new Context.Context();
        //liste pour stocker les donner 
        private List<Donnee> listeDonnee = new List<Donnee>();

        private Donnee d = new Donnee();

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
        public ActionResult charger()
        {
            string page = getPage();
            //decouper les chaines dans le fichier
            string[] lines = page.Split(new string[] { "&amp;", "None", "\n" }, StringSplitOptions.None);



            //dictionnaire contenant les cles values
            //Dictionary<string, string> dictionnaire = new Dictionary<string, string>();
            foreach (string line in lines)
            {
                try
                {
                    string[] pair = line.Split(new[] { '=' });
                    string key = pair[0];
                    string val = pair[1];

                    switch (key)
                    {
                        case ("slot_temperature"):
                            d.Temperature = val;
                            break;
                        case ("slot_debit"):
                            d.Debit = val;
                            break;
                        case ("data"):
                            break;
                        case ("slot_humidite_eau"):
                            d.Humidite_eau = val;
                            break;
                        case ("slot_humidite"):
                            d.Humidite = val;
                            break;
                        case ("time"):
                            break;
                        case ("device"):
                            break;
                        case ("signal"):
                            break;
                    }
                    if (d.Temperature != "" && d.Debit != "" && d.Humidite_eau != "" && d.Humidite != "")
                    {
                        d.RegionId = 3;
                        db.Donnnees.Add(d);
                        db.SaveChanges();
                        // new Donnee pour réutiliser l'objet d avec des attributs null
                        d = new Donnee();
                    }
                }
                catch (Exception e)
                {
                    
                }

            }
            return View();
        }
        
        private static string getPage()
        {
            string html;
            // obtain some arbitrary html....
            using (var client = new WebClient())
            {
                html = client.DownloadString("http://requestb.in/1fqdvv81?inspect");
            }
            // use the html agility pack: http://www.codeplex.com/htmlagilitypack
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            StringBuilder sb = new StringBuilder();
            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//pre[@class='body prettyprint']"))
            {
                sb.AppendLine(node.InnerText);
            }
            string final = sb.ToString();

            return final;
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
