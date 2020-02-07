using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways
{
    public interface IGateway
    {
        Task<HttpResponseMessage> GetAsync(string url);
        Task<HttpResponseMessage> PutAsync(string url, HttpContent content);
        Task<HttpResponseMessage> PatchAsync(object content);
        Task<HttpResponseMessage> PatchAsync(object content, bool encodeContent);
        Task<HttpResponse<T>> PatchAsync<T>(string url, object content);
        Task<HttpResponse<T>> PatchAsync<T>(string url, object content, bool encodeContent);
        Task<HttpResponseMessage> PostAsync(string url, object content);
        Task<HttpResponseMessage> PostAsync(string url, object content, bool encodeContent);
        Task<HttpResponseMessage> DeleteAsync(string url);
        void ChangeAuthenticationHeader(string authHeader);
    }
}