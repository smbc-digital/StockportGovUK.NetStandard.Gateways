using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockportGovUK.NetStandard.Gateways.Response;
using StockportGovUK.NetStandard.Models.Addresses;
using StockportGovUK.NetStandard.Models.Models.Verint;
using StockportGovUK.NetStandard.Models.Models.Verint.Update;

namespace StockportGovUK.NetStandard.Gateways.VerintServiceGateway
{
    public class VerintServiceGateway : Gateway, IVerintServiceGateway
    {
        private const string HttpClientName = "verintServiceGateway";
        private const string CaseEndpoint = "api/v1/Case";
        private const string PropertyEndpoint = "api/v1/Property";
        private const string OrganisationEndpoint = "api/v1/Organisation";
        private const string StreetEndpoint = "api/v1/Street";

        public VerintServiceGateway(HttpClient httpClient, ILogger<Gateway> logger) : base(httpClient, logger)
        {
        }

        public async Task<HttpResponse<Case>> GetCase(string caseRef)
        {
            return await GetAsync<Case>($"{CaseEndpoint}?caseId={caseRef}");
        }

        public async Task<HttpResponse<string>> CreateCase(Case crmCase)
        {
            return await PostAsync<string>($"{CaseEndpoint}", crmCase);
        }

        public async Task<HttpResponseMessage> UpdateCaseIntegrationFormField(IntegrationFormFieldsUpdateModel content)
        {
            return await PatchAsync($"{CaseEndpoint}/integration-form-fields", content);
        }

        public async Task<HttpResponse<List<AddressSearchResult>>> SearchForPropertyByPostcode(string postcode)
        {
            return await GetAsync<List<AddressSearchResult>>($"{PropertyEndpoint}/search/{postcode}");
        }

        public async Task<HttpResponse<List<Organisation>>> SearchForOrganisationByName(string organisation)
        {
            return await GetAsync<List<Organisation>>($"{OrganisationEndpoint}/search/{organisation}");
        }

        public async Task<HttpResponse<List<AddressSearchResult>>> GetStreetByReference(string street)
        {
            return await GetAsync<List<AddressSearchResult>>($"{StreetEndpoint}/streetsearch/{street}");
        }
    }
}
