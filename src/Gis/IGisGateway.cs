using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.NetStandard.Gateways.Gis
{
    public interface IGisGateway : IGateway
    {
        Task<HttpResponseMessage> GetPropertiesAsync(string postcode);
        Task<HttpResponseMessage> GetCollectionsAsync(string uprn);
        Task<HttpResponseMessage> GetCalendarAsync(string uprn);
    }
}