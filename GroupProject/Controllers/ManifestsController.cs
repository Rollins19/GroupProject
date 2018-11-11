using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GroupProject.Models;

namespace GroupProject.Controllers
{
    public class ManifestsController : Controller
    {
        private GroupProject20181102032945_dbEntities db = new GroupProject20181102032945_dbEntities();

        // GET: Manifests
        public ActionResult Index()
        {
            var manifests = db.Manifests.Include(m => m.FlightInfo).Include(m => m.PassengerInfo).Include(m => m.PaymentInfo);
            return View(manifests.ToList());
        }

        // GET: Manifests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manifest manifest = db.Manifests.Find(id);
            if (manifest == null)
            {
                return HttpNotFound();
            }
            return View(manifest);
        }

        // GET: Manifests/Create
        public ActionResult Create()
        {
            ViewBag.FlightNum = new SelectList(db.FlightInfoes, "FlightNum", "DepartureAirport");
            ViewBag.TicketNum = new SelectList(db.PassengerInfoes, "TicketNum", "FirstName");
            ViewBag.TransactionNum = new SelectList(db.PaymentInfoes, "TransactionNum", "TransactionNum");
            return View();
        }

        // POST: Manifests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ManifestID,TicketNum,FlightNum,TransactionNum")] Manifest manifest)
        {
            if (ModelState.IsValid)
            {
                db.Manifests.Add(manifest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FlightNum = new SelectList(db.FlightInfoes, "FlightNum", "DepartureAirport", manifest.FlightNum);
            ViewBag.TicketNum = new SelectList(db.PassengerInfoes, "TicketNum", "FirstName", manifest.TicketNum);
            ViewBag.TransactionNum = new SelectList(db.PaymentInfoes, "TransactionNum", "TransactionNum", manifest.TransactionNum);
            return View(manifest);
        }

        // GET: Manifests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manifest manifest = db.Manifests.Find(id);
            if (manifest == null)
            {
                return HttpNotFound();
            }
            ViewBag.FlightNum = new SelectList(db.FlightInfoes, "FlightNum", "DepartureAirport", manifest.FlightNum);
            ViewBag.TicketNum = new SelectList(db.PassengerInfoes, "TicketNum", "FirstName", manifest.TicketNum);
            ViewBag.TransactionNum = new SelectList(db.PaymentInfoes, "TransactionNum", "TransactionNum", manifest.TransactionNum);
            return View(manifest);
        }

        // POST: Manifests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ManifestID,TicketNum,FlightNum,TransactionNum")] Manifest manifest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manifest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FlightNum = new SelectList(db.FlightInfoes, "FlightNum", "DepartureAirport", manifest.FlightNum);
            ViewBag.TicketNum = new SelectList(db.PassengerInfoes, "TicketNum", "FirstName", manifest.TicketNum);
            ViewBag.TransactionNum = new SelectList(db.PaymentInfoes, "TransactionNum", "TransactionNum", manifest.TransactionNum);
            return View(manifest);
        }

        // GET: Manifests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manifest manifest = db.Manifests.Find(id);
            if (manifest == null)
            {
                return HttpNotFound();
            }
            return View(manifest);
        }

        // POST: Manifests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Manifest manifest = db.Manifests.Find(id);
            db.Manifests.Remove(manifest);
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
