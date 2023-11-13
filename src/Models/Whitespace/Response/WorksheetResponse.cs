using System;
using System.Collections.Generic;
using System.Text;

namespace StockportGovUK.NetStandard.Gateways.Models.Whitespace.Response;
public class WorksheetResponse
{
    public IEnumerable<Worksheet> Worksheets { get; set; }
}
