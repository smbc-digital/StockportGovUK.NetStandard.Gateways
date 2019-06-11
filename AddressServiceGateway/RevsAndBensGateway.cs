using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.AspNetCore.Gateways.AddressService;
using StockportGovUK.AspNetCore.Gateways.Response;

namespace StockportGovUK.AspNetCore.Gateways.AddressServicegateway
{
    public class RevsAndBensGateway : Gateway, IAddressServiceGateway
    {
        private const string HttpClientName = "civicaGateway";

        public RevsAndBensGateway(IHttpClientFactory clientFactory) : base(clientFactory)
        {

        }

        public async Task<HttpResponse<T>> GetAddressesAsync<T>(string postcode)
        {
            return await GetAsync<T>(HttpClientName, $"v1/civica/{postcode}");
        }

        public async Task<HttpResponse<T>> GetPropertyDetailsAsync<T>(string uprn)
        {
            return await GetAsync<T>(HttpClientName, $"v1/civica/properties/{uprn}");
        }
    }
}