using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.AspNetCore.Gateways.Response;
using StockportGovUK.NetStandard.Models.Models.ComplimentsComplaints;

namespace StockportGovUK.AspNetCore.Gateways.ComplimentsComplaintsServiceGateway
{
    public class ComplimentsComplaintsServiceGateway : Gateway, IComplimentsComplaintsServiceGateway
    {
        private const string HttpClientName = "complimentsComplaintsGateway";
        private const string ComplimentEndpoint = "api/v1/Compliments";

        public ComplimentsComplaintsServiceGateway(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }

        public async Task<HttpResponse<CreateCaseResponse>> SubmitCompliment(ComplimentDetails model)
        {
            return await PostAsync<CreateCaseResponse>(HttpClientName, $"{ComplimentEndpoint}/submit-compliment", model);
        }
    }
}