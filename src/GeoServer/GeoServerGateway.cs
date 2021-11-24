using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.GeoServer.Models;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.GeoServer
{
    public class GeoServerGateway : Gateway, IGeoServerGateway
    {
        public GeoServerGateway(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<HttpResponse<GeoServerResponseModel>> GetCollectionCalendarAsync(string uprn)
            => await GetAsync<GeoServerResponseModel>($"?service=wfs&version=1.0.0&request=getfeature&typename=bins%3Abin_calendar_lookup&outputFormat=json&propertyName=calendarcode&cql_filter=uprn%3D'{uprn}'");
    }
}