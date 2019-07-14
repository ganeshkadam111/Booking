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
        public JsonResult AddBookingFromSearch(SearchModel searchModel)
        {
            HotelViewModel hotelModel = repository.GetAllHotels().SingleOrDefault(x => x.Id == searchModel.HotelId);

            BookingModel bookingModel = new BookingModel();
            bookingModel.HotelId = hotelModel.Id;
            bookingModel.InvoiceNumber = "HMB"+ new Guid();
            bookingModel.FromDate = searchModel.FromDate;
            bookingModel.ToDate = searchModel.ToDate;
            bookingModel.Adult = searchModel.Adult;
            bookingModel.Children = searchModel.Children;
            bookingModel.BuyingCurrency = hotelModel.DefaultCurrency;
            bookingModel.BookingDate = DateTime.Now.ToString("dd/mm/yyyy");
            if (searchModel.CalculatedNight > 0)
            {
                bookingModel.BuyingPrice = hotelModel.PricePerNight * searchModel.CalculatedNight;
            }
            else
            {
                bookingModel.BuyingPrice = hotelModel.PricePerNight;
            }

            string data = repository.AddBooking(bookingModel);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddBooking(BookingModel model)
        {
            string data = repository.AddBooking(model);
            return Json(data, JsonRequestBehavior.AllowGet);
        }



    }
}