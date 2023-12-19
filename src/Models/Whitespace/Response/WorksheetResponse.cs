using System.Collections.Generic;

namespace StockportGovUK.NetStandard.Gateways.Models.Whitespace.Response;
public class WorksheetResponse
{
    public IEnumerable<Worksheet> Worksheets { get; set; }
}
