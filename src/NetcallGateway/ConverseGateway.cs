using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockportGovUK.NetStandard.Gateways.Netcall.Models;

namespace StockportGovUK.NetStandard.Gateways.Netcall
{
    public class ConverseGateway : Gateway, INetcallGateway
    {
        
        private const string NetcallEndpoint = "/api/liberty/2/partitions/:partitionId/acd/callrecordings";

        public ConverseGateway(HttpClient httpClient, ILogger<Gateway> logger) : base(httpClient, logger)
        {

        }

        public async Task<HttpResponseMessage> PauseRecordingAsync(string netcallUserId)
        {
            var request = new ConverseRequestModel
            {
                Identifier = netcallUserId,
                IdentifierType = IdentifierType.UserId,
                RecordingState = RecordingState.Pause
            };

            return await PutAsync($"{NetcallEndpoint}/pauserecording/{netcallUserId}?type=userid&respond=true", request, true);
        }
        
        public async Task<HttpResponseMessage> PauseRecordingFromExtensionAsync(string extension)
        {
            var request = new ConverseRequestModel
            {
                Identifier = extension,
                IdentifierType = IdentifierType.Extension,
                RecordingState = RecordingState.Pause
            };

            return await PutAsync($"{NetcallEndpoint}/pauserecording/{extension}?respond=true");
        }

        public async Task<HttpResponseMessage> ResumeRecordingAsync(string netcallUserId)
        {
            var request = new ConverseRequestModel
            {
                Identifier = netcallUserId,
                IdentifierType = IdentifierType.Extension,
                RecordingState = RecordingState.Resume
            };

            return await PutAsync($"{NetcallEndpoint}/resumerecording/{netcallUserId}?type=userid&respond=true");
        }
        
        public async Task<HttpResponseMessage> ResumeRecordingFromExtensionAsync(string extension)
        {
            var request = new ConverseRequestModel
            {
                Identifier = extension,
                IdentifierType = IdentifierType.Extension,
                RecordingState = RecordingState.Resume
            };
            return await PutAsync($"{NetcallEndpoint}/resumerecording/{extension}?respond=true");
        }
    }
}