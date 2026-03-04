using System;
using StockportGovUK.NetStandard.Gateways.Enums;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking.Response;

public class ContextUserResponse
{
    public Guid Id { get; set; }
    public string ActiveDirectoryUsername { get; set; }
    public DateTime LastLogin { get; set; }
    public EBookingUserRole Role { get; set; }
}
