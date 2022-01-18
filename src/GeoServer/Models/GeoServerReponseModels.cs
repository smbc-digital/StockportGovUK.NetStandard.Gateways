using System.Collections.Generic;
using Newtonsoft.Json;

namespace StockportGovUK.NetStandard.Gateways.GeoServer.Models
{
    public class GeoServerResponseModel
    {
        [JsonProperty("features")]
        public List<BinCalendarFeature> Features { get; set; }
    }

    public class BinCalendarFeature
    {
        [JsonProperty("properties")]
        public BinCalendarProperties Properties { get; set; } 
    }

    public class BinCalendarProperties
    {
        [JsonProperty("calendarcode")]
        public string CalendarCode { get; set; } 
    }
}