using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.AspNetCore.Gateways.Response;
using StockportGovUK.NetStandard.Models.Models.Verint;

namespace StockportGovUK.AspNetCore.Gateways.FosteringServiceGateway
{
    public class FosteringServiceGateway : Gateway, IFosteringServiceGateway
    {
        private const string HttpClientName = "fosteringServiceGateway";
        private const string CaseEndpoint = "api/v1/Fostering";

        public FosteringServiceGateway(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }

        public async Task<HttpResponse<Case>> GetCase(string caseRef)
        {
            return await GetAsync<Case>(HttpClientName, $"{CaseEndpoint}/case?caseId={caseRef}");
        }
    }
}
