using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Models.Models.ComplimentsComplaints;

namespace StockportGovUK.AspNetCore.Gateways.ComplimentsComplaintsServiceGateway
{
    public interface IComplimentsComplaintsServiceGateway
    {
        Task<HttpResponseMessage> SubmitCompliment(ComplimentDetails model);

        Task<HttpResponseMessage> SubmitComplaint(ComplaintDetails model);
    }
}