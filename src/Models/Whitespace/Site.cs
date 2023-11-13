namespace StockportGovUK.NetStandard.Gateways.Models.Whitespace;
public class Site
{
    public int Id { get; set; }
    public string SiteName { get; set; }
    public string Prefix { get; set; }
    public string Name { get; set; }
    public string ShortAddress { get; set; }
    public string Number { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string Town { get; set; }
    public string City { get; set; }
    public string County { get; set; }
    public string Country { get; set; }
    public string PostCode { get; set; }
    public string SiteReference { get; set; }
    public int AccountId { get; set; }
    public int StreetId { get; set; }
    public string StreetName { get; set; }
    public bool IsContractSite { get; set; }
    public int SiteParentId { get; set; }
    public string SiteFullAddress { get; set; }
}
