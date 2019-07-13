using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBooking.Models
{
    public class CityModel
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public int? CountryId { get; set; }
    }
}