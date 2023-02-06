using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking;

public class ForeignReference
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public string Reference { get; set; }
    public Guid? BookingId { get; set; }
}