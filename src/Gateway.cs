using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Polly.CircuitBreaker;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways
{
    public class Gateway : IGateway, ITypedGateway
    {
        protected readonly HttpClient Client;

        public Gateway(HttpClient client)
        {
            Client = client;
        }

        public void ChangeAuthenticationHeader(string authHeader)
            => Client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(authHeader);

        
        public async Task<HttpResponseMessage> GetAsync(string url)
            => await InvokeAsync(async req => await Client.GetAsync(url), url, "GetAsync");

        public async Task<HttpResponse<T>> GetAsync<T>(string url)
            => await InvokeAsync(async req => await HttpResponse<T>.Get(await Client.GetAsync(url)), url, "GetAsync");

        public async Task<HttpResponseMessage> PatchAsync(object content)
            => await PatchAsync(string.Empty, content, true);

        public async Task<HttpResponseMessage> PatchAsync(string url, object content)
            => await PatchAsync(url, content, true);

        public async Task<HttpResponseMessage> PatchAsync(string url, object content, bool encodeContent)
        {
            HttpContent bodyContent = encodeContent
                ? GetHttpContent(content)
                : (HttpContent)content;

            return await InvokeAsync(async req => await Client.SendAsync(new HttpRequestMessage
            {
                RequestUri = new Uri($"{Client.BaseAddress}{(!string.IsNullOrEmpty(url) && url.StartsWith("/") ? url.Substring(1) : url)}"),
                Method = new HttpMethod("PATCH"),
                Content = bodyContent
            }), url, "PatchAsync");
        }

        public async Task<HttpResponse<T>> PatchAsync<T>(string url, object content)
            => await PatchAsync<T>(url, content, true);

        public async Task<HttpResponse<T>> PatchAsync<T>(string url, object content, bool encodeContent)
        {
            HttpContent bodyContent = encodeContent
                ? GetHttpContent(content)
                : (HttpContent)content;

            return await InvokeAsync(async req =>
            {
                var result = await Client.SendAsync(new HttpRequestMessage
                {
                    RequestUri = new Uri($@"{Client.BaseAddress}{(!string.IsNullOrEmpty(url) && url.StartsWith("/") ? url.Substring(1) : url)}"),
                    Method = new HttpMethod("PATCH"),
                    Content = bodyContent
                });

                return await HttpResponse<T>.Get(result);
            }, url, "PatchAsync");
        }

        public async Task<HttpResponseMessage> PostAsync(string url, object content)
            => await PostAsync(url, content, true);

        public async Task<HttpResponseMessage> PostAsync(string url, object content, bool encodeContent)
        {
            var bodyContent = encodeContent
                ? GetHttpContent(content)
                : (HttpContent)content;

            return await InvokeAsync(async req => await Client.PostAsync(url, bodyContent), url, "PostAsync");
        }

        public async Task<HttpResponseMessage> PostAsync(string url, object content, string key, string value)
        {

            var bodyContent = GetHttpContent(content);
                

            HttpRequestMessage message = new HttpRequestMessage
            {
                RequestUri = new Uri(url),
                Content = bodyContent,
                Method = HttpMethod.Post
            };

            message.Headers.Add(key, value);

            return await Client.SendAsync(message);
        }



        public async Task<HttpResponse<T>> PostAsync<T>(string url, object content)
            => await InvokeAsync(async req => await HttpResponse<T>.Get(await Client.PostAsync(url, GetHttpContent(content))), url, "PostAsync");

        public async Task<HttpResponse<T>> PostAsync<T>(string url, object content, bool encodeContent)
        {
            HttpContent bodyContent = encodeContent
                ? GetHttpContent(content)
                : (HttpContent)content;

            return await InvokeAsync(async req =>
            {
                var result = await Client.PostAsync(url, bodyContent);
                return await HttpResponse<T>.Get(result);
            }, url, "PostAsync");
        }

        public async Task<HttpResponseMessage> PutAsync(string url, HttpContent content)
            => await InvokeAsync(async req => await Client.PutAsync(url, content), url, "PutAsync");

        public async Task<HttpResponseMessage> PutAsync(string url, object content, bool encodeContent)
        {
            var bodyContent = encodeContent
                ? GetHttpContent(content)
                : (HttpContent)content;

            return await InvokeAsync(async req => await Client.PutAsync(url, bodyContent), url, "PutAsync");
        }

        public async Task<HttpResponse<T>> PutAsync<T>(string url, object content)
            => await PutAsync<T>(url, content, true);

        public async Task<HttpResponse<T>> PutAsync<T>(string url, object content, bool encodeContent)
        {
            HttpContent bodyContent = encodeContent
                ? GetHttpContent(content)
                : (HttpContent)content;

            return await InvokeAsync(async req => await HttpResponse<T>.Get(await Client.PutAsync(url, bodyContent)), url, "PutAsync");
        }

        public async Task<HttpResponseMessage> DeleteAsync(string url)
            => await InvokeAsync(async req => await Client.DeleteAsync(url), url, "DeleteAsync");

        public async Task<HttpResponse<T>> DeleteAsync<T>(string url)
            => await InvokeAsync(async req => await HttpResponse<T>.Get(await Client.DeleteAsync(url)), url, "DeleteAsync");

        private async Task<T> InvokeAsync<T>(Func<string, Task<T>> function, string url, string requestType)
        {
            try
            {
                return await function(url);
            }
            catch (Exception ex)
            {
                throw new BrokenCircuitException($"{GetType().Name} => {requestType}({Client.BaseAddress}{url}) - Circuit open", ex);
            }
        }

        private static HttpContent GetHttpContent(object content)
            => new StringContent(JsonConvert.SerializeObject(content, Formatting.Indented, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                }), Encoding.UTF8, "application/json");
    }
}