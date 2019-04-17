using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.AspNetCore.Gateways;

namespace StockportGovUK.AspNetCore.Gateways.BinsService
{
    public interface IBinsServiceGateway : IGateway
    {
        Task<HttpResponseMessage> GetCollectionsAsync(string uprn);
        Task<HttpResponseMessage> GetCalendarAsync(string uprn);
    }
}