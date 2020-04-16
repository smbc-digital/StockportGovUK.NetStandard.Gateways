using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Polly.CircuitBreaker;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways
{
    public class Gateway : IGateway, ITypedGateway
    {
        protected readonly HttpClient Client;
        private readonly ILogger<Gateway> _logger;

        public Gateway(HttpClient client, ILogger<Gateway> logger)
        {
            Client = client;
            _logger = logger;
        }

        public void ChangeAuthenticationHeader(string authHeader)
        {
            Client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(authHeader);
        }

        private async Task<T> InvokeAsync<T>(Func<string, Task<T>> function, string url, string requestType)
        {
            try
            {
                return await function(url);
            }
            catch (BrokenCircuitException<HttpResponseMessage> ex)
            {
                var errorMessage = string.IsNullOrEmpty(ex.Message) ? ex.InnerException?.Message : ex.Message;
                _logger.LogWarning(ex, errorMessage);
                throw new BrokenCircuitException($"{GetType().Name} => {requestType}({url}) - Circuit broken due to: '{errorMessage}'", ex);
            }
            catch (BrokenCircuitException ex)
            {
                var errorMessage = string.IsNullOrEmpty(ex.Message) ? ex.InnerException?.Message : ex.Message;
                _logger.LogWarning(ex, errorMessage);
                throw new BrokenCircuitException($"{GetType().Name} => {requestType}({url}) - Circuit broken due to: '{errorMessage}'", ex);
            }
            catch (Exception ex)
            {
                var errorMessage = string.IsNullOrEmpty(ex.Message) ? ex.InnerException?.Message : ex.Message;
                _logger.LogWarning(ex, errorMessage);
                throw new Exception($"{GetType().Name} => {requestType}({url}) - failed with the following error: '{errorMessage}'", ex);
            }
        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await InvokeAsync(async req => await Client.GetAsync(url), url, "GetAsync");
        }

        public async Task<HttpResponse<T>> GetAsync<T>(string url)
        {
            return await InvokeAsync(async req =>
            {
                var result = await Client.GetAsync(url);

                return await HttpResponse<T>.Get(result);
            }, url, "GetAsync");
        }

        public async Task<HttpResponseMessage> PatchAsync(object content)
        {
            return await PatchAsync(string.Empty, content, false);
        }

        public async Task<HttpResponseMessage> PatchAsync(string url, object content)
        {
            return await PatchAsync(url, content, false);
        }

        public async Task<HttpResponseMessage> PatchAsync(string url, object content, bool encodeContent)
        {
            var bodyContent = encodeContent
                ? GetStringContent(content)
                : (HttpContent)content;

            return await InvokeAsync(async req => await Client.SendAsync(new HttpRequestMessage
            {
                RequestUri = new Uri($"{Client.BaseAddress}{(!string.IsNullOrEmpty(url) && url.StartsWith("/") ? url.Substring(1) : url)}"),
                Method = new HttpMethod("PATCH"),
                Content = bodyContent
            }), url, "PatchAsync");
        }

        public async Task<HttpResponse<T>> PatchAsync<T>(string url, object content)
        {
            return await PatchAsync<T>(url, content, false);
        }

        public async Task<HttpResponse<T>> PatchAsync<T>(string url, object content, bool encodeContent)
        {
            var bodyContent = encodeContent
                   ? GetStringContent(content)
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
        {
            return await PostAsync(url, content, false);
        }

        public async Task<HttpResponseMessage> PostAsync(string url, object content, bool encodeContent)
        {
            var bodyContent = encodeContent
                    ? GetStringContent(content)
                    : (HttpContent)content;

            return await InvokeAsync(async req => await Client.PostAsync(url, bodyContent), url, "PostAsync");
        }

        public async Task<HttpResponse<T>> PostAsync<T>(string url, object content)
        {
            return await PostAsync<T>(url, content, false);
        }

        public async Task<HttpResponse<T>> PostAsync<T>(string url, object content, bool encodeContent)
        {
            var bodyContent = encodeContent
                   ? GetStringContent(content)
                   : (HttpContent)content;

            return await InvokeAsync(async req =>
            {
                var result = await Client.PostAsync(url, bodyContent);

                return await HttpResponse<T>.Get(result);
            }, url, "PostAsync");
        }

        public async Task<HttpResponseMessage> PutAsync(string url, HttpContent content)
        {
            return await InvokeAsync(async req => await Client.PutAsync(url, content), url, "PutAsync");
        }

        public async Task<HttpResponse<T>> PutAsync<T>(string url, object content)
        {
            return await PutAsync<T>(url, content, false);
        }

        public async Task<HttpResponse<T>> PutAsync<T>(string url, object content, bool encodeContent)
        {
            var bodyContent = encodeContent
                    ? GetStringContent(content)
                    : (HttpContent)content;

            return await InvokeAsync(async req => {
                var result = await Client.PutAsync(url, bodyContent);

                return await HttpResponse<T>.Get(result);
            }, url, "PutAsync");
        }

        public async Task<HttpResponseMessage> DeleteAsync(string url)
        {
            return await InvokeAsync(async req => await Client.DeleteAsync(url), url, "DeleteAsync");
        }

        public async Task<HttpResponse<T>> DeleteAsync<T>(string url)
        {
            return await InvokeAsync(async req =>
            {
                var result = await Client.DeleteAsync(url);

                return await HttpResponse<T>.Get(result);
            }, url, "DeleteAsync");
        }

        private StringContent GetStringContent(object content)
        {
            var serializedContent = JsonConvert.SerializeObject(content, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            return new StringContent(serializedContent, Encoding.UTF8, "application/json");
        }
    }
}