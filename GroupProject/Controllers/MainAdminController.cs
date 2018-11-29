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
             ViewBag.DepartureDateList = new SelectList( GetFlightInfoList(), "FlightNum", "DepartureDate");
             ViewBag.ArrivalAirportList = new SelectList(GetFlightInfoList(), "FlightNum", "ArrivalAirport");
             ViewBag.FlightCapacityList = new SelectList(GetFlightInfoList(), "FlightNum", "FlightCapacity");
             ViewBag.FlightCapacityList = new SelectList(GetFlightInfoList(), "FlightNum", "FlightCapacity");
       
             return View();
        }

        [Authorize]
        public List<FlightInfo> GetFlightInfoList()
        {
             GroupProject20181102032945_dbEntities1 db = new GroupProject20181102032945_dbEntities1();
             List<FlightInfo> flightInfoes = db.FlightInfoes.ToList();
             return flightInfoes;
        }
     }
}