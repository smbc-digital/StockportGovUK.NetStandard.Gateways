using System.ComponentModel.DataAnnotations;
using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking.Request;

public class TimePeriodPolicyRequest
{
    public Guid UserId { get; set; }

    [Required]
    public TimePeriodPolicy TimePeriodPolicy { get; set; }
}