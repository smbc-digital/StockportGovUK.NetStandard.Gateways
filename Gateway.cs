using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StockportGovUK.AspNetCore.Gateways.Response;

namespace StockportGovUK.AspNetCore.Gateways
{
    public class Gateway : IGateway, ITypedGateway
    {
        private readonly HttpClient _client;

        public Gateway(HttpClient client)
        {
            _client = client;
        }

        public Gateway(HttpClient client, string authHeader)
        {
            _client = client;
            _client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(authHeader);
        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            try
            {
                return await _client.GetAsync(url);
            }
            catch(Exception ex)
            {
                throw new GatewayException($"{GetType().Name} => {MethodBase.GetCurrentMethod().Name}({url}) - failed with the following error: '{ex.Message}'", ex);
            }
        }

        public async Task<HttpResponse<T>> GetAsync<T>(string url)
        {
            try
            {
                var result = await _client.GetAsync(url);
                return await HttpResponse<T>.Get(result);
            }
            catch(Exception ex)
            {
                throw new GatewayException($"{GetType().Name} => {MethodBase.GetCurrentMethod().Name}<{nameof(T)}>({url}) - failed with the following error: '{ex.Message}'", ex);
            }
        }

        public async Task<HttpResponseMessage> PatchAsync(string url, object content)
        {
            try
            {
                return await _client.PatchAsync(url, GetStringContent(content));
            }
            catch(Exception ex)
            {
                throw new GatewayException($"{GetType().Name} => {MethodBase.GetCurrentMethod().Name}({url}) - failed with the following error: '{ex.Message}'", ex);
            }
        }

        public async Task<HttpResponse<T>> PatchAsync<T>(string url, object content)
        {
            try
            {
                var result = await _client.PatchAsync(url, GetStringContent(content));
                return await HttpResponse<T>.Get(result);   
            }
            catch(Exception ex)
            {
                throw new GatewayException($"{GetType().Name} => {MethodBase.GetCurrentMethod().Name}<{nameof(T)}>({url}) - failed with the following error: '{ex.Message}'", ex);
            }
        }

        public async Task<HttpResponseMessage> PostAsync(string url, object content)
        {
            try
            {
                return await _client.PostAsync(url, GetStringContent(content));
            }
            catch(Exception ex)
            {
                throw new GatewayException($"{GetType().Name} => {MethodBase.GetCurrentMethod().Name}({url}) - failed with the following error: '{ex.Message}'", ex);
            }
        }

        public async Task<HttpResponse<T>> PostAsync<T>(string url, object content)
        {
            try
            {
                var result = await _client.PostAsync(url, GetStringContent(content));
                return await HttpResponse<T>.Get(result);    
            }
            catch(Exception ex)
            {
                throw new GatewayException($"{GetType().Name} => {MethodBase.GetCurrentMethod().Name}<{nameof(T)}>({url}) - failed with the following error: '{ex.Message}'", ex);
            }
        }

        public async Task<HttpResponseMessage> PutAsync(string url, HttpContent content)
        {
            try
            {
                return await _client.PutAsync(url, content);
            }
            catch(Exception ex)
            {
                throw new GatewayException($"{GetType().Name} => {MethodBase.GetCurrentMethod().Name}({url}) - failed with the following error: '{ex.Message}'", ex);
            }
        }

        public async Task<HttpResponse<T>> PutAsync<T>(string url, object content)
        {
            try
            {
                var result = await _client.PutAsync(url, GetStringContent(content));
                return await HttpResponse<T>.Get(result);    
            }
            catch(Exception ex)
            {
                throw new GatewayException($"{GetType().Name} => {MethodBase.GetCurrentMethod().Name}<{nameof(T)}>({url}) - failed with the following error: '{ex.Message}'", ex);
            }
        }

        public async Task<HttpResponseMessage> DeleteAsync(string url)
        {
            try
            {
                return await _client.DeleteAsync(url);
            }
            catch(Exception ex)
            {
                throw new GatewayException($"{GetType().Name} => {MethodBase.GetCurrentMethod().Name}({url}) - failed with the following error: '{ex.Message}'", ex);
            }
        }

        public async Task<HttpResponse<T>> DeleteAsync<T>(string url)
        {
            try
            {
                var result = await _client.DeleteAsync(url);
                return await HttpResponse<T>.Get(result);    
            }
            catch(Exception ex)
            {
                throw new GatewayException($"{GetType().Name} => {MethodBase.GetCurrentMethod().Name}<{nameof(T)}>({url}) - failed with the following error: '{ex.Message}'", ex);
            }
        }

        private StringContent GetStringContent(object content)
        {
            return new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
        }

        public void ChangeAuthenticationHeader(string authHeader)
        {
            _client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(authHeader);
        }
    }
}