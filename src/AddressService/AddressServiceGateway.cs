using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Addresses;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.AddressService
{
    public class AddressServiceGateway : Gateway, IAddressServiceGateway
    {
        public AddressServiceGateway(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<HttpResponse<IEnumerable<AddressSearchResult>>> SearchAsync(AddressSearch model)
            => await GetAsync<IEnumerable<AddressSearchResult>>($"api/v1/Address/{model.AddressProvider}/{model.SearchTerm}");
    }
}
