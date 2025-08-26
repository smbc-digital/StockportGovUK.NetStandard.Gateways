using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking;
public class MetaDataDropdown
{
    public Guid Id { get; set; }
    public string Value { get; set; }
    public bool IsActive { get; set; }
    public Guid? MetaDataFieldId { get; set; }
}
