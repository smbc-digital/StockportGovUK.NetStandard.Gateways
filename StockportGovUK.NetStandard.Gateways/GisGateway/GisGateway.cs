using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace StockportGovUK.NetStandard.Gateways.Gis
{
    public class GisGateway : Gateway, IGisGateway
    {
        private const string HttpClientName = "gisGateway";

        public GisGateway(HttpClient httpClient, ILogger<Gateway> logger) : base(httpClient, logger)
        {
        }

        public async Task<HttpResponseMessage> GetPropertiesAsync(string postcode)
        {
            return await GetAsync($"?RequestType=LocationSearch&pagesize=150&startnum=1&mapsource=SMBC%2fMyHouse&location={postcode}");
        }

        public async Task<HttpResponseMessage> GetCollectionsAsync(string uprn)
        {
            return await GetAsync($"?format=json&RequestType=LocalInfo&mapsource=SMBC%2fMyHouse&group=Waste%20Collection&uid={uprn}");
        }

        public async Task<HttpResponseMessage> GetCalendarAsync(string uprn)
        {
            return await GetAsync($"?format=json&RequestType=LocalInfo&mapsource=SMBC%2fMyHouse&group=waste%20calendars&uid={uprn}");
        }
    }
}