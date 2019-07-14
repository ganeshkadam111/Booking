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
        public ActionResult AddRoom()
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
        public JsonResult AddRoom(RoomTypeModel model)
        {
            string data = repository.AddRoom(model);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult EditRoom(int Id)
        {
            ViewBag.ID = Id;
            return View();
        }
        [HttpGet]
        public JsonResult GetRoomById(int roomId)
        {
            RoomTypeModel model = repository.GetRoomById(roomId);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EditRoom(RoomTypeModel model)
        {
            string result = repository.UpdateRoom(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DeleteRoom(int Id)
        {
            string message = repository.DeleteRoom(Id);
            return Json(message, JsonRequestBehavior.AllowGet);
        }

    }
}