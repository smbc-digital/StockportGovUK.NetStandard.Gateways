using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockportGovUK.NetStandard.Gateways.Response;
using StockportGovUK.NetStandard.Models.ComplimentsComplaints;

namespace StockportGovUK.NetStandard.Gateways.ComplimentsComplaintsServiceGateway
{
    public class ComplimentsComplaintsServiceGateway : Gateway, IComplimentsComplaintsServiceGateway
    {
        private const string HttpClientName = "complimentsComplaintsGateway";
        private const string ComplimentEndpoint = "api/v1/Compliments";
        private const string FeedbackEndpoint = "api/v1/Feedback";
        private const string ComplaintEndpoint = "api/v1/Complaints";

        public ComplimentsComplaintsServiceGateway(HttpClient httpClient, ILogger<Gateway> logger) : base(httpClient, logger)
        {
        }

        public async Task<HttpResponse<string>> SubmitCompliment(ComplimentDetails model)
        {
            return await PostAsync<string>($"{ComplimentEndpoint}/submit-compliment", model);
        }

        public async Task<HttpResponse<string>> SubmitComplaint(ComplaintDetails model)
        {
            return await PostAsync<string>($"{ComplaintEndpoint}/submit-complaint", model);
        }

        public async Task<HttpResponse<string>> SubmitFeedback(FeedbackDetails model)
        {
            return await PostAsync<string>($"{FeedbackEndpoint}/submit-feedback", model);
        }

        public async Task<HttpResponse<string>> SubmitForm(string url, object model)
        {
            return await PostAsync<string>($"{url}", model);
        }
    }
}