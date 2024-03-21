using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.BinCollection.Response;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.WasteCollection
{
    public interface IWasteCollectionGateway
    {
        Task<HttpResponse<BinCollectionResponse>> Get(long uprn);
        Task<HttpResponse<BinCollectionResponse>> GetBinCollectionDates(string uprn);
    }
}
