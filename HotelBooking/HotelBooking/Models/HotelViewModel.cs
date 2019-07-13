using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBooking.Models
{
    public class HotelViewModel
    {
        public int Id { get; set; }
        public string HotelName { get; set; }
        public string Address { get; set; }
        public int? CityId { get; set; }
        public string CityName { get; set; }
        public int? CountryId { get; set; }
        public string CountryName { get; set; }
        public string PhoneNumber { get; set; }
        public string CancellationPolicy { get; set; }
        public string Description { get; set; }
        public string DefaultCurrency { get; set; }
        public decimal PricePerNight { get; set; }
    }
}