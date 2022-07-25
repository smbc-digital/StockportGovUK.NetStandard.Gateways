namespace StockportGovUK.NetStandard.Gateways.Models.Civica.Pay.Request
{
    public class BasketSummaryRequest
    {
        public string BasketReference { get; set; }

        public string BasketToken { get; set; }

        public string ToQueryString()
        {
            return $"?basketReference={BasketReference}&basketToken={BasketToken}";
        }
    }
}