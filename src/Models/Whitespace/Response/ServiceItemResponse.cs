using System.Collections.Generic;

namespace StockportGovUK.NetStandard.Gateways.Models.Whitespace.Response;

public class ServiceItemResponse
{
    public IEnumerable<ServiceItem> ServiceItems { get; set; }
}
