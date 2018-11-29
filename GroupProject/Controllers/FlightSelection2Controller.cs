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
    public class FlightSelection2Controller : Controller
    {
        private GroupProject20181102032945_dbEntities1 db = new GroupProject20181102032945_dbEntities1();

        // GET: FlightSelection2
        [Authorize]
        public ActionResult FlightSelection2()
        {
            return View(db.FlightInfoes.ToList());
        }
    }
}