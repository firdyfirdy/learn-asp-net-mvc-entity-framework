using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BelajarMvc.Data;
using BelajarMvc.Models;

namespace BelajarMvc.Controllers
{
    public class PenjualanController : Controller
    {
        private MainDbContext db = new MainDbContext();

        // GET: Penjualan
        public ActionResult Index()
        {
            var penjualan = db.Penjualan.Include(p => p.Customer).Include(p => p.Produk);
            return View(penjualan.ToList());
        }

        // GET: Penjualan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Penjualan penjualan = db.Penjualan.Find(id);
            if (penjualan == null)
            {
                return HttpNotFound();
            }
            return View(penjualan);
        }

        // GET: Penjualan/Create
        public ActionResult Create()
        {
            ViewBag.intCustomerId = new SelectList(db.Customer, "intCustomerId", "txtCustomerName");
            ViewBag.intProductId = new SelectList(db.Produk, "intProductId", "txtProductCode");
            return View(new Penjualan());
        }

        // POST: Penjualan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "intSalesOrderId,intCustomerId,intProductId,dtSalesOrder,intQty")] Penjualan penjualan)
        {
            if (ModelState.IsValid)
            {
                db.Penjualan.Add(penjualan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.intCustomerId = new SelectList(db.Customer, "intCustomerId", "txtCustomerName", penjualan.intCustomerId);
            ViewBag.intProductId = new SelectList(db.Produk, "intProductId", "txtProductCode", penjualan.intProductId);
            return View(penjualan);
        }

        // GET: Penjualan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Penjualan penjualan = db.Penjualan.Find(id);
            if (penjualan == null)
            {
                return HttpNotFound();
            }
            ViewBag.intCustomerId = new SelectList(db.Customer, "intCustomerId", "txtCustomerName", penjualan.intCustomerId);
            ViewBag.intProductId = new SelectList(db.Produk, "intProductId", "txtProductCode", penjualan.intProductId);
            return View(penjualan);
        }

        // POST: Penjualan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "intSalesOrderId,intCustomerId,intProductId,dtSalesOrder,intQty")] Penjualan penjualan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(penjualan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.intCustomerId = new SelectList(db.Customer, "intCustomerId", "txtCustomerName", penjualan.intCustomerId);
            ViewBag.intProductId = new SelectList(db.Produk, "intProductId", "txtProductCode", penjualan.intProductId);
            return View(penjualan);
        }

        // GET: Penjualan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Penjualan penjualan = db.Penjualan.Find(id);
            if (penjualan == null)
            {
                return HttpNotFound();
            }
            return View(penjualan);
        }

        // POST: Penjualan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Penjualan penjualan = db.Penjualan.Find(id);
            db.Penjualan.Remove(penjualan);
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
