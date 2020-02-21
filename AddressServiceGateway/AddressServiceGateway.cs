using Microsoft.Extensions.Logging;
using StockportGovUK.NetStandard.Gateways.Response;
using StockportGovUK.NetStandard.Models.Addresses;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.NetStandard.Gateways.AddressService
{
    public class AddressServiceGateway : Gateway, IAddressServiceGateway
    {
        public AddressServiceGateway(HttpClient httpClient, ILogger<Gateway> logger) : base(httpClient, logger)
        {
        }

        public async Task<HttpResponse<IEnumerable<AddressSearchResult>>> SearchAsync(AddressSearch model)
        {
            return await GetAsync<IEnumerable<AddressSearchResult>>($"api/v1/Address/{model.AddressProvider}/{model.SearchTerm}");
        }
    }
}
