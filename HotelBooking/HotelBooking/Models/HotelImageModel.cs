using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBooking.Models
{
    public class HotelImageModel : BaseModel
    {
        public string ImagePath { get; set; }
        public int? HotelId { get; set; }
    }
}