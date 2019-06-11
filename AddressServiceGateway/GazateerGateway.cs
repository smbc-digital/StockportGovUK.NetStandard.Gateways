using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.AspNetCore.Gateways;
using StockportGovUK.AspNetCore.Gateways.Response;

namespace StockportGovUK.AspNetCore.Gateways.AddressService
{
    public class GazateerGateway : Gateway, IAddressServiceGateway
    {
        private const string HttpClientName = "addressGateway";

        public GazateerGateway(IHttpClientFactory clientFactory) : base(clientFactory)
        {

        }

        public async Task<HttpResponse<T>> GetAddressesAsync<T>(string postcode)
        {
            return await GetAsync<T>(HttpClientName, $"v1/gis/{postcode}");
        }

        public async Task<HttpResponse<T>> GetPropertyDetailsAsync<T>(string uprn)
        {
            return await GetAsync<T>(HttpClientName, $"v1/gis/properties/{uprn}");
        }
    }
}