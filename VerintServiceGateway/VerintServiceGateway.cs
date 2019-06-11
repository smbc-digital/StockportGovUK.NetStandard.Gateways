using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.AspNetCore.Gateways.VerintServiceGateway
{
    public class VerintServiceGateway : Gateway, IVerintServiceGateway
    {
        private const string HttpClientName = "verintServiceGateway";
        private const string CaseEndpoint = "api/v1/Case";

        public VerintServiceGateway(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }

        public async Task<HttpResponseMessage> GetCase(string caseRef)
        {
            return await GetAsync(HttpClientName, $"{CaseEndpoint}?caseId={caseRef}");
        }

        public async Task<HttpResponseMessage> UpdateCase(HttpContent content)
        {
            return await PutAsync(HttpClientName, CaseEndpoint, content);
        }
    }
}
