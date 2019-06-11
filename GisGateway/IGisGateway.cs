using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.AspNetCore.Gateways.Response;

namespace StockportGovUK.AspNetCore.Gateways.Gis
{
    public interface IGisGateway : IGateway
    {
        Task<HttpResponse<T>> GetPropertiesAsync<T>(string postcode);
        Task<HttpResponse<T>> GetCollectionsAsync<T>(string uprn);
        Task<HttpResponse<T>> GetCalendarAsync<T>(string uprn);
    }
}