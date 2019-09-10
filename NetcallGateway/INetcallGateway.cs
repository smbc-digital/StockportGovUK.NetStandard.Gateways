using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.AspNetCore.Gateways.Response;

namespace StockportGovUK.AspNetCore.Gateways.Netcall
{
    public interface INetcallGateway : IGateway
    {
        Task<HttpResponseMessage> PauseRecordingAsync(string netcallUserId);
        Task<HttpResponseMessage> ResumeRecordingAsync(string netcallUserId);
    }
}