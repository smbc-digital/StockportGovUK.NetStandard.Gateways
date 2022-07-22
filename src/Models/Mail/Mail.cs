using StockportGovUK.NetStandard.Gateways.Enums;

namespace StockportGovUK.NetStandard.Gateways.Models.Mail
{
    public class Mail
    {
        public string Payload { get; set; }

        public EMailTemplate Template { get; set; }
    }
}
