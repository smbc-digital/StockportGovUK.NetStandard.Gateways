using System;
using System.ComponentModel.DataAnnotations;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking.Request
{
    public class AddReferenceRequest
    {
        public AddReferenceRequest() { }

        public AddReferenceRequest(Guid bookingId, string reference)
          => (BookingId, Reference) = (bookingId, reference);

        public AddReferenceRequest(Guid bookingId, string reference, string description)
          => (BookingId, Reference, Description) = (bookingId, reference, description);

        public Guid BookingId { get; set; }

        [Required(ErrorMessage = "Reference is required")]
        public string Reference { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Description { get; set; }
    }
}