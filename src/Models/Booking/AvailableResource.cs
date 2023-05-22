using System;
using System.Collections.Generic;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking;

public class AvailableResource
{
    public Guid Id { get; set; }

    public Guid? ResourceId { get; set; }

    public Resource Resource { get; set; }

    public Guid? TimePeriodPolicyId { get; set; }

    public TimePeriodPolicy TimePeriodPolicy { get; set; }

    public int Quantity { get; set; }

    public IList<Tuple<TimeSpan, int>> QuantityWithTime { get; set; }
}