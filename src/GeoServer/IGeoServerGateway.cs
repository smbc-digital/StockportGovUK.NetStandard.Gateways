using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.GeoServer.Models;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.GeoServer
{
    public interface IGeoServerGateway : IGateway
    {
        Task<HttpResponse<GeoServerResponseModel>> GetCollectionCalendarAsync(string uprn);
    }
}