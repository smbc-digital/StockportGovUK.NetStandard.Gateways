using System.Text.Json.Serialization;

namespace StockportGovUK.NetStandard.Gateways.Models.BinCollections
{
    public class BinCollectionsResponse
    {
        [JsonPropertyName("Blue_Bin_Collection")]
        public string BlueBinCollection { get; set; }

        [JsonPropertyName("Brown_Bin_Collection")]
        public string BrownBinCollection { get; set; }

        [JsonPropertyName("Black_Bin_Collection")]
        public string BlackBinCollection { get; set; }

        [JsonPropertyName("Green_Bin_Collection")]
        public string GreenBinCollection { get; set; }
    }
}