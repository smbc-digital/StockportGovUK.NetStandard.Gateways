using System;
using System.Collections.Generic;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking;

public class DailyPolicy
{
    public Guid Id { get; set; }

    public Guid ContextId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public TimeSpan BookingLimit { get; set; }

    public TimeSpan MinAppointmentInterval { get; set; }

    public IEnumerable<DailyPolicyTimePeriod> DailyPolicyTimePeriods { get; set; }

    public List<TimePeriodPolicy> TimePeriodPolicies { get; set; }
}