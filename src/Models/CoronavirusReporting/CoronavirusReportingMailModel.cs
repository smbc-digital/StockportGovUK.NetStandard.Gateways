using StockportGovUK.NetStandard.Gateways.Models.Mail;

namespace StockportGovUK.NetStandard.Gateways.Models.CoronavirusReporting
{
    public class CoronavirusReportingMailModel : BaseMailModel
    {
        public string Reference { get; set; }
    }
}
