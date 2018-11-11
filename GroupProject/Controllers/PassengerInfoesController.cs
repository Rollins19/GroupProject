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
    public class PassengerInfoesController : Controller
    {
        private GroupProject20181102032945_dbEntities db = new GroupProject20181102032945_dbEntities();

        // GET: PassengerInfoes
        public ActionResult Index()
        {
            return View(db.PassengerInfoes.ToList());
        }

        // GET: PassengerInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PassengerInfo passengerInfo = db.PassengerInfoes.Find(id);
            if (passengerInfo == null)
            {
                return HttpNotFound();
            }
            return View(passengerInfo);
        }

        // GET: PassengerInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PassengerInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TicketNum,FirstName,LastName,DOB,SeatNum,NumOfTickets,ManifestID")] PassengerInfo passengerInfo)
        {
            if (ModelState.IsValid)
            {
                db.PassengerInfoes.Add(passengerInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(passengerInfo);
        }

        // GET: PassengerInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PassengerInfo passengerInfo = db.PassengerInfoes.Find(id);
            if (passengerInfo == null)
            {
                return HttpNotFound();
            }
            return View(passengerInfo);
        }

        // POST: PassengerInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TicketNum,FirstName,LastName,DOB,SeatNum,NumOfTickets,ManifestID")] PassengerInfo passengerInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(passengerInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(passengerInfo);
        }

        // GET: PassengerInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PassengerInfo passengerInfo = db.PassengerInfoes.Find(id);
            if (passengerInfo == null)
            {
                return HttpNotFound();
            }
            return View(passengerInfo);
        }

        // POST: PassengerInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PassengerInfo passengerInfo = db.PassengerInfoes.Find(id);
            db.PassengerInfoes.Remove(passengerInfo);
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
