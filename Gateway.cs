using System;
using System.Diagnostics;
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

        public void ChangeAuthenticationHeader(string authHeader)
        {
            _client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(authHeader);
        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            var errorMessage = string.Empty;

            try
            {
                return await _client.GetAsync(url);
            }
            catch (BrokenCircuitException<HttpResponseMessage> ex)
            {
                errorMessage = $"{GetType().Name} => GetAsync({url}) - Circuit broken due to: '{ex.InnerException?.Message}'";
                _logger.LogWarning(errorMessage, ex.Message);
            }
            catch (BrokenCircuitException ex)
            {
                errorMessage = $"{GetType().Name} => GetAsync({url}) - Circuit broken due to: '{ex.InnerException?.Message}'";
                _logger.LogWarning(errorMessage, ex.Message);
            }
            catch (Exception ex)
            {
                errorMessage = $"{GetType().Name} => GetAsync({url}) - failed with the following error: '{ex.Message}'";
                _logger.LogError(errorMessage, ex.Message);
            }

            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                ReasonPhrase = errorMessage
            };
        }

        public async Task<HttpResponse<T>> GetAsync<T>(string url)
        {
            var errorMessage = string.Empty;

            try
            {
                var result = await _client.GetAsync(url);

                return await HttpResponse<T>.Get(result);
            }
            catch (BrokenCircuitException<HttpResponseMessage> ex)
            {
                errorMessage = $"{GetType().Name} => GetAsync<{nameof(T)}>({url}) - Circuit broken due to: '{ex.InnerException?.Message}'";
                _logger.LogWarning(errorMessage, ex.Message);
            }
            catch (BrokenCircuitException ex)
            {
                errorMessage = $"{GetType().Name} => GetAsync<{nameof(T)}>({url}) - Circuit broken due to: '{ex.InnerException?.Message}'";
                _logger.LogWarning(errorMessage, ex.Message);
            }
            catch (Exception ex)
            {
                errorMessage = $"{GetType().Name} => GetAsync<{nameof(T)}>({url}) - failed with the following error: '{ex.Message}'";
                _logger.LogError(errorMessage, ex.Message);
            }

            return new HttpResponse<T>
            {
                StatusCode = HttpStatusCode.InternalServerError,
                ReasonPhrase = errorMessage
            };
        }

        public async Task<HttpResponseMessage> PatchAsync(string url, object content)
        {
            var errorMessage = string.Empty;

            try
            {
                var bodyContent = GetStringContent(content);

                return await _client.PatchAsync(url, bodyContent);
            }
            catch (BrokenCircuitException<HttpResponseMessage> ex)
            {
                errorMessage = $"{GetType().Name} => PatchAsync({url}) - Circuit broken due to: '{ex.InnerException?.Message}'";
                _logger.LogWarning(errorMessage, ex.Message);
            }
            catch (BrokenCircuitException ex)
            {
                errorMessage = $"{GetType().Name} => PatchAsync({url}) - Circuit broken due to: '{ex.InnerException?.Message}'";
                _logger.LogWarning(errorMessage, ex.Message);
            }
            catch (Exception ex)
            {
                errorMessage = $"{GetType().Name} => PatchAsync({url}) - failed with the following error: '{ex.Message}'";
                _logger.LogError(errorMessage, ex.Message);
            }

            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                ReasonPhrase = errorMessage
            };
        }

        public async Task<HttpResponseMessage> PatchAsync(string url, object content, bool encodeContent)
        {
            var errorMessage = string.Empty;

            try
            {
                var bodyContent = encodeContent
                    ? GetStringContent(content)
                    : (HttpContent)content;

                return await _client.PatchAsync(url, bodyContent);
            }
            catch (BrokenCircuitException<HttpResponseMessage> ex)
            {
                errorMessage = $"{GetType().Name} => PatchAsync({url}) - Circuit broken due to: '{ex.InnerException?.Message}'";
                _logger.LogWarning(errorMessage, ex.Message);
            }
            catch (BrokenCircuitException ex)
            {
                errorMessage = $"{GetType().Name} => PatchAsync({url}) - Circuit broken due to: '{ex.InnerException?.Message}'";
                _logger.LogWarning(errorMessage, ex.Message);
            }
            catch (Exception ex)
            {
                errorMessage = $"{GetType().Name} => PatchAsync({url}) - failed with the following error: '{ex.Message}'";
                _logger.LogError(errorMessage, ex.Message);
            }

            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                ReasonPhrase = errorMessage
            };
        }

        public async Task<HttpResponse<T>> PatchAsync<T>(string url, object content)
        {
            var errorMessage = string.Empty;

            try
            {
                var bodyContent = GetStringContent(content);
                var result = await _client.PatchAsync(url, bodyContent);

                return await HttpResponse<T>.Get(result);
            }
            catch (BrokenCircuitException<HttpResponseMessage> ex)
            {
                errorMessage = $"{GetType().Name} => PatchAsync<{nameof(T)}>({url}) - Circuit broken due to: '{ex.InnerException?.Message}'";
                _logger.LogWarning(errorMessage, ex.Message);
            }
            catch (BrokenCircuitException ex)
            {
                errorMessage = $"{GetType().Name} => PatchAsync<{nameof(T)}>({url}) - Circuit broken due to: '{ex.InnerException?.Message}'";
                _logger.LogWarning(errorMessage, ex.Message);
            }
            catch (Exception ex)
            {
                errorMessage = $"{GetType().Name} => PatchAsync<{nameof(T)}>({url}) - failed with the following error: '{ex.Message}'";
                _logger.LogError(errorMessage, ex.Message);
            }

            return new HttpResponse<T>
            {
                StatusCode = HttpStatusCode.InternalServerError,
                ReasonPhrase = errorMessage
            };
        }

        public async Task<HttpResponse<T>> PatchAsync<T>(string url, object content, bool encodeContent)
        {
            var errorMessage = string.Empty;

            try
            {
                var bodyContent = encodeContent
                    ? GetStringContent(content)
                    : (HttpContent)content;

                var result = await _client.PatchAsync(url, bodyContent);

                return await HttpResponse<T>.Get(result);
            }
            catch (BrokenCircuitException<HttpResponseMessage> ex)
            {
                errorMessage = $"{GetType().Name} => PatchAsync<{nameof(T)}>({url}) - Circuit broken due to: '{ex.InnerException?.Message}'";
                _logger.LogWarning(errorMessage, ex.Message);
            }
            catch (BrokenCircuitException ex)
            {
                errorMessage = $"{GetType().Name} => PatchAsync<{nameof(T)}>({url}) - Circuit broken due to: '{ex.InnerException?.Message}'";
                _logger.LogWarning(errorMessage, ex.Message);
            }
            catch (Exception ex)
            {
                errorMessage = $"{GetType().Name} => PatchAsync<{nameof(T)}>({url}) - failed with the following error: '{ex.Message}'";
                _logger.LogError(errorMessage, ex.Message);
            }

            return new HttpResponse<T>
            {
                StatusCode = HttpStatusCode.InternalServerError,
                ReasonPhrase = errorMessage
            };
        }

        public async Task<HttpResponseMessage> PostAsync(string url, object content)
        {
            var errorMessage = string.Empty;

            try
            {
                var bodyContent = GetStringContent(content);

                return await _client.PostAsync(url, bodyContent);
            }
            catch (BrokenCircuitException<HttpResponseMessage> ex)
            {
                errorMessage = $"{GetType().Name} => PostAsync({url}) - Circuit broken due to: '{ex.InnerException?.Message}'";
                _logger.LogWarning(errorMessage, ex.Message);
            }
            catch (BrokenCircuitException ex)
            {
                errorMessage = $"{GetType().Name} => PostAsync({url}) - Circuit broken due to: '{ex.InnerException?.Message}'";
                _logger.LogWarning(errorMessage, ex.Message);
            }
            catch (Exception ex)
            {
                errorMessage = $"{GetType().Name} => PostAsync({url}) - failed with the following error: '{ex.Message}'";
                _logger.LogError(errorMessage, ex.Message);
            }

            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                ReasonPhrase = errorMessage
            };
        }

        public async Task<HttpResponseMessage> PostAsync(string url, object content, bool encodeContent)
        {
            var errorMessage = string.Empty;

            try
            {
                var bodyContent = encodeContent
                    ? GetStringContent(content)
                    : (HttpContent)content;

                return await _client.PostAsync(url, bodyContent);
            }
            catch (BrokenCircuitException<HttpResponseMessage> ex)
            {
                errorMessage = $"{GetType().Name} => PostAsync({url}) - Circuit broken due to: '{ex.InnerException?.Message}'";
                _logger.LogWarning(errorMessage, ex.Message);
            }
            catch (BrokenCircuitException ex)
            {
                errorMessage = $"{GetType().Name} => PostAsync({url}) - Circuit broken due to: '{ex.InnerException?.Message}'";
                _logger.LogWarning(errorMessage, ex.Message);
            }
            catch (Exception ex)
            {
                errorMessage = $"{GetType().Name} => PostAsync({url}) - failed with the following error: '{ex.Message}'";
                _logger.LogError(errorMessage, ex.Message);
            }

            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                ReasonPhrase = errorMessage
            };
        }

        public async Task<HttpResponse<T>> PostAsync<T>(string url, object content)
        {
            var errorMessage = string.Empty;

            try
            {
                var bodyContent = GetStringContent(content);
                var result = await _client.PostAsync(url, bodyContent);

                return await HttpResponse<T>.Get(result);
            }
            catch (BrokenCircuitException<HttpResponseMessage> ex)
            {
                errorMessage = $"{GetType().Name} => PostAsync<{nameof(T)}>({url}) - Circuit broken due to: '{ex.InnerException?.Message}'";
                _logger.LogWarning(errorMessage, ex.Message);
            }
            catch (BrokenCircuitException ex)
            {
                errorMessage = $"{GetType().Name} => PostAsync<{nameof(T)}>({url}) - Circuit broken due to: '{ex.InnerException?.Message}'";
                _logger.LogWarning(errorMessage, ex.Message);
            }
            catch (Exception ex)
            {
                errorMessage = $"{GetType().Name} => PostAsync<{nameof(T)}>({url}) - failed with the following error: '{ex.Message}'";
                _logger.LogError(errorMessage, ex.Message);
            }

            return new HttpResponse<T>
            {
                StatusCode = HttpStatusCode.InternalServerError,
                ReasonPhrase = errorMessage
            };
        }

        public async Task<HttpResponse<T>> PostAsync<T>(string url, object content, bool encodeContent)
        {
            var errorMessage = string.Empty;

            try
            {
                var bodyContent = encodeContent
                    ? GetStringContent(content)
                    : (HttpContent)content;

                var result = await _client.PostAsync(url, bodyContent);

                return await HttpResponse<T>.Get(result);
            }
            catch (BrokenCircuitException<HttpResponseMessage> ex)
            {
                errorMessage = $"{GetType().Name} => PostAsync<{nameof(T)}>({url}) - Circuit broken due to: '{ex.InnerException?.Message}'";
                _logger.LogWarning(errorMessage, ex.Message);
            }
            catch (BrokenCircuitException ex)
            {
                errorMessage = $"{GetType().Name} => PostAsync<{nameof(T)}>({url}) - Circuit broken due to: '{ex.InnerException?.Message}'";
                _logger.LogWarning(errorMessage, ex.Message);
            }
            catch (Exception ex)
            {
                errorMessage = $"{GetType().Name} => PostAsync<{nameof(T)}>({url}) - failed with the following error: '{ex.Message}'";
                _logger.LogError(errorMessage, ex.Message);
            }

            return new HttpResponse<T>
            {
                StatusCode = HttpStatusCode.InternalServerError,
                ReasonPhrase = errorMessage
            };
        }

        public async Task<HttpResponseMessage> PutAsync(string url, HttpContent content)
        {
            var errorMessage = string.Empty;

            try
            {
                return await _client.PutAsync(url, content);
            }
            catch (BrokenCircuitException<HttpResponseMessage> ex)
            {
                errorMessage = $"{GetType().Name} => PutAsync({url}) - Circuit broken due to: '{ex.InnerException?.Message}'";
                _logger.LogWarning(errorMessage, ex.Message);
            }
            catch (BrokenCircuitException ex)
            {
                errorMessage = $"{GetType().Name} => PutAsync({url}) - Circuit broken due to: '{ex.InnerException?.Message}'";
                _logger.LogWarning(errorMessage, ex.Message);
            }
            catch (Exception ex)
            {
                errorMessage = $"{GetType().Name} => PutAsync({url}) - failed with the following error: '{ex.Message}'";
                _logger.LogError(errorMessage, ex.Message);
            }

            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                ReasonPhrase = errorMessage
            };
        }


        public async Task<HttpResponse<T>> PutAsync<T>(string url, object content)
        {
            var errorMessage = string.Empty;

            try
            {
                var bodyContent = GetStringContent(content);
                var result = await _client.PutAsync(url, bodyContent);

                return await HttpResponse<T>.Get(result);
            }
            catch (BrokenCircuitException<HttpResponseMessage> ex)
            {
                errorMessage = $"{GetType().Name} => PutAsync<{nameof(T)}>({url}) - Circuit broken due to: '{ex.InnerException?.Message}'";
                _logger.LogWarning(errorMessage, ex.Message);
            }
            catch (BrokenCircuitException ex)
            {
                errorMessage = $"{GetType().Name} => PutAsync<{nameof(T)}>({url}) - Circuit broken due to: '{ex.InnerException?.Message}'";
                _logger.LogWarning(errorMessage, ex.Message);
            }
            catch (Exception ex)
            {
                errorMessage = $"{GetType().Name} => PutAsync<{nameof(T)}>({url}) - failed with the following error: '{ex.Message}'";
                _logger.LogError(errorMessage, ex.Message);
            }

            return new HttpResponse<T>
            {
                StatusCode = HttpStatusCode.InternalServerError,
                ReasonPhrase = errorMessage
            };
        }

        public async Task<HttpResponse<T>> PutAsync<T>(string url, object content, bool encodeContent)
        {
            var errorMessage = string.Empty;

            try
            {
                var bodyContent = encodeContent
                    ? GetStringContent(content)
                    : (HttpContent)content;

                var result = await _client.PutAsync(url, bodyContent);

                return await HttpResponse<T>.Get(result);
            }
            catch (BrokenCircuitException<HttpResponseMessage> ex)
            {
                errorMessage = $"{GetType().Name} => PutAsync<{nameof(T)}>({url}) - Circuit broken due to: '{ex.InnerException?.Message}'";
                _logger.LogWarning(errorMessage, ex.Message);
            }
            catch (BrokenCircuitException ex)
            {
                errorMessage = $"{GetType().Name} => PutAsync<{nameof(T)}>({url}) - Circuit broken due to: '{ex.InnerException?.Message}'";
                _logger.LogWarning(errorMessage, ex.Message);
            }
            catch (Exception ex)
            {
                errorMessage = $"{GetType().Name} => PutAsync<{nameof(T)}>({url}) - failed with the following error: '{ex.Message}'";
                _logger.LogError(errorMessage, ex.Message);
            }

            return new HttpResponse<T>
            {
                StatusCode = HttpStatusCode.InternalServerError,
                ReasonPhrase = errorMessage
            };
        }

        public async Task<HttpResponseMessage> DeleteAsync(string url)
        {
            var errorMessage = string.Empty;

            try
            {
                return await _client.DeleteAsync(url);
            }
            catch (BrokenCircuitException<HttpResponseMessage> ex)
            {
                errorMessage = $"{GetType().Name} => DeleteAsync({url}) - Circuit broken due to: '{ex.InnerException?.Message}'";
                _logger.LogWarning(errorMessage, ex.Message);
            }
            catch (BrokenCircuitException ex)
            {
                errorMessage = $"{GetType().Name} => DeleteAsync({url}) - Circuit broken due to: '{ex.InnerException?.Message}'";
                _logger.LogWarning(errorMessage, ex.Message);
            }
            catch (Exception ex)
            {
                errorMessage = $"{GetType().Name} => DeleteAsync({url}) - failed with the following error: '{ex.Message}'";
                _logger.LogError(errorMessage, ex.Message);
            }

            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                ReasonPhrase = errorMessage
            };
        }

        public async Task<HttpResponse<T>> DeleteAsync<T>(string url)
        {
            var errorMessage = string.Empty;

            try
            {
                var result = await _client.DeleteAsync(url);

                return await HttpResponse<T>.Get(result);
            }
            catch (BrokenCircuitException<HttpResponseMessage> ex)
            {
                errorMessage = $"{GetType().Name} => DeleteAsync<{nameof(T)}>({url}) - Circuit broken due to: '{ex.InnerException?.Message}'";
                _logger.LogWarning(errorMessage, ex.Message);
            }
            catch (BrokenCircuitException ex)
            {
                errorMessage = $"{GetType().Name} => DeleteAsync<{nameof(T)}>({url}) - Circuit broken due to: '{ex.InnerException?.Message}'";
                _logger.LogWarning(errorMessage, ex.Message);
            }
            catch (Exception ex)
            {
                errorMessage = $"{GetType().Name} => DeleteAsync<{nameof(T)}>({url}) - failed with the following error: '{ex.Message}'";
                _logger.LogError(errorMessage, ex.Message);
            }

            return new HttpResponse<T>
            {
                StatusCode = HttpStatusCode.InternalServerError,
                ReasonPhrase = errorMessage
            };
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