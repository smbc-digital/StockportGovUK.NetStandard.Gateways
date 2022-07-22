using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.TrackAReport.Requests;

namespace StockportGovUK.NetStandard.Gateways.TrackAReport
{
    public interface ITrackAReportGateway
    {
        Task<HttpResponseMessage> AssetEnquiry(TrackAReportRequest model);
    }
}
