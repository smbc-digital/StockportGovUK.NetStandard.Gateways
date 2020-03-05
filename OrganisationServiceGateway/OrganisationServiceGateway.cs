using Microsoft.Extensions.Logging;
using StockportGovUK.NetStandard.Gateways.Response;
using StockportGovUK.NetStandard.Models.Street;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Models.Verint.Lookup;

namespace StockportGovUK.NetStandard.Gateways.OrganisationServiceGateway
{
    public class OrganisationServiceGateway : Gateway, IOrganisationServiceGateway
    {
        public OrganisationServiceGateway(HttpClient httpClient, ILogger<Gateway> logger) : base(httpClient, logger)
        {
        }

        public async Task<HttpResponse<IEnumerable<OrganisationSearchResult>>> SearchAsync(OrganisationSearch model)
        {
            return await GetAsync<IEnumerable<OrganisationSearchResult>>($"api/v1/Organisation/{model.OrganisationProvider}/{model.SearchTerm}");
        }
    }
}
