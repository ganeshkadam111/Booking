using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBooking.Models
{
    public class PaymentViewModel:BaseModel
    {
        public int BookingId { get; set; }
        public  string InvoiceNumber { get; set; }
        public decimal? BuyingPrice { get; set; }
        public string BuyingCurrency { get; set; }
        public string Status { get; set; }
    }
}