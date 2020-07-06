using System.Collections.Generic;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Response;
using StockportGovUK.NetStandard.Models.Organisation;
using StockportGovUK.NetStandard.Models.Verint.Lookup;

namespace StockportGovUK.NetStandard.Gateways.OrganisationService
{
    public interface IOrganisationServiceGateway
    {
        Task<HttpResponse<IEnumerable<OrganisationSearchResult>>> SearchAsync(OrganisationSearch model);
    }
}
