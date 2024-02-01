using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.BinCollection.Response;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.WasteCollection
{
    public class WasteCollectionGateway : Gateway, IWasteCollectionGateway
    {
        private const string WasteDataEndpoint = "api/v1/Home";

        public WasteCollectionGateway(HttpClient httpClient) : base(httpClient) { }

        public async Task<HttpResponse<BinCollectionResponse>> Get(long uprn)
            => await GetAsync<BinCollectionResponse>($"{WasteDataEndpoint}/{uprn}");

        public async Task<HttpResponse<BinCollectionResponse>> GetBinCollectionDates(long uprn)
            => await GetAsync<BinCollectionResponse>($"{WasteDataEndpoint}/bin-collection-dates/{uprn}");
    }
}
