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

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; } = "GBR";

        [JsonProperty("country")]
        public string Country { get; set; } = "United Kingdom";

        [JsonProperty("optInStatus")]
        public string OptInStatus { get; set; } = "subscribed";

        [JsonProperty("listIds")]
        public IEnumerable<int> ContactListIds { get; set; } = new List<int>();

        public int ContactListId { get; set; }
    }
}
