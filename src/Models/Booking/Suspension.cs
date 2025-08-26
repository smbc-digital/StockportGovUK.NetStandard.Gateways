using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking;

public class Suspension
{
    public Guid Id { get; set; }

    public DateTime From { get; set; }

    public DateTime? Until { get; set; }

    public DateTime? EffectiveFrom { get; set; }

    public string AppointmentName { get; set; }

    public Guid AppointmentGuid { get; set; }

    public bool IsCancelled { get; set; }

    public int AppointmentDisplayOrder { get; set; }
}