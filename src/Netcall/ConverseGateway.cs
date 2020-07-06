using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockportGovUK.NetStandard.Gateways.Netcall.Models;

namespace StockportGovUK.NetStandard.Gateways.Netcall
{
    public class ConverseGateway : Gateway, IConverseGateway
    {
        
        private const string NETCALL_ENDPOINT = "/api/liberty/2/partitions/{0}/acd/callrecordings";

        public ConverseGateway(HttpClient httpClient, ILogger<Gateway> logger) : base(httpClient, logger)
        {

        }

        public async Task<HttpResponseMessage> PauseRecordingAsync(string pid, string netcallUserId)
        {
            var request = new ConverseRequestModel
            {
                Identifier = netcallUserId,
                IdentifierType = ConverseRequestModel.IDENTIFIERTYPE_USERID,
                RecordingState = ConverseRequestModel.RECORDINGSTATE_PAUSE
            };

            return await PutAsync(string.Format(NETCALL_ENDPOINT, pid), request, true);
        }
        
        public async Task<HttpResponseMessage> PauseRecordingFromExtensionAsync(string pid, string extension)
        {
            var request = new ConverseRequestModel
            {
                Identifier = extension,
                IdentifierType = ConverseRequestModel.IDENTIFIERTYPE_EXTENSION,
                RecordingState = ConverseRequestModel.RECORDINGSTATE_PAUSE
            };

            return await PutAsync(string.Format(NETCALL_ENDPOINT, pid), request, true);
        }

        public async Task<HttpResponseMessage> ResumeRecordingAsync(string pid, string netcallUserId)
        {
            var request = new ConverseRequestModel
            {
                Identifier = netcallUserId,
                IdentifierType = ConverseRequestModel.IDENTIFIERTYPE_USERID,
                RecordingState = ConverseRequestModel.RECORDINGSTATE_RESUME
            };

            return await PutAsync(string.Format(NETCALL_ENDPOINT, pid), request, true);
        }
        
        public async Task<HttpResponseMessage> ResumeRecordingFromExtensionAsync(string pid, string extension)
        {
            var request = new ConverseRequestModel
            {
                Identifier = extension,
                IdentifierType = ConverseRequestModel.IDENTIFIERTYPE_EXTENSION,
                RecordingState = ConverseRequestModel.RECORDINGSTATE_RESUME
            };

            return await PutAsync(string.Format(NETCALL_ENDPOINT, pid), request, true);
        }
    }
}