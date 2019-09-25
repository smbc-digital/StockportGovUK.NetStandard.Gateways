using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.AspNetCore.Gateways
{
    public interface IGateway
    {
        Task<HttpResponseMessage> GetAsync(string url);

        Task<HttpResponseMessage> PutAsync(string url, HttpContent content);

        Task<HttpResponseMessage> PatchAsync(string url, object content);

        Task<HttpResponseMessage> PostAsync(string url, object content);
    }
}