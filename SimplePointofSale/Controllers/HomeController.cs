using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimplePointofSale.DAL;
using SimplePointofSale.ViewModels;

namespace SimplePointofSale.Controllers
{
    public class HomeController : Controller
    {
        private PoSContext db = new PoSContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            IQueryable<InvoiceDateGroup> data = from invoice in db.Invoices
                                                   group invoice by invoice.InvoiceDate into dateGroup
                                                   select new InvoiceDateGroup()
                                                   {
                                                       InvoiceDate = dateGroup.Key,
                                                       InvoiceCount = dateGroup.Count()
                                                   };
            return View(data.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}