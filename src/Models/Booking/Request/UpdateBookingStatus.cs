using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking.Request
{
    public class UpdateBookingStatus
    {
        public Guid BookingId { get; set; }
        public Guid StatusId { get; set; }
    }
}
