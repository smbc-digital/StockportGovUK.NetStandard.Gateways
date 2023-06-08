using StockportGovUK.NetStandard.Gateways.Enums;

namespace StockportGovUK.NetStandard.Gateways.Models.Verint;
public class LinkCaseRequest
{
    public long CaseReference { get; set; }
    public long TargetCaseReference { get; set; }
    public ELinkType LinkType { get; set; }
}
