using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace StockportGovUK.AspNetCore.Gateways.CivicaServiceGateway
{
    public class CivicaServiceGateway : Gateway, ICivicaServiceGateway
    {
        const string BaseEndpoint = "api/v1";

        public CivicaServiceGateway(HttpClient httpClient, ILogger<Gateway> logger) : base(httpClient, logger)
        {
        }

        public async Task<HttpResponseMessage> GetSessionId(string personReference)
        {
            return await GetAsync($"{BaseEndpoint}/people/{personReference}/session-id");
        }

        public async Task<HttpResponseMessage> IsBenefitsClaimant(string personReference)
        {
            return await GetAsync($"{BaseEndpoint}/people/{personReference}/is-benefits-claimant");
        }

        public async Task<HttpResponseMessage> GetBenefits(string personReference)
        {
            return await GetAsync($"{BaseEndpoint}/people/{personReference}/benefits");
        }

        public async Task<HttpResponseMessage> GetBenefitDetails(string personReference, string claimReference, string placeReference)
        {
            return await GetAsync($"{BaseEndpoint}/people/{personReference}/benefits/{claimReference}/{placeReference}");
        }

        public async Task<HttpResponseMessage> GetHousingBenefitPaymentHistory(string personReference)
        {
            return await GetAsync($"{BaseEndpoint}/people/{personReference}/benefits/housing");
        }

        public async Task<HttpResponseMessage> GetCouncilTaxBenefitPaymentHistory(string personReference)
        {
            return await GetAsync($"{BaseEndpoint}/people/{personReference}/benefits/council-tax");
        }

        public async Task<HttpResponseMessage> GetAccounts(string personReference)
        {
            return await GetAsync($"{BaseEndpoint}/people/{personReference}/accounts");
        }

        public async Task<HttpResponseMessage> GetAccount(string personReference, string accountReference)
        {
            return await GetAsync($"{BaseEndpoint}/people/{personReference}/accounts/{accountReference}");
        }

        public async Task<HttpResponseMessage> GetAccountDetailsForYear(string personReference, string accountReference, int year)
        {
            return await GetAsync($"{BaseEndpoint}/people/{personReference}/accounts/{accountReference}/{year}");
        }

        public async Task<HttpResponseMessage> GetAllTransactionsForYear(string personReference, string accountReference, int year)
        {
            return await GetAsync($"{BaseEndpoint}/people/{personReference}/accounts/{accountReference}/transactions/{year}");
        }

        public async Task<HttpResponseMessage> GetDocumentsWithAccountReference(string personReference, string accountReference)
        {
            return await GetAsync($"{BaseEndpoint}/people/{personReference}/accounts/{accountReference}/documents");
        }

        public async Task<HttpResponseMessage> GetDocuments(string personReference)
        {
            return await GetAsync($"{BaseEndpoint}/people/{personReference}/documents");
        }

        public async Task<HttpResponseMessage> GetPropertiesOwned(string personReference)
        {
            return await GetAsync($"{BaseEndpoint}/people/{personReference}/properties");
        }

        public async Task<HttpResponseMessage> GetCurrentProperty(string personReference)
        {
            return await GetAsync($"{BaseEndpoint}/people/{personReference}/properties/current");
        }

        public async Task<HttpResponseMessage> GetPaymentSchedule(string personReference, int year)
        {
            return await GetAsync($"{BaseEndpoint}/people/{personReference}/payments/{year}");
        }
    }
}