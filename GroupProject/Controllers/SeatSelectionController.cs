using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroupProject.Controllers
{
    public class SeatSelectionController : Controller
    {
        // GET: SeatSelection
        [Authorize]
        public ActionResult SeatSelection()
        {
            return View();
        }
    }
}