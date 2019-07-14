using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelBooking.HotelEdmx;
using HotelBooking.Models;

namespace HotelBooking.Repository
{
    public class RoomRepository : IRoomRepository
    {

        public IEnumerable<AmenitiesModel> GetAllAmenities()
        {
            using (HotelDBContext _hotelEntities = new HotelDBContext())
            {
                var data = _hotelEntities.Amenities.ToList();
                List<AmenitiesModel> amenityList = new List<AmenitiesModel>();

                for (var i = 0; i < data.Count; i++)
                {
                    AmenitiesModel amenities = new AmenitiesModel();
                    amenities.Id = data[i].Id;
                    amenities.AmenityName = data[i].AmenityName;
                    amenityList.Add(amenities);
                }
                return amenityList;
            }
        }
        public IEnumerable<RoomTypeModel> GetAllRooms()
        {
            using (HotelDBContext _hotelEntities = new HotelDBContext())
            {
                var data = _hotelEntities.RoomTypes.ToList();
                List<RoomTypeModel> roomTypeList = new List<RoomTypeModel>();
                for (var i = 0; i < data.Count; i++)
                {
                    RoomTypeModel roomType = new RoomTypeModel();
                    roomType.Id = data[i].Id;
                    roomType.RoomName = data[i].RoomName;
                    roomType.Amenities = data[i].Amenities;
                    roomType.ImagePath = data[i].ImagePath;
                    roomTypeList.Add(roomType);
                }
                return roomTypeList;
            }
        }

        public string AddRoom(RoomTypeModel roomType)
        {
            string result = string.Empty;
            using (HotelDBContext _hotelEntities = new HotelDBContext())
            {
                try
                {
                    RoomType roomTbl = new RoomType();
                    roomTbl.RoomName = roomType.RoomName;
                    roomTbl.Amenities = roomType.Amenities;
                    roomTbl.ImagePath = roomType.ImagePath;
                    roomTbl.CreatedOn = System.DateTime.Now.ToShortDateString();
                    _hotelEntities.Entry(roomTbl).State = System.Data.Entity.EntityState.Added;
                    _hotelEntities.SaveChanges();
                    result = "Record Inserted";
                }
                catch (Exception)
                {
                    result = "Failed To Insert";
                }
                return result;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public RoomTypeModel GetRoomById(int roomID)
        {
            using (HotelDBContext _hotelEntities = new HotelDBContext())
            {
                var data = _hotelEntities.RoomTypes.ToList();
                List<RoomTypeModel> roomList = new List<RoomTypeModel>();
                for (var i = 0; i < data.Count; i++)
                {
                    RoomTypeModel model = new RoomTypeModel();
                    model.Id = data[i].Id;
                    model.RoomName = data[i].RoomName;
                    model.Amenities = data[i].Amenities;
                    roomList.Add(model);
                }
                RoomTypeModel getRoomData = roomList.SingleOrDefault(x => x.Id == roomID);
                return getRoomData;
            }

            
        
        }

        public string UpdateRoom(RoomTypeModel roomType)
        {
            string result = string.Empty;
            using (HotelDBContext _hotelEntities = new HotelDBContext())
            {
                try
                {
                    RoomType roomTbl = new RoomType();
                    roomTbl.Id = roomType.Id;
                    roomTbl.RoomName = roomType.RoomName;
                    roomTbl.Amenities = roomType.Amenities;
                    roomTbl.ImagePath = roomType.ImagePath;
                    roomTbl.ModifiedOn = System.DateTime.Now.ToShortDateString();
                    _hotelEntities.RoomTypes.Add(roomTbl);
                    _hotelEntities.Entry(roomTbl).State = System.Data.Entity.EntityState.Modified;
                    _hotelEntities.SaveChanges();
                    result = "Record Updated";
                }
                catch (Exception)
                {
                    result = "Failed To Upadate";
                }
                return result;
            }
        }

        public string DeleteRoom(int id)
        {
            string result = string.Empty;
            using (HotelDBContext _hotelEntities = new HotelDBContext())
            {
                try
                {
                    RoomType room = _hotelEntities.RoomTypes.Where(x => x.Id == id).FirstOrDefault<RoomType>();
                    _hotelEntities.RoomTypes.Remove(room);
                    _hotelEntities.SaveChanges();
                    result = "Record deleted";
                }
                catch (Exception)
                {
                    result = "Record failed to delete";
                }

                return result;
            }
        }
    }
}