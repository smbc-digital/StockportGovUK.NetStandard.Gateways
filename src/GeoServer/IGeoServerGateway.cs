using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.NetStandard.Gateways.GeoServer
{
    public interface IGeoServerGateway : IGateway
    {
        Task<HttpResponseMessage> GetCollectionCalendarAsync(string uprn);
    }
}