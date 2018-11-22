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
    public class FlightUpdateStatusController : Controller
    {
        GroupProject20181102032945_dbEntities1 db = new GroupProject20181102032945_dbEntities1();

        // GET: FlightUpdateStatus
        [Authorize]
        public ActionResult FlightUpdateStatus()
        {
            return View(db.FlightInfoes.ToList());
        }

        // GET: FlightInfoes/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlightInfo flightInfo = db.FlightInfoes.Find(id);
            if (flightInfo == null)
            {
                return HttpNotFound();
            }
            return View(flightInfo);
        }

        // POST: FlightInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FlightNum, DepartureAirport, ArrivalAirport, DepartureTime, ArrivalTime, DepartureDate, FlightCapacity, SingleTicketPrice, FlightStatus")] FlightInfo flightInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flightInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("FlightUpdateStatus");
            }
            return View(flightInfo);
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