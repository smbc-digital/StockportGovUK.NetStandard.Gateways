using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StockportGovUK.AspNetCore.Gateways.Response;

namespace StockportGovUK.AspNetCore.Gateways
{
    public class Gateway : IGateway
    {
        private readonly IHttpClientFactory _clientFactory;

        public Gateway(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            var client = _clientFactory.CreateClient();
            return await client.GetAsync(url);
        }

        public async Task<HttpResponse<T>> GetAsync<T>(string name, string url)
        {
            var client = _clientFactory.CreateClient(name);
            var result = await client.GetAsync(url);
            var response = await HttpResponse<T>.Get(result);

            return response;
        }

        public async Task<HttpResponseMessage> PutAsync(string name, string url, HttpContent content)
        {
            var client = _clientFactory.CreateClient(name);
            return await client.PutAsync(url, content);
        }

        public async Task<HttpResponseMessage> PatchAsync(string name, string url, object content)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.ASCII, "application/json");

            var client = _clientFactory.CreateClient(name);
            return await client.PatchAsync(url, stringContent);
        }
    }
}