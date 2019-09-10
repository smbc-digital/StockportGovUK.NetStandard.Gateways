using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.AspNetCore.Gateways.Response;

namespace StockportGovUK.AspNetCore.Gateways.Netcall
{
    public class NetcallGateway : Gateway, INetcallGateway
    {
        public NetcallGateway(HttpClient httpClient) : base(httpClient) 
        {

        }

        public async Task<HttpResponseMessage> PauseRecordingAsync(string netcallUserId)
        {
            var url = $"/services/simplegcc/pauserecording/{netcallUserId}?type=UserID?respond=true";
            return await GetAsync(url);
        }
        
        public async Task<HttpResponseMessage> ResumeRecordingAsync(string netcallUserId){
            var url = $"/services/simplegcc/resumerecording/{netcallUserId}?type=UserID?respond=true";
            return await GetAsync(url);
        }
    }
}