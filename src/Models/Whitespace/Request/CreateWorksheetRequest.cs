using System;
using System.Collections.Generic;

namespace StockportGovUK.NetStandard.Gateways.Models.Whitespace.Request;

public class CreateWorksheetRequest
{
    public string Uprn { get; set; }
    public int ServiceId { get; set; }
    public string CaseReference { get; set; }
    public string Message { get; set; }
    public DateTime StartDate { get; set; }
    public IEnumerable<ServiceItemRequest> ServiceItems { get; set; }
    public IEnumerable<ServicePropertyRequest> ServiceProperties { get; set; }
    public int AdHocRoundId { get; set; }
}
