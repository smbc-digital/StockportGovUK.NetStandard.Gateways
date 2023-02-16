using System.Collections.Generic;
using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking;

public class TimePeriodPolicy
{
    public Guid Id { get; set; }

    public Guid ContextId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }

    public TimeSpan BookingLimit { get; set; }

    public TimeSpan MinAppointmentInterval { get; set; }

    public IEnumerable<AvailableResource> AvailableResources { get; set; }

    public IEnumerable<AvailableAppointment> AvailableAppointments { get; set; }
}