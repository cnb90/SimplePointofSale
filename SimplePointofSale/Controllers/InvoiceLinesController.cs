using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SimplePointofSale.DAL;
using SimplePointofSale.Models;

namespace SimplePointofSale.Controllers
{
    public class InvoiceLinesController : Controller
    {
        private PoSContext db = new PoSContext();

        // GET: InvoiceLines
        public ActionResult Index()
        {
            var invoiceLines = db.InvoiceLines.Include(i => i.Invoice).Include(i => i.Product);
            return View(invoiceLines.ToList());
        }

        // GET: InvoiceLines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceLine invoiceLine = db.InvoiceLines.Find(id);
            if (invoiceLine == null)
            {
                return HttpNotFound();
            }
            return View(invoiceLine);
        }

        // GET: InvoiceLines/Create
        public ActionResult Create()
        {
            ViewBag.InvoiceID = new SelectList(db.Invoices, "InvoiceID", "InvoiceID");
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductFullName");
            return View();
        }

        // POST: InvoiceLines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InvoiceLineID,InvoiceID,ProductID,Quantity,Discount,PriceAtSale")] InvoiceLine invoiceLine)
        {
            if (ModelState.IsValid)
            {
                db.InvoiceLines.Add(invoiceLine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InvoiceID = new SelectList(db.Invoices, "InvoiceID", "InvoiceID", invoiceLine.InvoiceID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductFullName", invoiceLine.ProductID);
            return View(invoiceLine);
        }

        // GET: InvoiceLines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceLine invoiceLine = db.InvoiceLines.Find(id);
            if (invoiceLine == null)
            {
                return HttpNotFound();
            }
            ViewBag.InvoiceID = new SelectList(db.Invoices, "InvoiceID", "InvoiceID", invoiceLine.InvoiceID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductFullName", invoiceLine.ProductID);
            return View(invoiceLine);
        }

        // POST: InvoiceLines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InvoiceLineID,InvoiceID,ProductID,Quantity,Discount,PriceAtSale")] InvoiceLine invoiceLine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoiceLine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InvoiceID = new SelectList(db.Invoices, "InvoiceID", "InvoiceID", invoiceLine.InvoiceID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductFullName", invoiceLine.ProductID);
            return View(invoiceLine);
        }

        // GET: InvoiceLines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceLine invoiceLine = db.InvoiceLines.Find(id);
            if (invoiceLine == null)
            {
                return HttpNotFound();
            }
            return View(invoiceLine);
        }

        // POST: InvoiceLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InvoiceLine invoiceLine = db.InvoiceLines.Find(id);
            db.InvoiceLines.Remove(invoiceLine);
            db.SaveChanges();
            return RedirectToAction("Index");
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
