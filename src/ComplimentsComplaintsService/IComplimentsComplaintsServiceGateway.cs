using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.ComplimentsComplaints;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.ComplimentsComplaintsService
{
    public interface IComplimentsComplaintsServiceGateway
    {
        Task<HttpResponse<string>> SubmitCompliment(ComplimentDetails model);
        Task<HttpResponse<string>> SubmitFeedback(FeedbackDetails model);
        Task<HttpResponse<string>> SubmitComplaint(ComplaintDetails model);
        Task<HttpResponse<string>> SubmitForm(string url, object model);
    }
}