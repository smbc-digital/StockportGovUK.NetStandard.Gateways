using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.ComplimentsComplaints;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.ComplimentsComplaintsService
{
    public class ComplimentsComplaintsServiceGateway : Gateway, IComplimentsComplaintsServiceGateway
    {
        private const string ComplimentEndpoint = "api/v1/Compliments";
        private const string FeedbackEndpoint = "api/v1/Feedback";
        private const string ComplaintEndpoint = "api/v1/Complaints";

        public ComplimentsComplaintsServiceGateway(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<HttpResponse<string>> SubmitCompliment(ComplimentDetails model)
            => await PostAsync<string>($"{ComplimentEndpoint}/submit-compliment", model);

        public async Task<HttpResponse<string>> SubmitComplaint(ComplaintDetails model)
            => await PostAsync<string>($"{ComplaintEndpoint}/submit-complaint", model);

        public async Task<HttpResponse<string>> SubmitFeedback(FeedbackDetails model)
            => await PostAsync<string>($"{FeedbackEndpoint}/submit-feedback", model);

        public async Task<HttpResponse<string>> SubmitForm(string url, object model)
            => await PostAsync<string>($"{url}", model);
    }
}