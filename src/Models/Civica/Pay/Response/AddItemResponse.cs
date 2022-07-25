namespace StockportGovUK.NetStandard.Gateways.Models.Civica.Pay.Response
{
    public class AddItemResponse
    {
        public bool Success { get; set; }

        public int BasketItemReference { get; set; }

        public string ErrorMessage { get; set; }

        public string ResponseCode { get; set; }

        public string ErrorSummary { get; set; }

        public string FieldErrors { get; set; }

        public double BasketCurrentTotal { get; set; }

        public int BasketCurrentCount { get; set; }

        public string ResponseDescription { get; set; }
    }
}