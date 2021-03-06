﻿using System;
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
        private GroupProject20181102032945_dbEntities1 db = new GroupProject20181102032945_dbEntities1();

        // GET: Manifests
        [Authorize]
        public ActionResult Index()
        {
            var manifests = db.Manifests.Include(m => m.FlightInfo).Include(m => m.PassengerInfo);
            return View(manifests.ToList());
        }

        // GET: Manifests/Details/5
        [Authorize]
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
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.FlightNum = new SelectList(db.FlightInfoes, "FlightNum", "FlightNum");
            ViewBag.PassengerID = new SelectList(db.PassengerInfoes, "PassengerID", "PassengerID");
            return View();
        }

        // POST: Manifests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ManifestID,PassengerID,FlightNum,TicketNum,SeatNum")] Manifest manifest)
        {
            if (ModelState.IsValid)
            {
                db.Manifests.Add(manifest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FlightNum = new SelectList(db.FlightInfoes, "FlightNum", "DepartureAirport", manifest.FlightNum);
            ViewBag.PassengerID = new SelectList(db.PassengerInfoes, "PassengerID", "FirstName", manifest.PassengerID);
            return View(manifest);
        }

        // GET: Manifests/Edit/5
        [Authorize]
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
            ViewBag.PassengerID = new SelectList(db.PassengerInfoes, "PassengerID", "FirstName", manifest.PassengerID);
            return View(manifest);
        }

        // POST: Manifests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ManifestID,PassengerID,FlightNum,TicketNum,SeatNum")] Manifest manifest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manifest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FlightNum = new SelectList(db.FlightInfoes, "FlightNum", "DepartureAirport", manifest.FlightNum);
            ViewBag.PassengerID = new SelectList(db.PassengerInfoes, "PassengerID", "FirstName", manifest.PassengerID);
            return View(manifest);
        }

        // GET: Manifests/Delete/5
        [Authorize]
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
