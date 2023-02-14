using System;
using System.ComponentModel.DataAnnotations;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking.Request;

public class DailyPolicyRequest
{
    public Guid UserId { get; set; }

    [Required]
    public DailyPolicy DailyPolicy { get; set; }
}