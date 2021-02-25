using System.Threading.Tasks;
using System.Net.Http;
using StockportGovUK.NetStandard.Models.TrackAReport.Requests;

namespace StockportGovUK.NetStandard.Gateways.TrackAReport
{
    public interface ITrackAReportGateway
    {
        Task<HttpResponseMessage> AssetEnquiry(TrackAReportRequest model);
    }
}
