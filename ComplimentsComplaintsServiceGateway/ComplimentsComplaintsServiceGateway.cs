using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Models.Models.ComplimentsComplaints;

namespace StockportGovUK.AspNetCore.Gateways.ComplimentsComplaintsServiceGateway
{
    public class ComplimentsComplaintsServiceGateway : Gateway, IComplimentsComplaintsServiceGateway
    {
        private const string HttpClientName = "complimentsComplaintsGateway";
        private const string ComplimentEndpoint = "api/v1/Compliments";
        private const string ComplaintEndpoint = "api/v1/Complaints";

        public ComplimentsComplaintsServiceGateway(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<HttpResponseMessage> SubmitCompliment(ComplimentDetails model)
        {
            return await PostAsync($"{ComplimentEndpoint}/submit-compliment", model);
        }

        public async Task<HttpResponseMessage> SubmitComplaint(ComplaintDetails model)
        {
            return await PostAsync($"{ComplaintEndpoint}/submit-complaint", model);
        }
    }
}