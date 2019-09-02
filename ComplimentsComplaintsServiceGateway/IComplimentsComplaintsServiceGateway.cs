using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.AspNetCore.Gateways.Response;
using StockportGovUk.NetStandard.Models.Models.ComplimentsComplaints;

namespace StockportGovUK.AspNetCore.Gateways.ComplimentsComplaintsServiceGateway
{
    public interface IComplimentsComplaintsServiceGateway
    {
        Task<ComplimentsComplaintsResponse> SubmitCompliment(ComplimentDetails model);
    }
}