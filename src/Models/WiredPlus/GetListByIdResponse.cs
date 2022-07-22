using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StockportGovUK.NetStandard.Gateways.Models.WiredPlus
{
    public class GetListByIdResponse
    {
        [JsonPropertyName("id")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("list_visibility")]
        public string ListVisibility { get; set; }

        [DataType("Date")]
        [JsonPropertyName("create_date")]
        public string CreatedDate { get; set; }

        [DataType("Date")]
        [JsonPropertyName("update_date")]
        public string UpdatedDate { get; set; }

        [JsonPropertyName("contacts")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public int Contacts { get; set; }

        [JsonPropertyName("error")]
        public string Error { get; set; }
    }
}
