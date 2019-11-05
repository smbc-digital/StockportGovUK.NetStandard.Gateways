using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.AspNetCore.Gateways.CivicaServiceGateway
{
    public class CivicaServiceGateway : Gateway, ICivicaServiceGateway
    {
        const string CaseEndpoint = "/api/v1";

        public CivicaServiceGateway(HttpClient client) : base(client)
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