using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Polly.CircuitBreaker;
using StockportGovUK.AspNetCore.Gateways.Response;

namespace StockportGovUK.AspNetCore.Gateways
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

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            Func<Task<HttpResponseMessage>> function = async () => await _client.GetAsync(url);

            return await Invoke(function);
        }

        public async Task<HttpResponse<T>> GetAsync<T>(string url)
        {
            Func<Task<HttpResponseMessage>> function = async () => await _client.GetAsync(url);

            var result =  await Invoke(function);

            return await HttpResponse<T>.Get(result);
        }

        public async Task<HttpResponseMessage> PatchAsync(string url, object content)
        {
            Func<Task<HttpResponseMessage>> function = async () => await _client.PatchAsync(url, GetStringContent(content));

            return await Invoke(function);
        }

        public async Task<HttpResponseMessage> PatchAsync(string url, object content, bool encodeContent)
        {
            Func<Task<HttpResponseMessage>> function = async () => await _client.PatchAsync(url, encodeContent ? GetStringContent(content) : (HttpContent)content);

            return await Invoke(function);
        }

        public async Task<HttpResponse<T>> PatchAsync<T>(string url, object content)
        {
            Func<Task<HttpResponseMessage>> function = async () => await _client.PatchAsync(url, GetStringContent(content));

            var result =  await Invoke(function);

            return await HttpResponse<T>.Get(result);
        }

        public async Task<HttpResponse<T>> PatchAsync<T>(string url, object content, bool encodeContent)
        {
            Func<Task<HttpResponseMessage>> function = async () => await _client.PatchAsync(url, encodeContent ? GetStringContent(content) : (HttpContent)content);

            var result =  await Invoke(function);

            return await HttpResponse<T>.Get(result);
        }

        public async Task<HttpResponseMessage> PostAsync(string url, object content)
        {
            Func<Task<HttpResponseMessage>> function = async () => await _client.PostAsync(url, GetStringContent(content));

            return await Invoke(function);
        }

        public async Task<HttpResponseMessage> PostAsync(string url, object content, bool encodeContent)
        {
            Func<Task<HttpResponseMessage>> function = async () => await _client.PostAsync(url, encodeContent ? GetStringContent(content) : (HttpContent)content);

            return await Invoke(function);
        }

        public async Task<HttpResponse<T>> PostAsync<T>(string url, object content)
        {
            Func<Task<HttpResponseMessage>> function = async () => await _client.PostAsync(url, GetStringContent(content));

            var result =  await Invoke(function);

            return await HttpResponse<T>.Get(result);
        }

        public async Task<HttpResponse<T>> PostAsync<T>(string url, object content, bool encodeContent)
        {
            Func<Task<HttpResponseMessage>> function = async () => await _client.PostAsync(url, encodeContent ? GetStringContent(content) : (HttpContent)content);

            var result =  await Invoke(function);

            return await HttpResponse<T>.Get(result);
        }

        public async Task<HttpResponseMessage> PutAsync(string url, HttpContent content)
        {
            Func<Task<HttpResponseMessage>> function = async () => await _client.PutAsync(url, content);

            return await Invoke(function);
        }


        public async Task<HttpResponse<T>> PutAsync<T>(string url, object content)
        {
            Func<Task<HttpResponseMessage>> function = async () => await _client.PutAsync(url, GetStringContent(content));

            var result =  await Invoke(function);

            return await HttpResponse<T>.Get(result);
        }

        public async Task<HttpResponse<T>> PutAsync<T>(string url, object content, bool encodeContent)
        {
            Func<Task<HttpResponseMessage>> function = async () => await _client.PutAsync(url, encodeContent ? GetStringContent(content) : (HttpContent)content);

            var result =  await Invoke(function);

            return await HttpResponse<T>.Get(result);
        }

        public async Task<HttpResponseMessage> DeleteAsync(string url)
        {
            Func<Task<HttpResponseMessage>> function = async () => await _client.DeleteAsync(url);

            return await Invoke(function);
        }

        public async Task<HttpResponse<T>> DeleteAsync<T>(string url)
        {
            Func<Task<HttpResponseMessage>> function = async () => await _client.DeleteAsync(url);
            
            var result =  await Invoke(function);

            return await HttpResponse<T>.Get(result);
        }

        private Task<HttpResponseMessage> Invoke(Func<Task<HttpResponseMessage>> function)
        {
            var errorMessage = string.Empty;

            try
            {
                return function.Invoke();
            }
            catch (BrokenCircuitException<HttpResponseMessage> ex)
            {
                errorMessage = $"{GetType().Name} => {MethodBase.GetCurrentMethod().Name}({((Polly.CircuitBreaker.BrokenCircuitException<System.Net.Http.HttpResponseMessage>)ex).Result.RequestMessage.RequestUri.AbsoluteUri}) - {ex.Message}";
                _logger.LogWarning(errorMessage, ex);
            }
            catch (BrokenCircuitException ex)
            {
                errorMessage = $"{GetType().Name} => {MethodBase.GetCurrentMethod().Name}({((Polly.CircuitBreaker.BrokenCircuitException<System.Net.Http.HttpResponseMessage>)ex).Result.RequestMessage.RequestUri.AbsoluteUri}) - {ex.Message}";
                _logger.LogWarning(errorMessage, ex);
            }
            catch (Exception ex)
            {
                errorMessage = $"{GetType().Name} => {MethodBase.GetCurrentMethod().Name}({((Polly.CircuitBreaker.BrokenCircuitException<System.Net.Http.HttpResponseMessage>)ex).Result.RequestMessage.RequestUri.AbsoluteUri}) - failed with the following error: '{ex.Message}'";
                _logger.LogError(errorMessage, ex);
            }

            return Task.FromResult(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                ReasonPhrase = errorMessage
            });
        }

        private StringContent GetStringContent(object content)
        {
            var serializedContent = JsonConvert.SerializeObject(content, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
                        
            return new StringContent(serializedContent, Encoding.UTF8, "application/json");
        }

        public void ChangeAuthenticationHeader(string authHeader)
        {
            _client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(authHeader);
        }
    }
}