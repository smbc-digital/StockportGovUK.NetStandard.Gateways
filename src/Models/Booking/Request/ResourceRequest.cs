using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking.Request;

public class ResourceRequest
{
    public Guid UserId { get; set; }

    public Resource Resource { get; set; }
}