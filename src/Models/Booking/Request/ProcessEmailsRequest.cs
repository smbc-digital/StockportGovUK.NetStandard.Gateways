using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking.Request;

public class ProcessEmailsRequest
{
    public Guid BookingId { get; set; }
}
