using System.Collections.Generic;

namespace StockportGovUK.NetStandard.Gateways.Models.Civica.Pay.Response
{
    public class FullBasketSummaryResponse : BasketSummaryResponse
    {
        public List<BasketItem> BasketItems { get; set; }
    }
}