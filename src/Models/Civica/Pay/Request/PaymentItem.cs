namespace StockportGovUK.NetStandard.Gateways.Models.Civica.Pay.Request
{
    public class PaymentItem
    {
        public PaymentDetail PaymentDetails { get; set; }

        public AddressDetail AddressDetails { get; set; }
    }
}