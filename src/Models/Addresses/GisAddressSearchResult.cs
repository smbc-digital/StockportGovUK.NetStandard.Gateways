namespace StockportGovUK.NetStandard.Gateways.Models.Addresses
{
    public class GisAddressSearchResult
    {
        public string UniqueId { get; set; }
        public string Parent { get; set; }
        public string DisplayName { get; set; }
        public string Type { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public string Rank { get; set; }
        public string Name { get; set; }
        public string Zoom { get; set; }
    }
}