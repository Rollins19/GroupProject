using GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroupProject.Controllers
{
    public class FlightSelectionController : Controller
    {     

          private GroupProject20181102032945_dbEntities db = new GroupProject20181102032945_dbEntities();

          // GET: FlightSelection
          public ActionResult FlightSelection()
          {
               var flightInfo = db.FlightInfoes.ToList();
               return View("FlightSelection", flightInfo);
          }
    }
}