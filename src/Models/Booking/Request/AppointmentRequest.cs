using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking.Request;

public class AppointmentRequest
{
    public Guid UserId { get; set; }

    public Appointment Appointment { get; set; }
}