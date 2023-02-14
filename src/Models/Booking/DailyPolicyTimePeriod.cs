using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking;

public class DailyPolicyTimePeriod
{
    public Guid DailyPolicyId { get; set; }
    public Guid TimePeriodPolicyId { get; set; }
}