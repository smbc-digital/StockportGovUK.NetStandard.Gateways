using System.Collections.Generic;

namespace StockportGovUK.NetStandard.Gateways.Models.Conesso
{
    public class ContactResponse
    {
        public IEnumerable<Contact> Data {  get; set; }
        public string Error { get; set; }
        public IEnumerable<IEnumerable<string>> Message { get; set; }

    }
}
