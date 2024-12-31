namespace StockportGovUK.NetStandard.Gateways.Models.Whitespace.Request;

public class UpdateSiteServiceItemRequest
{
    public string SiteServiceId { get; set; }
    public string ItemQuantity { get; set; }
    public string ValidFromDate { get; set; }
    public string ValidToDate { get; set; }
    public string ChargeTypeId { get; set; }
}
