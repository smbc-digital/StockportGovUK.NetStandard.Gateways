using StockportGovUK.NetStandard.Gateways.Models.Verint.Enums;

namespace StockportGovUK.NetStandard.Gateways.Models.Verint;
public class ReopenCaseRequest
{
    public EAllocationType AllocationType { get; set; }
    public string CaseReference { get; set; }
    public string QueueOrUserName { get; set; }
    public string Reason { get; set; }
}
