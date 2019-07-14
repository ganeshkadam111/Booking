using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelBooking.Common;
using HotelBooking.HotelEdmx;
using HotelBooking.Models;

namespace HotelBooking.Repository
{
    public class TravellerRepository:ITravellerRepository
    {
       

        public string AddTraveller(TravellerModel travellerModel)
        {
            string result = string.Empty;
            using (HotelDBContext travellerEntities = new HotelDBContext())
            {
                try
                {
                    Traveller traveller = new Traveller();
                    traveller.FirstName = travellerModel.FirstName;
                    traveller.MiddleName = travellerModel.MiddleName;
                    traveller.LastName = travellerModel.LastName;
                    traveller.MobileNo = travellerModel.MobileNo;
                    traveller.EmailId = travellerModel.EmailId;
                    traveller.Gender = travellerModel.Gender;
                    traveller.Address = travellerModel.Address;
                    traveller.FirstName_2 = travellerModel.FirstName_2;
                    traveller.MiddleName_2 = travellerModel.MiddleName_2;
                    traveller.LastName_2 = travellerModel.LastName_2;
                    traveller.CreatedOn= System.DateTime.Now.ToShortDateString();
                    travellerEntities.Entry(traveller).State = System.Data.Entity.EntityState.Added;
                    travellerEntities.SaveChanges();
                    result = "Record Inserted";
                }
                catch (Exception ex)
                {
                    Log.Error("Failed To Insert", ex);
                    result = "Failed To Insert";
                }
                return result;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}