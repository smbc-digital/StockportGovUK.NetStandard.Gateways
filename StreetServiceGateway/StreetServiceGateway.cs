using Microsoft.Extensions.Logging;
using StockportGovUK.NetStandard.Gateways.Response;
using StockportGovUK.NetStandard.Models.Addresses;
using StockportGovUK.NetStandard.Models.Street;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.NetStandard.Gateways.StreetServiceGateway
{
    public class StreetServiceGateway : Gateway, IStreetServiceGateway
    {
        public StreetServiceGateway(HttpClient httpClient, ILogger<Gateway> logger) : base(httpClient, logger)
        {
        }

        public async Task<HttpResponse<IEnumerable<AddressSearchResult>>> SearchAsync(StreetSearch model)
        {
            return await GetAsync<IEnumerable<AddressSearchResult>>($"api/v1/Street/{model.StreetProvider}/{model.SearchTerm}");
        }
    }
}
