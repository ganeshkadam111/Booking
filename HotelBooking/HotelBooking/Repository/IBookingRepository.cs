using HotelBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Repository
{
    interface IBookingRepository:IDisposable
    {
        IEnumerable<BookingViewModel> GetAllBookings();
        IEnumerable<HotelModel> GetAllHotel();
        IEnumerable<RoomTypeModel> GetAllRoomType();
        string AddBooking(BookingModel bookingModel);
    }
}
