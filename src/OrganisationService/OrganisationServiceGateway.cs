using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Response;
using StockportGovUK.NetStandard.Models.Organisation;
using StockportGovUK.NetStandard.Models.Verint.Lookup;

namespace StockportGovUK.NetStandard.Gateways.OrganisationService
{
    public class OrganisationServiceGateway : Gateway, IOrganisationServiceGateway
    {
        public OrganisationServiceGateway(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<HttpResponse<IEnumerable<OrganisationSearchResult>>> SearchAsync(OrganisationSearch model)
            => await GetAsync<IEnumerable<OrganisationSearchResult>>($"api/v1/Organisation/{model.OrganisationProvider}/{model.SearchTerm}");
    }
}
