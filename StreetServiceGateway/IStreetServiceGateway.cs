using StockportGovUK.NetStandard.Gateways.Response;
using StockportGovUK.NetStandard.Models.Addresses;
using StockportGovUK.NetStandard.Models.Street;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockportGovUK.NetStandard.Gateways.StreetServiceGateway
{
    public interface IStreetServiceGateway
    {
        Task<HttpResponse<IEnumerable<AddressSearchResult>>> SearchAsync(StreetSearch model);
    }
}
