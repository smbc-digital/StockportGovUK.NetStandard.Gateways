using System;
using System.ComponentModel.DataAnnotations;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking.Request
{
    public class BookingRequest : BaseRequest
    {
        public BookingRequest() : base() { }

        public BookingRequest(Customer customer, DateTime startDateTime, Guid appointmentId)
          : base(appointmentId) => (Customer, StartDateTime) = (customer, startDateTime);

        [Required]
        public DateTime StartDateTime { get; set; }

        [Required]
        public Customer Customer { get; set; }

        public string AdditionalInformation { get; set; }
    }
}
