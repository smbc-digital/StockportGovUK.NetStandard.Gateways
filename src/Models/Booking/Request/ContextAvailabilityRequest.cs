using System;
using System.ComponentModel.DataAnnotations;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking.Request;

public class ContextAvailabilityRequest
{
    [Required]
    public Guid ContextId { get; set; }
    public bool IsDisabled { get; set; } = true;
}