using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.NetStandard.Gateways.RevsBensService
{
    public class RevsBensServiceGateway : Gateway, IRevsBensServiceGateway
    {
        const string BaseEndpoint = "api/v1";

        public RevsBensServiceGateway(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<HttpResponseMessage> IsBenefitsClaimant(string personReference)
            => await GetAsync($"{BaseEndpoint}/people/{personReference}/is-benefits-claimant");

        public async Task<HttpResponseMessage> GetBenefits(string personReference)
            => await GetAsync($"{BaseEndpoint}/people/{personReference}/benefits");

        public async Task<HttpResponseMessage> GetCouncilTaxDetails(string personReference, string accountReference, int year)
            => await GetAsync($"{BaseEndpoint}/people/{personReference}/council-tax/{accountReference}/{year}");

        public async Task<HttpResponseMessage> GetBaseCouncilTaxAccount(string personReference)
            => await GetAsync($"{BaseEndpoint}/people/{personReference}/council-tax");

        public async Task<HttpResponseMessage> GetCivicaAvailability()
            => await GetAsync($"{BaseEndpoint}/availability/civica");

        public async Task<HttpResponseMessage> GetCivicaBrokersAvailability()
            => await GetAsync($"{BaseEndpoint}/availability/civica-brokers");

        public async Task<HttpResponseMessage> GetDocumentForAccount(string personReference, string accountReference, string documentId)
            => await GetAsync($"{BaseEndpoint}/people/{personReference}/council-tax/{accountReference}/documents/{documentId}");
    }
}
