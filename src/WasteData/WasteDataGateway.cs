using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.WasteDataService.Response;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.WasteData
{
    public class WasteDataGateway : Gateway, IWasteDataGateway
    {
        private const string WasteDataEndpoint = "api/v1/WasteData";

        public WasteDataGateway(HttpClient httpClient) : base(httpClient) { }

        public async Task<HttpResponse<PropertyWasteData>> Get(long uprn)
            => await GetAsync<PropertyWasteData>($"{WasteDataEndpoint}?uprn={uprn}");
    }
}
