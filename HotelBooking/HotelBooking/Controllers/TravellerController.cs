using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelBooking.Controllers
{
    public class TravellerController : Controller
    {
        // GET: Traveller
        public ActionResult AddTraveller()
        {
            return View();
        }

    }
}