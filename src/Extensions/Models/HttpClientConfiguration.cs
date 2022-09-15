namespace StockportGovUK.NetStandard.Gateways.Extensions.Models
{
    public class HttpClientConfiguration
    {
        public string BaseUrl { get; set; }
        public string AuthToken { get; set; }
        public string Scheme { get; set; }
        public bool EnablePollyPolicies { get; set; } = true;
        public string ProxyUrl { get; set; }
        public int ProxyPort { get; set; }
    }
}
