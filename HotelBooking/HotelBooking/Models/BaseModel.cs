﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBooking.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public string CreatedOn { get; set; }
        public string ModifiedOn { get; set; }
    }
}