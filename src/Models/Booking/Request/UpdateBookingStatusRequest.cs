using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking.Request
{
    public class UpdateBookingStatusRequest
    {
        public Guid BookingId { get; set; }
        public Guid StatusId { get; set; }
    }
}
