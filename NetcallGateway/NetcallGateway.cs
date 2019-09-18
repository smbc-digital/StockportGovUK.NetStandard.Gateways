using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.AspNetCore.Gateways.Netcall
{
    public class NetcallGateway : Gateway, INetcallGateway
    {
        
        private const string NetcallEndpoint = "/services/simplegcc";

        public NetcallGateway(HttpClient httpClient) : base(httpClient) 
        {

        }

        public async Task<HttpResponseMessage> PauseRecordingAsync(string netcallUserId)
        {
            return await GetAsync($"{NetcallEndpoint}/pauserecording/{netcallUserId}?type=UserID?respond=true");
        }
        
        public async Task<HttpResponseMessage> ResumeRecordingAsync(string netcallUserId){
            return await GetAsync($"{NetcallEndpoint}/resumerecording/{netcallUserId}?type=UserID?respond=true");
        }
    }
}