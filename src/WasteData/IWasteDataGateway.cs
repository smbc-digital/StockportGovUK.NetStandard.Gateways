using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Response;
using StockportGovUK.NetStandard.Models.WasteDataService.Response;

namespace StockportGovUK.NetStandard.Gateways.WasteData
{
    public interface IWasteDataGateway
    {
        Task<HttpResponse<PropertyWasteData>> Get(long uprn);
    }
}
