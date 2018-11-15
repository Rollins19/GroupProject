using GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroupProject.Controllers
{
    public class CancelFlightController : Controller
    {
        GroupProject20181102032945_dbEntities db = new GroupProject20181102032945_dbEntities();
        // GET: CancelFlight
        public ActionResult CancelFlight()
        {
            return View();
        }
    }
}