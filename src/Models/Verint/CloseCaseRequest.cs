namespace StockportGovUK.NetStandard.Gateways.Models.Verint
{
    public class CloseCaseRequest
    {
        public string CaseReference { get; set; }

        public string ReasonTitle { get; set; }

        public string Description { get; set; }
    }
}