using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.AspNetCore.Gateways.Response;
using StockportGovUK.NetStandard.Models.Models.Verint;
using StockportGovUK.NetStandard.Models.Models.Verint.Update;

namespace StockportGovUK.AspNetCore.Gateways.VerintServiceGateway
{
    public class VerintServiceGateway : Gateway, IVerintServiceGateway
    {
        private const string HttpClientName = "verintServiceGateway";
        private const string CaseEndpoint = "api/v1/Case";

        public VerintServiceGateway(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }

        public async Task<HttpResponse<Case>> GetCase(string caseRef)
        {
            return await GetAsync<Case>(HttpClientName, $"{CaseEndpoint}?caseId={caseRef}");
        }

        public async Task<HttpResponse<CreateCaseResponse>> CreateCase(Case crmCase)
        {
            return await PostAsync<CreateCaseResponse>(HttpClientName, $"{CaseEndpoint}", crmCase);
        } 

        public async Task<HttpResponseMessage> UpdateCaseIntegrationFormField(IntegrationFormFieldsUpdateModel content)
        {
            return await PatchAsync(HttpClientName, $"{CaseEndpoint}/integration-form-fields", content);
        }
    }
}
