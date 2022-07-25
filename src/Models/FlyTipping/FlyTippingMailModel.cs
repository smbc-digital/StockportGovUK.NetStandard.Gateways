using StockportGovUK.NetStandard.Gateways.Models.Mail;

namespace StockportGovUK.NetStandard.Gateways.Models.FlyTipping
{
    public class FlyTippingMailModel : BaseMailModel
    {
        public string Reference { get; set; }
        public string StreetInput { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
