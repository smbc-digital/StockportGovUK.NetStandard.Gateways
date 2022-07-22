namespace StockportGovUK.NetStandard.Gateways.Models.Civica.Pay.Response
{
    public class CatalogueItem
    {
        public string CatalogueReference { get; set; }

        public string ItemType { get; set; }

        public string ItemDescriptionKey { get; set; }

        public string FundCode { get; set; }

        public string DFES { get; set; }

        public string ItemCode { get; set; }

        public string FundGroup { get; set; }

        public int FundNumber { get; set; }

        public int Shop { get; set; }

        public string ShopCode { get; set; }

        public string ShopDescription { get; set; }

        public int Category { get; set; }

        public string CategoryCode { get; set; }

        public string FundName { get; set; }

        public string Description { get; set; }

        public string VatCode { get; set; }

        public int MaximumQuantity { get; set; }

        public double DefaultAmount { get; set; }

        public bool AmountAvailable { get; set; }

        public string NarrativeLabel { get; set; }

        public string ReferenceLabel { get; set; }

        public bool TrackQuantity { get; set; }

        public int QuantityAvailable { get; set; }

        public bool RequiresImmediatePayment { get; set; }

        public bool ExternalItem { get; set; }

        public string ExternalItemSystemURL { get; set; }
    }
}