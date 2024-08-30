using System;
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
        public int Timeout { get; set; }
        public string ProxyUrl { get; set; }
        public int ProxyPort { get; set; }
        public IEnumerable<HeaderEntry> Headers { get; set; } = Enumerable.Empty<HeaderEntry>();

    }

    public class HeaderEntry
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
