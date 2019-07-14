using HotelBooking.Common;
using HotelBooking.Models;
using HotelBooking.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelBooking.Controllers
{
    public class HotelSearchController : Controller
    {
        private IHotelRepository hotelRepository = null;

        public HotelSearchController()
        {
            this.hotelRepository = new HotelRepository();

        }
        // GET: HotelSearch
        public ActionResult HotelSearchBooking()
        {
            return View();
        }

        [HttpGet]
        public JsonResult HotelSearchBookingList(string keyword)
        {
            //Searching records from list using LINQ query  
            var searchHotelList = GetHotelSearchList(keyword);

            return Json(searchHotelList, JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<HotelViewModel> GetHotelSearchList(string searchValue)
        {
            try
            {
                IEnumerable<HotelViewModel> searchHotelList= new List<HotelViewModel>();
                if (!string.IsNullOrEmpty(searchValue))
                {
                    searchHotelList = hotelRepository.GetAllHotels().Where(f =>
                              f.CityName.ToLower().Contains(searchValue.ToLower()) ||
                              f.CountryName.ToLower().Contains(searchValue.ToLower()));
                }
                return searchHotelList;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message.ToString());
                return null;
            }
        }

    }
}