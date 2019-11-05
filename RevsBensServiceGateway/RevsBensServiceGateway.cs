using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.AspNetCore.Gateways.RevsBensServiceGateway
{
    public class RevsBensServiceGateway : Gateway, IRevsBensServiceGateway
    {

        const string CaseEndpoint = "/api/v1";

        public RevsBensServiceGateway(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<HttpResponseMessage> IsBenefitsClaimant(string personReference)
        {
            return await GetAsync($"{CaseEndpoint}/person/summary/{personReference}/benefits-claimant");
        }

        public async Task<HttpResponseMessage> GetBenefitDetails(string personReference)
        {
            return await GetAsync($"{CaseEndpoint}/benefits/{personReference}/details");
        }
    }
}
