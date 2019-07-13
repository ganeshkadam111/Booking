using HotelBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Repository
{
    interface IPaymentRepository:IDisposable
    {
        IEnumerable<BookingModel> GetAllBooking();
        IEnumerable<PaymentViewModel> GetPaymentDetails();
        string AddPayment(PaymentModel paymentModel);
    }
}
