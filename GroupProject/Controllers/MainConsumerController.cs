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
          private GroupProject20181102032945_dbEntities db = new GroupProject20181102032945_dbEntities();
        // GET: MainConsumer
        public ActionResult MainConsumer()
        {
               ViewBag.DepartureDate = new SelectList(db.FlightInfoes, "FlightNum", "DepartureDate.date");
               ViewBag.ArrivalAirport = new SelectList(db.FlightInfoes, "FlightNum", "ArrivalAirport");
               ViewBag.FlightCapacity = new SelectList(db.FlightInfoes, "FlightNum", "FlightCapacity");
            return View();
        }
    }
}