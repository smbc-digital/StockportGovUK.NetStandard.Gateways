using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking.Request;

public class CancelBookingRequest
{
    public Guid BookingId { get; set; }
    public string Reason { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; }
}
