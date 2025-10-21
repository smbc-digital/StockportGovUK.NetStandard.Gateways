using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
        public IEnumerable<HeaderEntry> Headers { get; set; } = Enumerable.Empty<HeaderEntry>();
        public int TimeoutInSeconds { get; set; } = 60;
        public int Retries { get; set; } = 2;

    }

    public class HeaderEntry
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
