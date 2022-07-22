namespace StockportGovUK.NetStandard.Gateways.Models.Civica.Pay.Request
{
    public class BasketSecurityDetailsRequest
    {
        public string CallingAppIdentifier { get; set; }

        public string CustomerId { get; set; }

        public string ApiPassword { get; set; }

        public string UserName { get; set; }

        public string BasketReference { get; set; }
    }
}