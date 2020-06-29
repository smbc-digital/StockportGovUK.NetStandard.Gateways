using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.NetStandard.Gateways.Gis
{
    public class GisGateway : Gateway, IGisGateway
    {
        public GisGateway(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<HttpResponseMessage> GetPropertiesAsync(string postcode)
            => await GetAsync($"?RequestType=LocationSearch&pagesize=150&startnum=1&mapsource=SMBC%2fMyHouse&location={postcode}");

        public async Task<HttpResponseMessage> GetCollectionsAsync(string uprn)
            => await GetAsync($"?format=json&RequestType=LocalInfo&mapsource=SMBC%2fMyHouse&group=Waste%20Collection&uid={uprn}");

        public async Task<HttpResponseMessage> GetCalendarAsync(string uprn)
            => await GetAsync($"?format=json&RequestType=LocalInfo&mapsource=SMBC%2fMyHouse&group=waste%20calendars&uid={uprn}");
    }
}