using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.NetStandard.Gateways.GeoServer
{
    public class GeoServerGateway : Gateway, IGeoServerGateway
    {
        public GeoServerGateway(HttpClient httpClient) : base(httpClient)
        {
            
        }

        public async Task<HttpResponseMessage> GetCollectionCalendarAsync(string uprn)
            => await GetAsync($"?service=wfs&version=1.0.0&request=getfeature&typename=bins%3Abin_calendar_lookup&outputFormat=json&propertyName=calendarcode&cql_filter=uprn%3D'{uprn}'");
    }
}