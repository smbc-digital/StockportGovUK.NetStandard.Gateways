using System.Collections.Generic;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Response;
using StockportGovUK.NetStandard.Models.Addresses;

namespace StockportGovUK.NetStandard.Gateways.AddressService
{
    public interface IAddressServiceGateway
    {
        Task<HttpResponse<IEnumerable<AddressSearchResult>>> SearchAsync(AddressSearch model);
    }
}
