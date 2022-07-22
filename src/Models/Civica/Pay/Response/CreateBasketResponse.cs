namespace StockportGovUK.NetStandard.Gateways.Models.Civica.Pay.Response
{
    public class CreateBasketResponse
    {
        public string BasketReference { get; set; }

        public string BasketToken { get; set; }

        public string Success { get; set; }

        public string ResponseCode { get; set; }

        public string ErrorMessage { get; set; }
    }
}