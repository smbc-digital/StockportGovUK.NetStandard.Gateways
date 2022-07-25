namespace StockportGovUK.NetStandard.Gateways.Models.Civica.Pay.Request
{
    public class AddItemRequest
    {
        public string CallingAppIdentifier { get; set; }

        public string BasketReference { get; set; }

        public string BasketToken { get; set; }

        public PaymentDetail PaymentDetails { get; set; }

        public AddressDetail AddressDetails { get; set; }
    }
}