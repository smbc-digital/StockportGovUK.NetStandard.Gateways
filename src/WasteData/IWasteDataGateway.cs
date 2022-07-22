using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.WasteDataService.Response;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.WasteData
{
    public interface IWasteDataGateway
    {
        Task<HttpResponse<PropertyWasteData>> Get(long uprn);
    }
}
