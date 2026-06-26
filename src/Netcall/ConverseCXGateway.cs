using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Netcall.Models;

namespace StockportGovUK.NetStandard.Gateways.Netcall
{
    public class ConverseCXGateway : Gateway, IConverseCXGateway
    {
        private const string NETCALL_ENDPOINT = "/api/v1/recordings";

        public ConverseCXGateway(HttpClient httpClient) : base(httpClient)
        {}

        public async Task<HttpResponseMessage> PauseRecordingByEmailAsync(string email)
            => await PutAsync(NETCALL_ENDPOINT, new ConverseCXRecordingRequestModel(ConverseCXRecordingStateEnum.Pause, agentId: null, agentEmail: email), true);

        public async Task<HttpResponseMessage> PauseRecordingByIdAsync(string agentId)
            => await PutAsync(NETCALL_ENDPOINT, new ConverseCXRecordingRequestModel(ConverseCXRecordingStateEnum.Pause, agentId: agentId, agentEmail: null), true);

        public async Task<HttpResponseMessage> ResumeRecordingByEmailAsync(string email)
            => await PutAsync(NETCALL_ENDPOINT, new ConverseCXRecordingRequestModel(ConverseCXRecordingStateEnum.Resume, agentId: null, agentEmail: email), true);

        public async Task<HttpResponseMessage> ResumeRecordingByIdAsync(string agentId)
            => await PutAsync(NETCALL_ENDPOINT, new ConverseCXRecordingRequestModel(ConverseCXRecordingStateEnum.Resume, agentId: agentId, agentEmail: null), true);
    }
}