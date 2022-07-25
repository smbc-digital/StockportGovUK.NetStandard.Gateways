using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Addresses;
using StockportGovUK.NetStandard.Gateways.Models.Street;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.StreetService
{
    public class StreetServiceGateway : Gateway, IStreetServiceGateway
    {
        public StreetServiceGateway(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<HttpResponse<IEnumerable<AddressSearchResult>>> SearchAsync(StreetSearch model)
            => await GetAsync<IEnumerable<AddressSearchResult>>($"api/v1/Street/{model.StreetProvider}/{model.SearchTerm}");
    }
}
