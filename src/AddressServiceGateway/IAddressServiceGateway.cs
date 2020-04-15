using StockportGovUK.NetStandard.Gateways.Response;
using StockportGovUK.NetStandard.Models.Addresses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockportGovUK.NetStandard.Gateways.AddressService
{
    public interface IAddressServiceGateway
    {
        Task<HttpResponse<IEnumerable<AddressSearchResult>>> SearchAsync(AddressSearch model);
    }
}
