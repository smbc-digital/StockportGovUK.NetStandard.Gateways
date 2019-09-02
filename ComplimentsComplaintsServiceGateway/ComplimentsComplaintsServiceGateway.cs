using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.AspNetCore.Gateways.Response;
using StockportGovUK.NetStandard.Models.Models;

namespace StockportGovUK.AspNetCore.Gateways.ComplimentsComplaintsServiceGateway
{
    public class ComplimentsComplaintsServiceGateway : Gateway, IComplimentsComplaintsServiceGateway
    {
        private const string HttpClientName = "complimentsComplaintsGateway";
        private const string ComplimentEndpoint = "api/v1/Compliment";

        public ComplimentsComplaintsServiceGateway(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }

        public async Task<ComplimentsComplaintsResponse> SubmitCompliment(ComplimentDetails model)
        {
            return await PostAsync(HttpClientName, $"{ComplimentEndpoint}/submit-compliment", model);
        }
    }
}