using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace StockportGovUK.AspNetCore.Gateways.RevsBensServiceGateway
{
    public class RevsBensServiceGateway : Gateway, IRevsBensServiceGateway
    {
        const string BaseEndpoint = "api/v1";

        public RevsBensServiceGateway(HttpClient httpClient, ILogger<Gateway> logger) : base(httpClient, logger)
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

        public async Task<HttpResponseMessage> GetCouncilTaxDetails(string personReference, string accountReference, int year)
        {
            return await GetAsync($"{BaseEndpoint}/people/{personReference}/council-tax/{accountReference}/{year}");
        }

        public async Task<HttpResponseMessage> GetCivicaAvailability()
        {
            return await GetAsync($"{BaseEndpoint}/availability/civica");
        }
    }
}
