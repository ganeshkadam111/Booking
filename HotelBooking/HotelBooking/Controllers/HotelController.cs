using HotelBooking.GenericRepository;
using HotelBooking.HotelEdmx;
using HotelBooking.Models;
using HotelBooking.Models.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace HotelBooking.Controllers
{
    public class HotelController : Controller
    {
        private IHotelRepository repository = null;

        public HotelController()
        {
            this.repository = new HotelRepository();
        }
      
        [HttpGet]
        public ActionResult HotelList()
        {
            IEnumerable<HotelViewModel> model = repository.GetAllHotels();
            return View(model);
        }

        [HttpGet]
        public ActionResult AddHotel()
        {
            return View();
        }
       
        public JsonResult GetCountry()
        {
            IEnumerable<CountryModel> listCountry = repository.GetAllCountry();
            return Json(listCountry, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCity()
        {
            IEnumerable<CityModel> listCity = repository.GetAllCity();
            return Json(listCity, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCityByCountryId(int countryId)
        {
            IEnumerable<CityModel> cityList = repository.GetAllCity().ToList().Where(x => x.CountryId == countryId);
            return Json(cityList, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AddHotel(HotelModel model)
        {
            string data = repository.AddHotel(model);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
       
        [HttpGet]
        public JsonResult GethotelById(int hotelId)
        {
            HotelModel model = repository.GetHotelById(hotelId);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult EditHotel(int Id)
        {
            ViewBag.ID = Id;
            return View();
        }
        [HttpPost]
        public JsonResult EditHotel(HotelModel model)
        {
            string result = repository.UpdateHotel(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DeleteHotel(int Id)
        {
            string message = repository.DeleteHotel(Id);
            return Json(message, JsonRequestBehavior.AllowGet);
        }

    }
}