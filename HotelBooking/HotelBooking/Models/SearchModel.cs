using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBooking.Models
{
    public class SearchModel
    {
        public int HotelId { get; set; }
        public string searchValue { get; set; }
        public int RoomId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int Adult { get; set; }
        public int Children { get; set; }
        public int CalculatedNight { get; set; }
    }
}