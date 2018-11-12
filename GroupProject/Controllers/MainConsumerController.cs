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

         // public string ArrivalAirport { get; private set; }

          // GET: MainConsumer
        public ActionResult MainConsumer()
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

        public List<FlightInfo> GetFlightInfoList()
        {
             GroupProject20181102032945_dbEntities db = new GroupProject20181102032945_dbEntities();
             List<FlightInfo> flightInfoes = db.FlightInfoes.ToList();
             return flightInfoes;
        }
          /*
        public List<FlightInfo> GetArrivalAirportList(int FlightNum)
        {
             GroupProject20181102032945_dbEntities db = new GroupProject20181102032945_dbEntities();
             List<FlightInfo> arrivalAirportList = db.FlightInfoes.Where(x => x.ArrivalAirport == ArrivalAirport).ToList();
             return arrivalAirportList;
        }*/
    }
}