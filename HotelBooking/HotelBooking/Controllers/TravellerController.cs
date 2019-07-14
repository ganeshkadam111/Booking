using HotelBooking.Models;
using HotelBooking.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelBooking.Controllers
{
    public class TravellerController : Controller
    {
            private TravellerRepository repository = null;

            public TravellerController()
            {
                this.repository = new TravellerRepository();
            }
            // GET: Traveller
            [HttpGet]
            public ActionResult AddTraveller()
            {
                return View();
            }
            [HttpPost]
            public JsonResult AddTraveller(TravellerModel model)
            {
                string data = repository.AddTraveller(model);
                return Json(data, JsonRequestBehavior.AllowGet);
            }

    }
}