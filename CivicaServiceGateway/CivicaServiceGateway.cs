using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.AspNetCore.Gateways.CivicaServiceGateway
{
    public class CivicaServiceGateway : Gateway, ICivicaServiceGateway
    {
        public CivicaServiceGateway(HttpClient client) : base(client)
        {
        }

        public async Task<HttpResponseMessage> IsBenefitsClaimant(string personReference)
        {
            return await GetAsync($"api/v1/person/summary/{personReference}/benefits-claimant");
        }
    }
}