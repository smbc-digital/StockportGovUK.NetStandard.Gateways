using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking;

public class Status
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public bool IsSystemStatus { get; set; }

    public bool IsEnabled { get; set; }
}