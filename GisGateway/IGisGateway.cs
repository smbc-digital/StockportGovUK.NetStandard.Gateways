using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.AspNetCore.Gateways.Response;

namespace StockportGovUK.AspNetCore.Gateways.Gis
{
    public interface IGisGateway : IGateway
    {
        Task<HttpResponseMessage> GetPropertiesAsync(string postcode);
        Task<HttpResponseMessage> GetCollectionsAsync(string uprn);
        Task<HttpResponseMessage> GetCalendarAsync(string uprn);
    }
}