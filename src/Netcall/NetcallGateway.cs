using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.NetStandard.Gateways.Netcall
{
    public class NetcallGateway : Gateway, INetcallGateway
    {
        private const string NetcallEndpoint = "/services/simplegcc";

        public NetcallGateway(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<HttpResponseMessage> PauseRecordingAsync(string netcallUserId)
            => await GetAsync($"{NetcallEndpoint}/pauserecording/{netcallUserId}?type=userid&respond=true");

        public async Task<HttpResponseMessage> PauseRecordingFromExtensionAsync(string extension)
            => await GetAsync($"{NetcallEndpoint}/pauserecording/{extension}?respond=true");

        public async Task<HttpResponseMessage> ResumeRecordingAsync(string netcallUserId)
            => await GetAsync($"{NetcallEndpoint}/resumerecording/{netcallUserId}?type=userid&respond=true");

        public async Task<HttpResponseMessage> ResumeRecordingFromExtensionAsync(string extension)
            => await GetAsync($"{NetcallEndpoint}/resumerecording/{extension}?respond=true");
    }
}