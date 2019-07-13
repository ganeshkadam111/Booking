using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBooking.Models
{
    public class RoomTypeModel : BaseModel
    {
        public string RoomName { get; set; }
        public string Amenities { get; set; }
        public string ImagePath { get; set; }
    }
}