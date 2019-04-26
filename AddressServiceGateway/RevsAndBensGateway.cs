using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.AspNetCore.Gateways;

namespace StockportGovUK.AspNetCore.Gateways.AddressService
{
    public class RevsAndBensGateway : Gateway, IAddressServiceGateway
    {
        private const string HttpClientName = "civicaGateway";

        public RevsAndBensGateway(IHttpClientFactory clientFactory) : base(clientFactory)
        {

        }

        public async Task<HttpResponseMessage> GetAddressesAsync(string postcode)
        {
            return await GetAsync(HttpClientName, $"v1/civica/{postcode}");
        }

        public async Task<HttpResponseMessage> GetPropertyDetailsAsync(string uprn)
        {
            return await GetAsync(HttpClientName, $"v1/civica/properties/{uprn}");
        }
    }
}