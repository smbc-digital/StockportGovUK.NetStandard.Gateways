using System;
using System.Net;
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
        protected readonly HttpClient _client;
        private readonly ILogger<Gateway> _logger;

        public Gateway(HttpClient client, ILogger<Gateway> logger)
        {
            _client = client;
            _logger = logger;
        }

        public void ChangeAuthenticationHeader(string authHeader)
        {
            _client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(authHeader);
        }

        public async Task<T> InvokeAsync<T>(Func<string, Task<T>> function, string url, string requestType)
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
            return await InvokeAsync<HttpResponseMessage>(async requestUrl => await _client.GetAsync(requestUrl), url, "GetAsync");
        }

        public async Task<HttpResponse<T>> GetAsync<T>(string url)
        {
            return await InvokeAsync<HttpResponse<T>>(async requestUrl =>
            {
                var result = await _client.GetAsync(requestUrl);

                return await HttpResponse<T>.Get(result);
            }, url, "GetAsync");
        }

        // TODO: Should this be here? How does it work? Magnets.
        public async Task<HttpResponseMessage> PatchAsync(object content)
        {
            var bodyContent = GetStringContent(content);

            return await InvokeAsync<HttpResponseMessage>(async requestUrl =>
            {
                return await _client.SendAsync(new HttpRequestMessage
                {
                    Method = new HttpMethod("PATCH"),
                    Content = bodyContent
                });
            }, _client.BaseAddress.ToString(), "PatchAsync");
        }

        public async Task<HttpResponseMessage> PatchAsync(string url, object content)
        {
            var bodyContent = GetStringContent(content);

            return await InvokeAsync<HttpResponseMessage>(async requestUrl =>
            {
                return await _client.SendAsync(new HttpRequestMessage
                {
                    Method = new HttpMethod("PATCH"),
                    Content = bodyContent,
                    RequestUri = new Uri($"{_client.BaseAddress}{url}")
                });
            }, url, "PatchAsync");
        }

        public async Task<HttpResponseMessage> PatchAsync(string url, object content, bool encodeContent)
        {
            var bodyContent = encodeContent
                ? GetStringContent(content)
                : (HttpContent)content;

            return await InvokeAsync<HttpResponseMessage>(async requestUrl =>
            {
                return await _client.SendAsync(new HttpRequestMessage
                {
                    RequestUri = new Uri($"{_client.BaseAddress}{url}"),
                    Method = new HttpMethod("PATCH"),
                    Content = bodyContent
                });
            }, url, "PatchAsync");
        }

        public async Task<HttpResponse<T>> PatchAsync<T>(string url, object content)
        {
            var bodyContent = GetStringContent(content);

            return await InvokeAsync<HttpResponse<T>>(async requestUrl =>
            {
                var result = await _client.SendAsync(new HttpRequestMessage
                {
                    RequestUri = new Uri($"{_client.BaseAddress}{url}"),
                    Method = new HttpMethod("PATCH"),
                    Content = bodyContent
                });

                return await HttpResponse<T>.Get(result);
            }, url, "PatchAsync");
        }

        public async Task<HttpResponse<T>> PatchAsync<T>(string url, object content, bool encodeContent)
        {
            var bodyContent = encodeContent
                   ? GetStringContent(content)
                   : (HttpContent)content;

            return await InvokeAsync<HttpResponse<T>>(async requestUrl =>
            {
                var result = await _client.SendAsync(new HttpRequestMessage
                {
                    RequestUri = new Uri($"{_client.BaseAddress}{url}"),
                    Method = new HttpMethod("PATCH"),
                    Content = bodyContent
                });

                return await HttpResponse<T>.Get(result);
            }, url, "PatchAsync");
        }

        public async Task<HttpResponseMessage> PostAsync(string url, object content)
        {
            var bodyContent = GetStringContent(content);

            return await InvokeAsync<HttpResponseMessage>(async requestUrl =>
            {
                return await _client.PostAsync(url, bodyContent);
            }, url, "PostAsync");
        }

        public async Task<HttpResponseMessage> PostAsync(string url, object content, bool encodeContent)
        {
            var bodyContent = encodeContent
                    ? GetStringContent(content)
                    : (HttpContent)content;

            return await InvokeAsync<HttpResponseMessage>(async requestUrl =>
            {
                return await _client.PostAsync(url, bodyContent);
            }, url, "PostAsync");
        }

        public async Task<HttpResponse<T>> PostAsync<T>(string url, object content)
        {
            var bodyContent = GetStringContent(content);

            return await InvokeAsync<HttpResponse<T>>(async requestUrl =>
            {
                var result = await _client.PostAsync(url, bodyContent);

                return await HttpResponse<T>.Get(result);
            }, url, "PostAsync");
        }

        public async Task<HttpResponse<T>> PostAsync<T>(string url, object content, bool encodeContent)
        {
            var bodyContent = encodeContent
                   ? GetStringContent(content)
                   : (HttpContent)content;

            return await InvokeAsync<HttpResponse<T>>(async requestUrl =>
            {
                var result = await _client.PostAsync(url, bodyContent);

                return await HttpResponse<T>.Get(result);
            }, url, "PostAsync");
        }

        public async Task<HttpResponseMessage> PutAsync(string url, HttpContent content)
        {
            return await InvokeAsync<HttpResponseMessage>(async requestUrl =>
            {
                return await _client.PutAsync(url, content);
            }, url, "PutAsync");
        }

        public async Task<HttpResponse<T>> PutAsync<T>(string url, object content)
        {
            var bodyContent = GetStringContent(content);

            return await InvokeAsync<HttpResponse<T>>(async requestUrl =>
            {
                var result = await _client.PutAsync(url, bodyContent);

                return await HttpResponse<T>.Get(result);
            }, url, "PutAsync");
        }

        public async Task<HttpResponse<T>> PutAsync<T>(string url, object content, bool encodeContent)
        {
            var bodyContent = encodeContent
                    ? GetStringContent(content)
                    : (HttpContent)content;

            return await InvokeAsync<HttpResponse<T>>(async requestUrl => {
                var result = await _client.PutAsync(url, bodyContent);

                return await HttpResponse<T>.Get(result);
            }, url, "PutAsync");
        }

        public async Task<HttpResponseMessage> DeleteAsync(string url)
        {
            return await InvokeAsync<HttpResponseMessage>(async requestUrl => await _client.DeleteAsync(requestUrl), url, "DeleteAsync");
        }

        public async Task<HttpResponse<T>> DeleteAsync<T>(string url)
        {
            return await InvokeAsync<HttpResponse<T>>(async requestUrl =>
            {
                var result = await _client.DeleteAsync(requestUrl);

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