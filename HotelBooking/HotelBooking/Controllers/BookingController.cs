using HotelBooking.Models;
using HotelBooking.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelBooking.Controllers
{
    public class BookingController : Controller
    {
        private IBookingRepository repository = null;

        public BookingController()
        {
            this.repository = new BookingRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult BookingList()
        {
            IEnumerable<BookingViewModel> model = repository.GetAllBookings();
            return View(model);
        }
        [HttpGet]
        public JsonResult GetAllHotel()
        {
            IEnumerable<HotelModel> listHotel = repository.GetAllHotel();
            return Json(listHotel, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetAllRoomName()
        {
            IEnumerable<RoomTypeModel> listRooms = repository.GetAllRoomType();
            return Json(listRooms, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddBooking()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AddBooking(BookingModel model)
        {
            string data = repository.AddBooking(model);
            return Json(data, JsonRequestBehavior.AllowGet);
        }





    }
}