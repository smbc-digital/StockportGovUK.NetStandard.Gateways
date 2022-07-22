namespace StockportGovUK.NetStandard.Gateways.Models.Civica.Pay.Response
{
    public class BasketItem
    {
        public string ItemReference { get; set; }

        public int ItemId { get; set; }

        public double Amount { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public bool PaymentAllowed { get; set; }
    }
}