using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.NetStandard.Gateways
{
    public interface IGateway
    {
        void ChangeAuthenticationHeader(string authHeader);
        Task<HttpResponseMessage> GetAsync(string url);
        Task<HttpResponseMessage> PutAsync(string url, HttpContent content);
        Task<HttpResponseMessage> PutAsync(string url, object content, bool encodeContent);
        Task<HttpResponseMessage> PatchAsync(object content);
        Task<HttpResponseMessage> PatchAsync(string url, object content);
        Task<HttpResponseMessage> PatchAsync(string url, object content, bool encodeContent);
        Task<HttpResponseMessage> PostAsync(string url, object content);
        Task<HttpResponseMessage> PostAsync(string url, object content, bool encodeContent);
        Task<HttpResponseMessage> DeleteAsync(string url);
    }
}