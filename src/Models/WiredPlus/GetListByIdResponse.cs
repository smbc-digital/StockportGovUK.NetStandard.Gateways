using System;
using System.Text.Json.Serialization;
using static StockportGovUK.NetStandard.Gateways.JsonConverters.DateTimeConverters;

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

        [JsonPropertyName("create_date")]
        [JsonConverter(typeof(DateTimeJsonConverterFrenchCanada))]
        public DateTime CreatedDate { get; set; }

        [JsonPropertyName("update_date")]
        [JsonConverter(typeof(DateTimeJsonConverterFrenchCanada))]
        public DateTime UpdatedDate { get; set; }

        [JsonPropertyName("contacts")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public int Contacts { get; set; }

        [JsonPropertyName("error")]
        public string Error { get; set; }
    }
}
