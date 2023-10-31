using System;
using System.ComponentModel.DataAnnotations;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking.Request;

public class RescheduleBookingRequest
{
    [Required]
    public Guid BookingId { get; set; }
    public Guid UserId { get; set; }
    public DateTime NewStartDateTime { get; set; }
}
