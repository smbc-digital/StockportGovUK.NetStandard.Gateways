using System.Collections.Generic;

namespace StockportGovUK.NetStandard.Gateways.Models.Civica.Pay.Response
{
    public class CatalogueItemListResponse
    {
        public bool IsOK { get; set; }

        public int ItemsPerPage { get; set; }

        public int TotalMatchingItems { get; set; }

        public int CurrentPageNumber { get; set; }

        public int TotalPageNumber { get; set; }

        public List<CatalogueItem> Items { get; set; }
    }
}