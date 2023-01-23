using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking.Request
{
    public class GetByDateRequest
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }
    }
}
