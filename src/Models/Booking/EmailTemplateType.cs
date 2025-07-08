using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking;

public class EmailTemplateType
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}
