﻿using GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroupProject.Controllers
{
    public class CancelFlightController : Controller
    {
        GroupProject20181102032945_dbEntities1 db = new GroupProject20181102032945_dbEntities1();

        // GET: CancelFlight
        [Authorize]
        public ActionResult CancelFlight()
        {
            return View();
        }
    }
}