namespace StockportGovUK.NetStandard.Gateways.Extensions.Models
{
    public class HttpClientConfiguration
    {
        public string BaseUrl { get; set; }
        public string AuthToken { get; set; }
        public bool EnablePollyPolicies { get; set; } = true;
    }
}
