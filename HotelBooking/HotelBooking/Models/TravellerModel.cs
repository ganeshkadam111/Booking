using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBooking.Models
{
    public class TravellerModel: BaseModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }
        public string FirstName_2 { get; set; }
        public string MiddleName_2 { get; set; }
        public string LastName_2 { get; set; }

    }
}