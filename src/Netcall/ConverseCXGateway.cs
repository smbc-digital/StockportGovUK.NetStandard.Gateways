using System;
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
        
        public async Task<HttpResponseMessage> PauseRecordingAsync(string agentId)
            => await PutAsync(NETCALL_ENDPOINT, new ConverseCXRequestModel(ConverseCXRequestModel.RecordingStateValue.Pause, agentId), true);

        public async Task<HttpResponseMessage> ResumeRecordingAsync(string agentId)
            => await PutAsync(NETCALL_ENDPOINT, new ConverseCXRequestModel(ConverseCXRequestModel.RecordingStateValue.Resume, agentId), true);
    }
}