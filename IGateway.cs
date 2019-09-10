using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.AspNetCore.Gateways.Response;

namespace StockportGovUK.AspNetCore.Gateways
{
    public interface IGateway
    {
        Task<HttpResponseMessage> GetAsync(string url);

        Task<HttpResponseMessage> GetAsync(string name, string url);

        Task<HttpResponse<T>> GetAsync<T>(string url);

        Task<HttpResponse<T>> GetAsync<T>(string name, string url);
        
        Task<HttpResponseMessage> PutAsync(string url, HttpContent content);

        Task<HttpResponseMessage> PutAsync(string name, string url, HttpContent content);
        
        Task<HttpResponseMessage> PatchAsync(string url, object content);

        Task<HttpResponseMessage> PatchAsync(string name, string url, object content);

        Task<HttpResponse<T>> PatchAsync<T>(string url, object content);

        Task<HttpResponse<T>> PatchAsync<T>(string name, string url, object content);

        Task<HttpResponse<T>> PostAsync<T>(string url, object content);

        Task<HttpResponse<T>> PostAsync<T>(string name, string url, object content);

        Task<HttpResponseMessage> PostAsync(string url, object content);

        Task<HttpResponseMessage> PostAsync(string name, string url, object content);
    }
}