using GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroupProject.Controllers
{
    public class MainAdminController : Controller
    {
        private GroupProject20181102032945_dbEntities1 db = new GroupProject20181102032945_dbEntities1();

        // GET: MainAdmin
        [Authorize]
        public ActionResult MainAdmin()
        {
             ViewBag.DepartureDate = new SelectList(db.FlightInfoes, "FlightNum", "DepartureDate.date");
             ViewBag.ArrivalAirport = new SelectList(db.FlightInfoes, "FlightNum", "ArrivalAirport");
             ViewBag.FlightCapacity = new SelectList(db.FlightInfoes, "FlightNum", "FlightCapacity");
       
             return View();
        }
     }
}