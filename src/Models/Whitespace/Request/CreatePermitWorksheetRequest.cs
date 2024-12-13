using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Whitespace.Request;
public class CreatePermitWorksheetRequest
{
    public CreateWorksheetRequest CreateWorksheetRequest { get; set; }
    public DateTime? EndDate { get; set; }
    public string Quantity { get; set; }
    public Verint.Address Address { get; set; }
}
