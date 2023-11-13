namespace StockportGovUK.NetStandard.Gateways.Models.Whitespace;
public class AccountSite
{
    public int Id { get; set; }
    public string Uprn { get; set; }
    public int NumberOfChildren { get; set; }
    public Site Site { get; set; }
}
