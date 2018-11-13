using GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroupProject.Controllers
{
    public class CheckFlightStatusController : Controller
    {
          GroupProject20181102032945_dbEntities db = new GroupProject20181102032945_dbEntities();
          // GET: CheckFlightStatus
          public ActionResult CheckFlightStatus()
          {
   
              return View(db.FlightInfoes.ToList());
          }

         
    }
}