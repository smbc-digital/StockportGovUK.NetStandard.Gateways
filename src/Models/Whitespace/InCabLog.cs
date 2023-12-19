using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Whitespace;
public class InCabLog
{
    public int Id { get; set; }
    public DateTime LogDate { get; set; }
    public string ContractId { get; set; }
    public string StreetName { get; set; }
    public string Usrn { get; set; }
    public int SiteId { get; set; }
    public int AccountSiteId { get; set; }
    public string Uprn { get; set; }
    public string SiteAddress { get; set; }
    public string Reason { get; set; }
    public string Round { get; set; }
}
