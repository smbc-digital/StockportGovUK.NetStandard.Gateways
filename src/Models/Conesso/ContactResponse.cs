using System.Collections.Generic;

namespace StockportGovUK.NetStandard.Gateways.Models.Conesso
{
    public class ContactResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string OptInStatus { get; set; }
        public IEnumerable<ListResponse> Lists { get; set; }
        public string Error { get; set; }
        public IEnumerable<IEnumerable<string>> Message { get; set; }
    }
}
