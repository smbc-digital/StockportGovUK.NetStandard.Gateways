using System.Threading.Tasks;
using StockportGovUK.AspNetCore.Gateways.Response;
using StockportGovUK.NetStandard.Models.Models.ComplimentsComplaints;

namespace StockportGovUK.AspNetCore.Gateways.ComplimentsComplaintsServiceGateway
{
    public interface IComplimentsComplaintsServiceGateway
    {
        Task<HttpResponse<ComplimentsComplaintsResponse>> SubmitCompliment(ComplimentDetails model);
    }
}