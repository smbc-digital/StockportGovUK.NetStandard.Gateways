using System;
using System.ComponentModel.DataAnnotations;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking.Request;

public class ContextRequest
{
    public Guid UserId { get; set; }

    [Required]
    public Context Context { get; set; }
}