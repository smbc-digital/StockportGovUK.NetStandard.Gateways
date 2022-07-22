using System.Collections.Generic;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Addresses;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.AddressService
{
    public interface IAddressServiceGateway
    {
        Task<HttpResponse<IEnumerable<AddressSearchResult>>> SearchAsync(AddressSearch model);
    }
}
