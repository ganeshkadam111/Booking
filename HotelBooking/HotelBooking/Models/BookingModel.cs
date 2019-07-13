using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBooking.Models
{
    public class BookingModel:BaseModel
    {
        public string InvoiceNumber { get; set; }
        public int HotelId { get; set; }
        public int RoomId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string BookingDate { get; set; }
        public int? Adult { get; set; }
        public int? Children { get; set; }
        public decimal? BuyingPrice { get; set; }
        public string BuyingCurrency { get; set; }
    }
}