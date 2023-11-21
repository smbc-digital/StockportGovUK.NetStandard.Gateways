using StockportGovUK.NetStandard.Gateways.Enums.Whitespace;

namespace StockportGovUK.NetStandard.Gateways.Models.Whitespace.Request;

public class SiteWorksheetsRequest
{
    public string Uprn { get; set; }
    public EWorksheetSubject? WorksheetSubject { get; set; }
}
