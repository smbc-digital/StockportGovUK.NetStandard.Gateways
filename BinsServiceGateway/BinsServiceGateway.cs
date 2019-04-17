using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.AspNetCore.Gateways;

namespace StockportGovUK.AspNetCore.Gateways.BinsService
{
    public class BinsServiceGateway : Gateway, IBinsServiceGateway
    {
        private const string HttpClientName = "binsGateway";

        public BinsServiceGateway(IHttpClientFactory clientFactory) : base(clientFactory)
        {

        }

        public async Task<HttpResponseMessage> GetCollectionsAsync(string uprn)
        {
            return await GetAsync(HttpClientName, $"v1/gis/{uprn}");
        }

        public async Task<HttpResponseMessage> GetCalendarAsync(string uprn)
        {
            return await GetAsync(HttpClientName, $"v1/gis/{uprn}/calendar");
        }
    }
}