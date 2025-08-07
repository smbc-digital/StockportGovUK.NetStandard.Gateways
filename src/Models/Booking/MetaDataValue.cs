using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking;

public class MetaDataValue
{
    public Guid Id { get; set; }
    public string Value { get; set; }
    public DateTime DateTimeValue { get; set; }
    public int IntValue { get; set; }
    public Guid? BookingId { get; set; }
    public Guid? MetaDataFieldId { get; set; }
    public Guid? MetaDataDropDownId { get; set; }
}