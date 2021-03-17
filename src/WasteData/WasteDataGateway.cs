using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Response;
using StockportGovUK.NetStandard.Models.WasteDataService.Response;

namespace StockportGovUK.NetStandard.Gateways.WasteData
{
    public class WasteDataGateway : Gateway, IWasteDataGateway
    {
        private const string WasteDataEndpoint = "api/v1/WasteData";

        public WasteDataGateway(HttpClient httpClient) : base(httpClient) { }

        public async Task<HttpResponse<PropertyWasteData>> Get(string uprn)
            => await GetAsync<PropertyWasteData>($"{WasteDataEndpoint}?uprn={uprn}");
    }
}
