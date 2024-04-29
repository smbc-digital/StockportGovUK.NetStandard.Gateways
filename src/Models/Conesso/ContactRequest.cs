using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StockportGovUK.NetStandard.Gateways.Models.Conesso
{
    public class ContactRequest
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // PREFERRED NAME
        public string PhoneNumber { get; set; }
        public string Company { get; set; }
        public string JobTitle { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public string CountryCode { get; set; } = "GBR";
        public string Country { get; set; } = "United Kingdom";
        public string Website { get; set; }
        public string Gender { get; set; }
        public string Tags { get; set; }
        public List<KeyValuePair<string, string>> CustomValues { get; set; } = new List<KeyValuePair<string, string>>();
        [Required]
        public string OptInStatus { get; set; }
        [Required]
        public IEnumerable<int> ListIds { get; set; }
    }
}
