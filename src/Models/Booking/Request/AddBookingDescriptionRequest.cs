using System;
using System.ComponentModel.DataAnnotations;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking.Request
{
    public class AddBookingDescriptionRequest
    {
        public AddBookingDescriptionRequest() { }

        public AddBookingDescriptionRequest(Guid bookingId, string description)
          => (BookingId, Description) = (bookingId, description);

        [Required]
        public Guid BookingId { get; set; }

        [Required]
        public string Description { get; set; }
    }
}