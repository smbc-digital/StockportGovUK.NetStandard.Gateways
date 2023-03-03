using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking.Request;

public class AddNoteRequest
{
    public Guid UserId { get; set; }
    public Note Note { get; set; }
}