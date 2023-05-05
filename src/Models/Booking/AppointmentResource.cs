using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking;

public class AppointmentResource
{
    public Guid Id { get; set; }
    public int MinQuantity { get; set; }
    public Guid AppointmentId { get; set; }
    public Guid ResourceId { get; set; }
    public int MaxQuantity { get; set; }
    public string Name { get; set; }
}