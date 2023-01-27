using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking;

public class MetaDataField
{
    public Guid Id { get; set; }
    public string Key { get; set; }
    public string Name { get; set; }
    public int Type { get; set; }
    public bool IsMandatory { get; set; }
    public bool IsActive { get; set; }
    public Guid? AppointmentId { get; set; }
    public int SortOrder { get; set; }
}