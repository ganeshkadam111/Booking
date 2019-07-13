using HotelBooking.HotelEdmx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBooking.Models.Repository
{
    public class HotelRepository : IHotelRepository
    {

        public IEnumerable<CityModel> GetAllCity()
        {
            using (HotelDBContext _hotelEntities = new HotelDBContext())
            {
                var data = _hotelEntities.Cities.ToList();
                List<CityModel> cityList = new List<CityModel>();
                for (var i = 0; i < data.Count; i++)
                {
                    CityModel city = new CityModel();
                    city.Id = data[i].Id;
                    city.CityName = data[i].CityName;
                    city.CountryId = data[i].CountryId;
                    cityList.Add(city);
                }
                return cityList;
            }
        }

        public IEnumerable<CountryModel> GetAllCountry()
        {
            using (HotelDBContext _hotelEntities = new HotelDBContext())
            {
                var data = _hotelEntities.Countries.ToList();
                List<CountryModel> countryList = new List<CountryModel>();

                for (var i = 0; i < data.Count; i++)
                {
                    CountryModel country = new CountryModel();
                    country.Id = data[i].Id;
                    country.CountryName = data[i].CountryName;
                    countryList.Add(country);
                }
                return countryList;
            }
        }

        public IEnumerable<HotelViewModel> GetAllHotels()
        {
            using (HotelDBContext _hotelEntities = new HotelDBContext())
            {
                var data = _hotelEntities.Hotels.ToList();
                List<HotelViewModel> hotelList = new List<HotelViewModel>();
                for (var i = 0; i < data.Count; i++)
                {
                    HotelViewModel hotelView = new HotelViewModel();
                    hotelView.Id = data[i].Id;
                    hotelView.HotelName = data[i].HotelName;
                    hotelView.Address = data[i].Address;
                    hotelView.PhoneNumber = data[i].PhoneNumber;
                    hotelView.CountryId = Convert.ToInt32(data[i].CountryId);
                    CountryModel countryModel = GetAllCountry().SingleOrDefault(x => x.Id == hotelView.CountryId);
                    hotelView.CountryName = countryModel.CountryName;
                    hotelView.CityId = Convert.ToInt32(data[i].CityId);
                    CityModel cityModel = GetAllCity().SingleOrDefault(x => x.Id == hotelView.CityId);
                    hotelView.CityName = cityModel.CityName;
                    hotelView.PricePerNight = Convert.ToDecimal(data[i].PricePerNight);
                    hotelView.DefaultCurrency = data[i].DefaultCurrency;
                    hotelList.Add(hotelView);
                }
                return hotelList;
            }
        }

        public string AddHotel(HotelModel model)
        {
            string result = string.Empty;
            using (HotelDBContext _hotelEntities = new HotelDBContext())
            {
                try
                {
                    Hotel hotel = new Hotel();
                    hotel.HotelName = model.HotelName;
                    hotel.Address = model.Address;
                    hotel.CityId = model.CityId;
                    hotel.CountryId = model.CountryId;
                    hotel.PhoneNumber = model.PhoneNumber;
                    hotel.Description = model.Description;
                    hotel.CancellationPolicy = model.CancellationPolicy;
                    hotel.DefaultCurrency = model.DefaultCurrency;
                    hotel.PricePerNight = model.PricePerNight;
                    hotel.CreatedOn = System.DateTime.Now.ToShortDateString();
                    _hotelEntities.Entry(hotel).State = System.Data.Entity.EntityState.Added;
                    _hotelEntities.SaveChanges();
                    result = "Record Inserted";
                }
                catch (Exception)
                {
                    result = "Failed To Insert";
                }
                return result;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public HotelModel GetHotelById(int hotelID)
        {
            using (HotelDBContext _hotelEntities = new HotelDBContext())
            {
                var data = _hotelEntities.Hotels.ToList();
                List<HotelModel> hotelList = new List<HotelModel>();
                for (var i = 0; i < data.Count; i++)
                {
                    HotelModel model = new HotelModel();
                    model.Id = data[i].Id;
                    model.HotelName = data[i].HotelName;
                    model.Address = data[i].Address;
                    model.CityId = data[i].CityId;
                    model.CountryId = data[i].CountryId;
                    model.PhoneNumber = data[i].PhoneNumber;
                    model.CancellationPolicy = data[i].CancellationPolicy;
                    model.Description = data[i].Description;
                    model.DefaultCurrency = data[i].DefaultCurrency;
                    model.PricePerNight = data[i].PricePerNight;
                    hotelList.Add(model);
                }
                HotelModel getHotelData = hotelList.SingleOrDefault(x => x.Id == hotelID);
                return getHotelData;
            }
        }

        public string UpdateHotel(HotelModel hotelModel)
        {
            string result = string.Empty;
            using (HotelDBContext _hotelEntities = new HotelDBContext())
            {
                try
                {
                    Hotel hotel = new Hotel();
                    hotel.Id = hotelModel.Id;
                    hotel.HotelName = hotelModel.HotelName;
                    hotel.Address = hotelModel.Address;
                    hotel.CityId = hotelModel.CityId;
                    hotel.CountryId = hotelModel.CountryId;
                    hotel.PhoneNumber = hotelModel.PhoneNumber;
                    hotel.Description = hotelModel.Description;
                    hotel.CancellationPolicy = hotelModel.CancellationPolicy;
                    hotel.DefaultCurrency = hotelModel.DefaultCurrency;
                    hotel.PricePerNight = hotelModel.PricePerNight;
                    hotel.ModifiedOn = System.DateTime.Now.ToShortDateString();

                    _hotelEntities.Hotels.Add(hotel);
                    _hotelEntities.Entry(hotel).State = System.Data.Entity.EntityState.Modified;
                    _hotelEntities.SaveChanges();
                    result = "Record Updated";
                }
                catch (Exception)
                {
                    result = "Failed To Upadate";
                }
                return result;
            }
        }

        public string DeleteHotel(int id)
        {
            string result = string.Empty;
            using (HotelDBContext _hotelEntities = new HotelDBContext())
            {
                try
                {
                    Hotel hotel = _hotelEntities.Hotels.Where(x => x.Id == id).FirstOrDefault<Hotel>();
                    _hotelEntities.Hotels.Remove(hotel);
                    _hotelEntities.SaveChanges();
                    result = "Record deleted";
                }
                catch (Exception)
                {
                    result = "Record failed to delete";
                }

                return result;
            }
        }

    }
}