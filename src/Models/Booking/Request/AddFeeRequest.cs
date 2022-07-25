using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking.Request
{
    public class AddFeeRequest
    {
        public AddFeeRequest() { }

        public AddFeeRequest(Guid bookingId, decimal feePaid)
          => (BookingId, FeePaid) = (bookingId, feePaid);

        public Guid BookingId { get; set; }

        public decimal FeePaid { get; set; }
    }
}