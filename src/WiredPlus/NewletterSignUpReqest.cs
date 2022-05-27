using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StockportGovUK.NetStandard.Gateways.WiredPlus
{
    public class NewletterSignUpReqest
    {
        [Required]
        public string Email { get; set; }
        
        [Required]
        public int OptIn { get; set; } = 1;

        [Required]
        public int ContactListId {get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Company { get; set; }
        public string JobTitle { get; set; }
        public string Address { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; } = "United Kingdom";
        public string CountryCode { get; set; } = "GBR";
        public string WebAddress { get; set; }       
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Tags { get; set; }
        public List<KeyValuePair<string, string>> CustomValues { get; set; } = new List<KeyValuePair<string, string>>();
    }
}