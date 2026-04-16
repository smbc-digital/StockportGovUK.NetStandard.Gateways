using System.Collections.Generic;

namespace StockportGovUK.NetStandard.Gateways.Models.AdvicePro;

public class GetResponse
{
    public int HttpStatusCode { get; set; }
    public List<string> Messages { get; set; }
    public object Model { get; set; }
}
