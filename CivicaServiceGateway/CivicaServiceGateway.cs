using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.AspNetCore.Gateways.CivicaServiceGateway
{
    public class CivicaServiceGateway : Gateway, ICivicaServiceGateway
    {
        const string BaseEndpoint = "api/v1";

        public CivicaServiceGateway(HttpClient client) : base(client)
        {
        }

        public async Task<HttpResponseMessage> IsBenefitsClaimant(string personReference)
        {
            return await GetAsync($"{BaseEndpoint}/people/{personReference}/is-benefits-claimant");
        }

        public async Task<HttpResponseMessage> GetBenefitDetails(string personReference)
        {
            return await GetAsync($"{BaseEndpoint}/people/{personReference}/benefits");
        }
    }
}