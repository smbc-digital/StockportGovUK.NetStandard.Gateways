using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.AspNetCore.Gateways.Response;

namespace StockportGovUK.AspNetCore.Gateways
{
    public interface IGateway
    {
        Task<HttpResponseMessage> GetAsync(string url);

        Task<HttpResponse<T>> GetAsync<T>(string name, string url);

        Task<HttpResponseMessage> PatchAsync(string name, string url, object content);

        Task<HttpResponse<T>> PatchAsync<T>(string name, string url, object content);

        Task<HttpResponse<T>> PostAsync<T>(string name, string url, object content);

        Task<HttpResponseMessage> PostAsync(string name, string url, object content);
    }
}