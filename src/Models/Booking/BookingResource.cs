using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking;

public class BookingResource
{
    public Guid Id { get; set; }
    public Guid? ResourceId { get; set; }
    public int Quantity { get; set; }
    public Guid? BookingId { get; set; }
}