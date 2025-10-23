using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Whitespace.Request;
public class CreatePermitWorksheetRequest
{
    public CreateWorksheetRequest CreateWorksheetRequest { get; set; }
    public DateTime EndDate { get; set; }
    public int Quantity { get; set; }
    public Verint.Address Address { get; set; }
    public Verint.Address DeliveryAddress { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
    public ExistingSiteService ExistingSiteService { get; set; }
}

public class ExistingSiteService
{
    public int ExistingItemQuantity { get; set; }
    public int SiteServiceId { get; set; }
    public DateTime ExistingSiteServiceValidFrom { get; set; }
    public DateTime ExistingSiteServiceValidTo { get; set; }
}
