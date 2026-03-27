using System.Collections.Generic;

namespace StockportGovUK.NetStandard.Gateways.Models.AdvicePro;

public class PostResponse
{
    public int HttpStatusCode { get; set; }
    public List<string> Messages { get; set; }
    public int Identifier { get; set; }
}
