using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways
{
    public interface ITypedGateway
    {
        void ChangeAuthenticationHeader(string authHeader);
        Task<HttpResponse<T>> GetAsync<T>(string url);
        Task<HttpResponse<T>> PatchAsync<T>(string url, object content);
        Task<HttpResponse<T>> PatchAsync<T>(string url, object content, bool encodeContent);
        Task<HttpResponse<T>> PostAsync<T>(string url, object content);
        Task<HttpResponse<T>> PostAsync<T>(string url, object content, bool encodeContent);
        Task<HttpResponse<T>> PutAsync<T>(string url, object content);
        Task<HttpResponse<T>> PutAsync<T>(string url, object content, bool encodeContent);
        Task<HttpResponse<T>> DeleteAsync<T>(string url);
    }
}