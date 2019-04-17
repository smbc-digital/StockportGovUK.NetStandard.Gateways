using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.AspNetCore.Gateways
{
    public class Gateway : IGateway
    {
        private readonly IHttpClientFactory _clientFactory;

        public Gateway(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        protected async Task<HttpResponseMessage> GetAsync(string url)
        {
            var client = _clientFactory.CreateClient();
            return await client.GetAsync(url);
        }

        protected async Task<HttpResponseMessage> GetAsync(string name, string url)
        {
            var client = _clientFactory.CreateClient(name);
            return await client.GetAsync(url);
        }
    }
}