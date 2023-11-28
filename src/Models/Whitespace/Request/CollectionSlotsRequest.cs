using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Whitespace.Request;

public class CollectionSlotsRequest
{
    public string Uprn { get; set; }
    public int ServiceId { get; set; }
    public DateTime? SearchToDate { get; set; }
}
