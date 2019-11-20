using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.AspNetCore.Gateways.RevsBensServiceGateway
{
    public class RevsBensServiceGateway : Gateway, IRevsBensServiceGateway
    {
        const string BaseEndpoint = "api/v1";

        public RevsBensServiceGateway(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<HttpResponseMessage> IsBenefitsClaimant(string personReference)
        {
            return await GetAsync($"{BaseEndpoint}/people/{personReference}/is-benefits-claimant");
        }

        public async Task<HttpResponseMessage> GetBenefits(string personReference)
        {
            return await GetAsync($"{BaseEndpoint}/people/{personReference}/benefits");
        }

        public async Task<HttpResponseMessage> GetAllTransactionsForYear(string personReference, string accountReference, int year)
        {
            return await GetAsync($"{BaseEndpoint}/person/{personReference}/details/{accountReference}/transactions/{year}");
        }
    }
}
