using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.AspNetCore.Gateways.Response;

namespace StockportGovUK.AspNetCore.Gateways.BinsService
{
    public interface IBinsServiceGateway : IGateway
    {
        Task<HttpResponse<T>> GetCollectionsAsync<T>(string uprn);
        Task<HttpResponse<T>> GetCalendarAsync<T>(string uprn);
    }
}