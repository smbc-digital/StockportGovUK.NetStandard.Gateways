using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking;

public class ResourceModifier
{
    public Guid Id { get; set; }
    public int Value { get; set; }
    public DateTime From { get; set; }
    public DateTime? Until { get; set; }
    public bool IsCancelled { get; set; }
    public string Notes { get; set; }
    public Guid? ResourceId { get; set; }
    public string ResourceName { get; set; }
    public TimeSpan FromTime { get; set; }
    public TimeSpan UntilTime { get; set; }
    public int ResourceDisplayOrder { get; set; }
}