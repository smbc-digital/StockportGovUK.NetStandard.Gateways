using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking.Request;

public class NoteRequest
{
    public int BookingId { get; set; }
    public string Reason { get; set; }
    public Guid CreatedById { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
}
