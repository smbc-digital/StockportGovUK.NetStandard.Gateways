using System.Collections;
using System.Collections.Generic;

namespace StockportGovUK.NetStandard.Gateways.Models.Conesso
{
    public class Contact
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string OptInStatus { get; set; }
        public IEnumerable<List> Lists { get; set; }
        public string Error { get; set; }
    }
}
