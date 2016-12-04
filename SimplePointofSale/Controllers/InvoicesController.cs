using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SimplePointofSale.DAL;
using SimplePointofSale.Models;
using PagedList;

namespace SimplePointofSale.Views
{
    public class InvoicesController : Controller
    {
        private PoSContext db = new PoSContext();

        // GET: Invoices
        public ViewResult Index(string sortOrder, string CurrentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Date_desc" : "";
            ViewBag.FNameSortParm = sortOrder == "FName" ? "fname_desc" : "FName";
            ViewBag.LNameSortParm = sortOrder == "LName" ? "lname_desc" : "LName";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = CurrentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var invoices = db.Invoices.Include(s => s.Customer);
            

            if (!String.IsNullOrEmpty(searchString))
            {
                invoices = invoices.Where(s => s.Customer.LName.Contains(searchString)
                                       || s.Customer.FName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "FName":
                    invoices = invoices.OrderBy(s => s.Customer.FName);
                    break;
                case "fname_desc":
                    invoices = invoices.OrderByDescending(s => s.Customer.FName);
                    break;
                case "LName":
                    invoices = invoices.OrderBy(s => s.Customer.LName);
                    break;
                case "lname_desc":
                    invoices = invoices.OrderByDescending(s => s.Customer.LName);
                    break;
                case "Date":
                    invoices = invoices.OrderBy(s => s.InvoiceDate);
                    break;
                case "date_desc":
                    invoices = invoices.OrderByDescending(s => s.InvoiceDate);
                    break;
                default:
                    invoices = invoices.OrderByDescending(s => s.InvoiceDate);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(invoices.ToPagedList(pageNumber, pageSize));
        }

        // GET: Invoices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // GET: Invoices/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FullName");
            return View();
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InvoiceID,CustomerID,InvoiceDate")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Invoices.Add(invoice);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = invoice.InvoiceID});
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FullName", invoice.CustomerID);
            return View(invoice);
        }

        // GET: Invoices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            var invoiceWithLines = from s in db.Invoices.Include("InvoiceLines")
                                   where s.InvoiceID == id
                                   select s;
            ViewData.Model = invoiceWithLines;

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FullName", invoice.CustomerID);
            ViewBag.InvoiceID = new SelectList(db.Invoices, "InvoiceID", "InvoiceID");
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductFullName");
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InvoiceID,CustomerID,InvoiceDate")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FullName", invoice.CustomerID);
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Invoice invoice = db.Invoices.Find(id);
            db.Invoices.Remove(invoice);
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
