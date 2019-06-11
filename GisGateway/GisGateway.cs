using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.AspNetCore.Gateways.Response;

namespace StockportGovUK.AspNetCore.Gateways.Gis
{
    public class GisGateway : Gateway, IGisGateway
    {
        private const string HttpClientName = "gisGateway";

        public GisGateway(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }

        public async Task<HttpResponse<T>> GetPropertiesAsync<T>(string postcode)
        {
            return await GetAsync<T>(HttpClientName, $"?RequestType=LocationSearch&pagesize=150&startnum=1&mapsource=SMBC%2fMyHouse&location={postcode}");
        }

        public async Task<HttpResponse<T>> GetCollectionsAsync<T>(string uprn)
        {
            return await GetAsync<T>(HttpClientName, $"?format=json&RequestType=LocalInfo&mapsource=SMBC%2fMyHouse&group=Waste%20Collection&uid={uprn}");
        }

        public async Task<HttpResponse<T>> GetCalendarAsync<T>(string uprn)
        {
            return await GetAsync<T>(HttpClientName, $"?format=json&RequestType=LocalInfo&mapsource=SMBC%2fMyHouse&group=waste%20calendars&uid={uprn}");
        }
    }
}