using System;
using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Netcall.Models;

namespace StockportGovUK.NetStandard.Gateways.Netcall
{
    public class ConverseCXGateway : Gateway, IConverseGateway
    {
        private const string NETCALL_ENDPOINT = "/api/v1/recordings";

        public ConverseCXGateway(HttpClient httpClient) : base(httpClient)
        {}
        
        public async Task<HttpResponseMessage> PauseRecordingAsync(string pid, string netcallUserId)
            => await PutAsync(NETCALL_ENDPOINT, new ConverseCXRequestModel(ConverseCXRequestModel.RecordingStateValue.Pause, netcallUserId), true);

        public async Task<HttpResponseMessage> ResumeRecordingAsync(string pid, string netcallUserId)
            => await PutAsync(NETCALL_ENDPOINT, new ConverseCXRequestModel(ConverseCXRequestModel.RecordingStateValue.Resume, netcallUserId), true);
        
        [Obsolete("Pausing recording from extension is not currently supported by Netcall Converse CX")]
        public Task<HttpResponseMessage> PauseRecordingFromExtensionAsync(string pid, string extension)
            => throw new NotImplementedException("Pausing recording from extension is not currently supported by Netcall Converse CX");

        [Obsolete("Resuming recording from extension is not currently supported by Netcall Converse CX")]
        public Task<HttpResponseMessage> ResumeRecordingFromExtensionAsync(string pid, string extension)
            => throw new NotImplementedException("Resuming recording from extension is not currently supported by Netcall Converse CX");
    }
}