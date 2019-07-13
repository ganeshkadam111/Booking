using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBooking.Models
{
    public class PaymentModel: BaseModel 
    {
        public int BookingId { get; set; }
        public int CardNumber { get; set; }
        public string NameOnCard { get; set; }
        public string ExpiryDate { get; set; }
        public string Status { get; set; }
    }
}