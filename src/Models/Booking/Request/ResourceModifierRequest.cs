using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking.Request;
public class ResourceModifierRequest
{
    public Guid Id { get; set; }
    public int Value { get; set; }
    public DateTime From { get; set; }
    public DateTime Until { get; set; }
    public bool IsCancelled { get; set; }
    public string Notes { get; set; }
    public Guid? ResourceId { get; set; }
}
