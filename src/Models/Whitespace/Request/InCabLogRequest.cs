using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Whitespace.Request;
public class InCabLogRequest
{
    public string Uprn { get; set; }
    public string Usrn { get; set; }
    public DateTime? From { get; set; }
    public DateTime? To { get; set; }
}
