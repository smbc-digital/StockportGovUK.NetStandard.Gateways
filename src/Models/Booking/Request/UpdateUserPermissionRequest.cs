using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking.Request;
public class UpdateUserPermissionRequest : BaseUserRequest
{
    public Guid ContextId { get; set; }
    public int Role { get; set; }
}
