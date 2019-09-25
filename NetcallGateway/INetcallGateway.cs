using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.AspNetCore.Gateways.Netcall
{
    public interface INetcallGateway : IGateway
    {
        Task<HttpResponseMessage> PauseRecordingAsync(string netcallUserId);
        Task<HttpResponseMessage> ResumeRecordingAsync(string netcallUserId);
    }
}