using HotelBooking.HotelEdmx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Models.Repository
{
    interface IHotelRepository:IDisposable
    {
        IEnumerable<HotelViewModel> GetAllHotels();
        IEnumerable<CityModel> GetAllCity();
        IEnumerable<CountryModel> GetAllCountry();
        string AddHotel(HotelModel hotelModel);
        HotelModel GetHotelById(int hotelID);
        string UpdateHotel(HotelModel hotelModel);
        string DeleteHotel(int id);
    }
}
