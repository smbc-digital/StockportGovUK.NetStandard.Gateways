using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StockportGovUK.NetStandard.Gateways.GeoServer.Models
{
    public class GeoServerResponseModel
    {
        [JsonPropertyName("features")]
        public List<BinCalendarFeature> Features { get; set; }
    }

    public class BinCalendarFeature
    {
        [JsonPropertyName("properties")]
        public BinCalendarProperties Properties { get; set; }
    }

    public class BinCalendarProperties
    {
        [JsonPropertyName("calendarcode")]
        public string CalendarCode { get; set; }
    }
}