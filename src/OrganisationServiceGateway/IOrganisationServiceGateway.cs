using StockportGovUK.NetStandard.Gateways.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Models.Organisation;
using StockportGovUK.NetStandard.Models.Verint.Lookup;

namespace StockportGovUK.NetStandard.Gateways.OrganisationServiceGateway
{
    public interface IOrganisationServiceGateway
    {
        Task<HttpResponse<IEnumerable<OrganisationSearchResult>>> SearchAsync(OrganisationSearch model);
    }
}
