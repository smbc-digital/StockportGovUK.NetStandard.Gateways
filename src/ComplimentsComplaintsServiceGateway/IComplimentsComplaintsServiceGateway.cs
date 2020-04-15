using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Response;
using StockportGovUK.NetStandard.Models.ComplimentsComplaints;

namespace StockportGovUK.NetStandard.Gateways.ComplimentsComplaintsServiceGateway
{
    public interface IComplimentsComplaintsServiceGateway
    {
        Task<HttpResponse<string>> SubmitCompliment(ComplimentDetails model);
        Task<HttpResponse<string>> SubmitFeedback(FeedbackDetails model);
        Task<HttpResponse<string>> SubmitComplaint(ComplaintDetails model);
        Task<HttpResponse<string>> SubmitForm(string url, object model);
    }
}