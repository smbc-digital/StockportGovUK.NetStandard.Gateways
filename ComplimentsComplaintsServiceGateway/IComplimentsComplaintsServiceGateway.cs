using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using StockportGovUK.AspNetCore.Gateways.Response;
using StockportGovUK.NetStandard.Models.Models.ComplimentsComplaints;

namespace StockportGovUK.AspNetCore.Gateways.ComplimentsComplaintsServiceGateway
{
    public interface IComplimentsComplaintsServiceGateway
    {
        Task<HttpResponse<string>> SubmitCompliment(ComplimentDetails model);

        Task<HttpResponse<string>> SubmitComplaint(ComplaintDetails model);
    }
}