using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Whitespace.Request;
public class CollectionRequest
{
    public string Uprn { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
}
