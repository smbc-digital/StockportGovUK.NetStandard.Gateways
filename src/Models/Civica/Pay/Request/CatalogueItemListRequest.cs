namespace StockportGovUK.NetStandard.Gateways.Models.Civica.Pay.Request
{
    public class CatalogueItemListRequest
    {
        public CatalogueItemListRequest()
        {
            LanguageName = string.Empty;
            CategoryFilter = 0;
            ShopFilter = 0;
            Search = string.Empty;
            NumberOfItems = 100;
            PageNumber = 1;
            FundCode = string.Empty;
            CatalogueItemReference = string.Empty;
        }

        public string LanguageName { get; set; }

        public int CategoryFilter { get; set; }

        public int ShopFilter { get; set; }

        public string Search { get; set; }

        public int NumberOfItems { get; set; }

        public int PageNumber { get; set; }

        public string FundCode { get; set; }

        public string CatalogueItemReference { get; set; }

        public string ToQueryString()
        {
            return $"?LanguageName={LanguageName}&CategoryFilter={CategoryFilter}&ShopFilter={ShopFilter}&Search={Search}&NumberOfItems={NumberOfItems}&PageNumber={PageNumber}&FundCode={FundCode}&CatalogueItemReference={CatalogueItemReference}";
        }
    }
}