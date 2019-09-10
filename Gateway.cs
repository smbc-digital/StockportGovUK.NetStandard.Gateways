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
        private readonly HttpClient _client;

        public Gateway(HttpClient client)
        {
            _client = client;
        }

        public Gateway(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await _client.GetAsync(url);
        }

        public async Task<HttpResponseMessage> GetAsync(string name, string url)
        {
            var client = _clientFactory.CreateClient(name);
            return await client.GetAsync(url);
        }

        public async Task<HttpResponse<T>> GetAsync<T>(string url)
        {
            var result = await _client.GetAsync(url);
            return await HttpResponse<T>.Get(result);
        }

        public async Task<HttpResponse<T>> GetAsync<T>(string name, string url)
        {
            var client = _clientFactory.CreateClient(name);
            var result = await client.GetAsync(url);
            return await HttpResponse<T>.Get(result);
        }

        public async Task<HttpResponseMessage> PutAsync(string name, string url, HttpContent content)
        {
            var client = _clientFactory.CreateClient(name);
            return await client.PutAsync(url, content);
        }

        public async Task<HttpResponseMessage> PutAsync(string url, HttpContent content)
        {
            return await _client.PutAsync(url, content);
        }
      
        public async Task<HttpResponseMessage> PatchAsync(string url, object content)
        {
            return await _client.PatchAsync(url, GetStringContent(content));
        }

        public async Task<HttpResponseMessage> PatchAsync(string name, string url, object content)
        {
            var client = _clientFactory.CreateClient(name);
            return await client.PatchAsync(url, GetStringContent(content));
        }

        public async Task<HttpResponse<T>> PatchAsync<T>(string url, object content)
        {
            var result = await _client.PatchAsync(url, GetStringContent(content));
            return await HttpResponse<T>.Get(result);
        }

        public async Task<HttpResponse<T>> PatchAsync<T>(string name, string url, object content)
        {
            var client = _clientFactory.CreateClient(name);
            var result = await client.PatchAsync(url, GetStringContent(content));
            return await HttpResponse<T>.Get(result);
        }

        public async Task<HttpResponse<T>> PostAsync<T>(string url, object content)
        {
            var result = await _client.PostAsync(url, GetStringContent(content));
            return await HttpResponse<T>.Get(result);
        }

        public async Task<HttpResponse<T>> PostAsync<T>(string name, string url, object content)
        {
            var client = _clientFactory.CreateClient(name);
            var result = await client.PostAsync(url, GetStringContent(content));
            return await HttpResponse<T>.Get(result);
        }

        public async Task<HttpResponseMessage> PostAsync(string url, object content)
        {
            return await _client.PostAsync(url, GetStringContent(content));
        }

        public async Task<HttpResponseMessage> PostAsync(string name, string url, object content)
        {
            var client = _clientFactory.CreateClient(name);
            return await client.PostAsync(url, GetStringContent(content));
        }

        private StringContent GetStringContent(object content)
        {
             return new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
        }
    }
}