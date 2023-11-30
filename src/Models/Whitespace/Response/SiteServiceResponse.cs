using System.Collections.Generic;

namespace StockportGovUK.NetStandard.Gateways.Models.Whitespace.Response;
public class SiteServiceResponse
{
    public IEnumerable<SiteService> SiteServices { get; set; }
}
