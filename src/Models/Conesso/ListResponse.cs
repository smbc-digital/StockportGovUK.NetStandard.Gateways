using System.Collections.Generic;

namespace StockportGovUK.NetStandard.Gateways.Models.Conesso
{
    public class ListResponse
    {
        public IEnumerable<List> Data { get; set; }
        public string Error { get; set; }
    }
}
