namespace StockportGovUK.NetStandard.Gateways.Models.Uniform
{
    public class Payment
    {
        public string PaymentRef { get; set; }

        public string PaymentType { get; set; }

        public string OrderSrqNo { get; set; }

        public string CostCentre { get; set; }

        public string GlCode { get; set; }

        public decimal? Amount { get; set; }

        public string DiscountType { get; set; }

        public string DiscountRef { get; set; }

        public string PaymentCode { get; set; }

        public string AdditionalInformation { get; set; }
    }
}