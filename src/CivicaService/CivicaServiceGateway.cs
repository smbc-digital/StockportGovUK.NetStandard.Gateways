using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.NetStandard.Gateways.CivicaService
{
    public class CivicaServiceGateway : Gateway, ICivicaServiceGateway
    {
        private const string BaseEndpoint = "api/v1";

        public CivicaServiceGateway(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<HttpResponseMessage> GetSessionId(string personReference)
            => await GetAsync($"{BaseEndpoint}/people/{personReference}/session-id");

        public async Task<HttpResponseMessage> IsBenefitsClaimant(string personReference)
            => await GetAsync($"{BaseEndpoint}/people/{personReference}/is-benefits-claimant");

        public async Task<HttpResponseMessage> GetBenefits(string personReference)
            => await GetAsync($"{BaseEndpoint}/people/{personReference}/benefits");

        public async Task<HttpResponseMessage> GetBenefitDetails(string personReference, string claimReference, string placeReference)
            => await GetAsync($"{BaseEndpoint}/people/{personReference}/benefits/{claimReference}/{placeReference}");

        public async Task<HttpResponseMessage> GetHousingBenefitPaymentHistory(string personReference)
            => await GetAsync($"{BaseEndpoint}/people/{personReference}/benefits/housing");

        public async Task<HttpResponseMessage> GetCouncilTaxBenefitPaymentHistory(string personReference)
            => await GetAsync($"{BaseEndpoint}/people/{personReference}/benefits/council-tax");

        public async Task<HttpResponseMessage> GetAccounts(string personReference)
            => await GetAsync($"{BaseEndpoint}/people/{personReference}/accounts");

        public async Task<HttpResponseMessage> GetAccount(string personReference, string accountReference)
            => await GetAsync($"{BaseEndpoint}/people/{personReference}/accounts/{accountReference}");

        public async Task<HttpResponseMessage> GetAccountDetailsForYear(string personReference, string accountReference, int year)
            => await GetAsync($"{BaseEndpoint}/people/{personReference}/accounts/{accountReference}/{year}");

        public async Task<HttpResponseMessage> GetAllTransactionsForYear(string personReference, string accountReference, int year)
            => await GetAsync($"{BaseEndpoint}/people/{personReference}/accounts/{accountReference}/transactions/{year}");

        public async Task<HttpResponseMessage> GetDocumentsWithAccountReference(string personReference, string accountReference)
            => await GetAsync($"{BaseEndpoint}/people/{personReference}/accounts/{accountReference}/documents");

        public async Task<HttpResponseMessage> GetDocuments(string personReference)
            => await GetAsync($"{BaseEndpoint}/people/{personReference}/documents");

        public async Task<HttpResponseMessage> GetDocumentForAccount(string personReference, string accountReference, string documentId)
            => await GetAsync($"{BaseEndpoint}/people/{personReference}/accounts/{accountReference}/documents/{documentId}");

        public async Task<HttpResponseMessage> GetPropertiesOwned(string personReference)
            => await GetAsync($"{BaseEndpoint}/people/{personReference}/properties");

        public async Task<HttpResponseMessage> GetCurrentProperty(string personReference, string accountReference)
            => await GetAsync($"{BaseEndpoint}/people/{personReference}/accounts/{accountReference}/properties/current");

        public async Task<HttpResponseMessage> GetPaymentSchedule(string personReference, int year)
            => await GetAsync($"{BaseEndpoint}/people/{personReference}/payments/{year}");

        public async Task<HttpResponseMessage> GetAvailability()
            => await GetAsync($"{BaseEndpoint}/availability");
    }
}