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
    public class PaymentInfoesController : Controller
    {
        private GroupProject20181102032945_dbEntities1 db = new GroupProject20181102032945_dbEntities1();

        [Authorize]
        public ActionResult PaymentConfirmation()
        {
            return View();
        }
    


        // GET: PaymentInfoes
        [Authorize]
        public ActionResult Index()
        {
            var paymentInfoes = db.PaymentInfoes.Include(p => p.Manifest);
            return View(paymentInfoes.ToList());
        }

        // GET: PaymentInfoes/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentInfo paymentInfo = db.PaymentInfoes.Find(id);
            if (paymentInfo == null)
            {
                return HttpNotFound();
            }
            return View(paymentInfo);
        }

        // GET: PaymentInfoes/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.ManifestID = new SelectList(db.Manifests, "ManifestID", "ManifestID");
            return View();
        }

        // POST: PaymentInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransactionNum,FirstName,LastName,SecurityCode,ExpirationDate,TotalCost,CradNum,ManifestID")] PaymentInfo paymentInfo)
        {
            if (ModelState.IsValid)
            {
                db.PaymentInfoes.Add(paymentInfo);
                db.SaveChanges();
                return RedirectToAction("PaymentConfirmation");
            }

            ViewBag.ManifestID = new SelectList(db.Manifests, "ManifestID", "SeatNum", paymentInfo.ManifestID);
            return View(paymentInfo);
        }

        // GET: PaymentInfoes/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentInfo paymentInfo = db.PaymentInfoes.Find(id);
            if (paymentInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManifestID = new SelectList(db.Manifests, "ManifestID", "SeatNum", paymentInfo.ManifestID);
            return View(paymentInfo);
        }

        // POST: PaymentInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransactionNum,FirstName,LastName,SecurityCode,ExpirationDate,TotalCost,CradNum,ManifestID")] PaymentInfo paymentInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paymentInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ManifestID = new SelectList(db.Manifests, "ManifestID", "SeatNum", paymentInfo.ManifestID);
            return View(paymentInfo);
        }

        // GET: PaymentInfoes/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentInfo paymentInfo = db.PaymentInfoes.Find(id);
            if (paymentInfo == null)
            {
                return HttpNotFound();
            }
            return View(paymentInfo);
        }

        // POST: PaymentInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PaymentInfo paymentInfo = db.PaymentInfoes.Find(id);
            db.PaymentInfoes.Remove(paymentInfo);
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
