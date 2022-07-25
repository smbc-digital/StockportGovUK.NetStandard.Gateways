namespace StockportGovUK.NetStandard.Gateways.Models.Civica.Pay.Response
{
    public class BasketSecurityDetailsResponse
    {
        public string BasketReference { get; set; }

        public string BasketToken { get; set; }

        public bool Success { get; set; }

        public string ErrorMessage { get; set; }

        public string ResponseCode { get; set; }
    }
}