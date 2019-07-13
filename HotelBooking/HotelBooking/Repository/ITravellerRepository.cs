﻿using HotelBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Repository
{
    interface ITravellerRepository:IDisposable
    {
        string AddTraveller(TravellerModel travellerModel);
    }
}
