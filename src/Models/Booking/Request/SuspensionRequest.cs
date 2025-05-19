using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking.Request;
public class SuspensionRequest
{
    public Guid Id { get; set; }
    public DateTime From { get; set; }
    public DateTime Until { get; set; }
    public bool IsCancelled { get; set; }
    public Guid AppointmentId { get; set; }
}
