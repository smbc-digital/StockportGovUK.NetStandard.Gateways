using System.Collections.Generic;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Response;
using StockportGovUK.NetStandard.Models.Addresses;
using StockportGovUK.NetStandard.Models.Street;

namespace StockportGovUK.NetStandard.Gateways.StreetService
{
    public interface IStreetServiceGateway
    {
        Task<HttpResponse<IEnumerable<AddressSearchResult>>> SearchAsync(StreetSearch model);
    }
}
