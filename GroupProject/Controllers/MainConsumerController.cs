using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data;
using System.Net;
using GroupProject.Models;

namespace GroupProject.Controllers
{
    public class MainConsumerController : Controller
    {
          private Group2DBEntities db = new Group2DBEntities();
        // GET: MainConsumer
        public ActionResult MainConsumer()
        {
               ViewBag.DepartureDate = new SelectList(db.FlightInfoes, "FlightNum", "DepartureDate.date");
               ViewBag.ArrivalAirport = new SelectList(db.FlightInfoes, "FlightNum", "ArrivalAirport");
               ViewBag.DepartureTime = new SelectList(db.FlightInfoes, "FlightNum", "DepartureTime"); //Need to modify flight capacity to available seat capacity
               return View();
        }
    }
}