using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.AspNetCore.Gateways.Response;
using StockportGovUK.NetStandard.Models.Models.Verint;

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

        public async Task<HttpResponseMessage> UpdateCase(HttpContent content)
        {
            return await PutAsync(HttpClientName, CaseEndpoint, content);
        }
    }
}
