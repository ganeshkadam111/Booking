using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelBooking.HotelEdmx;
using HotelBooking.Models;

namespace HotelBooking.Repository
{
    public class BookingRepository : IBookingRepository
    {
        public void Dispose()
        {
            throw new NotImplementedException();
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
                    hotelView.CancellationPolicy = data[i].CancellationPolicy;
                    hotelView.Description = data[i].Description;
                    hotelView.CountryId = Convert.ToInt32(data[i].CountryId);
                    hotelView.CityId = Convert.ToInt32(data[i].CityId);
                    hotelView.PricePerNight = Convert.ToDecimal(data[i].PricePerNight);
                    hotelView.DefaultCurrency = data[i].DefaultCurrency;
                    hotelList.Add(hotelView);
                }
                return hotelList;
            }
        }
    
        public IEnumerable<RoomTypeModel> GetAllRoomType()
        {
            using (HotelDBContext _hotelEntities = new HotelDBContext())
            {
                var data = _hotelEntities.RoomTypes.ToList();
                List<RoomTypeModel> roomList = new List<RoomTypeModel>();

                for (var i = 0; i < data.Count; i++)
                {
                    RoomTypeModel room = new RoomTypeModel();
                    room.Id = data[i].Id;
                    room.RoomName = data[i].RoomName;
                    roomList.Add(room);
                }
                return roomList;
            }

        }

        public IEnumerable<BookingViewModel> GetAllBookings()
        {
            using (HotelDBContext _hotelEntities = new HotelDBContext())
            {
                var data = _hotelEntities.Bookings.ToList();
                List<BookingViewModel> bookingList = new List<BookingViewModel>();
                for (var i = 0; i < data.Count; i++)
                {
                    BookingViewModel bookingView = new BookingViewModel();
                    bookingView.Id = data[i].Id;
                    bookingView.InvoiceNumber = data[i].InvoiceNumber;
                    bookingView.HotelId = Convert.ToInt32(data[i].HotelId);
                    bookingView.RoomId = Convert.ToInt32(data[i].RoomId);
                    RoomTypeModel roomModel = GetAllRoomType().SingleOrDefault(x => x.Id == bookingView.RoomId);
                    bookingView.FromDate = roomModel.RoomName;
                    bookingView.ToDate = roomModel.RoomName;
                    bookingView.BookingDate = roomModel.RoomName;
                    bookingView.Adult = data[i].Adult;
                    bookingView.Children = data[i].Children;
                    bookingView.BuyingPrice = data[i].BuyingPrice;
                    bookingList.Add(bookingView);
                }
                return bookingList;
            }
        }
        public string AddBooking(BookingModel model)
        {
            string result = string.Empty;
            using (HotelDBContext _hotelEntities = new HotelDBContext())
            {
                try
                {
                    Booking bookingTbl = new Booking();
                    bookingTbl.InvoiceNumber = model.InvoiceNumber;
                    bookingTbl.HotelId = model.HotelId;
                    bookingTbl.RoomId = model.RoomId;
                    bookingTbl.FromDate = model.FromDate;
                    bookingTbl.ToDate = model.ToDate;
                    bookingTbl.BookingDate = model.BookingDate;
                    bookingTbl.BuyingPrice = model.BuyingPrice;
                    bookingTbl.BuyingCurrency = model.BuyingCurrency;
                    bookingTbl.CreatedOn = System.DateTime.Now.ToShortDateString();
                   _hotelEntities.Entry(bookingTbl).State = System.Data.Entity.EntityState.Added;
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

    }
}