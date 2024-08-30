using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking.Request;

public class AddUserRequest
{
    public Guid Id { get; set; }
    public Guid ActiveDirectoryId { get; set; }
    public string ActiveDirectoryUsername { get; set; }
}
