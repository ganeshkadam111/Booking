//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelBooking.HotelEdmx
{
    using System;
    using System.Collections.Generic;
    
    public partial class Booking
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public Nullable<int> HotelId { get; set; }
        public Nullable<int> RoomId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string BookingDate { get; set; }
        public Nullable<int> Adult { get; set; }
        public Nullable<int> Children { get; set; }
        public Nullable<decimal> BuyingPrice { get; set; }
        public string BuyingCurrency { get; set; }
        public string CreatedOn { get; set; }
        public string ModifiedOn { get; set; }
    }
}
