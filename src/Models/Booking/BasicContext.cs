using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking;

public class BasicContext
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
}