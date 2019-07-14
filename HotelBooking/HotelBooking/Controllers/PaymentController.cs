using HotelBooking.Models;
using HotelBooking.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelBooking.Controllers
{
    public class PaymentController : Controller
    {
        private IPaymentRepository repository = null;

        public PaymentController()
        {
            this.repository = new PaymentRepository();
        }

        // GET: Payment

        [HttpGet]
        public ActionResult PaymentDetails()
        {
            IEnumerable<PaymentViewModel> model = repository.GetPaymentDetails();
            return View(model);
        }
        public JsonResult GetBooking()
        {
            IEnumerable<BookingModel> listBooking = repository.GetAllBooking();
            return Json(listBooking, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddPayment()
        {
            return View();
        }

       [HttpPost]
        public JsonResult AddPayment(PaymentModel model)
        {
            string data = repository.AddPayment(model);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}