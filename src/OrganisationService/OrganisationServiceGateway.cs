using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Organisation;
using StockportGovUK.NetStandard.Gateways.Models.Verint.Lookup;
using StockportGovUK.NetStandard.Gateways.Response;

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
