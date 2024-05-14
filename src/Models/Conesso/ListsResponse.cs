using System.Collections.Generic;

namespace StockportGovUK.NetStandard.Gateways.Models.Conesso
{
    public class ListsResponse
    {
        public IEnumerable<ListResponse> Data { get; set; }
        public string Error { get; set; }
        public IEnumerable<IEnumerable<string>> Message { get; set; }
    }
}
