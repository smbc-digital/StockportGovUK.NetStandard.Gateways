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

        public async Task<HttpResponseMessage> GetAllTransactionsForYear(string personReference, string accountReference, int year)
        { 
            return await GetAsync($"api/v2/council-tax/{personReference}/details/{accountReference}/transactions/{year}");
        }
    }
}