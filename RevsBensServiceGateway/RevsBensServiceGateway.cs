using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.AspNetCore.Gateways.RevsBensServiceGateway
{
    public class RevsBensServiceGateway : Gateway, IRevsBensServiceGateway
    {
        public RevsBensServiceGateway(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<HttpResponseMessage> IsBenefitsClaimant(string personReference)
        {
            return await GetAsync($"api/v1/person/summary/{personReference}/benefits-claimant");
        }
    }
}
