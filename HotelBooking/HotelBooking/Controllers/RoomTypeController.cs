using HotelBooking.Models;
using HotelBooking.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelBooking.Controllers
{
    public class RoomTypeController : Controller
    {
        private IRoomRepository repository = null;

        public RoomTypeController()
        {
            this.repository = new RoomRepository();
        }


        [HttpGet]
        public ActionResult RoomTypeList()
        {
            IEnumerable<RoomTypeModel> model = repository.GetAllRooms();
            return View(model);
        }

        [HttpGet]
        public ActionResult AddRooms()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetAmenities()
        {
            IEnumerable<AmenitiesModel> listAmenities = repository.GetAllAmenities();
            return Json(listAmenities, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AddRooms(RoomTypeModel model)
        {
            string data = repository.AddRoom(model);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}