using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace StockportGovUK.NetStandard.Gateways.Netcall
{
    public class NetcallGateway : Gateway, INetcallGateway
    {
        
        private const string NetcallEndpoint = "/services/simplegcc";

        public NetcallGateway(HttpClient httpClient, ILogger<Gateway> logger) : base(httpClient, logger)
        {

        }

        public async Task<HttpResponseMessage> PauseRecordingAsync(string netcallUserId)
        {
            return await GetAsync($"{NetcallEndpoint}/pauserecording/{netcallUserId}?type=userid&respond=true");
        }
        
        public async Task<HttpResponseMessage> PauseRecordingFromExtensionAsync(string extension)
        {
            return await GetAsync($"{NetcallEndpoint}/pauserecording/{extension}?respond=true");
        }

        public async Task<HttpResponseMessage> ResumeRecordingAsync(string netcallUserId)
        {
            return await GetAsync($"{NetcallEndpoint}/resumerecording/{netcallUserId}?type=userid&respond=true");
        }
        
        public async Task<HttpResponseMessage> ResumeRecordingFromExtensionAsync(string extension)
        {
            return await GetAsync($"{NetcallEndpoint}/resumerecording/{extension}?respond=true");
        }
    }
}