using StockportGovUK.NetStandard.Gateways.Models.Mail;

namespace StockportGovUK.NetStandard.Gateways.Models.CoronavirusIsolationPaymentMailModel
{
    public class CoronavirusIsolationPaymentMailModel : BaseMailModel
    {
        public string Reference { get; set; }
    }
}
