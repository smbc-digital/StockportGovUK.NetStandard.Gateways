using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Response;
using StockportGovUK.NetStandard.Models;

namespace StockportGovUK.NetStandard.Gateways.WasteCollection
{
    public interface IWasteCollectionGateway
    {
        Task<HttpResponse<BinCollectionResponse>> Get(long uprn);
    }
}
