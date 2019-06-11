using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.AspNetCore.Gateways.Response;

namespace StockportGovUK.AspNetCore.Gateways.BinsService
{
    public class BinsServiceGateway : Gateway, IBinsServiceGateway
    {
        private const string HttpClientName = "binsGateway";

        public BinsServiceGateway(IHttpClientFactory clientFactory) : base(clientFactory)
        {

        }

        public async Task<HttpResponse<T>> GetCollectionsAsync<T>(string uprn)
        {
            return await GetAsync<T>(HttpClientName, $"v1/gis/{uprn}");
        }

        public async Task<HttpResponse<T>> GetCalendarAsync<T>(string uprn)
        {
            return await GetAsync<T>(HttpClientName, $"v1/gis/{uprn}/calendar");
        }
    }
}