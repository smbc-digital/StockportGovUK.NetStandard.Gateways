namespace StockportGovUK.NetStandard.Gateways.Models.Civica.Pay.Request
{
    public class RemoveItemRequest
    {
        public string BasketReference { get; set; }

        public string BasketToken { get; set; }

        public int BasketItemId { get; set; }
    }
}