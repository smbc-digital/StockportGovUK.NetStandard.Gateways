namespace StockportGovUK.NetStandard.Gateways.Models.Civica.Pay.Response
{
    public class CreateImmediateBasketResponse : CreateBasketResponse
    {
        public string ErrorSummary { get; set; }

        public dynamic FieldErrors { get; set; }
    }
}