using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StockportGovUK.NetStandard.Gateways.Models.Conesso
{
    public class ContactRequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [Required]
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("jobTitle")]
        public string JobTitle { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("address2")]
        public string Address2 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("county")]
        public string County { get; set; }

        [JsonProperty("postcode")]
        public string Postcode { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; } = "GBR";

        [JsonProperty("country")]
        public string Country { get; set; } = "United Kingdom";

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("tags")]
        public string Tags { get; set; }

        [JsonProperty("customValues")]
        public List<KeyValuePair<string, string>> CustomValues { get; set; } = new List<KeyValuePair<string, string>>();

        [Required]
        [JsonProperty("optInStatus")]
        public string OptInStatus { get; set; }

        [Required]
        [JsonProperty("listIds")]
        public IEnumerable<int> ListIds { get; set; }
    }
}
