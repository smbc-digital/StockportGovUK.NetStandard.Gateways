namespace StockportGovUK.NetStandard.Gateways.Models.Civica.Pay.Request
{
    public class CreateBasketRequest : CreateBasketRequestBase
    {
        public string SiteName { get; set; }

        public string PaymentNotificationURL { get; set; }

        public bool ImmediateRedirect { get; set; }
    }
}
