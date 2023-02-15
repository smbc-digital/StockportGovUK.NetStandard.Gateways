using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking.Request;

public class PolicyRequest
{
    public Guid UserId { get; set; }
    public Policy Policy { get; set; }
}