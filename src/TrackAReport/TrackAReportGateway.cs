using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Models.TrackAReport.Requests;

namespace StockportGovUK.NetStandard.Gateways.TrackAReport
{
    public class TrackAReportGateway : Gateway, ITrackAReportGateway
    {
        private const string AssetEnquiryEndpoint = "api/v1/AssetEnquiry";

        public TrackAReportGateway(HttpClient httpClient) : base(httpClient) { }

        public async Task<HttpResponseMessage> AssetEnquiry(TrackAReportRequest model) =>
            await PostAsync(AssetEnquiryEndpoint, model);
    }
}
