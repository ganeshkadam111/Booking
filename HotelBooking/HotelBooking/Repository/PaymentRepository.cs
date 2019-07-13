using HotelBooking.HotelEdmx;
using HotelBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBooking.Repository
{
    public class PaymentRepository : IPaymentRepository
    {

        

        public IEnumerable<BookingModel> GetAllBooking()
        {
            using (HotelDBContext _hotelEntities = new HotelDBContext())
            {
                var data = _hotelEntities.Bookings.ToList();
                List<BookingModel> bookingList = new List<BookingModel>();

                for (var i = 0; i < data.Count; i++)
                {
                    BookingModel booking = new BookingModel();
                    booking.Id = data[i].Id;
                    booking.InvoiceNumber = data[i].InvoiceNumber;
                    booking.BuyingPrice = data[i].BuyingPrice;
                    booking.BuyingCurrency = data[i].BuyingCurrency;
                    bookingList.Add(booking);
                }
                return bookingList;
            }
        }

        public IEnumerable<PaymentViewModel> GetPaymentDetails()
        {
            using (HotelDBContext _hotelEntities = new HotelDBContext())
            {
                var data = _hotelEntities.Payments.ToList();
                List<PaymentViewModel>paymentList = new List<PaymentViewModel>();
                for (var i = 0; i < data.Count; i++)
                {
                    PaymentViewModel paymentView = new PaymentViewModel();
                    paymentView.Id = data[i].Id;
                    paymentView.Status = data[i].Status;
                    paymentView.BookingId = Convert.ToInt32(data[i].BookingId);
                    BookingModel bookingModel = GetAllBooking().SingleOrDefault(x => x.Id == paymentView.BookingId);
                    paymentView.InvoiceNumber = bookingModel.InvoiceNumber;
                    paymentView.BuyingPrice= bookingModel.BuyingPrice;
                    paymentView.BuyingCurrency = bookingModel.BuyingCurrency;
                    paymentList.Add(paymentView);
                }
                return paymentList;
            }
        }
        public string AddPayment(PaymentModel model)
        {
            string result = string.Empty;
            using (HotelDBContext dBEntities = new HotelDBContext())
            {
                try
                {
                    Payment paymentTbl = new Payment();
                    paymentTbl.BookingId = model.BookingId;
                    paymentTbl.CardNumber = model.CardNumber;
                    paymentTbl.NameOnCard = model.NameOnCard;
                    paymentTbl.ExpiryDate = model.ExpiryDate;
                    paymentTbl.Status = model.Status;
                    paymentTbl.CreatedOn = System.DateTime.Now.ToShortDateString();
                    paymentTbl.ModifiedOn = System.DateTime.Now.ToShortDateString();
                    dBEntities.Entry(paymentTbl).State = System.Data.Entity.EntityState.Added;
                    dBEntities.SaveChanges();
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
    }
}