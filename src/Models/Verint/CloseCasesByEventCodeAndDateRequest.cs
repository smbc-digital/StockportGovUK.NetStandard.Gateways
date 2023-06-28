using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Verint;

public class CloseCasesByEventCodeAndDateRequest
{
    public int EventCode { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateUntil { get; set; }
}
